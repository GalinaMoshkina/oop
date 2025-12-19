using System;
using Game.Player;
// using Game.Actions;

namespace Game.Actions
{
    using Game.Player;
    public static class MoveToAmsterdam
    {
        private const int RequiredMood = 80;
        private const double DeathChance = 1.0 / 1000000;
        public static void Execute(Game.Player.Player player)
        {
            if (player == null)
            {
                return;
            }
            if (!player.IsAlive)
            {
                return;
            }
            if (player.Mood < RequiredMood)
            {
                return;
            }
            var ticket = player.Inventory.FindItemsByName("Билет в Амстердам").FirstOrDefault();
            if (ticket == null)
            {
                return;
            }
            if (new Random().NextDouble() < DeathChance)
            {
                player.Health = 0;
                return;
            }
        }
    }
}