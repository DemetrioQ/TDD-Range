using System;

namespace KataRange
{
    public class Range
    {
        private int Min;
        private int Max;
        public Range(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentException("Empty Range");
            }
            string[] numbers = expression.Split(',');
            int min = Convert.ToInt32(numbers[0].TrimStart('(', '['));
            int max = Convert.ToInt32(numbers[1].TrimEnd(')', ']'));

            if (min > max)
            {
                throw new ArgumentException("Inverted Range");
            }

            if (expression[0] == '(')
            {
                min = min + 1;
            }

            if (expression[expression.Length - 1] == ')')
            {
                max = max - 1;
            }
            this.Min = min;
            this.Max = max;
        }

        public bool Contains(params int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < this.Min || numbers[i] > this.Max)
                {
                    return false;
                }
            }
            return true;
        }

        public int[] EndPoints()
        {
            return new int[] { this.Min, this.Max };
        }

        public bool ContainsRange(Range other)
        {
            return this.Min <= other.Min && this.Max >= other.Max;
        }

        public int[] GetAllPoints()
        {
            int[] points = new int[this.Max - this.Min + 1];
            int current_value = this.Min;
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = current_value;
                current_value++;
            }

            return points;
        }

        public bool Equals(Range other)
        {
            return this.Min == other.Min && this.Max == other.Max;
        }

        public bool OverlapsRange(Range other)
        {
            return Contains(other.Min) || Contains(other.Max);
        }

    }
}
