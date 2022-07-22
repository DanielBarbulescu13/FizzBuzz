using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzzEnumerator : IEnumerator
    {
        public string[] fizzbuzzED;

        int position = -1;

        public FizzBuzzEnumerator(string[] list)
        {
            fizzbuzzED = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < fizzbuzzED.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public string Current
        {
            get
            {
                try
                {
                    return fizzbuzzED[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
