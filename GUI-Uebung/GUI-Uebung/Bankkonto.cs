using System.Windows;

namespace GUI_Uebung
{
    class Bankkonto
    {
        private string _inhaber;
        private decimal _kontostand;

        public Bankkonto(string inhaber, decimal kontostand)
        {
            _inhaber = inhaber;
            _kontostand = kontostand;
        }

        public string Inhaber { get { return _inhaber; } set { _inhaber = Inhaber; } }
        public decimal Kontostand { get { return _kontostand; } set { _kontostand = Kontostand; } }

        public void Einzahlen(decimal betrag)
        {
            if (betrag > 0)
            {
                _kontostand += betrag;
            }
            else
            {
                MessageBox.Show("Betrag muss positiv sein!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void Auszahlen(decimal betrag)
        {
            if (betrag > 0 && _kontostand >= betrag)
            {
                _kontostand -= betrag;
            }
            else
            {
                MessageBox.Show("Nicht genug Guthaben!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
