using CourseShop.Core.Business.FSM.Repositories;
using CourseShop.Core.Entities.Enums;
using CourseShop.Core.Entities.FSM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.DAL.Repositories
{
    public class FSMRepository : IFSMRepository
    {
        private readonly CourseContext courseContext;

        public FSMRepository(CourseContext courseContext)
        {
            this.courseContext = courseContext;
        }
        public async Task<IEnumerable<FSMTransition>> GetPossibleTransitions(OrderStatus statusFrom)
        {
            var transitions = await courseContext.FSMTransitions.Where(t => t.OrderStatusIdFrom == (int)statusFrom).ToListAsync();
            foreach(var transition in transitions)
            {
                transition.Conditions = await courseContext.FSMConditions.Where(c => c.FSMTransitionId == transition.FSMTransitionId).ToListAsync();
                transition.Actions = await courseContext.FSMActions.Where(c => c.FSMTransitionId == transition.FSMTransitionId).ToListAsync();
            }
            return transitions;
        }
    }
}
