using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// https://www.youtube.com/watch?v=dK4Yb6-LxAk&list=RDCMUCs_tLP3AiwYKwdUHpltJPuA&start_radio=1&rv=dK4Yb6-LxAk&t=0
    /// https://github.com/jasontaylordev/CleanArchitecture
    /// public class TodoList : AuditableEntity
    /// </summary>
    public class TodoList
    {

        //Avoid using data annotations we don't want to use EFcore to validate
        public int Id { get; set; }

        public string Title { get; set; }

        //public Colour Colour { get; set; } = Colour.White;
        
        /// <summary>
        /// Remember Initialise all collections & use private setters
        /// https://www.youtube.com/watch?v=dK4Yb6-LxAk&list=RDCMUCs_tLP3AiwYKwdUHpltJPuA&start_radio=1
        /// 14.10
        /// </summary>
        public TodoList()
        {
            Items = new List<TodoItem>();
        }
        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>(); //Avoid Null Reference
    }
}
