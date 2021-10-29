using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Country
    {
        /// <summary>
        /// https://en.wikipedia.org/wiki/List_of_FIFA_country_codes
        /// //Official code for country 
        /// </summary>
        public string FifaAlphaCode { get; set; }        
        public string CountryName { get; set; }        
        public virtual ICollection<Team> Teams { get; set; }
    }
}
