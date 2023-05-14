using DotNetNuke.Data;
using System.Collections.Generic;
using XpressKuponXpressKupon.Models;

namespace XpressKuponXpressKupon.DAL
{
	public class RewardsPointRepository
	{
		public IEnumerable<JutalomPont> GetRewardsPoints()
		{
			IDataContext dbContext = DataContext.Instance();
			var query = dbContext.ExecuteQuery<JutalomPont>(System.Data.CommandType.Text,"SELECT * FROM {databaseOwner}[{objectQualifier}hcc_RewardsPoints]");
			return query;
		}
	}
}
