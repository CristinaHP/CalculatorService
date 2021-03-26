using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Calculator.Services
{
	public class OperationService
	{
		private readonly object syncLock = new object();
		private static List<User> operationsByUser = new List<User>();

		public void SaveOperations(User user)
		{
			lock (syncLock)
			{
				operationsByUser.Add(user);
			}
		}

		public List<Operation> GetOperationsByTrackingId(string trackinId)
		{
			List<Operation> operationsList = new List<Operation>();

			foreach (User user in operationsByUser)
			{
				if (user.TrackingId.Id == trackinId)
				{
					operationsList.Add(user.Operation);
				}
			}

			return operationsList;
		}
	}
}
