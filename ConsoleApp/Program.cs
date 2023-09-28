using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class BmiCalculator
    {
        private SortedDictionary<double, string> womenRanges;
        private SortedDictionary<double, string> menRanges;

        private BmiCalculator()
        {
            PopulateBmiRanges();
        }

        private static void Main()
        {
            var program = new BmiCalculator();
            
            while (true)
            {
                program.Run();
            }
        }

        private void Run()
        {
            var height = GetHeightFromUser();
            var weight = GetWeightFromUser();
            var bmi = CalculateBmi(height, weight);

            var isMale = GetGenderFromUser();
            var message = GetText(isMale, bmi);

            Console.Write("Your BMI is " + bmi.ToString("0.0") + ".");
            Console.WriteLine("You are " + message + ".\n");
            Console.WriteLine("*************************\n");
        }

        private float GetWeightFromUser()
        {
            Console.WriteLine("Enter your weight in kg.");
            var input = Console.ReadLine();
            return float.Parse(input);
        }

        private float GetHeightFromUser()
        {
            Console.WriteLine("Enter your height in m.");
            var input = Console.ReadLine();
            return float.Parse(input);
        }

        private bool GetGenderFromUser()
        {
            Console.WriteLine("Are you male (M) or female (F)?");
            var gender = Console.ReadLine()?.Trim().ToUpper();

            while (gender != "M" && gender != "F")
            {
                Console.WriteLine("Sorry, I did not get that. Please enter 'M' for male or 'F' for female.");
                gender = Console.ReadLine()?.Trim().ToUpper();
            }

            return gender == "M";
        }

        private double CalculateBmi(float height, float weight)
        {
            return weight / (height * height);

        }

        private string GetText(bool isMale, double bmi)
        {
            var range = isMale ? menRanges : womenRanges;
            var result = "";

            foreach (KeyValuePair<double, string> entry in range)
            {
                if (bmi > entry.Key)
                {
                    result = entry.Value;
                }
            }
            return result;
        }

        private void PopulateBmiRanges()
        {
            womenRanges = new SortedDictionary<double, string>
            {
                { 0, "severely underweight" },
                { 17.5, "underweight" },
                { 19.1, "in normal range" },
                { 25.8, "marginally overweight" },
                { 27.3, "overweight" },
                { 32.3, "very overweight or obese" },
                { 40, "severely obese" },
                { 50, "morbidly obese" },
                { 60, "super obese" }
            };

            menRanges = new SortedDictionary<double, string>
            {
                { 0, "severely underweight" },
                { 18.5, "underweight" },
                { 20.7, "in normal range" },
                { 26.4, "marginally overweight" },
                { 27.8, "overweight" },
                { 31.1, "very overweight or obese" },
                { 40, "severely obese" },
                { 50, "morbidly obese" },
                { 60, "super obese" }
            };
        }
    }
}
