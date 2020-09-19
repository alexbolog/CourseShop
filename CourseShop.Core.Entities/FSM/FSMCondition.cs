using CourseShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Entities.FSM
{
    public class FSMCondition
    {
        public int FSMConditionId { get; set; }
        public int FSMTransitionId { get; set; }
        public int ConditionTypeId { get; set; }
        public string ConditionName { get; set; }

        public FSMConditionType ConditionType
        {
            get
            {
                return (FSMConditionType)ConditionTypeId;
            }
            set
            {
                ConditionTypeId = (int)value;
            }
        }
    }
}
