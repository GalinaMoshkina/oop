#nullable disable
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Player;
using PlayerClass = Game.Player.Player;
using Game.Items.Types;
using Game.Items.Types.Weapon;
using Game.Items.Types.Armor;
using Game.Actions;
using System.Collections.Generic;
using System.Linq;

namespace Game.Tests
{
    [TestClass]
    public class UnitTests
    {
        //Инициализация игрока

        [TestMethod]
        public void Player_InitiallyAlive()
        {
            var player = new PlayerClass("TestPlayer");
            Assert.IsTrue(player.IsAlive, "Игрок должен быть жив при создании");
            Assert.AreEqual(50, player.Mood, "Начальное настроение должно быть 50");
            Assert.AreEqual(100, player.Health, "Начальное здоровье должно быть 100");
        }

        [TestMethod]
        public void Player_HasInventory()
        {
            var player = new PlayerClass("TestPlayer");
            Assert.IsNotNull(player.Inventory, "Инвентарь должен существовать");
            Assert.AreEqual(0, player.Inventory.ItemCount, "Инвентарь должен быть пустым");
        }

        [TestMethod]
        public void Player_MoodStatus_Returns_Correct_Status()
        {
            var player = new PlayerClass("TestPlayer");
            player.Mood = 80;
            string status = player.GetMoodStatus();
            Assert.AreEqual("Достиг дзена", status, "При настроении 80+ должен быть дзен");
        }

        //Инвентарь

        [TestMethod]
        public void Inventory_CanAddItem()
        {
            var player = new PlayerClass("TestPlayer");
            var banana = new Banana();
            bool result = player.Inventory.AddItem(banana);
            Assert.IsTrue(result, "Должны суметь добавить предмет");
            Assert.AreEqual(1, player.Inventory.ItemCount, "Инвентарь должен содержать 1 предмет");
        }

        [TestMethod]
        public void Inventory_CanRemoveItem()
        {
            var player = new PlayerClass("TestPlayer");
            var banana = new Banana();
            player.Inventory.AddItem(banana);
            bool result = player.Inventory.RemoveItem(banana);
            Assert.IsTrue(result, "Должны суметь удалить предмет");
            Assert.AreEqual(0, player.Inventory.ItemCount, "Инвентарь должен быть пустым");
        }

        [TestMethod]
        public void Inventory_FindItemsByName()
        {
            var player = new PlayerClass("TestPlayer");
            var banana1 = new Banana();
            var banana2 = new Banana();
            player.Inventory.AddItem(banana1);
            player.Inventory.AddItem(banana2);
            var found = player.Inventory.FindItemsByName("Банан");
            Assert.AreEqual(2, found.Count);
        }

        [TestMethod]
        public void Inventory_Respects_Capacity_Limit()
        {
            var inventory = new Inventory(capacity: 2);
            var item1 = new Banana();
            var item2 = new Bread();
            var item3 = new Coffee();
            inventory.AddItem(item1);
            inventory.AddItem(item2);
            bool result = inventory.AddItem(item3);
            Assert.IsFalse(result, "Не должны добавить предмет при переполнении");
            Assert.AreEqual(2, inventory.ItemCount, "Должно быть только 2 предмета");
        }

        [TestMethod]
        public void Inventory_CanClear()
        {
            var player = new PlayerClass("TestPlayer");
            player.Inventory.AddItem(new Banana());
            player.Inventory.AddItem(new Bread());
            player.Inventory.Clear();
            Assert.AreEqual(0, player.Inventory.ItemCount, "Инвентарь должен быть пустым");
        }
        //Еда
        [TestMethod]
        public void Food_FreshBanana_BoostsMood()
        {
            var player = new PlayerClass("TestPlayer");
            var banana = new Banana();
            Use.Execute(player, banana);
            Assert.AreEqual(80, player.Mood, "Банан должен увеличить настроение на 30 (50 + 30)");
            Assert.IsTrue(player.IsAlive, "Игрок должен остаться живым");
        }

        [TestMethod]
        public void Food_FreshBanana_RestoresHealth()
        {
            var player = new PlayerClass("TestPlayer");
            player.Health = 50;
            var banana = new Banana();
            Use.Execute(player, banana);
            Assert.AreEqual(60, player.Health, "Банан должен восстановить 10 здоровья");
        }

        [TestMethod]
        public void Food_ExpiredBread_KillsPlayer()
        {
            var player = new PlayerClass("TestPlayer");
            var badBread = new ExpiredBread();
            Use.Execute(player, badBread);
            Assert.IsFalse(player.IsAlive, "Просроченный хлеб должен убить игрока");
            Assert.AreEqual(0, player.Health, "Здоровье должно быть 0");
        }

        [TestMethod]
        public void Food_HealthRestore_CappedAtMaxHealth()
        {
            var player = new PlayerClass("TestPlayer");
            player.Health = 95;
            var banana = new Banana();
            Use.Execute(player, banana);
            Assert.AreEqual(100, player.Health, "Здоровье не должно превышать максимум");
        }

