using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XpressKuponXpressKupon.Models
{
	public class JutalomPont
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public int Points { get; set; }
		public int PointsHeld { get; set; }
		public DateTime TransactionTime { get; set; }
		public int StoreId { get; set; }
	}
}