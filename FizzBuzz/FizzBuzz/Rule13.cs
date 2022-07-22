using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    class Rule13 : Rule
    {
        public override void ApplyRule(string manipulate_this)
        {
            if (String.IsNullOrEmpty(manipulate_this))
                manipulate_this = "Fezz";
            else if (!manipulate_this.Contains('B'))
                manipulate_this += "Fezz";
            else
            {
                int index = manipulate_this.IndexOf('B');
                string first_manipulate_this = manipulate_this.Substring(0, index);
                string second_manipulate_this = manipulate_this.Substring(index, manipulate_this.Length - first_manipulate_this.Length);
                manipulate_this = first_manipulate_this + "Fezz" + second_manipulate_this;
            }
        }
    }
}