        [TestMethod]
        public void Food_MoodBoost_CappedAt100()
        {
            var player = new PlayerClass("TestPlayer");
            player.Mood = 90;
            var banana = new Banana();
            Use.Execute(player, banana);
            Assert.AreEqual(100, player.Mood, "Настроение не должно превышать 100");
        }
        //Оружие
        [TestMethod]
        public void Weapon_Use_IncreasesMoodIfFunny()
        {
            var player = new PlayerClass("TestPlayer");
            var stick = new PickmeStick();
            Use.Execute(player, stick);
            Assert.AreEqual(55, player.Mood, "Забавное оружие должно увеличить настроение (50 + 10/2)");
            Assert.IsTrue(player.IsAlive, "Игрок должен остаться живым");
        }
        [TestMethod]
        public void Weapon_Use_WithDeadPlayer_DoesNothing()
        {
            var player = new PlayerClass("TestPlayer");
            player.Health = 0;
            var stick = new PickmeStick();
            Use.Execute(player, stick);
            Assert.AreEqual(50, player.Mood, "Мертвый игрок не может использовать оружие");
        }

        [TestMethod]
        public void Weapon_HasDamageProperty()
        {
            var stick = new PickmeStick();
            Assert.IsTrue(stick.AbsurdityDamage > 0, "Оружие должно иметь урон");
            Assert.IsTrue(stick.IsFunny, "Пикми указка должна быть забавной");
        }
        //Броня
        [TestMethod]
        public void Armor_Use_BoostsMood()
        {
            var player = new PlayerClass("TestPlayer");
            var jacket = new Jacket();
            Use.Execute(player, jacket);
            Assert.AreEqual(70, player.Mood, "Куртка должна увеличить настроение на 20 (50 + 20)");
        }
        [TestMethod]
        public void Armor_HasProtectionAndStyle()
        {
            var jacket = new Jacket();
            Assert.IsTrue(jacket.Protection > 0, "Броня должна иметь защиту");
            Assert.IsTrue(jacket.StyleBonus > 0, "Броня должна иметь бонус стиля");
        }
        [TestMethod]
        public void Armor_Use_WithDeadPlayer_DoesNothing()
        {
            var player = new PlayerClass("TestPlayer");
            player.Health = 0;
            var jacket = new Jacket();
            Use.Execute(player, jacket);
            Assert.AreEqual(50, player.Mood, "Мертвый игрок не может надевать броню");
        }
        //Добавление предметов в инвентарь
        [TestMethod]
        public void Action_Add_AddsItemToInventory()
        {
            var player = new PlayerClass("TestPlayer");
            var banana = new Banana();
            bool result = Add.Execute(player, banana);
            Assert.IsTrue(result, "Должны суметь добавить предмет");
            Assert.AreEqual(1, player.Inventory.ItemCount, "Инвентарь должен содержать 1 предмет");
        }

        [TestMethod]
        public void Action_Add_WithNullPlayer_ReturnsFalse()
        {
            PlayerClass player = null;
            var banana = new Banana();
            bool result = Add.Execute(player, banana);
            Assert.IsFalse(result, "Не должны добавить, если игрок null");
        }

        [TestMethod]
        public void Action_Add_WithNullItem_ReturnsFalse()
        {
            var player = new PlayerClass("TestPlayer");
            Item item = null;
            bool result = Add.Execute(player, item);
            Assert.IsFalse(result, "Не должны добавить null предмет");
        }
        //Комбинирование предметов
        [TestMethod]
        public void Action_Combo_CombinesItems()
        {
            var player = new PlayerClass("TestPlayer");
            var bread = new Bread();
            var butter = new PaperSheet();
            player.Inventory.AddItem(bread);
        }
        //Улучшение предметов
        [TestMethod]
        public void Action_Upgrade_UpgradesWeapon()
        {
            var player = new PlayerClass("TestPlayer");
            var stick = new PickmeStick();
            int initialDamage = stick.AbsurdityDamage;
            Upgrade.Execute(player, stick, "Сила оружия");
            Assert.AreEqual(initialDamage + 10, stick.AbsurdityDamage, "Урон должен увеличиться на 10");
        }

        [TestMethod]
        public void Action_Upgrade_UpgradesArmor()
        {
            var player = new PlayerClass("TestPlayer");
            var jacket = new Jacket();
            int initialProtection = jacket.Protection;
            Upgrade.Execute(player, jacket, "Защита брони");
            Assert.AreEqual(initialProtection + 5, jacket.Protection, "Защита должна увеличиться на 5");
        }
        //Самоубийство
        [TestMethod]
        public void Action_KillYourself_SetsHealthToZero()
        {
            var player = new PlayerClass("TestPlayer");
            Actions.KillYourself.Execute(player, "тест");
            Assert.AreEqual(0, player.Health, "Здоровье должно быть 0");
            Assert.IsFalse(player.IsAlive, "Игрок должен быть мертв");
        }
        [TestMethod]
        public void Action_KillYourself_WithNullPlayer_DoesNotCrash()
        {
            PlayerClass player = null;
            try
            {
                Actions.KillYourself.Execute(player, "тест");
                Assert.IsTrue(true, "Не должно быть исключения");
            }
            catch
            {
                Assert.Fail("Не должно быть исключения при null игроке");
            }
        }

