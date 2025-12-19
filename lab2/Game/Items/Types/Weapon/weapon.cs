using System;
using Game.Items.Types;

namespace Game.Items.Types.Weapon
{
    using Game.Player;
    public abstract class Weapon : Item
    {
        public int AbsurdityDamage { get; set; }
        public double AttackSpeed { get; set; }
        public bool IsFunny { get; set; }
        protected Weapon(string name, string description, int weight, int absurdityDamage, double attackSpeed, bool isFunny, ItemRarity rarity = ItemRarity.Common)
            : base(name, description, weight, rarity)
        {
            AbsurdityDamage = absurdityDamage;
            AttackSpeed = attackSpeed;
            IsFunny = isFunny;
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

            if (IsFunny)
            {
                user.Mood += AbsurdityDamage / 2;
            }
            else
            {
                user.Mood -= AbsurdityDamage / 10;
            }
            if (AbsurdityDamage > 50)
            {
                user.Mood -= 5;
            }
            if (user.Mood > 100) user.Mood = 100;
            if (user.Mood < 0) user.Mood = 0;
        }
    }
}