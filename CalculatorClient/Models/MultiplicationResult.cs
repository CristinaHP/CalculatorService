using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorClient.Models
{
	public class MultiplicationResult
	{
		public int Product { get; set; }

		public MultiplicationResult()
		{
			Product = 0;
		}

		public override string ToString()
		{
			return $"Product: {Product}";
		}
	}
}
