namespace GildedRose
{
  public class ItemBuilder
  {
    private int? SellIn;
    private int? Quality;
    private string Name;

    public ItemBuilder WithSellIn(int value)
    {
      SellIn = value;
      return this;
    }

    public ItemBuilder WithQuality(int value)
    {
      Quality = value;
      return this;
    }

    public ItemBuilder WithName(string value)
    {
      Name = value;
      return this;
    }

    public Item Build()
    {
      return new Item
      {
        Name = Name ?? "Arbitrary Item",
        Quality = Quality ?? 17,
        SellIn = SellIn ?? 42
      };
    }
  }
}