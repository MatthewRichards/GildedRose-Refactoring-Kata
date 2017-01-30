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
      var item = new ItemBuilder().WithName(GildedRose.SulfurasHandOfRagnaros).WithSellIn(initialSellIn).Build();
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

    [Test]
    public void Quality_ForAgedBrie_IncreasesWithAge()
    {
      const int initialQuality = 19;
      var item = new ItemBuilder().WithName(GildedRose.AgedBrie).WithQuality(initialQuality).Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(initialQuality + 1, item.Quality);
    }

    [Test]
    [TestCase(GildedRose.AgedBrie)]
    [TestCase(GildedRose.BackstagePasses)]
    public void Quality_DoesntIncreaseAbove50(string interestingProductName)
    {
      const int maxQuality = 50;
      var item = new ItemBuilder().WithName(interestingProductName).WithQuality(maxQuality).Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(maxQuality, item.Quality);
    }

    [Test]
    [TestCase(-1)]
    [TestCase(1)]
    public void Quality_StaysConstantForSulfuras(int sellIn)
    {
      const int initialQuality = 41;
      var item = new ItemBuilder().WithName(GildedRose.SulfurasHandOfRagnaros).WithQuality(initialQuality).WithSellIn(sellIn).Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(initialQuality, item.Quality);
    }

    [Test]
    [TestCase(15, 1)]
    [TestCase(10, 2)]
    [TestCase(5, 3)]
    [TestCase(1, 3)]
    public void Quality_ForBackstagePasses_AcceleratesAsSellByDateApproaches(int sellIn, int qualityIncrement)
    {
      const int initialQuality = 10;
      var item =
        new ItemBuilder().WithName(GildedRose.BackstagePasses)
          .WithSellIn(sellIn)
          .WithQuality(initialQuality)
          .Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(initialQuality + qualityIncrement, item.Quality);
    }

    [Test]
    public void Quality_ForBackstagePasses_DropsToZeroAfterSellByDate()
    {
      var item = new ItemBuilder().WithName(GildedRose.BackstagePasses).WithSellIn(0).Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(0, item.Quality);
    }

    [Test]
    public void Quality_ForConjouredItems_FallsAtDoubleSpeed()
    {
      var initialQuality = 19;
      var item = new ItemBuilder().WithName(GildedRose.ConjouredRabbit).WithQuality(initialQuality).Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(initialQuality - 2, item.Quality);
    }

    [Test]
    public void Quality_ForConjouredItems_FallsAtQuadrupleSpeedAfterSellByDate()
    {
      var initialQuality = 18;
      var item =
        new ItemBuilder().WithName(GildedRose.ConjouredRabbit).WithQuality(initialQuality).WithSellIn(0).Build();
      GildedRose app = new GildedRose(new[] {item});

      app.UpdateQuality();

      Assert.AreEqual(initialQuality - 4, item.Quality);
    }

  }
}

