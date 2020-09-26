using CourseShop.Core.Business.FSM.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Business.FSM.BooleanExpression.Operators
{
    public class None : Operator
    {
        private readonly FSMConditionBase condition;

        public None(FSMConditionBase condition)
        {
            this.condition = condition;
        }

        public override bool Evaluate()
        {
            return condition.Evaluate();
        }
    }
}
