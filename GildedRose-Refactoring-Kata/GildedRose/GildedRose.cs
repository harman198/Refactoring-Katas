using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> Items)
{
    public IList<Item> Items { get; private init; } = Items;

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            item.UpdateItemQuality();
        }
    }
}