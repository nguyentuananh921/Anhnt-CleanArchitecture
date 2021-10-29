using Domain.Enums;
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
    /// 15:17 Talk about the Audit
    ///public class TodoItem : AuditableEntity, IHasDomainEvent
    /// </summary>
    public class TodoItem 
    {
        public int Id { get; set; }

        public TodoList List { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public PriorityLevel Priority { get; set; }

        public DateTime? Reminder { get; set; }

        private bool _done;
        public bool Done
        {
            get => _done;
            set
            {
                //if (value == true && _done == false)
                //{
                //    DomainEvents.Add(new TodoItemCompletedEvent(this));
                //}

                //_done = value;
            }
        }

        //public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
