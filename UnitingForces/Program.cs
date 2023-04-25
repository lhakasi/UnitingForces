using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitingForces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Terminal terminal = new Terminal();

            terminal.Work();
        }
    }

    class Soldier
    {
        private string _weapon;

        private int _servicLife;

        public Soldier(string name, string rank, string weapon, int servicLife)
        {
            Name = name;
            Rank = rank;
            _weapon = weapon;
            _servicLife = servicLife;
        }

        public string Name { get; private set; }
        public string Rank { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} {Rank} - Оружие: {_weapon}, Срок службы: {_servicLife} мес.");
        }
    }

    class Terminal
    {
        private List<Soldier> _platoon1;
        private List<Soldier> _platoon2;

        public Terminal()
        {
            _platoon1 = new List<Soldier>()
            {
                new Soldier("Терентьев", "Капитан", "Винтовка", 120),
                new Soldier("Мельников", "Полковник", "Пистолет", 210),
                new Soldier("Подольских", "Лейтенант", "Автомат", 90),
                new Soldier("Павлов", "Майор", "Пистолет", 184),
                new Soldier("Хлебников", "Полковник", "Пистолет", 240),
                new Soldier("Воробьев", "Ст. Лейтенант", "Автомат", 110),
                new Soldier("Балош", "Капитан", "Винтовка", 135),
                new Soldier("Захаров", "Подполковник", "Пистолет", 200),
                new Soldier("Сотников", "Ст. Лейтенант", "Автомат", 105)
            };

            _platoon2 = new List<Soldier>()
            {
                new Soldier("Треугольников", "Капитан", "Винтовка", 110),
                new Soldier("Ломов", "Лейтенант", "Автомат", 73),
                new Soldier("Бобриков", "Лейтенант", "Автомат", 80),
            };
        }

        public void Work()
        {
            string platoon1 = "Взвод 1:";
            string platoon2 = "Взвод 2:";
            
            ShowPlatoon(platoon1, _platoon1);
            ShowPlatoon(platoon2, _platoon2);

            Transfer();

            Console.WriteLine($"Перевод бойцов с фамилией начинающейся на \"Б\" произведен\n");

            ShowPlatoon(platoon1, _platoon1);
            ShowPlatoon(platoon2, _platoon2);

            Console.ReadKey();            
        }
        
        private void Transfer()
        {
            var soldiersForTransfer = _platoon1.Where(player => player.Name.StartsWith("Б"));
            _platoon2 = _platoon2.Union(soldiersForTransfer).ToList();
            _platoon1 = _platoon1.Except(soldiersForTransfer).ToList();
        }

        private void ShowPlatoon(string platoon, List<Soldier> soldiers)
        {
            Console.WriteLine(platoon);
            Console.WriteLine();
            
            foreach (Soldier soldier in soldiers)            
                soldier.ShowInfo();
            
            Console.WriteLine();
        }
    }
}
