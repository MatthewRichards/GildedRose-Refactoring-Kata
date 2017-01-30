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

    [Test]
    public void Quality_Decreases()
    {
      const int initialQuality = 14;
      var item = new ItemBuilder().WithQuality(initialQuality).Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(initialQuality - 1, item.Quality);
    }

    [Test]
    public void Quality_AfterSellByDate_DecreasesAtDoubleSpeed()
    {
      const int initialQuality = 14;
      var item = new ItemBuilder().WithQuality(initialQuality).WithSellIn(-1).Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(initialQuality - 2, item.Quality);
    }

    [Test]
    public void Quality_OnSellByDate_DecreasesAtDoubleSpeed()
    {
      const int initialQuality = 15;
      var item = new ItemBuilder().WithQuality(initialQuality).WithSellIn(0).Build();
      GildedRose app = new GildedRose(new[] { item });

      app.UpdateQuality();

      Assert.AreEqual(initialQuality - 2, item.Quality);
    }

    [Test]
    public void Quality_DoesNotGoNegative()
    {
      var item = new ItemBuilder().WithQuality(0).Build();
      GildedRose app = new GildedRose(new[] { item });

      app.UpdateQuality();

      Assert.GreaterOrEqual(0, item.Quality);
    }

    [Test]
    public void Quality_AfterSellByDate_DoesNotGoNegative()
    {
      var item = new ItemBuilder().WithQuality(0).WithSellIn(-1).Build();
      GildedRose app = new GildedRose(new[] { item });

      app.UpdateQuality();

      Assert.GreaterOrEqual(0, item.Quality);
    }
  }
}

