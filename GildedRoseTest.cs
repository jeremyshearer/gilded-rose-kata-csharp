using System.Collections.Generic;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;

namespace csharp
{
    public class GildedRoseTest
    {
        [Fact]
        public void RegularItemDecreasesInQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 1 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void RegularItemQualityDoesNotDecreaseBelowZero()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void RegularItemQualityDecreasesByTwoWhenPastSellBy()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 2 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("foo", items[0].Name);
            Assert.Equal(0, items[0].Quality);
        }
        
        [Fact]
        public void AgedBrieQualityIncreasesInQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", items[0].Name);
            Assert.Equal(1, items[0].Quality);
        }
        
        [Fact]
        public void AgedBrieQualityDoesNotIncreasesPast50()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", items[0].Name);
            Assert.Equal(50, items[0].Quality);
        }
        
        [Fact]
        public void AgedBrieQualityIncreasesInQualityBy2WithNegativeSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", items[0].Name);
            Assert.Equal(2, items[0].Quality);
        }

        [Fact]
        public void SulfurasDoesNotChangeInQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("Sulfuras, Hand of Ragnaros", items[0].Name);
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void BackStagePassesIncreaseInQuality()
        {
            {
                IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 0 } };
                GildedRose app = new GildedRose(items);
                app.UpdateQuality();
                Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
                Assert.Equal(1, items[0].Quality);
            }
        }
        
        [Fact]
        public void BackStagePassesDoNotIncreasePast50()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 50 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void BackStagePassesIncreaseInQualityBy2WhenSellInLessThan11()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.Equal(2, items[0].Quality);
        }
        
        [Fact]
        public void BackStagePassesIncreaseInQualityBy3WhenSellInLessThan6()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.Equal(3, items[0].Quality);
        }
        
        [Fact]
        public void BackStagePassesDecreaseTo0WithNegativeSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 50 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact, Ignore("Not yet implemented")]
        public void ConjuredDecreasesBy2()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Conjured", SellIn = 1, Quality = 2 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("Conjured", items[0].Name);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact, Ignore("Not yet implemented")]
        public void ConjuredDecreasesBy4WhenSellByIsNegative()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 4 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal("Conjured", items[0].Name);
            Assert.Equal(0, items[0].Quality);
        }
    }
}
