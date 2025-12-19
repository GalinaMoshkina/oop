using System;
using Game.Items.Types;


namespace Game.Items.Types
{
    using Game.Player;
    public enum ItemRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
    public abstract class Item
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Weight { get; protected set; }
        public ItemRarity Rarity { get; protected set; }

        protected Item(string name, string description, int weight, ItemRarity rarity = ItemRarity.Common)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Weight = weight;
            Rarity = rarity;
        }

        public abstract bool CanUse();
        public abstract void Use(Player player);

        public override string ToString()
        {
            return $"[{Rarity}] {Name}: {Description} (Вес: {Weight})";
        }
    }
}
