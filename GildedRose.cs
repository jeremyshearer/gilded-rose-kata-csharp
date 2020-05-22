using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateQuality(Items[i]);
            }
        }

        private static void UpdateQuality(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return;
            }

            item.SellIn -= 1;
            var qualityUpdater = BuildQualityUpdater(item);
            qualityUpdater.UpdateQuality();
        }
        private static QualityUpdater BuildQualityUpdater(Item item)
        {
            switch (item.Name)
            {
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassQualityUpdater(item);
                case "Aged Brie":
                    return new AgedBrieQualityUpdater(item);
                case "Conjured":
                    return new ConjuredQualityUpdater(item);
                default: 
                    return new QualityUpdater(item);
            } 
        }
    }
}
