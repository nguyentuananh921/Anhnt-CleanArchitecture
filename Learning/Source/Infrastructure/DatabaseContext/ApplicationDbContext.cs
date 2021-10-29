using Application.Interfaces.Contexts;
using Application.Interfaces.Shared;
using Domain.Common;
using Domain.Entities;
using IdentityServer4.EntityFramework.Options;
using Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enums;

namespace Infrastructure.DatabaseContext
{
    //This context is to store Data, In order to Separation Data and Identity connnection
    /// <summary>
    /// https://codewithmukesh.com/blog/audit-trail-implementation-in-aspnet-core/
    /// https://alexcodetuts.com/2020/02/06/asp-net-core-3-1-clean-architecture-invoice-management-app-part-2-ef-core-audit/
    /// public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        #region Constructor
            private readonly ICurrentUserService _currentUserService;
            public ApplicationDbContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options)
            {
                _currentUserService = currentUserService;
            }
        #endregion

        #region follow mukesh instruction 
            //https://codewithmukesh.com/blog/specification-pattern-in-aspnet-core/
            //https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
            public DbSet<Developer> Developers { get; set; }
            public DbSet<Address> Addresses { get; set; }
            public DbSet<Movie> Movies { get; set; }
        #endregion

        #region CleanArchitech-jasontaylor Todolist TodoItem
            public DbSet<TodoItem> TodoItems { get; set; }
            public DbSet<TodoList> TodoLists { get; set; }
        #endregion

        #region follow instruction clean architecture nishanc
            //https://nishanc.medium.com/clean-architecture-net-core-part-2-implementation-7376896390c5
            public DbSet<Book> Books { get; set; }
        #endregion

        public DbSet<Contact> Contacts { get; set; }

        #region invoice-management-app
            //https://alexcodetuts.com/2020/02/06/asp-net-core-3-1-clean-architecture-invoice-management-app-part-2-ef-core-audit/?fbclid=IwAR0u06OATyHRIRRccJD7bexRvy1plpeWR_mffKd_2XVk88C5MZY1XCPY_Tw
            public DbSet<Invoice> Invoices { get; set; }
            public DbSet<InvoiceItem> InvoiceItems { get; set; }
        #endregion

        #region Tasklist
            /// <summary>
            /// https://www.youtube.com/watch?v=liyhZW22WmQ&lc=UgwtXr4ghuC3wBsZYZ14AaABAg.9P0tGh3Ooul9P6a9S6z8FM
            /// https://github.com/itsdevkev/TaskList
            /// public class TaskItem : BaseEntity //For Audit
            /// </summary>    
            public DbSet<TaskItem> TaskItems { get; set; }
        #endregion
        #region CQRS Student
            /// <summary>
            /// https://www.hosting.work/onion-architecture-aspnet-core-cqrs/
            /// </summary>       
            public DbSet<Student> Students { get; set; }
            /// <summary>
            /// https://www.youtube.com/watch?v=xKKVW94F2bc
            /// </summary>
            public DbSet<Car> Cars { get; set; }
        #endregion

        #region CQRS Employee
            /// <summary>
            /// https://www.c-sharpcorner.com/article/introduction-to-clean-architecture-and-implementation-with-asp-net-core/
            /// https://github.com/Bishwanath-Dey-Nayan/CleanArchitectureWithNetCore
            /// </summary>
            /// 
            public DbSet<Employee> Employees { get; set; }
        #endregion

        #region Gadgets

        /// <summary>
        /// https://www.learmoreseekmore.com/2021/05/clean-architecture-in-dotnet5-application.html
        /// https://github.com/Naveen512/Dotnet5CleanArchitecture
        /// </summary>
        public DbSet<Gadget> Gadgets { get; set; }
        #endregion

        #region AuditFunction
        #region No Audit
        public async Task<int> SaveChangeAsync()
                {            
                     return await base.SaveChangesAsync();
                }
                public Task SaveChangesAsync()
                {
                    return base.SaveChangesAsync();
                }
        #endregion

        #region Simple Audit
        //https://alexcodetuts.com/2020/02/06/asp-net-core-3-1-clean-architecture-invoice-management-app-part-2-ef-core-audit/?fbclid=IwAR0u06OATyHRIRRccJD7bexRvy1plpeWR_mffKd_2XVk88C5MZY1XCPY_Tw
        public Task<int> SaveSimpleAuditAsync(CancellationToken cancellationToken = new CancellationToken())
                    {
                        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                        {
                            switch (entry.State)
                            {
                                case EntityState.Added:
                                    entry.Entity.CreatedBy = _currentUserService.UserId;
                                    entry.Entity.Created = DateTime.UtcNow;
                                    break;
                                case EntityState.Modified:
                                    entry.Entity.LastModifiedBy = _currentUserService.UserId;
                                    entry.Entity.LastModified = DateTime.UtcNow;
                                    break;
                            }
                        }
                        return base.SaveChangesAsync(cancellationToken);
                    }
            #endregion
            #region Way 2 mukesh
                //https://github.com/aspnetcorehero/EntityFrameworkCore.AuditTrail
                //https://codewithmukesh.com/blog/audit-trail-implementation-in-aspnet-core/
                public DbSet<Audit> AuditLogs { get; set; }
                public DbSet<Product> Products { get; set; }
                public async Task<int> SaveAuditsAsync(CancellationToken cancellationToken = new CancellationToken())
                {
                    var userId = _currentUserService.UserId;
                    OnBeforeSaveChanges(userId);
                    var result = await base.SaveChangesAsync();
                    return result;
                }
                private void OnBeforeSaveChanges(string userId)
                {
                    ChangeTracker.DetectChanges();
                    var auditEntries = new List<AuditEntry>();
                    foreach (var entry in ChangeTracker.Entries())
                    {
                        if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                            continue;
                        var auditEntry = new AuditEntry(entry);
                        //Mapping from entry in ChangeTracker.Entries to auditEntry
                        auditEntry.TableName = entry.Entity.GetType().Name;
                        auditEntry.UserId = userId;
                        auditEntries.Add(auditEntry);
                        foreach (var property in entry.Properties)
                        {
                            string propertyName = property.Metadata.Name;
                            if (property.Metadata.IsPrimaryKey())
                            {
                                auditEntry.KeyValues[propertyName] = property.CurrentValue;
                                continue;
                            }
                            switch (entry.State)
                            {
                                case EntityState.Added:
                                    auditEntry.AuditType = AuditType.Create;
                                    auditEntry.NewValues[propertyName] = property.CurrentValue;
                                    break;
                                case EntityState.Deleted:
                                    auditEntry.AuditType = AuditType.Delete;
                                    auditEntry.OldValues[propertyName] = property.OriginalValue;
                                    break;
                                case EntityState.Modified:
                                    if (property.IsModified)
                                    {
                                        auditEntry.ChangedColumns.Add(propertyName);
                                        auditEntry.AuditType = AuditType.Update;
                                        auditEntry.OldValues[propertyName] = property.OriginalValue;
                                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                                    }
                                    break;
                            }
                        }
                    }
                    foreach (var auditEntry in auditEntries)
                    {
                        AuditLogs.Add(auditEntry.ToAudit());
                    }
                }

        
        #endregion
        #endregion

    }
}
