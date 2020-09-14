using System;
using System.Collections.Generic;
using System.Linq;
namespace Statistics
{

    public class StatsComputer
    {
        #region DataMembers
        Double average;
        Double max;
        Double min;
        #endregion
        #region Methods
        public Double ComputAverage<T>(List<T> numbers)
        {
            Double sum = 0;
            int size = numbers.Count;
            for (int i = 0; i < size; i++)
            {
                sum += Convert.ToDouble(numbers.ElementAt(i));
            }
            return sum / (size);
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
                List<T> numbersNew = new List<T>();
                numbersNew = genarateNewNumberListWhichHasNoNAN(numbers);
                average = ComputAverage(numbersNew);
                max = ComputMax(numbersNew);
                min = ComputMin(numbersNew);
            }

        }
        public List<T> genarateNewNumberListWhichHasNoNAN<T>(List<T> numbers)
        {
            List<T> numbersNew = new List<T>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (!Double.IsNaN(Convert.ToDouble(numbers.ElementAt(i))))
                {
                    numbersNew.Add(numbers.ElementAt(i));
                }
            }
            return numbersNew;
        }
        #endregion
        #region Properties
        public Double Average
        {
            get
            {
                return this.average;
            }
        }
        public Double Max
        {
            get
            {
                return this.max;
            }
        }
        public Double Min
        {
            get
            {
                return this.min;
            }
        }
        #endregion
    }
}
