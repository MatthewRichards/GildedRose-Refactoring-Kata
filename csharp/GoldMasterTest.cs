using System.Text;
using NUnit.Framework;

namespace GildedRose
{
  [TestFixture]
  public class GoldMasterTest
  {
    [Test]
    public void GoldMaster()
    {
      var inputItems = new[]
      {
        new Item {Name = "Aged Brie", Quality = 17, SellIn = 40},
        new Item {Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 20},
        new Item {Name = "Sulfuras, Hand of Ragnaros", Quality = 4, SellIn = 5},
        new Item {Name = "Some other item", Quality = 17, SellIn = 5}
      };

      var output = new StringBuilder();
      var app = new GildedRose(inputItems);
      AddToOutput(output, 0, inputItems);

      for (int i = 0; i < 50; i++)
      {
        app.UpdateQuality();
        AddToOutput(output, i, inputItems);
      }

      Assert.AreEqual(ExpectedOutput, output.ToString());
    }

    private void AddToOutput(StringBuilder output, int step, Item[] items)
    {
      output.AppendLine();
      output.AppendLine($"State after step {step}:");

      foreach (Item item in items)
      {
        output.AppendLine($"  {item.Name}: Quality {item.Quality}, Sell In {item.SellIn}");
      }
    }

    private const string ExpectedOutput = @"
State after step 0:
  Aged Brie: Quality 17, Sell In 40
  Backstage passes to a TAFKAL80ETC concert: Quality 1, Sell In 20
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 17, Sell In 5

State after step 0:
  Aged Brie: Quality 18, Sell In 39
  Backstage passes to a TAFKAL80ETC concert: Quality 2, Sell In 19
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 16, Sell In 4

State after step 1:
  Aged Brie: Quality 19, Sell In 38
  Backstage passes to a TAFKAL80ETC concert: Quality 3, Sell In 18
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 15, Sell In 3

State after step 2:
  Aged Brie: Quality 20, Sell In 37
  Backstage passes to a TAFKAL80ETC concert: Quality 4, Sell In 17
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 14, Sell In 2

State after step 3:
  Aged Brie: Quality 21, Sell In 36
  Backstage passes to a TAFKAL80ETC concert: Quality 5, Sell In 16
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 13, Sell In 1

State after step 4:
  Aged Brie: Quality 22, Sell In 35
  Backstage passes to a TAFKAL80ETC concert: Quality 6, Sell In 15
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 12, Sell In 0

State after step 5:
  Aged Brie: Quality 23, Sell In 34
  Backstage passes to a TAFKAL80ETC concert: Quality 7, Sell In 14
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 10, Sell In -1

State after step 6:
  Aged Brie: Quality 24, Sell In 33
  Backstage passes to a TAFKAL80ETC concert: Quality 8, Sell In 13
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 8, Sell In -2

State after step 7:
  Aged Brie: Quality 25, Sell In 32
  Backstage passes to a TAFKAL80ETC concert: Quality 9, Sell In 12
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 6, Sell In -3

State after step 8:
  Aged Brie: Quality 26, Sell In 31
  Backstage passes to a TAFKAL80ETC concert: Quality 10, Sell In 11
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 4, Sell In -4

State after step 9:
  Aged Brie: Quality 27, Sell In 30
  Backstage passes to a TAFKAL80ETC concert: Quality 11, Sell In 10
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 2, Sell In -5

State after step 10:
  Aged Brie: Quality 28, Sell In 29
  Backstage passes to a TAFKAL80ETC concert: Quality 13, Sell In 9
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -6

State after step 11:
  Aged Brie: Quality 29, Sell In 28
  Backstage passes to a TAFKAL80ETC concert: Quality 15, Sell In 8
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -7

State after step 12:
  Aged Brie: Quality 30, Sell In 27
  Backstage passes to a TAFKAL80ETC concert: Quality 17, Sell In 7
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -8

State after step 13:
  Aged Brie: Quality 31, Sell In 26
  Backstage passes to a TAFKAL80ETC concert: Quality 19, Sell In 6
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -9

State after step 14:
  Aged Brie: Quality 32, Sell In 25
  Backstage passes to a TAFKAL80ETC concert: Quality 21, Sell In 5
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -10

State after step 15:
  Aged Brie: Quality 33, Sell In 24
  Backstage passes to a TAFKAL80ETC concert: Quality 24, Sell In 4
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -11

State after step 16:
  Aged Brie: Quality 34, Sell In 23
  Backstage passes to a TAFKAL80ETC concert: Quality 27, Sell In 3
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -12

State after step 17:
  Aged Brie: Quality 35, Sell In 22
  Backstage passes to a TAFKAL80ETC concert: Quality 30, Sell In 2
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -13

State after step 18:
  Aged Brie: Quality 36, Sell In 21
  Backstage passes to a TAFKAL80ETC concert: Quality 33, Sell In 1
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -14

State after step 19:
  Aged Brie: Quality 37, Sell In 20
  Backstage passes to a TAFKAL80ETC concert: Quality 36, Sell In 0
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -15

State after step 20:
  Aged Brie: Quality 38, Sell In 19
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -1
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -16

State after step 21:
  Aged Brie: Quality 39, Sell In 18
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -2
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -17

State after step 22:
  Aged Brie: Quality 40, Sell In 17
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -3
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -18

State after step 23:
  Aged Brie: Quality 41, Sell In 16
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -4
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -19

State after step 24:
  Aged Brie: Quality 42, Sell In 15
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -5
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -20

State after step 25:
  Aged Brie: Quality 43, Sell In 14
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -6
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -21

State after step 26:
  Aged Brie: Quality 44, Sell In 13
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -7
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -22

State after step 27:
  Aged Brie: Quality 45, Sell In 12
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -8
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -23

State after step 28:
  Aged Brie: Quality 46, Sell In 11
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -9
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -24

State after step 29:
  Aged Brie: Quality 47, Sell In 10
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -10
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -25

State after step 30:
  Aged Brie: Quality 48, Sell In 9
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -11
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -26

State after step 31:
  Aged Brie: Quality 49, Sell In 8
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -12
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -27

State after step 32:
  Aged Brie: Quality 50, Sell In 7
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -13
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -28

State after step 33:
  Aged Brie: Quality 50, Sell In 6
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -14
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -29

State after step 34:
  Aged Brie: Quality 50, Sell In 5
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -15
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -30

State after step 35:
  Aged Brie: Quality 50, Sell In 4
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -16
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -31

State after step 36:
  Aged Brie: Quality 50, Sell In 3
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -17
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -32

State after step 37:
  Aged Brie: Quality 50, Sell In 2
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -18
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -33

State after step 38:
  Aged Brie: Quality 50, Sell In 1
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -19
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -34

State after step 39:
  Aged Brie: Quality 50, Sell In 0
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -20
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -35

State after step 40:
  Aged Brie: Quality 50, Sell In -1
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -21
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -36

State after step 41:
  Aged Brie: Quality 50, Sell In -2
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -22
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -37

State after step 42:
  Aged Brie: Quality 50, Sell In -3
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -23
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -38

State after step 43:
  Aged Brie: Quality 50, Sell In -4
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -24
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -39

State after step 44:
  Aged Brie: Quality 50, Sell In -5
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -25
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -40

State after step 45:
  Aged Brie: Quality 50, Sell In -6
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -26
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -41

State after step 46:
  Aged Brie: Quality 50, Sell In -7
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -27
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -42

State after step 47:
  Aged Brie: Quality 50, Sell In -8
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -28
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -43

State after step 48:
  Aged Brie: Quality 50, Sell In -9
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -29
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -44

State after step 49:
  Aged Brie: Quality 50, Sell In -10
  Backstage passes to a TAFKAL80ETC concert: Quality 0, Sell In -30
  Sulfuras, Hand of Ragnaros: Quality 4, Sell In 5
  Some other item: Quality 0, Sell In -45
";
  }
}