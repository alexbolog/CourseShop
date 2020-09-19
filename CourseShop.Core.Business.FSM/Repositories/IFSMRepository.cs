using CourseShop.Core.Entities.Enums;
using CourseShop.Core.Entities.FSM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.FSM.Repositories
{
    public interface IFSMRepository
    {
        Task<IEnumerable<FSMTransition>> GetPossibleTransitions(OrderStatus statusFrom);
    }
}
