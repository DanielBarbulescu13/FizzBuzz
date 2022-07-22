using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzz : IEnumerable
    {
        private string[] fizzbuzzED;

        public FizzBuzz(string max, Rule Rule, Program program)
        {
            fizzbuzzED = new string[Int64.Parse(max)];

            for (int i = 1; i <= Int64.Parse(max); i++)
            {
                string message = program.FizzBuzzLogic(i, Rule);

                fizzbuzzED[i - 1] = message;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new FizzBuzzEnumerator(fizzbuzzED);
        }
    }
}
