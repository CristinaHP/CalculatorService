using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorClient.Models
{
	public class AdditionResult
	{
		public int Sum { get; set; }

		public AdditionResult()
		{
			Sum = 0;
		}

		public override string ToString()
		{
			return $"Sum: {Sum}";
		}
	}
}
