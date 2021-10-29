using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TodoLists.Queries.GetTodoListsQuery
{
    public class GetTodoListsVM
    {
        public IList<PriorityLevelDto> PriorityLevels { get; set; }

        public IList<GetTodoListsVM> Lists { get; set; }
    }
}
