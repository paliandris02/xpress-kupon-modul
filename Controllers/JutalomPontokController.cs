using System.Web.Mvc;
using XpressKuponXpressKupon.Services;

namespace YourModuleName.Controllers
{
	public class RewardsPointController : Controller
	{
		public ActionResult Index()
		{
			var service = new RewardsPointService();
			var rewardsPoints = service.GetRewardsPoints();
			return View(rewardsPoints);
		}
	}
}
