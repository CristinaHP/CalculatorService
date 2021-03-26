using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorClient.Models
{
	public class SqrtResult
	{
		public double Square { get; set; }

		public SqrtResult()
		{
			Square = 0;
		}

		public override string ToString()
		{
			return $"Square: {Square}";
		}
	}
}
