using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Team
    {
        #region Primitive Properties
        public string TeamName { get; set; }
        public string TeamCode { get; set; }

        //https://en.wikipedia.org/wiki/List_of_FIFA_country_codes
        public string FifaAlphaCode { get; set; } //Official code for country          
        public string TypeName { get; set; } //For the internal tournament in the country teamtype will be club
        #endregion

        #region Relationship
        public virtual TeamType TeamTypes { get; set; }  //For the Team represet a country type=International.
        public virtual Country Countries { get; set; }
        //One Country can have multiple Team separation by TeamType or By TeamName
        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> GuestMatches { get; set; }
        #endregion

    }
}
