using System;
using Game.Items.Types;

namespace Game.Items.Types.Armor
{
    using Game.Player;
    public abstract class Armor : Item
    {
        public int Protection { get; set; } 
        public int StyleBonus { get; set; } 
        public SlotType Slot { get; set; } 
        protected Armor(string name, string description, int weight, int protection, int styleBonus, SlotType slot, ItemRarity rarity = ItemRarity.Common)
            : base(name, description, weight, rarity)
        {
            Protection = protection;
            StyleBonus = styleBonus;
            Slot = slot;
        }
        public override bool CanUse()
        {
            return true;
        }
        public override void Use(Player user)
        {
            if (user == null || !user.IsAlive)
            {
                return;
            }
            user.Mood += StyleBonus;
            if (user.Mood > 100) user.Mood = 100;
            if (user.Mood < 0) user.Mood = 0;
        }
    }
}