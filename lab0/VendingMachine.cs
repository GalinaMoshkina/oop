public class Settings
{
    public string product { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
}
public class ProductList
{
    public List<Settings> Products { get; set; }
    public ProductList()
    {
        Products = new List<Settings>();
        Products.Add(new Settings { product = "Энергетик Monster", price = 100, quantity = 2 });
        Products.Add(new Settings { product = "Киткат", price = 50, quantity = 5 });
        Products.Add(new Settings { product = "Вода без газа 0.5", price = 60, quantity = 10 });
    }
    public void ShowProducts()
    {
        Console.WriteLine("\nДоступные товары:");

        if (Products.Count == 0)
        {
            Console.WriteLine("Пусто");
            return;
        }
        for (int i = 0; i < Products.Count; i++)
        {
            Settings product = Products[i];
            Console.WriteLine($"{i + 1}. {product.product}. Цена: {product.price} руб. Осталось: {product.quantity} шт.");
        }
    }
}
class Program
{
    static ProductList productList = new ProductList();
    static int UserBalance = 0;
    static int MachineBalance = 1000;
    static List<int> depositedCoins = new List<int>();
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите функцию и данного списка:");
            Console.WriteLine("1. Посмотреть список доступных товаров с их ценами и количеством");
            Console.WriteLine("2. Вставить монеты");
            Console.WriteLine("3. Выбрать товар и купить его");
            Console.WriteLine("4. Получить сдачу");
            Console.WriteLine("5. Административный режим");
            Console.WriteLine("6. Отмена");
            string operation = Console.ReadLine();
            switch (operation)
            {
                case "1":
                    ShowProducts();
                    break;
                case "2":
                    InsertCoins();
                    break;
                case "3":
                    SelectProduct();
                    break;
                case "4":
                    GetCharge();
                    break;
                case "5":
                    Admin();
                    break;
                case "6":
                    Cancel();
                    break;
                default:
                    Console.WriteLine("Такой операции не существует");
                    break;
            }
            Console.WriteLine("\nНажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
    static void ShowProducts()
    {
        productList.ShowProducts();
    }

    static void InsertCoins()
    {
        Console.WriteLine("Внесите деньги. Доступно для внесения: 1, 2, 5, 10");
        Console.WriteLine("Введите 0 для завершения внесения денег");
        while (true)
        {
        Console.Write("Вставьте монету: ");
        string input = Console.ReadLine();
        
        if (input == "0")
        {
            Console.WriteLine($"Ваш текущий баланс: {UserBalance} руб.");
            break;
        }
        
        int[] allowedCoins = {1, 2, 5, 10};
        if (int.TryParse(input, out int coin) && allowedCoins.Contains(coin))
        {
            UserBalance += coin;
            depositedCoins.Add(coin);
            Console.WriteLine($"Внесено: {coin} руб. Общий баланс: {UserBalance} руб.");
        }
        else
        {
            Console.WriteLine("Автомат не принимает такие монеты");
        }
        }
    }

    static void SelectProduct()
    {
        if (UserBalance == 0)
        {
            Console.WriteLine("Сначала внесите деньги");
            return;
        }
    
        productList.ShowProducts();
        Console.Write("Введите номер товара для покупки: ");
    
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= productList.Products.Count)
        {
            Settings selectedProduct = productList.Products[choice - 1];
        
            if (selectedProduct.quantity <= 0)
            {
                Console.WriteLine("Этот товар закончился");
                return;
            }
        
            if (UserBalance >= selectedProduct.price)
            {
                selectedProduct.quantity--;
                MachineBalance += UserBalance;
                UserBalance -= selectedProduct.price;
                Console.WriteLine($"\nПоздравляем! Вы купили: {selectedProduct.product}");
                Console.WriteLine($"Списано: {selectedProduct.price} руб.");
                Console.WriteLine($"Остаток на балансе: {UserBalance} руб.");
                if (UserBalance > 0)
                {
                    Console.Write("Хотите получить сдачу? (да/нет): ");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "да" || answer == "yes")
                    {
                        GetCharge();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Недостаточно средств! Нужно: {selectedProduct.price} руб., у вас: {UserBalance} руб.");
            }
        }
        else
        {
            Console.WriteLine("Неверный номер товара!");
        }
    }

    static void GetCharge()
    {
        if (UserBalance > 0)
        {
            if (MachineBalance >= UserBalance)
            {
                Console.WriteLine($"\nВыдана сдача: {UserBalance} руб.");
                MachineBalance -= UserBalance;
                UserBalance = 0;
                depositedCoins.Clear();
            }
            else
            {
                Console.WriteLine($"Извините, в автомате недостаточно денег для выдачи сдачи {UserBalance} руб.");
            }
        }
        else
        {
            Console.WriteLine("У вас нет средств для получения сдачи.");
        }
    }

    static void Admin()
    {
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();
        if (password != "A1BC3")
            {
            Console.WriteLine("Неверный пароль!");
            return;
            }
        while (true)
        {
            Console.WriteLine("1. Посмотреть список доступных товаров");
            Console.WriteLine("2. Добавить новый товар");
            Console.WriteLine("3. Изъять деньги из автомата");
            Console.WriteLine("4. Показать баланс автомата");
            Console.WriteLine("5. Пополнение товара");
            Console.WriteLine("6. Выйти из административного режима");
            Console.Write("Выберите действие: ");

            string AdminChoice = Console.ReadLine();

            switch (AdminChoice)
            {
                case "1":
                    productList.ShowProducts();
                    break;
                case "2":
                    AddNewProduct();
                    break;
                case "3":
                    WithdrawMoney();
                    break;
                case "4":
                    Console.WriteLine($"\nБаланс автомата: {MachineBalance} руб.");
                    break;
                case "5":
                    Refill();
                    break;
                case "6":
                    return;
                    break;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    static void AddNewProduct()
    {
        Console.Write("Введите название товара: ");
        string name = Console.ReadLine();
        Console.Write("Введите цену: ");
        int price = int.Parse(Console.ReadLine());
        Console.Write("Введите количество: ");
        int quantity = int.Parse(Console.ReadLine());

        productList.Products.Add(new Settings { product = name, price = price, quantity = quantity });
        Console.WriteLine("Товар успешно добавлен!");
    }
    static void WithdrawMoney()
    {
        MachineBalance = 100;
        Console.WriteLine("Баланс: 100");
    }
    static void Refill()
    {
        productList.ShowProducts();
        Console.Write("Введите номер товара для пополнения: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= productList.Products.Count)
        {
            Console.Write("Введите количество для добавления: ");
            if (int.TryParse(Console.ReadLine(), out int amount))
            {
                productList.Products[choice - 1].quantity += amount;
                Console.WriteLine("Количество товара успешно пополнено!");
            }
        }
        else
        {
            Console.WriteLine("Неверный номер товара!");
        }
    }
    }
    static void Cancel()
    {
        Console.WriteLine("Пришлите на номер телефона 89851876187 товар, мы вернем вам денежные средства, если возникли проблемы");
    }
}
