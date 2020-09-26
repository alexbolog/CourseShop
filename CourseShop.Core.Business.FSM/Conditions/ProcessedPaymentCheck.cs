using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.FSM.Conditions
{
    public class ProcessedPaymentCheck : FSMConditionBase
    {
        public override bool Evaluate()
        {
            return true;
        }
    }
}
