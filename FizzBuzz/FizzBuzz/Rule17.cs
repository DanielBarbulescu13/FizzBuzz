using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    class Rule17 : Rule
    {
        public override void ApplyRule(string manipulate_this)
        {
            if (!String.IsNullOrEmpty(manipulate_this))
            {
                string reversed_manipulate_this = "";
                int pos = manipulate_this.Length;
                while (pos != 0)
                {
                    reversed_manipulate_this += manipulate_this.Substring(pos - 4, 4);
                    pos -= 4;
                }

                manipulate_this = reversed_manipulate_this;
            }
        }
    }
}
