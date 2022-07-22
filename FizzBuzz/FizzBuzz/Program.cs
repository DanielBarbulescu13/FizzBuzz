using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    public class Program
    {
        public string FizzBuzzLogic(int i, Rule Rule)
        {
            string message = "";
            if (i % 3 == 0 && Rule.three)
            {
                if (i % 5 == 0 && Rule.five)
                    message = "FizzBuzz";
                else
                    message = "Fizz";
            }
            else if (i % 5 == 0 && Rule.five)
                message = "Buzz";
            if (i % 7 == 0 && Rule.seven)
                if (String.IsNullOrEmpty(message))
                    message = "Bang";
                else message += "Bang";
            if (i % 11 == 0 && Rule.eleven)
                message = "Bong";
            if (i % 13 == 0 && Rule.thirteen)
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
            if (i % 17 == 0 && !String.IsNullOrEmpty(message) && Rule.seventeen)
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
            Rule Rule = program.setRule(args);
            string max = program.getIterations();

            for (int i = 1; i <= Int64.Parse(max); i++)
            {
                string message = program.FizzBuzzLogic(i, Rule);

                Console.WriteLine(message);
            }

            Console.WriteLine("Using IEnumerable ... ");

            var fizzBuzzer = new FizzBuzz(max, Rule, program);

            foreach (var value in fizzBuzzer)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("One-Liner ... ");

            IEnumerable fizzbuzzED = Enumerable.Range(1, Int32.Parse(max)).Select(x => x % 3 == 0 ? (x % 5 == 0 && x % 7 == 0 ? "FizzBuzzBang" : (x % 5 == 0 ? "FizzBuzz" : (x % 7 == 0 ? "FizzBang" : "Fizz"))) : (x % 5 == 0 ? (x % 7 == 0 ? "BuzzBang" : "Buzz") : (x % 7 == 0 ? "Bang" : x.ToString())));

            foreach (var fizbuzzEDcurrent in fizzbuzzED)
            {
                Console.WriteLine(fizbuzzEDcurrent);
            }

        }
        private Rule setRule(string[] args)
        {
            Rule Rule = new Rule();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "3")
                {
                    Rule.three = true;
                }
                else if (args[i] == "7")
                {
                    Rule.seven = true;
                }
                else if (args[i] == "5")
                {
                    Rule.five = true;
                }
                else if (args[i] == "11")
                {
                    Rule.eleven = true;
                }
                else if (args[i] == "13")
                {
                    Rule.thirteen = true;
                }
                else if (args[i] == "17")
                {
                    Rule.seventeen = true;
                }
            }

            return Rule;
        }

        private string getIterations()
        {
            Console.WriteLine("Write maximum number : ");
            return Console.ReadLine();
        }
    }
}