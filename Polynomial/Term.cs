using System;
namespace Polynomial
{
	public class Term
	{
		public int Power { get; set; }
		public double Coefficient { get; set; }

		public Term(int power, double coefficient)
		{
			Power = power;
            Coefficient = coefficient;
		}


		//TODO
		public override string ToString()
		{
			if (Power == 0)
            {
                return $"{Coefficient}";
            }
			if (Power == 1)
            {
                return $"{Coefficient}x^{Power}+";
            }
            return $"{Coefficient}x^{Power}";
		}

	}
}

