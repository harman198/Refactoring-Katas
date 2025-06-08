namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    private static void UpdateAgedBrieItemQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality = item.Quality + 1;
        }

        item.SellIn = item.SellIn - 1;

        if (item.SellIn < 0)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }

    private static void UpdateBackstagePassesItemQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality = item.Quality + 1;

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

        item.SellIn = item.SellIn - 1;

        if (item.SellIn < 0)
        {
            item.Quality = item.Quality - item.Quality;
        }
    }

    private static void UpdateDefaultItemQuality(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality = item.Quality - 1;
        }

        item.SellIn = item.SellIn - 1;

        if (item.SellIn < 0)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }
    }

    private static void UpdateSulfurasItemQuality(Item item)
    {
    }

    public static void UpdateItemQuality(Item item)
    {
        if (item.Name == "Aged Brie")
        {
            UpdateAgedBrieItemQuality(item);
        }
        else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")

        {
            UpdateBackstagePassesItemQuality(item);
        }
        else if (item.Name == "Sulfuras, Hand of Ragnaros")
        {
            UpdateSulfurasItemQuality(item);
        }
        else
        {
            UpdateDefaultItemQuality(item);
        }
    }
}