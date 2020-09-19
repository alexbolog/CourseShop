using CourseShop.Core.Business.FSM.Actions;
using CourseShop.Core.Business.FSM.Conditions;
using CourseShop.Core.Business.FSM.Repositories;
using CourseShop.Core.Entities.Enums;
using CourseShop.Core.Entities.FSM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.FSM.Services
{
    public interface IFSMService
    {
        Task<IEnumerable<FSMTransition>> GetPossibleTransitionsAsync(OrderStatus statusFrom);
        Task<FSMConditionBase> GetConditionByType(FSMConditionType type);
        Task<FSMActionBase> GetActionByType(FSMActionType type);
    }

    public class FSMService : IFSMService
    {
        private readonly IFSMRepository repository;

        public FSMService(IFSMRepository repository)
        {
            this.repository = repository;
        }

        public async Task<FSMActionBase> GetActionByType(FSMActionType type)
        {
            return new SendEmailAction();
        }

        public async Task<FSMConditionBase> GetConditionByType(FSMConditionType type)
        {
            switch (type)
            {
                case FSMConditionType.AccountConfirmedCheck:
                    return new AccountConfirmedCheck();
                case FSMConditionType.ProcessedPaymentCheck:
                    return new ProcessedPaymentCheck();
                default:
                    return null;
            }
        }

        public async Task<IEnumerable<FSMTransition>> GetPossibleTransitionsAsync(OrderStatus statusFrom)
        {
            return await repository.GetPossibleTransitions(statusFrom);
        }
    }
}
