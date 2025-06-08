namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    private void UpdateAgedBrieItemQuality()
    {
        if (Quality < 50)
        {
            Quality = Quality + 1;
        }

        SellIn = SellIn - 1;

        if (SellIn < 0)
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }
        }
    }

    private void UpdateBackstagePassesItemQuality()
    {
        if (Quality < 50)
        {
            Quality = Quality + 1;

            if (SellIn < 11)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }

            if (SellIn < 6)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }
        }

        SellIn = SellIn - 1;

        if (SellIn < 0)
        {
            Quality = Quality - Quality;
        }
    }

    private void UpdateDefaultItemQuality()
    {
        if (Quality > 0)
        {
            Quality = Quality - 1;
        }

        SellIn = SellIn - 1;

        if (SellIn < 0)
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
        }
    }

    private void UpdateSulfurasItemQuality()
    {
    }

    public void UpdateItemQuality()
    {
        if (Name == "Aged Brie")
        {
            UpdateAgedBrieItemQuality();
        }
        else if (Name == "Backstage passes to a TAFKAL80ETC concert")

        {
            UpdateBackstagePassesItemQuality();
        }
        else if (Name == "Sulfuras, Hand of Ragnaros")
        {
            UpdateSulfurasItemQuality();
        }
        else
        {
            UpdateDefaultItemQuality();
        }
    }
}