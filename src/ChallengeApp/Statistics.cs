using System;

namespace ChallengeApp
{
    public class Statistics
    {
        
        public double High;
        public double Low;
        public double Sum;
        public int Count;

        public Statistics()
        {
            Sum = 0;
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;            
        }

        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 5:
                    return 'A';
                
                    case var d when d >= 4 && d< 5:
                    return 'B';

                    case var d when d >= 3 && d < 4:
                    return 'C';
                
                    case var d when d >= 2 && d < 3:
                    return 'D';
                
                    default:
                    return 'E';                                
                }
            }
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);           
        }

    }
}