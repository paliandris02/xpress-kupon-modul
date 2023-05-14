using System.Collections.Generic;
using XpressKuponXpressKupon.DAL;
using XpressKuponXpressKupon.Models;


namespace XpressKuponXpressKupon.Services
{
	public class RewardsPointService
	{
		public IEnumerable<JutalomPont> GetRewardsPoints()
		{
			var repository = new RewardsPointRepository();
			return repository.GetRewardsPoints();
		}
	}
}
