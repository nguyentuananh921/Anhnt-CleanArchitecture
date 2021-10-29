using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TeamType
    {
        #region Primitive Properties.
            public string TypeName { get; set; }
        #endregion
        #region RelationShip
            public virtual ICollection<Team> Teams { get; set; }
        #endregion

    }
}
