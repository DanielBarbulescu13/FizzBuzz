using System;
using System.Collections;

namespace FizzBuzz
{
    public class Flags
    {
        public bool three = false;
        public bool five = false;
        public bool seven = false;
        public bool eleven = false;
        public bool thirteen = false;
        public bool seventeen = false;
    }

    public class Program
    {
        private Flags setFlags(string[] args)
        {
            Flags flags = new Flags();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "3")
                    flags.three = true;
                else if (args[i] == "7")
                    flags.seven = true;
                else if (args[i] == "5")
                    flags.five = true;
                else if (args[i] == "11")
                    flags.eleven = true;
                else if (args[i] == "13")
                    flags.thirteen = true;
                else if (args[i] == "17")
                    flags.seventeen = true;
            }
            return flags;
        }

        private string getIterations()
        {
            Console.WriteLine("Write maximum number : ");
            string max;
            max = Console.ReadLine();
            return max;
        }

        public string FizzBuzzLogic(int i, Flags flags)
        {
            string message = "";
            if (i % 3 == 0 && flags.three)
            {
                if (i % 5 == 0 && flags.five)
                    message = "FizzBuzz";
                else
                    message = "Fizz";
            }
            else if (i % 5 == 0 && flags.five)
                message = "Buzz";
            if (i % 7 == 0 && flags.seven)
                if (String.IsNullOrEmpty(message))
                    message = "Bang";
                else message += "Bang";
            if (i % 11 == 0 && flags.eleven)
                message = "Bong";
            if (i % 13 == 0 && flags.thirteen)
                if (String.IsNullOrEmpty(message))
                    message = "Fezz";
                else if (!message.Contains('B'))
                    message += "Fezz";
                else
                {
                    int index = message.IndexOf('B');
                    string first_message = message.Substring(0, index);
                    string second_message = message.Substring(index, message.Length - first_message.Length);
                    message = first_message + "Fezz" + second_message;
                }
            if (i % 17 == 0 && !String.IsNullOrEmpty(message) && flags.seventeen)
            {
                string reversed_message = "";
                int pos = message.Length;
                while (pos != 0)
                {
                    reversed_message += message.Substring(pos - 4, 4);
                    pos -= 4;
                }
                message = reversed_message;
            }

            if (String.IsNullOrEmpty(message))
                message = i.ToString();

            return message;
        }

        static void Main(string[] args)
        {
            var program = new Program();
            Flags flags = program.setFlags(args);
            string max = program.getIterations();

            for (int i = 1; i <= Int64.Parse(max); i++)
            {
                string message = program.FizzBuzzLogic(i, flags);

                Console.WriteLine(message);
            }

            Console.WriteLine("Using IEnumerable ... ");

            var fizzBuzzer = new FizzBuzz(max, flags, program);

            foreach (var value in fizzBuzzer)
            {
                Console.WriteLine(value);
            }

        }
    }

    public class FizzBuzz : IEnumerable
    {
        private string[] fizzbuzzED;

        public FizzBuzz(string max, Flags flags, Program program)
        {
            fizzbuzzED = new string[Int64.Parse(max)];

            for (int i = 1; i <= Int64.Parse(max); i++)
            {
                string message = program.FizzBuzzLogic(i, flags);

                fizzbuzzED[i - 1] = message;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new FizzBuzzEnumerator(fizzbuzzED);
        }
    }

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