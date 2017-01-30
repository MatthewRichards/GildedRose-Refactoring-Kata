using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace GildedRose
{
  [TestFixture]
  public class GildedRoseTest
  {
    [Test]
    public void SellIn_Decreases()
    {
      const int initialSellIn = 42;
      var item = new ItemBuilder().WithSellIn(initialSellIn).Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(initialSellIn - 1, item.SellIn);
    }

    [Test]
    public void SellIn_GoesNegative()
    {
      var item = new ItemBuilder().WithSellIn(0).Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(-1, item.SellIn);
    }

    [Test]
    public void SellIn_StaysConstantForSulfuras()
    {
      const int initialSellIn = 17;
      var item = new ItemBuilder().WithName("Sulfuras, Hand of Ragnaros").WithSellIn(initialSellIn).Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(initialSellIn, item.SellIn);
    }
  }
}

