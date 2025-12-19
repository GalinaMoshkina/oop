using Game.Player;
namespace Game.Actions
{
    using Game.Player;
    public static class DeployInfo
    {
        public static void Execute(Game.Player.Player player)
        {
            if (player == null)
            {
                return;
            }
            player.Inventory.DisplayInventory();
        }
    }
}