using System;
using System.Collections.Generic;
using System.Linq;
using Game.Items.Types;
using Game.Player;
// using Game.Actions;

namespace Game.Actions
{
    using Game.Player;
    public static class Craft
    {
        private static readonly Dictionary<string, int> AmsterdamTicketRecipe = new()
        {
            { "Лист бумаги", 1 },
            { "Паспорт", 1 }
        };
        public static void Execute(Game.Player.Player player, string targetItemName)
        {
            if (player == null || string.IsNullOrWhiteSpace(targetItemName))
            {
                return;
            }
            if (targetItemName.Equals("Билет в Амстердам", StringComparison.OrdinalIgnoreCase))
            {
                bool hasRequiredItems = true;
                foreach (var requirement in AmsterdamTicketRecipe)
                {
                    var itemsInInventory = player.Inventory.FindItemsByName(requirement.Key);
                    if (itemsInInventory.Count < requirement.Value)
                    {
                        hasRequiredItems = false;
                        break;
                    }
                }
                if (!hasRequiredItems)
                {
                    return;
                }
                foreach (var requirement in AmsterdamTicketRecipe)
                {
                    for (int i = 0; i < requirement.Value; i++)
                    {
                        var itemToRemove = player.Inventory.FindItemsByName(requirement.Key).FirstOrDefault();
                        if (itemToRemove != null)
                        {
                            player.Inventory.RemoveItem(itemToRemove);
                        }
                    }
                }
                var ticket = new AmsterdamTicket();
                Add.Execute(player, ticket);
            }
        }
    }
    public class AmsterdamTicket : Item
    {
        public AmsterdamTicket() : base(
            name: "Билет в Амстердам",
            description: "Путь к счастью",
            weight: 0,
            rarity: ItemRarity.Legendary)
        {
        }
        public override bool CanUse() => true;
        public override void Use(Player player)
        {
            Environment.Exit(0);
        }
    }
}