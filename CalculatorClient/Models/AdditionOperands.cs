using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClient.Models
{
	public class AdditionOperands
	{
		public List<int> Addends { get; set; }

		public AdditionOperands()
		{
			Addends = new List<int>();
		}
	}
}
