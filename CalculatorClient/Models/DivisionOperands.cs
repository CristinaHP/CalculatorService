using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClient.Models
{
	public class DivisionOperands
	{
		public int Dividend { get; set; }
		public int Divisor { get; set; }

		public DivisionOperands()
		{
			Dividend = 0;
			Divisor = 0;
		}

		public DivisionOperands(int number1, int number2)
		{
			Dividend = number1;
			Divisor = number2;
		}
	}
}
