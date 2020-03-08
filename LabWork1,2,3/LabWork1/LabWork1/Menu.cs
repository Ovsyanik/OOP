using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace LabWork1
{
    static class Menu
    {
        public static Map map = new Map();

        //Гланое меню
        public static void MainMenu()
        {
           //Console.Clear();
            Console.WriteLine("1 - Сделать героя");
            Console.WriteLine("2 - Сделать NPC");
            Console.WriteLine("3 - Сделать клонирование");
            Console.WriteLine("4 - Показать всех героев");
            Console.WriteLine("5 - Найти героя");
            Console.WriteLine("6 - Играть героем");
            Console.WriteLine("7 - Выйти");
            Console.WriteLine("Выберите действие: \t");
            switch (GetCommand())
            {
                case 1:
                    {
                        map.AddComponent(new Adapter(MakeHeroMenu()));
                    }
                    break;
                case 2:
                    {
                        Console.Clear();
                        string nameNpc = Console.ReadLine();
                        NPCSingleton NPC = NPCSingleton.GetInstance(nameNpc);
                        Console.WriteLine($"NPC {NPC._name} создан");
                    }
                    break;
                case 3:
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Введите имя клонируемого объекта:");
                            string str = Console.ReadLine();
                            Adapter hero = (Adapter)map.Find(str);
                            Adapter hero1 = hero.Clone();
                            Console.WriteLine(hero1);
                            map.AddComponent(hero);

                        }
                        catch(ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;
                case 4:
                    map.ShowHero();
                    break;
                case 5:
                    {
                        Console.WriteLine("Введите имя героя: ");
                        string name = Console.ReadLine();
                        map.Find(name);
                    }
                    break;
                case 6:
                    MoveHero();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        //Cоздание героя
        public static Hero MakeHeroMenu()
        {
            Console.Clear();
            Director creator = new Director();
            AbstractHeroBuilder builder = new HeroBuilder();
            Console.WriteLine("1 - Сделать героя с помощью Builder");
            Console.WriteLine("2 - Сделать героя с помощью Decorator");
            Console.WriteLine("3 - Сделать героя с помощью Abstract Factory");
            Console.WriteLine("Выберите действие: \t");
            switch (GetCommand())
            {
                case 1:
                    Hero hero = creator.Make(builder);
                    Console.WriteLine(hero.ToString());
                    return hero;
                    break;
                case 2:
                    Hero hero1 = creator.Make(builder);
                    Hero flyHero = new FlyHeroDecorator(hero1);
                    Console.WriteLine(flyHero.ToString());
                    return flyHero;
                    break;
                case 3:                 
                    return MakeHeroAbstractMenu();
                    break;
                default:
                    break;
            }
            return null;
        }

        //Создание героя с помощью Abstract Factory
        public static Hero MakeHeroAbstractMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Сделать Assasin");
            Console.WriteLine("2 - Сделать Hunter");
            Console.WriteLine("3 - Сделать Warrior");
            Console.WriteLine("Выберите действие: \t");
            switch (GetCommand())
            {
                case 1:
                    Hero person = new Hero(new Assasin());
                    return person;
                case 2:
                    Hero person1 = new Hero(new Hunter());
                    return person1;
                case 3:
                    Hero person2 = new Hero(new Warrior());
                    return person2;
                default:
                    break;
            }
            return null;
        }

        //Перемещение героем
        public static void MoveHero()
        {
            Console.WriteLine("Введите имя героя: \t");
            string str = Console.ReadLine();
            Hero hero = new Hero { Name = str };

            var stayState = new SingleState(new StayCommand());
            var runState = new SingleState(new RunCommand());
            var jumpState = new ComplexState(new JumpCommand(), stayState);
            var attackState = new ComplexState(new AttackCommand(), stayState);
            var heroContext = new Context(stayState, hero.Name);
            var stateRestorer = new Restorer(heroContext);

            if (map.Find(str) is null)
            {
                Console.Clear();
                Console.WriteLine("Герой не найден");
            }
            else
            {
                Console.WriteLine("Игра начинается!");
                do
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.UpArrow:
                            heroContext.Update(jumpState);
                            stateRestorer.BackUp();
                            break;
                        case ConsoleKey.LeftArrow:
                            heroContext.Update(runState);
                            stateRestorer.BackUp();
                            break;
                        case ConsoleKey.RightArrow:
                            heroContext.Update(runState);
                            stateRestorer.BackUp();
                            break;
                        case ConsoleKey.DownArrow:
                            heroContext.Update(attackState);
                            stateRestorer.BackUp();
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            return;
                        default:
                            stateRestorer.Undo();
                            break;
                    }
                    heroContext.Request();
                } while (true);
            }
        }

        public static int GetCommand()
        {
            int count;
            while (!int.TryParse(Console.ReadLine(), out count))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число!!!");
            }
            return count;
        }

        
    }
}
