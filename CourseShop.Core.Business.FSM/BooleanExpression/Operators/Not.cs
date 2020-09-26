using CourseShop.Core.Business.FSM.Conditions;
using CourseShop.Core.Entities.FSM;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Business.FSM.BooleanExpression.Operators
{
    public class Not : Operator
    {
        private readonly FSMConditionBase condition;

        public Not(FSMConditionBase condition)
        {
            this.condition = condition;
        }

        public override bool Evaluate()
        {
            return !condition.Evaluate();
        }
    }
}
