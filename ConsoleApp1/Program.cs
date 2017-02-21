using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {  
            // Read the number of years remaining the individual has to work
            var yearsReamining = ReadIntInput("How many working years do you have remaining in your career?");

            // Read the amount of money the individual can put aside in their savings account
            var annualSavings = ReadDoubleInput("What is the annual amount of money that you can save?");

            // Calculate the total amount of savings using the years remaining in a person's career and the 
            // annual savings amount they can put forth
            var totalSavings = CalculateSavings(yearsReamining, annualSavings);

            // Calculate the amount of wealth each year after their annual expenses have been taken out
            // and interest has been added
            var wealthEachYear = CalculateWealthLeft(totalSavings);

            // Print the amount of wealth the individual has per year
            Amortize(wealthEachYear);
            Console.Read();
        }

        private static void Amortize(ArrayList wealthEachYear)
        {
            Console.WriteLine("");
            // The current year
            int year = 0;
            foreach(double wealth in wealthEachYear)
            {
                Console.WriteLine($"Year: {year} - ${wealth:N}");
                year++;
            }
        }

        private static ArrayList CalculateWealthLeft(double totalSavings)
        {
            ArrayList wealthPerYear = new ArrayList();
            double savings = totalSavings, interestEarned;
            int year = 0;
            const double MONEY_SPENT = 50000.00, INTEREST = 0.03;
            

            while(year <= 40 && savings > 0)
            {
                // Add the amount of money we currently have to the ArrayList "wealthPerYear"
                wealthPerYear.Add(savings);

                // Subtract the amount of money you spent from the total savings account
                savings = (savings - MONEY_SPENT);

                // Calcuate the interest based on the amount of money you have after expenses are taken out
                interestEarned = savings * INTEREST;

                // Add the interest earning to the savings account
                savings += interestEarned;

                // Increase the year by one
                year++;
            }
            return wealthPerYear;
        }

        private static double CalculateSavings(int yearsReamining, double annualSavings)
        {
            return (double) yearsReamining * annualSavings;
        }

        private static int ReadIntInput(string message)
        {
            int output = 0;
            bool isValid = false;

            Console.WriteLine(message);

            while(!isValid || output < 0)
            {
                isValid = int.TryParse(Console.ReadLine(), out output);

                if(!isValid || output < 0)
                {
                    Console.WriteLine("Please enter a valid positive integer\n");
                    Console.WriteLine(message);
                }
            }

            Console.WriteLine("");

            return output;
        }

        private static double ReadDoubleInput(string message)
        {
            double output = 0;
            bool isValid = false;

            Console.WriteLine(message);

            while (!isValid || output < 0)
            {
                isValid = double.TryParse(Console.ReadLine(), out output);

                if (!isValid || output < 0)
                {
                    Console.WriteLine("Please enter a valid positive double\n");
                    Console.WriteLine(message);
                }
            }

            Console.WriteLine("");

            return output;
        }
    }
}
