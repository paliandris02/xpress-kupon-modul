using DotNetNuke.Entities.Modules;
using DotNetNuke.Security;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using Hotcakes.Commerce;
using Hotcakes.Commerce.Catalog;
using Hotcakes.Commerce.Catalog.Extensions;
using Hotcakes.Commerce.Payment.Methods;
using System.Web.Mvc;
using XpressKuponXpressKupon.Models;
using DotNetNuke.Data;

namespace XpressKuponXpressKupon.Controllers
{
	[DnnHandleError]
	public class RewardsPointsController : DnnController
	{
		public ActionResult Index()
		{
			string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=DNNDEV;Integrated Security=True";
			// SQLExpress adatbázis kapcsolat inicializálása
			var dataProvider = new SqlDataProvider(connectionString);

			// RewardPontok lekérése az adatbázisból
			var rewardPontok = GetRewardPontok(dataProvider);

			// Adatok továbbítása a nézetnek
			ViewBag.RewardPontok = rewardPontok;

			// Nézet megjelenítése
			return View();
		}

		private RewardPointsModel[] GetRewardPontok(DotNetNuke.Data.SqlDataProvider dataProvider)
		{
			// SQL lekérdezés végrehajtása az adatbázisban
			var sqlCommand = "SELECT * FROM dbo.hcc_RewardsPoints";
			var rewardPontok = dataProvider.ExecuteQuery<RewardPointsModel>(System.Data.CommandType.Text, sqlCommand);

			return rewardPontok;
		}
	}
}
