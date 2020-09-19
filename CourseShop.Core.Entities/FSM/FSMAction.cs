using CourseShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Entities.FSM
{
    public class FSMAction
    {
        public int FSMActionId { get; set; }
        public int FSMTransitionId { get; set; }
        public int ActionTypeId { get; set; }
        public string Value { get; set; }
        public FSMActionType ActionType
        {
            get
            {
                return (FSMActionType)ActionTypeId;
            }
            set
            {
                ActionTypeId = (int)value;
            }
        }
    }
}
