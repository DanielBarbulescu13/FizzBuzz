using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    class Rule7 : Rule
    {
        public override void ApplyRule(string manipulate_this)
        {
            if (String.IsNullOrEmpty(manipulate_this))
                manipulate_this = "Bang";
            else manipulate_this += "Bang";
        }
    }
}