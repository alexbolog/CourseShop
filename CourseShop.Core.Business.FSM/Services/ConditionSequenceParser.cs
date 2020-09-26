//using CourseShop.Core.Business.FSM.BooleanExpression;
//using CourseShop.Core.Business.FSM.BooleanExpression.Operators;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace CourseShop.Core.Business.FSM.Services
//{
//    //          &
//    //(   |         c3
//    // c1   c2 
//    public class ConditionSequenceParser
//    {
//        public void Parse(string conditionSequence) // (c1 | c2) & c3)( & c4 --- 
//        {
//            conditionSequence = conditionSequence.Replace(" ", ""); // ((c1|c2)&c3)

//            // ((c1|c2) & c3)
//            while (HasParanthesis(conditionSequence)) // true
//            {
//                var op = GetFromParanthesis(conditionSequence, out var parsed); // op = (c1|c2); condSeq = ( &c3)
//                conditionSequence
//            }
            
//        }

//        private bool HasParanthesis(string seq) => seq.Contains("(") || seq.Contains(")");

//        private Operator GetFromParanthesis(string sequence, out string paranthesis) // ((c1|c2)&c3)
//        {
//            var lastOpenedP = sequence.LastIndexOf('(');
//            var firstClosedP = sequence.Substring(lastOpenedP + 1).IndexOf(')');
            
//            paranthesis = sequence.Substring(lastOpenedP, firstClosedP - lastOpenedP).Replace("(", "").Replace(")", "");// c1|c2

//            return Operator.Parse(paranthesis);
//        }
//    }
//}
