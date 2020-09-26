using CourseShop.Core.Business.FSM.BooleanExpression.Operators;
using CourseShop.Core.Business.FSM.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Business.FSM.BooleanExpression
{
    public abstract class Operator
    {
        public abstract bool Evaluate();

        public static Operator Parse(string op)
        {
            if(op.Contains("|"))
            {
                return new Or(op);
            }
            return new And(op);
        }

        protected Operator GetSimpleCondition(string conditionName)
        {
            return null; // TODO: return simple condition (None or Not)
        }
    }
}
