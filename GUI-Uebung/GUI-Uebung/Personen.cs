namespace GUI_Uebung
{
    class Person
    {
        private string _name;
        private string _beruf;
        private decimal _gehalt;
        private Bankkonto _konto;

        public Person() { }

        public Person(string name, string beruf, decimal gehalt)
        {
            _name = name;
            _beruf = beruf;
            _gehalt = gehalt;
            _konto = new Bankkonto(Name, gehalt);

        }

        public string Name { get { return _name; } set { _name = value; } }
        public string Beruf { get { return _beruf; } set { _beruf = value; } }
        public decimal Gehalt { get { return _gehalt; } set { _gehalt = value; } }
        public Bankkonto Konto { get { return _konto; } }


    }
}
