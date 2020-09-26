using CourseShop.Core.Business.FSM.Services;
using CourseShop.Core.Business.Services;
using CourseShop.Core.Entities;
using CourseShop.Core.Entities.FSM;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.FSM
{
    public interface IFSMManager
    {
        Task Run();
    }

    public class FSMManager : IFSMManager
    {
        private readonly IOrderService orderService;
        private readonly IFSMService fsmService;

        public FSMManager(IOrderService orderService, IFSMService fsmService)
        {
            this.orderService = orderService;
            this.fsmService = fsmService;
        }


        public async Task Run()
        {
            var orders = await orderService.GetNotCompletedOrdersAsync();
            foreach (var order in orders)
            {
                await RunForOrder(order);
            }
        }

        private async Task RunForOrder(Order order)
        {
            var possibleTransitions = await fsmService.GetPossibleTransitionsAsync(order.OrderStatus);
            foreach (var transition in possibleTransitions)
            {
                if (await TryRunTransition(transition, order))
                {
                    await orderService.UpdateStatusAsync(order.OrderId, transition.OrderStatusIdTo);
                    await ExecuteActionsAsync(transition.Actions);
                    break;
                }
            }
        }

        private async Task ExecuteActionsAsync(List<FSMAction> actions)
        {
            foreach (var actionInfo in actions)
            {
                var action = await fsmService.GetActionByType(actionInfo.ActionType);
                await action.Run();
            }
        }

        private async Task<bool> TryRunTransition(FSMTransition transition, Order order)
        {
            
            // (AccountConfirmed&ProcessedPayment)|c3 => 
            // TODO: enhance with ConditionSequence and fetch conditions based on ConditionName
            foreach (var conditionInfo in transition.Conditions)
            {
                var condition = await fsmService.GetConditionByType(conditionInfo.ConditionType);
                return condition.Evaluate();
            }
            return false;
        }
    }
}
