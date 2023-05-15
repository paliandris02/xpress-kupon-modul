/*
' Copyright (c) 2023 Xpress
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;
using System;
using System.Web.Caching;

namespace XpressKuponXpressKupon.Models
{
	[TableName("hcc_RewardsPoints")]
	//setup the primary key for table
	[PrimaryKey("Id", AutoIncrement = true)]
	//configure caching using PetaPoco
	[Cacheable("Items", CacheItemPriority.Default, 20)]
	//scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
	[Scope("ModuleId")]
	public class Item
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public int Points { get; set; }
		public int PointsHeld { get; set; }
		public DateTime TransactionTime { get; set; }
		public int StoreId { get; set; }
	}
}
