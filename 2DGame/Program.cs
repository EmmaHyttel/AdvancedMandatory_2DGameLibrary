using GameLibrary.Enums;
using GameLibrary.Factories;
using GameLibrary.Interfaces;
using GameLibrary.Models;
using GameLibrary.Models.Containers;
using GameLibrary.Models.Creatures;
using GameLibrary.Models.Player;
using GameLibrary.Models.Potions;
using GameLibrary.Records;
using GameLibrary.States;
using Microsoft.Extensions.DependencyInjection;

MyLogger.Instance.Start();
ServiceProvider serviceProvider;

// Build the service provider for DI
SetupServiceCollection();


World.Initialize("Fromhedania");

AddCreaturesToWorld();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"You have stepped into a world with {World.Creatures.Count} creatures!");
Console.WriteLine($"What is your name hero?");
Console.ResetColor();

string heroName = Console.ReadLine() ?? "";

if (string.IsNullOrEmpty(heroName))
{
    heroName = "Default Hero Name";
}

AddHeroToWorld(heroName);

Console.Clear();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Welcome '{heroName}' to the world of '{World.Name}'!");
Console.ResetColor();

var hero = World.Creatures.FirstOrDefault(c => c is Hero) as Hero;
ApplyFlamePotionToWeaponDebug(hero);

var debugOrc = new Orc() { CurrentPosition = new Position(1, 1) };
World.Creatures.Add(debugOrc);

while (true)
{
    if (hero != null && hero.IsAlive)
    {
        await CheckForEncounters(hero);
    }
}

async Task CheckForEncounters(Hero hero)
{
    // Find a creature in the same position as the hero
    var creature = World.Creatures
        .OfType<BaseCreature>()
        .FirstOrDefault(c => c.CurrentPosition == hero.CurrentPosition && c != hero && c.IsAlive);

    if (creature != null)
    {
        await StartEncounter(hero, creature);
    }
}

async Task StartEncounter(Hero hero, BaseCreature creature)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{creature.Name} has encountered {hero.Name}!");
    Console.ResetColor();

    var heroRoll = RollDice(20);
    var creatureRoll = RollDice(20);
    bool heroGoesFirst = heroRoll >= creatureRoll;

    Console.WriteLine($"Initiative Roll: {hero.Name} rolled {heroRoll}, {creature.Name} rolled {creatureRoll}");
    Console.WriteLine(heroGoesFirst ? $"{hero.Name} attacks first!" : $"{creature.Name} attacks first!");

    while (hero.IsAlive && creature.IsAlive)
    {

        if (hero.Health <= 10)
        {
            UseHealthPotionDebug(hero);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{hero.Name} used a health potion! Current health: {hero.Health}");
            Console.ResetColor();
        }

        if (heroGoesFirst)
        {
            hero.Hit(creature);
            if (!creature.IsAlive) break;

            await Task.Delay(1000);

            creature.Hit(hero);
            if (!hero.IsAlive) break;
        }
        else
        {
            creature.Hit(hero);
            if (!hero.IsAlive) break;

            await Task.Delay(1000);

            hero.Hit(creature);
            if (!creature.IsAlive) break;
        }
    }

    if (hero.IsAlive)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{hero.Name} has won the encounter!");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{creature.Name} has defeated {hero.Name}! :-(");
        Console.ResetColor();
    }
}

int RollDice(int sides)
{
    var random = new Random();
    return random.Next(1, sides + 1);
}

//while (true)
//{
//    ConsoleKey key = Console.ReadKey(true).Key;

//    switch (key)
//    {
//        case ConsoleKey.W:
//            hero.ChangeState(new MovingUp());
//            break;
//        case ConsoleKey.S:
//            hero.ChangeState(new MovingDown());
//            break;
//        case ConsoleKey.A:
//            hero.ChangeState(new MovingLeft());
//            break;
//        case ConsoleKey.D:
//            hero.ChangeState(new MovingRight());
//            break;
//        default:
//            break;
//    }

//    hero.Update();
//}



void SetupServiceCollection()
{
    var serviceCollection = new ServiceCollection();
    serviceCollection.AddSingleton<ICreatureFactory, CreatureFactory>();

    serviceProvider = serviceCollection.BuildServiceProvider();
}

void AddCreaturesToWorld()
{
    var creatureFactory = serviceProvider.GetRequiredService<ICreatureFactory>();

    var orcAmount = 5;
    var wizardAmount = 2;
    var trollAmount = 3;

    for (int i = 0; i < orcAmount; i++)
    {
        var creature = creatureFactory.Create(Creatures.Orc);
        World.Creatures.Add(creature);
    }

    for (int i = 0; i < wizardAmount; i++)
    {
        var creature = creatureFactory.Create(Creatures.Wizard);
        World.Creatures.Add(creature);
    }

    for (int i = 0; i < trollAmount; i++)
    {
        var creature = creatureFactory.Create(Creatures.Troll);
        World.Creatures.Add(creature);
    }
}

void AddHeroToWorld(string heroName)
{
    var hero = new Hero(heroName, 30, new Position(1, 1));

    var newPotionBelt = new PotionBelt()
    {
        Items = new List<IItem>()
        {
            new HealthPotion(),
            new FlameWeaponPotion()
        }
    };

    hero.Inventory.Add(newPotionBelt);

    hero.ChangeState(new IdleState());

    hero.CreatureEvent += (sender, e) =>
    {
        switch (e.EventType)
        {
            case CreatureEventTypes.HitReceived:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{hero.Name} has been hit! Current health: {hero.Health}");
                break;
            case CreatureEventTypes.HitDealt:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{hero.Name} has successfully hit!");
                break;

            case CreatureEventTypes.CreatureKilled:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Oh dear! You are dead.");
                break;

            case CreatureEventTypes.KilledCreature:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{hero.Name} has killed a creature!");
                break;

            default:
                break;
        }

        Console.ResetColor();
    };

    World.Creatures.Add(hero);
}

void ApplyFlamePotionToWeaponDebug(BaseCreature creature)
{
    var potionBag = creature.Inventory
    .OfType<PotionBelt>()
    .FirstOrDefault();

    var flamePotion = potionBag?.Items.OfType<FlameWeaponPotion>().FirstOrDefault();

    flamePotion?.UsePotion(creature.GetEquippedWeapon());
}

void UseHealthPotionDebug(BaseCreature creature)
{
    var potionBag = creature.Inventory
    .OfType<PotionBelt>()
    .FirstOrDefault();

    var flamePotion = potionBag?.Items.OfType<HealthPotion>().FirstOrDefault();

    flamePotion?.UsePotion(creature);
}