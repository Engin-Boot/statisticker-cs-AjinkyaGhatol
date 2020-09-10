using System;
using System.Collections.Generic;
using System.Linq;
namespace Statistics
{
   
    public class StatsComputer
    {

        public Double average;
        public Double max;
        public Double min;
        public Double  ComputAverage<T>(List<T> numbers)
        {
            Double sum = 0;
            
                int size = numbers.Count;
            for (int i = 0; i<size; i++)
            {
                sum = sum+Convert.ToDouble(numbers.ElementAt(i));
            }
            return sum / size;
        }
        public Double ComputMax<T>(List<T> numbers)
        {
            return Convert.ToDouble(numbers.Max());
        }
        public Double ComputMin<T>(List<T> numbers)
        {
            return Convert.ToDouble(numbers.Min());
        }

        public void CalculateStatistics<T>(List<T> numbers)
        {
            if (numbers.Count == 0)
            {
                average = Double.NaN;
                min = Double.NaN;
                max = Double.NaN;
            }
            else
            {   
                average = ComputAverage(numbers);
                max = ComputMax(numbers);
                min = ComputMin(numbers);
            }
            
        }

    }
}
