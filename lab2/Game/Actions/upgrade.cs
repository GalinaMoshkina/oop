using System;
using System.Collections.Generic;
using Game.Items.Types;
using Game.Items.Types.Weapon;
using Game.Items.Types.Armor;
// using Game.Player;
// using Game.Actions;

namespace Game.Actions
{
    using Game.Player;
    public interface IUpgradeStrategy
    {
        void Apply(Item item, Player player);
    }

    public class WeaponPowerUpgrade : IUpgradeStrategy
    {
        public void Apply(Item item, Player player)
        {
            if (item is Weapon weapon)
            {
                int oldDamage = weapon.AbsurdityDamage;
                weapon.AbsurdityDamage += 10;
            }
        }
    }

    public class ArmorProtectionUpgrade : IUpgradeStrategy
    {
        public void Apply(Item item, Player player)
        {
            if (item is Armor armor)
            {
                int oldProtection = armor.Protection;
                armor.Protection += 5;
            }
        }
    }

    public class ArmorStyleUpgrade : IUpgradeStrategy
    {
        public void Apply(Item item, Player player)
        {
            if (item is Armor armor)
            {
                int oldStyle = armor.StyleBonus;
                armor.StyleBonus += 5;
            }
        }
    }
    public static class Upgrade
    {
        private static readonly Dictionary<string, IUpgradeStrategy> UpgradeRecipes = new()
        {
            { "Сила оружия", new WeaponPowerUpgrade() },
            { "Защита брони", new ArmorProtectionUpgrade() },
            { "Стиль брони", new ArmorStyleUpgrade() }
        };

        public static void Execute(Game.Player.Player player, Item item, string upgradeType)
        {
            if (player == null || item == null || string.IsNullOrWhiteSpace(upgradeType))
            {
                return;
            }
            if (UpgradeRecipes.TryGetValue(upgradeType, out var strategy))
            {
                strategy.Apply(item, player);
            }
        }
    }
}