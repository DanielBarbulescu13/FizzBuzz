using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    class Rule5 : Rule
    {
        public override void ApplyRule(string manipulate_this)
        {
            manipulate_this += "Buzz";
        }
    }
}
