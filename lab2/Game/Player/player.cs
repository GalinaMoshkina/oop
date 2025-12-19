namespace Game.Player
{
    public enum SlotType
    {
        Head, Body, Legs, Feet, Hands, Accessory
    }

    public class Player
    {
        public string Nickname { get; private set; }
        public int Health { get; set; }
        public int MaxHealth { get; private set; }
        public int Mana { get; set; }
        public int MaxMana { get; private set; }
        public int Mood { get; set; }
        public int Level { get; private set; }
        public Inventory Inventory { get; private set; }

        public Player(string nickname)
        {
            Nickname = nickname;
            MaxHealth = 100;
            Health = MaxHealth;
            MaxMana = 50;
            Mana = MaxMana;
            Mood = 50;
            Level = 1;
            Inventory = new Inventory(capacity: 10);
        }

        public bool IsAlive => Health > 0;

        public string GetMoodStatus()
        {
            return Mood switch
            {
                >= 80 => "Достиг дзена",
                >= 60 => "+вайб",
                >= 40 => "Все норм",
                >= 20 => "Не рискуйте задавать вопрос 'Как дела?'",
                _ => "Тильт"
            };
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - damage);
            Mood -= 5;
        }

        public void LevelUp()
        {
            Level++;
            MaxHealth += 10;
            Health = MaxHealth;
            Mood += 10;
        }
    }
}