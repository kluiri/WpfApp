using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{

    public class Mitarbeiter
    {
        // 1. Attribute der Klasse Mitarbeiter
        public string Name { get; set; }
        public string Position { get; set; }
        public double Gehalt { get; set; }

        // Konstruktor zum Initialisieren der Attribute
        public Mitarbeiter(string name, string position, double gehalt)
        {
            Name = name;
            Position = position;
            Gehalt = gehalt;
        }

        // 2. Methode zur Beschreibung der Person
        public string Beschreiben()
        {
            return $"Name: {Name}, Position: {Position}, Gehalt: {Gehalt:C}";
        }

    }
}
