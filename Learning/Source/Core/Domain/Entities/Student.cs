using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// https://www.hosting.work/onion-architecture-aspnet-core-cqrs/
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Standard { get; set; }
        public int Rank { get; set; }
    }
}
