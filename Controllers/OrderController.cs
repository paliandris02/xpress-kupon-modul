/*
' Copyright (c) 2023 AndrasPali
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;
using XpressKuponXpressKupon.Components;
using XpressKuponXpressKupon.Models;

namespace XpressKuponXpressKupon.Controllers
{
	[DnnHandleError]
	public class OrderController : DnnController
	{
		//[HttpGet]
		public ActionResult ButtonClickAction()
		{
			var orders = OrderManager.Instance.GetOrders();
			var items = ItemManager.Instance.GetItems();
			foreach ( var order in orders )
			{
				int GiftCardCount = 0;
				foreach ( var item in items )
				{
					if(order.Id != item.OrderId) GiftCardCount++;
				}
				
				if(GiftCardCount -1 == items.Count())
				{
					Item newGiftCard = new Item
					{
						IssueDateUtc = order.TimeOfOrder,
						RecipientEmail = order.UserEmail,
						OrderId = order.Id,
						LineItemId = 1,
						CardNumber = Guid.NewGuid().ToString(),
						Amount = (float)(order.GrandTotal * 0.05),
						UsedAmount = 0,
						GiftMessage = "asd",
						ExpirationDateUtc = order.TimeOfOrder.AddMonths(1),
						RecipientName = "teszt",
						StoreId = 1,
						Enabled = 1,
					};
					ItemManager.Instance.CreateItem(newGiftCard);
				}
			}
			return View();
		}
	}
}
