using Game.Player;
// using Game.Actions;
namespace Game.Actions
{
    using Game.Player;
    public static class KillYourself
    {
        public static void Execute(Game.Player.Player player, string cause = "неизвестная причина")
        {
            if (player == null)
            {
                return;
            }

            if (player.Health <= 0)
            {
                return;
            }
            player.Health = 0;
        }
    }
}