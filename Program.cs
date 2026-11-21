// Probe.Run();

Hero yaroslav = new Hero("Ярослав", 100);
Hero anastasia = new Hero("Анастасия", 90);
Hero artem = new Hero("Артём", 120);
Hero alexander = new Hero("   Александр   ", 150);
Hero sergey = new Hero("Сергей", 110);

alexander.TakeDamage(10);
alexander.Heal(10);

Guild guild = new Guild("Гильдия героев");
guild.AddHero(yaroslav);
guild.AddHero(anastasia);
guild.AddHero(artem);
guild.AddHero(alexander);
guild.AddHero(sergey);

Console.WriteLine($">>> {guild.Name}: участников {guild.MemberCount} <<<");
Console.WriteLine();

QuestBoard board = new QuestBoard(guild);

Quest floatQuest = new Quest(101, "Вернуть поплавок", 100, 30);
Console.WriteLine($"Поручение добавлено: {board.AddQuest(floatQuest)}");
Console.WriteLine($">>> №{floatQuest.Id}: {floatQuest.Title} <<<");

Console.WriteLine($"Назначение Сергея: {board.TryAssign(101, " сЕрГеЙ ")}");
Hero? assigned = floatQuest.AssignedHero;
if (assigned != null)
{
    Console.WriteLine($"Исполнитель: {assigned.Name}");
}
Console.WriteLine($"Опыт после назначения: {sergey.Experience}");

Console.WriteLine($"Завершение: {board.TryComplete(101)}");
Console.WriteLine($"Опыт после завершения: {sergey.Experience}");
Console.WriteLine($"Повторное завершение: {board.TryComplete(101)}");
Console.WriteLine($"Опыт после повтора: {sergey.Experience}");

Console.WriteLine();
Console.WriteLine(floatQuest.GetInfo());
Console.WriteLine(sergey.GetInfo());

Console.WriteLine();
Warehouse warehouse = new Warehouse("Оружейный склад гильдии");

Product shield = new Product("Железный щит", 800, 10);
Product sword = new Product("Стальной меч", 1200, 2);
Product potion = new Product("Зелье лечения", 150, 15);
Product bow = new Product("Охотничий лук", 950, 1);

warehouse.AddProduct(shield);
warehouse.AddProduct(sword);
warehouse.AddProduct(potion);
warehouse.AddProduct(bow);

Console.WriteLine($">>> {warehouse.Name}: работа с заказами <<<");

Order failedOrder = new Order(501, 5);
Console.WriteLine($"Заказ №501 на 5 мечей (в наличии 2): {failedOrder.TryStart(sword)}");

Order validOrder = new Order(502, 4);
Console.WriteLine($"Заказ №502 на 4 зелья (старт): {validOrder.TryStart(potion)}");
Console.WriteLine($"Остаток зелий до отгрузки: {potion.StockQuantity} шт.");

Console.WriteLine($"Отгрузка заказа №502: {validOrder.TryFinish()}");
Console.WriteLine($"Повторная отгрузка заказа №502: {validOrder.TryFinish()}");
Console.WriteLine(validOrder.GetInfo());

Product? checkPotion = warehouse.FindProductByName("зелье лечения");
if (checkPotion != null)
{
    Console.WriteLine($"Проверка по складу — {checkPotion.Name}: остаток {checkPotion.StockQuantity} шт.");
}
