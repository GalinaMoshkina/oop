using System;
// using Game.Player;
using Game.Items.Types;
// using Game.Items.Types.Food;
using Game.Items.Types.Weapon;
using Game.Items.Types.Armor;
using Game.Actions;

namespace Game
{

    class Program
    {
        static void Main(string[] args)
        {
            // var player = new Player("ninja");
            var player = new Game.Player.Player("ninja");
            var banana = new Banana();
            var stick = new PickmeStick();
            var jacket = new Jacket();
            Add.Execute(player, banana);
            Add.Execute(player, stick);
            Add.Execute(player, jacket);
            Use.Execute((Game.Player.Player)player, banana);
            Use.Execute((Game.Player.Player)player, stick); 
            Use.Execute((Game.Player.Player)player, jacket);
            DeployInfo.Execute((Game.Player.Player)player); 
        }
    }
}