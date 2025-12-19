using System;
using Game.Items.Types;

namespace Game.Items.Types
{
    using Game.Player;
    public enum FoodState
    {
        Fresh,
        Expired
    }
    public class Food : Item
    {
        public int HealthRestore { get; private set; }
        public int ManaRestore { get; set; }
        public int MoodBoost { get; private set; }
        public int TasteQuality { get; private set; }
        public bool IsShareable { get; private set; }
        public int EatTime { get; private set; }
        public FoodState State { get; set; } = FoodState.Fresh;

        public Food(
            string name,
            string description,
            int healthRestore,
            int moodBoost,
            int tasteQuality,
            bool isShareable = false,
            int eatTime = 5,
            ItemRarity rarity = ItemRarity.Common,
            FoodState state = FoodState.Fresh) 
            : base(name, description, 1, rarity)
        {
            HealthRestore = healthRestore;
            MoodBoost = moodBoost;
            TasteQuality = tasteQuality;
            IsShareable = isShareable;
            EatTime = eatTime;
            ManaRestore = 0;
            State = state;
        }

        public override bool CanUse() => true;

        public override void Use(Player player)
        {
            if (player == null || !player.IsAlive)
            {
                return;
            }
            if (State == FoodState.Expired)
            {
                Actions.KillYourself.Execute(player, $"просроченной еды: {Name}");
                return;
            }
            player.Health += HealthRestore;
            if (player.Health > player.MaxHealth) player.Health = player.MaxHealth;
            player.Mood += MoodBoost;
            if (player.Mood > 100) player.Mood = 100;
            if (ManaRestore > 0)
            {
                player.Mana += ManaRestore;
                if (player.Mana > player.MaxMana) player.Mana = player.MaxMana;
            }
        }
        public string RateFood()
        {
            return $"{TasteQuality}";
        }
    }
}