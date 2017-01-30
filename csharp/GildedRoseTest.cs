using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose
{
	[TestFixture]
	public class GildedRoseTest
	{
		[Test]
		public void foo()
    {
			IList<Item> items = new List<Item> { new Item{Name = "foo", SellIn = 0, Quality = 0} };
			GildedRose app = new GildedRose(items);
			app.UpdateQuality();
			Assert.AreEqual("fixme", items[0].Name);
		}
	}
}

