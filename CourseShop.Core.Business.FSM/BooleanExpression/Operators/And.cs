using System;
using System.Collections.Generic;
using System.Text;

namespace CourseShop.Core.Business.FSM.BooleanExpression.Operators
{
    public class And : Operator
    {
        private readonly Operator c1;
        private readonly Operator c2;

        public And(string op)
        {
            var split = op.Split('&');
            this.c1 = GetSimpleCondition(split[0]);
            this.c1 = GetSimpleCondition(split[1]);
        }

        public And(Operator c1, Operator c2)
        {
            this.c1 = c1;
            this.c2 = c2;
        }

        public override bool Evaluate()
        {
            return c1.Evaluate() && c2.Evaluate();
        }
    }
}
