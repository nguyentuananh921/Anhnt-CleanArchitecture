using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Federation
    {
        // Reverse navigation
        /// <summary>
        /// Child Teams where [Teams].[Federation] point to this entity (FK_Teams_Federations)
        /// </summary>
        //public virtual ICollection<Team> Teams { get; set; }
        ///// <summary>
        ///// Child Tournaments where [Tournaments].[Federation] point to this entity (FK_Tournaments_Federations)
        ///// </summary>
        
        public string FName { get; set; }

        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
