using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution
{
    public interface ICalculator
    {
        double CalculateAverage(List<double> values);
    }

    public class MeanCalculator : ICalculator
    {
        public double CalculateAverage(List<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Sum() / values.Count;
        }
    }
    public class MedianCalculator : ICalculator
    {
        public double CalculateAverage(List<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            var sortedValues = values.OrderBy(x => x).ToList();

            int n = sortedValues.Count;

            if (n % 2 == 1)
            {
                return sortedValues[(n - 1) / 2];
            }

            return (sortedValues[sortedValues.Count / 2 - 1] + sortedValues[n / 2]) / 2;
        }
    }
    public class Calculator
    {
        public delegate double AverageCalcultion(List<double> values);
        private Dictionary<AveragingMethod, AverageCalcultion> methods;
        public Calculator()
        {
            methods = new Dictionary<AveragingMethod, AverageCalcultion>();
            methods[AveragingMethod.Mean] = MeanAverage;
            methods[AveragingMethod.Median] = MedianAverage;
        }

        private double MeanAverage(List<double> values)
        {
            return values.Sum() / values.Count;
        }

        private double MedianAverage(List<double> values)
        {
            var sortedValues = values.OrderBy(x => x).ToList();

            int n = sortedValues.Count;

            if (n % 2 == 1)
            {
                return sortedValues[(n - 1) / 2];
            }

            return (sortedValues[sortedValues.Count / 2 - 1] + sortedValues[n / 2]) / 2;
        }
        public double CalculateAverage(List<double> values, AveragingMethod averagingMethod)
        {
            if (values == null)
            {
                throw  new ArgumentNullException(nameof(values));
            }

            if (!methods.ContainsKey(averagingMethod))
            {
                throw new ArgumentException("Invalid averagingMethod value");
            }

            return methods[averagingMethod](values);
        }
    }
}
