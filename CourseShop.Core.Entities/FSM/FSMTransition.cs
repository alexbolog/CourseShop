using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Entities.FSM
{
    public class FSMTransition
    {
        public int FSMTransitionId { get; set; }
        public int OrderStatusIdFrom { get; set; }
        public int OrderStatusIdTo { get; set; }
        public string ConditionSequence { get; set; }

        public List<FSMCondition> Conditions { get; set; }
        public List<FSMAction> Actions { get; set; }
    }
}
