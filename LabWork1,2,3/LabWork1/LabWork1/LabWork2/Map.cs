using System;
using System.Collections.Generic;

namespace LabWork1
{
    [Serializable]
    public class Map : IComponent
    {
        public List<IComponent> _map = new List<IComponent>();
        public string Title { get; set; }

        public void AddComponent(IComponent component)
        {
            if(component is null)
            {
                throw new ArgumentNullException(nameof(component));
            }
            _map.Add(component);
            Console.Clear();
            Console.WriteLine($"Обьект добавлен на карту");
        }

        public void Draw()
        {
            foreach (var item in this._map)
            {
                item.Draw();
            };
        }
        
        public IComponent Find(string title)
        {
            foreach (var item in _map)
            {
                if(item.Find(title).Title.Equals(title))
                {
                    Console.WriteLine($"Герой {item.Find(title).Title.ToString()} Найден") ; 
                    return item;
                }
            }
            Console.WriteLine("Герой не найден!!!");
            return null;
        }

        public void ShowHero()
        {
            Console.Clear();
            Console.WriteLine("\nСписок героев:");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in _map)
            {
                if (item is null)
                    Console.WriteLine($"Героя(ев) нету");
                else
                {
                    Console.WriteLine(item.ToString());
                    item.Draw();
                }
            }
            Console.ResetColor();
        }

        
    }
}
