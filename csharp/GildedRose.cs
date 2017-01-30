using System;
using System.Collections.Generic;

namespace GildedRose
{
	class GildedRose
	{
	  public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
	  public const string AgedBrie = "Aged Brie";
	  public const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
	  public const string ConjouredRabbit = "Conjoured rabbit";

	  private readonly IList<Item> items;

    public GildedRose(IList<Item> items) 
		{
			this.items = items;
		}

	  private readonly Dictionary<string, Func<int, int, int>> qualityRules = new Dictionary<string, Func<int, int, int>>
	  {
	    {AgedBrie, (sellIn, quality) => quality + 1},
	    {
	      BackstagePasses, (sellIn, quality) =>
	      {
	        if (sellIn < 6) return quality + 3;
	        if (sellIn < 11) return quality + 2;
	        return quality + 1;
	      }
	    },
      {SulfurasHandOfRagnaros, (sellIn, quality) => quality }
	  };

	  private readonly Func<int, int, int> defaultQualityRule = (sellIn, quality) => quality - 1;


    public void UpdateQuality()
		{
		  foreach (Item item in items)
		  {
		    var qualityRule = qualityRules.ContainsKey(item.Name) ? qualityRules[item.Name] : defaultQualityRule;
		    item.Quality = EnforceQualityRange(qualityRule(item.SellIn, item.Quality));
        
        
		    if (item.SellIn <= 0)
		    {
		      if (item.Name != AgedBrie)
		      {
		        if (item.Name != BackstagePasses)
		        {
		          if (item.Quality > 0)
		          {
		            if (item.Name != SulfurasHandOfRagnaros)
		            {
		              item.Quality = item.Quality - 1;
		            }
		          }
		        }
		        else
		        {
		          item.Quality = item.Quality - item.Quality;
		        }
		      }
		      else
		      {
		        if (item.Quality < 50)
		        {
		          item.Quality = item.Quality + 1;
		        }
		      }
		    }

        if (item.Name == ConjouredRabbit)
		    {
		      if (item.SellIn <= 0)
		      {
		        item.Quality--;
		      }

		      item.Quality--;
		    }

        if (item.Name != SulfurasHandOfRagnaros)
        {
          item.SellIn = item.SellIn - 1;
        }
      }
    }

	  private int EnforceQualityRange(int quality)
	  {
	    return Math.Min(50, Math.Max(0, quality));
	  }
	}
	
	public class Item
	{
		public string Name { get; set; }
		
		public int SellIn { get; set; }
		
		public int Quality { get; set; }
	}
	
}
