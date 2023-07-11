using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_number_57
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();

            string initialLetter = "Б";

            database.ShowAllSquad();

            Console.WriteLine("Для того что бы перенести всех солдат у которых начинается имя на букву б нажмите любую клавишу!");
            Console.ReadKey();
            Console.Clear();

            database.FilterSoldierwithInitialLetter(initialLetter);

            database.ShowAllSquad();

            Console.ReadKey();
        }
    }

    class Soldier
    {
        public Soldier(string name, string arms, string rank, int serviceLife)
        {
            Name = name;
            Arms = arms;
            Rank = rank;
            ServiceLife = serviceLife;
        }

        public string Name { get; private set; }
        public string Arms { get; private set; }
        public string Rank { get; private set; }
        public int ServiceLife { get; private set; }
    }

    class Database
    {
        private List<Soldier> _firstSquad = new List<Soldier>();
        private List<Soldier> _secondSquad = new List<Soldier>();

        public Database()
        {
            Fill();
        }

        public void FilterSoldierwithInitialLetter(string initialLetter)
        {
            var filteredSoldiers = (from Soldier soldier in _firstSquad
                                    where soldier.Name.StartsWith(initialLetter)
                                    select soldier).ToList();

            _secondSquad = _secondSquad.Union(filteredSoldiers).ToList();

            _firstSquad.RemoveAll(soldier => soldier.Name.StartsWith(initialLetter));
        }

        public void ShowAllSquad()
        {
            Console.WriteLine("Первый отряд:\n" +
                              "\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");

            ShowSquad(_firstSquad);

            Console.WriteLine("Второй отряд:\n" +
                              "\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");

            ShowSquad(_secondSquad);
        }

        private void ShowSquad(List<Soldier> squad)
        {
            foreach (Soldier soldier in squad)
            {
                Console.WriteLine("Солдат:");
                Console.WriteLine($"Имя : {soldier.Name}");
                Console.WriteLine($"Оружие : {soldier.Arms}");
                Console.WriteLine($"Звание: {soldier.Rank}");
                Console.WriteLine($"Время службы в месяцах: {soldier.ServiceLife}");
                Console.WriteLine();
            }
        }

        private void Fill()
        {
            Random random = new Random();

            List<string> soldierNames = new List<string>()
            {
            "Иван",
            "Петр",
            "Алексей",
            "Михаил",
            "Сергей",
            "Борис"
            };
            List<string> weaponNames = new List<string>()
            {
            "Автомат",
            "Пистолет",
            "Винтовка",
            "Пулемет",
            "Гранатомет"
            };
            List<string> ranks = new List<string>()
        {
            "Рядовой",
            "Ефрейтор",
            "Младший сержант",
            "Сержант",
            "Старший сержант"
        };

            int maxServiceLife = 60;
            int minServiceLife = 1;
            int quantitySoldiers = 10;

            for (int i = 0; i < quantitySoldiers; i++)
            {
                _firstSquad.Add(new Soldier(soldierNames[random.Next(soldierNames.Count)],
                                          weaponNames[random.Next(weaponNames.Count)],
                                          ranks[random.Next(ranks.Count)],
                                          random.Next(minServiceLife, maxServiceLife)));

                _secondSquad.Add(new Soldier(soldierNames[random.Next(soldierNames.Count)],
                                         weaponNames[random.Next(weaponNames.Count)],
                                         ranks[random.Next(ranks.Count)],
                                         random.Next(minServiceLife, maxServiceLife)));
            }
        }
    }
}
