using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Core.Business.FSM.Actions
{
    public abstract class FSMActionBase
    {
        public abstract Task Run();
    }
}
