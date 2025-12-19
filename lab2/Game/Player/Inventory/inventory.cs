using System;
using System.Collections.Generic;
using System.Linq;
using Game.Items.Types;

namespace Game.Player
{
    public class Inventory
    {
        private List<Item> _items;

        public int Capacity { get; private set; }
        public int CurrentWeight { get; private set; }
        public int ItemCount => _items.Count;
        public event Action<Item>? OnItemAdded;
        public event Action<Item>? OnItemRemoved;

        public Inventory(int capacity = 20)
        {
            _items = new List<Item>();
            Capacity = capacity;
            CurrentWeight = 0;
        }
        public bool AddItem(Item item)
        {
            if (item == null)
            {
                return false;
            }

            if (_items.Count >= Capacity)
            {
                return false;
            }

            if (CurrentWeight + item.Weight > Capacity * 5)
            {
                return false;
            }

            _items.Add(item);
            CurrentWeight += item.Weight;
            OnItemAdded?.Invoke(item);
            return true;
        }
        public bool RemoveItem(Item item)
        {
            if (item == null || !_items.Contains(item))
            {
                return false;
            }

            _items.Remove(item);
            CurrentWeight -= item.Weight;
            OnItemRemoved?.Invoke(item);
            return true;
        }
        public Item? FindItem(string itemId)
        {
            return _items.FirstOrDefault(item => item.Id == itemId);
        }
        public List<Item> FindItemsByName(string name)
        {
            return _items.Where(item => item.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<T> GetItemsByType<T>() where T : Item
        {
            return _items.OfType<T>().ToList();
        }
        public bool CanAddItem(Item item)
        {
            return _items.Count < Capacity &&
                   CurrentWeight + item.Weight <= Capacity * 5;
        }
        public void Clear()
        {
            _items.Clear();
            CurrentWeight = 0;
        }
        public void DisplayInventory()
        {
            Console.WriteLine("Инвентарь:");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item.Name} (Вес: {item.Weight})");
            }
            Console.WriteLine($"Всего предметов: {_items.Count}, Вес: {CurrentWeight}/{Capacity * 5}");
        }
    }
}