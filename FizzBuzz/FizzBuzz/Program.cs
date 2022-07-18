using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write maximum number : ");
            string max;
            max = Console.ReadLine();
            for (int i = 1; i <= Int64.Parse(max); i++) 
            {
                string message = "";
                if (i % 3 == 0)
                {
                    if (i % 5 == 0)
                        message = "FizzBuzz";
                    else
                        message = "Fizz";
                }
                else if (i % 5 == 0)
                    message = "Buzz";
                if (i % 7 == 0)
                    if (String.IsNullOrEmpty(message))
                        message = "Bang";
                    else message += "Bang";
                if (i % 11 == 0)
                    message = "Bong";
                if(i % 13 ==0)
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
                if (i % 17 == 0 && !String.IsNullOrEmpty(message)) 
                {
                    string reversed_message = "";
                    int pos = message.Length;
                    while(pos != 0)
                    {
                        reversed_message += message.Substring(pos - 4, 4);
                        pos -= 4;
                    }
                    message = reversed_message;
                }


                if (String.IsNullOrEmpty(message))
                    Console.WriteLine(i);
                else Console.WriteLine(message);
            }
        }
    }
}