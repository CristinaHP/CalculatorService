using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClient.Models
{
	public class Operation
	{
		public string OperationType { get; set; }
		public string Calculation { get; set; }
		public DateTime DateTime { get; set; }

		public Operation()
		{
			OperationType = string.Empty;
			Calculation = string.Empty;
			DateTime = DateTime.Now;
		}

		public Operation(string operationType, string calculation, DateTime dateTime)
		{
			OperationType = operationType;
			Calculation = calculation;
			DateTime = dateTime;
		}

		public override string ToString()
		{
			return $"Operation: {OperationType}, Calculation: {Calculation}, Date: {DateTime}";
		}
	}
}
