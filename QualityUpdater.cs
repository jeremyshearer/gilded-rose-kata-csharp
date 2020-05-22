namespace csharp
{
    public class QualityUpdater
    {
        internal readonly Item item;

        public QualityUpdater(Item item)
        {
            this.item = item;
        }

        public virtual void UpdateQuality()
        {
            DecreaseQuality(item);
            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }

        internal static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }

    class ConjuredQualityUpdater : QualityUpdater
    {
        public ConjuredQualityUpdater(Item item) : base(item)
        {}

        public override void UpdateQuality()
        {
            base.UpdateQuality();
            base.UpdateQuality();
        }
    }

    class AgedBrieQualityUpdater : QualityUpdater
    {
        public AgedBrieQualityUpdater(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            IncreaseQuality(item);
            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }
    }

    class BackstagePassQualityUpdater : QualityUpdater
    {
        public BackstagePassQualityUpdater(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            IncreaseQuality(item);
            if (item.SellIn < 11)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 6)
            {
                IncreaseQuality(item);
            }   
        }
    }
}