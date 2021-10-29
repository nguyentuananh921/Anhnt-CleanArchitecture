using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Contexts
{
    /// <summary>
    /// Interface is placed  in the Inner Layer (Application) and 
    /// Implementation is placed in the Outsite Layer (Infrastructure)    
    /// </summary>
    public interface IApplicationDbContext
    {
        #region InvoiceManagementApp
        /// <summary>
        /// https://alexcodetuts.com/2020/02/06/asp-net-core-3-1-clean-architecture-invoice-management-app-part-2-ef-core-audit/?fbclid=IwAR0u06OATyHRIRRccJD7bexRvy1plpeWR_mffKd_2XVk88C5MZY1XCPY_Tw
        /// https://github.com/alexcalingasan/InvoiceManagementApp
        /// </summary>
        DbSet<Invoice> Invoices { get; set; }
        DbSet<InvoiceItem> InvoiceItems { get; set; }
        #endregion


        #region CleanArchitectureDemo
        /// <summary>
        /// https://nishanc.medium.com/clean-architecture-net-core-part-1-introduction-e70e1c49ef6
        /// https://github.com/nishanc/CleanArchitectureDemo
        /// </summary>
        DbSet<Book> Books { get; set; }
        #endregion
        DbSet<Contact> Contacts { get; set; }
        DbSet<Movie> Movies { get; set; }
        #region CleanArchitect-Jascontaylor
        /// <summary>
        /// https://www.youtube.com/watch?v=dK4Yb6-LxAk&list=RDCMUCs_tLP3AiwYKwdUHpltJPuA&start_radio=1&rv=dK4Yb6-LxAk&t=0
        /// https://github.com/jasontaylordev/CleanArchitecture
        /// 
        /// </summary>
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<TodoList> TodoLists { get; set; }
        #endregion

        #region CQRS Student
        /// <summary>
        /// https://www.hosting.work/onion-architecture-aspnet-core-cqrs/
        /// </summary>
        DbSet<Student> Students { get; set; }
        #endregion
        #region CQRS Car
        /// <summary>
        /// https://www.youtube.com/watch?v=xKKVW94F2bc
        /// </summary>
        DbSet<Car> Cars { get; set; }
        #endregion
        #region CQRS Employee
        /// <summary>
        /// https://www.c-sharpcorner.com/article/introduction-to-clean-architecture-and-implementation-with-asp-net-core/
        /// https://github.com/Bishwanath-Dey-Nayan/CleanArchitectureWithNetCore
        /// </summary>
        /// 
        DbSet<Employee> Employees { get; set; }
        #endregion
        #region Gadgets

        /// <summary>
        /// https://www.learmoreseekmore.com/2021/05/clean-architecture-in-dotnet5-application.html
        /// https://github.com/Naveen512/Dotnet5CleanArchitecture
        /// </summary>
        DbSet<Gadget> Gadgets { get; set; }
        #endregion
        #region No Audit
        Task SaveChangesAsync();
            Task<int> SaveChangeAsync();
        #endregion

        #region Simple Audit
            /// <summary>
            /// //We will overide this function in Infrastructure Layer to Audit the Entity
            /// </summary>        
            Task<int> SaveSimpleAuditAsync(CancellationToken cancellationToken);
        #endregion

        #region Auditlog
        /// <summary>
        /// https://codewithmukesh.com/blog/audit-trail-implementation-in-aspnet-core/
        /// </summary>        
        DbSet<Product> Products { get; set; }
        DbSet<Audit> AuditLogs { get; set; }
        Task<int> SaveAuditsAsync(CancellationToken cancellationToken);
        #endregion

        #region
        /// <summary>
        /// https://www.youtube.com/watch?v=liyhZW22WmQ&lc=UgwtXr4ghuC3wBsZYZ14AaABAg.9P0tGh3Ooul9P6a9S6z8FM
        /// https://github.com/itsdevkev/TaskList
        /// public class TaskItem : BaseEntity //For Audit
        /// </summary>    
        DbSet<TaskItem> TaskItems { get; set; }
        #endregion
    }
}
