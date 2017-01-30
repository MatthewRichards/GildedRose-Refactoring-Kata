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
		
		public void UpdateQuality()
		{
		  foreach (Item item in items)
		  {
		    if (item.Name != AgedBrie && item.Name != BackstagePasses)
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
		      if (item.Quality < 50)
		      {
		        item.Quality = item.Quality + 1;
						
		        if (item.Name == BackstagePasses)
		        {
		          if (item.SellIn < 11)
		          {
		            if (item.Quality < 50)
		            {
		              item.Quality = item.Quality + 1;
		            }
		          }
							
		          if (item.SellIn < 6)
		          {
		            if (item.Quality < 50)
		            {
		              item.Quality = item.Quality + 1;
		            }
		          }
		        }
		      }
		    }
				
		    if (item.Name != SulfurasHandOfRagnaros)
		    {
		      item.SellIn = item.SellIn - 1;
		    }
				
		    if (item.SellIn < 0)
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
		      if (item.SellIn < 0)
		      {
		        item.Quality--;
		      }

		      item.Quality--;
		    }
		  }
		}
		
	}
	
	public class Item
	{
		public string Name { get; set; }
		
		public int SellIn { get; set; }
		
		public int Quality { get; set; }
	}
	
}