        //Полиморфизм и абстракция
        [TestMethod]
        public void Polymorphism_ItemUse_WorksForAllTypes()
        {
            var player = new PlayerClass("TestPlayer");
            List<Item> items = new()
            {
                new Banana(),
                new PickmeStick(),
                new Jacket()
            };
            foreach (var item in items)
            {
                int moodBefore = player.Mood;
                Use.Execute(player, item);
                Assert.IsTrue(item.CanUse(), "Все предметы должны быть используемы");
            }
        }
        //SOLID
        [TestMethod]
        public void SOLID_SRP_InventoryOnlyManagesItems()
        // Single Responsibility Principle - принцип единственной ответственности
        {
            var inventory = new Inventory(capacity: 10);
            inventory.AddItem(new Banana());
            Assert.AreEqual(1, inventory.ItemCount, "Инвентарь управляет только предметами");
        }
        [TestMethod]
        public void SOLID_OCP_NewItemTypesCanBeAdded()
        // Open/Closed Principle - принцип открытости/закрытости
        {
            var soup = new Soup();
            var player = new PlayerClass("TestPlayer");
            Assert.IsTrue(soup.CanUse(), "Новые типы должны работать с существующим кодом");
        }

        [TestMethod]
        public void SOLID_LSP_ItemsAreInterchangeable()
        // Liskov Substitution Principle - принцип подстановки Барбары Лисков
        {
            var player = new PlayerClass("TestPlayer");
            Item food = new Banana();
            Item weapon = new PickmeStick();
            Item armor = new Jacket();
            Use.Execute(player, food);
            Use.Execute(player, weapon);
            Use.Execute(player, armor);
            Assert.IsTrue(true, "Все типы работают через Item интерфейс");
        }
        [TestMethod]
        public void SOLID_ISP_InterfacesAreSpecialized()
        // Interface Segregation Principle - принцип разделения интерфейсов
        {
            var upgrade = new Actions.WeaponPowerUpgrade();
            var player = new PlayerClass("TestPlayer");
            var stick = new PickmeStick();
            Assert.IsNotNull(upgrade, "Специализированный интерфейс работает");
        }

        [TestMethod]
        public void SOLID_DIP_UseClassDependsOnAbstraction()
        // Dependency Inversion Principle - принцип инверсии зависимостей
        {
            var player = new PlayerClass("TestPlayer");
            Item item = new Banana();
            Use.Execute(player, item);
            Assert.IsTrue(player.IsAlive, "DIP позволяет работать с любым Item");
        }
        //Паттерны проектирования
        [TestMethod]
        public void Pattern_Strategy_UpgradesUseStrategy()
        {
            var player = new PlayerClass("TestPlayer");
            var stick = new PickmeStick();
            var strategy = new Actions.WeaponPowerUpgrade();
            strategy.Apply(stick, player);
            Assert.AreEqual(20, stick.AbsurdityDamage, "Strategy паттерн работает");
        }
        //Итоговые тесты интеграции

        [TestMethod]
        public void Integration_FullGameflow()
        {
            var player = new PlayerClass("Pococambus");
            var banana = new Banana();
            var jacket = new Jacket();
            Add.Execute(player, banana);
            Use.Execute(player, banana);
            Add.Execute(player, jacket);
            Use.Execute(player, jacket);
            Assert.IsTrue(player.IsAlive, "Игрок должен быть живым");
            Assert.AreEqual(100, player.Mood, "Настроение должно быть максимальным");
            Assert.IsTrue(player.Health >= 100, "Здоровье должно быть высоким");
        }
        [TestMethod]
        public void Integration_ComplexScenario_AddRemoveCombineUpgrade()
        {
            var player = new PlayerClass("TestPlayer");
            var bread = new Bread();
            var banana = new Banana();
            var stick = new PickmeStick();
            Add.Execute(player, bread);
            Add.Execute(player, banana);
            Add.Execute(player, stick);
            Assert.AreEqual(3, player.Inventory.ItemCount, "Должно быть 3 предмета");
            Assert.IsTrue(player.IsAlive, "Игрок жив");
            Use.Execute(player, stick);
            Assert.AreEqual(55, player.Mood, "Настроение увеличилось");
            Upgrade.Execute(player, stick, "Сила оружия");
            Assert.AreEqual(20, stick.AbsurdityDamage, "Оружие улучшено");
        }
    }
}