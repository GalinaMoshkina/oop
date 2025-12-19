using System;
using Game.Items.Types;

namespace Game.Actions
{
    using Game.Player;
    public static class Use
    {
        // public static void Execute(Player player, Item item)
        public static void Execute(Game.Player.Player player, Item item)
        {
            if (player == null || item == null)
            {
                return;
            }

            if (!item.CanUse())
            {
                return;
            }
            // item.Use(player);
            item.Use((Game.Player.Player)player);
        }
    }
}