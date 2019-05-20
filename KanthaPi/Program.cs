using System;

namespace KanthaPi
{
    class Program
    {
        static void Main()
        {
            bool KeepGoing = true;
            int maxIterations = 12000;

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

                if (InputIsValid)
                {

                    // Make accuracy limiter

                    string accuracyString = "0.";
                    for (int i = 0; i <= digits; i++)
                    {
                        accuracyString += "0";
                    }
                    accuracyString += "1";
                    double accuracy = double.Parse(accuracyString);

                    // Calculate Pi

                    double answer = 3;
                    double baseNum = 2;
                    int counter = 0;

                    for (int i = 1; Math.Abs(Math.PI - answer) > accuracy && i < maxIterations; i++)
                    {
                        if (i % 2 == 1) // odds
                        {
                            answer += (4 / (baseNum * (baseNum +1 ) * (baseNum + 2)));
                            baseNum += 2;
                            counter += 1;
                            Console.WriteLine(i + ": " + answer);
                        }
                        else // evens
                        {
                            answer -= (4 / (baseNum * (baseNum + 1) * (baseNum + 2)));
                            baseNum += 2;
                            counter += 1;
                            Console.WriteLine(i + ": " + answer);
                        }

                    } // end for

                    // Write answer to screen

                    if (counter == maxIterations - 1)
                    {
                        Console.WriteLine("Sorry!  This program only does " + maxIterations + " iterations.  You've hit that limit, " +
                            "and we still don't have Pi to " + digits + " digits.");
                    }
                    else
                    {
                        char[] answerArray = answer.ToString().ToCharArray();
                        string answerOutput = "";
                        for (int i = 0; i < 2 + digits; i++)
                        {
                            answerOutput += answerArray[i];
                        }
                        Console.WriteLine("Pi to " + digits + " significant digits is " + answerOutput + ".");
                        Console.WriteLine("It took " + counter + " steps to get that answer.");
                    }                    

                } // end InputIsValid
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
