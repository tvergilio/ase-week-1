using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class BMICalculator
    {
        private SortedDictionary<double, string> womenRanges;
        private SortedDictionary<double, string> menRanges;

        BMICalculator()
        {
            PopulateBMIRanges();
        }

        static void Main(string[] args)
        {
            BMICalculator program = new BMICalculator();
            
            while (true)
            {
                program.Run();
            }
        }

        private void Run()
        {
            float height = GetHeightFromUser();
            float weight = GetWeightFromUser();
            double bmi = CalculateBMI(height, weight);

            bool isMale = GetGenderFromUser();
            string message = GetText(isMale, bmi);

            Console.Write("Your BMI is " + bmi.ToString("0.0") + ".");
            Console.WriteLine("You are " + message + ".\n");
            Console.WriteLine("*************************\n");
        }

        private float GetWeightFromUser()
        {
            Console.WriteLine("Enter your weight in kg.");
            string input = Console.ReadLine();
            return Single.Parse(input);
        }

        private float GetHeightFromUser()
        {
            Console.WriteLine("Enter your height in m.");
            string input = Console.ReadLine();
            return Single.Parse(input);
        }

        private bool GetGenderFromUser()
        {
            Console.WriteLine("Are you male (M) or female (F)?");
            string gender = Console.ReadLine();
            if (gender != null && !gender.ToUpper().Equals("M") && !gender.ToUpper().Equals("F"))
            {
                Console.WriteLine("Sorry, I did not get that.");
                GetGenderFromUser();
            }
            return gender.ToUpper().Equals("M");
        }

        private double CalculateBMI(float height, float weight)
        {
            return weight / (height * height);

        }

        private string GetText(bool isMale, double bmi)
        {
            SortedDictionary<double, string> range = isMale ? menRanges : womenRanges;
            string result = "";

            foreach (KeyValuePair<double, string> entry in range)
            {
                if (bmi > entry.Key)
                {
                    result = entry.Value;
                }
            }
            return result;
        }

        private void PopulateBMIRanges()
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
