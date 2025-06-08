using DiffEngine;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTests
{
    public GildedRoseTests()
    {
        DiffTools.UseOrder(DiffTool.VisualStudio, DiffTool.AraxisMerge);
    }

    [Fact]
    public Task VerifyTest()
    {
        string[] names = ["foo", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros"];
        int[] qualities = [int.MinValue, 0, 1, 2, 49, 50, 51, int.MaxValue];
        int[] sellIns = [int.MinValue, -1, 0, 1, 5, 6, 7, 10, 11, 12, int.MaxValue];

        return Combination()
            .Verify(Test, names, qualities, sellIns);
    }

    private static string Test(string name, int quality, int sellIn)
    {
        var item = new Item() { Name = name, Quality = quality, SellIn = sellIn };
        var app = new GildedRose([item]);
        app.UpdateQuality();

        return $"{app.Items[0].Name}, {app.Items[0].Quality}, {app.Items[0].SellIn}";
    }
}
