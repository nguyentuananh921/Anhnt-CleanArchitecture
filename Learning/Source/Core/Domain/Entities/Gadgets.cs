using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// https://www.learmoreseekmore.com/2021/05/clean-architecture-in-dotnet5-application.html
    /// https://github.com/Naveen512/Dotnet5CleanArchitecture
    /// </summary>
    public class Gadget
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public decimal Cost { get; set; }
        public string Type { get; set; }
    }
}
