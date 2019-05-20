using System;

namespace KanthaPi
{
    class Program
    {
        static void Main()
        {
            bool KeepGoing = true;

            do
            {
                // Get user input

                Console.WriteLine("How many significant digits of Pi should I calculate?  Type 'exit' to quit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }

                // Validate

                bool InputIsValid = int.TryParse(input, out int digits);
                if (digits < 0)
                {
                    Console.WriteLine("Please enter a whole number greater than or equal to 0.");
                    break;
                }

                // Calculate Pi

                if (InputIsValid)
                {
                    Console.WriteLine("Valid input");

                }
                else
                {
                    // Let user know about input issues
                    Console.WriteLine("Sorry, there was a problem with your entry.  Please enter a whole number.");
                }

            }
            while (KeepGoing);

        } // end Main()
    } // end Program
} // end namespace
