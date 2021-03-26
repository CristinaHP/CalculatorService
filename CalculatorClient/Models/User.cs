using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorClient.Models
{
	public class User
	{
		public TrackingId TrackingId { get; set; }
		public Operation Operation { get; set; }

		public User(TrackingId trackingId) : this (trackingId, new Operation())
		{
		}

		public User(TrackingId trackingId, Operation operation)
		{
			TrackingId = trackingId;
			Operation = operation;
		}
	}
}
