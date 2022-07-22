using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    public class Program
    {
        public List<Rule> rules_list;

        public Program()
        {
            rules_list = new List<Rule>();
        }
        public string FizzBuzzLogic(int i)
        {
            string message = "";
            
            if (rules_list.Count==0)
                message = i.ToString();
            else
            {
                foreach (var current_rule in rules_list)
                {
                    current_rule.ApplyRule(message);
                }
            }

            return message;
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.setRulesList(args);
            string max = program.getIterations();

            for (int i = 1; i <= Int64.Parse(max); i++)
            {
                string message = program.FizzBuzzLogic(i);

                Console.WriteLine(message);
            }

            Console.WriteLine("Using IEnumerable ... ");

            var fizzBuzzer = new FizzBuzz(max, program);

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
        private void setRulesList(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "3")
                {
                    rules_list.Add(new Rule3());
                }
                else if (args[i] == "7")
                {
                    rules_list.Add(new Rule7());
                }
                else if (args[i] == "5")
                {
                    rules_list.Add(new Rule3());
                }
                else if (args[i] == "11")
                {
                    rules_list.Add(new Rule11());
                }
                else if (args[i] == "13")
                {
                    rules_list.Add(new Rule13());
                }
                else if (args[i] == "17")
                {
                    rules_list.Add(new Rule17());
                }
            }
        }

        private string getIterations()
        {
            Console.WriteLine("Write maximum number : ");
            return Console.ReadLine();
        }
    }
}