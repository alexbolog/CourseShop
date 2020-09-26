using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.FSM.Conditions
{
    public abstract class FSMConditionBase
    {
        public abstract bool Evaluate();
    }
}
