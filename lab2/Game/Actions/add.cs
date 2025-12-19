using Game.Items.Types;
using Game.Player;
// using Game.Actions;

namespace Game.Actions
{
    using Game.Player;
    public static class Add
    {
        public static bool Execute(Game.Player.Player player, Item item)
        {
            if (player == null)
            {
                return false;
            }

            if (item == null)
            {
                return false;
            }
            bool success = player.Inventory.AddItem(item);
            return success;
        }
    }
}