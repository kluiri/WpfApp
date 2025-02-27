using System.Windows;

namespace GUI_Uebung
{
    public partial class MainWindow : Window
    {
        private List<Person> personen; // Klassenvariable für die Personenliste
        private Person selectedPerson;

        public MainWindow()
        {
            InitializeComponent();
            TextBox_Betrag.Visibility = Visibility.Collapsed;
            Button_Einzahlen.Visibility = Visibility.Collapsed;
            Button_Auszahlen.Visibility = Visibility.Collapsed;
            Label_Kontostand.Visibility = Visibility.Collapsed;
            Label_Bezeichner_Kontostand.Visibility = Visibility.Collapsed;
            Label_Bezeichner_Geldwert.Visibility = Visibility.Collapsed;
            Label_Euro.Visibility = Visibility.Collapsed;
            Label_Bewegung.Visibility = Visibility.Collapsed;

            // Personenliste initialisieren
            personen = new List<Person>
            {
                new Person("Barbara", "Fisi", 50000),
                new Person("Irina", "Fiae", 55000),
                new Person("Sophie", "Fiae", 45000)
            };

            DataContext = this;

            // Anzeige der verfügbaren Namen in der UI
            listBoxPersonen.ItemsSource = personen;
        }

        private void Button_Auswahl_Click(object sender, RoutedEventArgs e)
        {
            var eingabePerson = listBoxPersonen.SelectedItem as Person;
            selectedPerson = new Person();


            // Personenliste durchsuchen
            foreach (Person person in personen)
            {
                if (person == eingabePerson)
                {
                    selectedPerson = person;
                    break;
                }
            }

            // Wenn Person gefunden wurde
            if (selectedPerson != null)
            {
                //Kontostand Anzeige anpassen
                Label_Kontostand.Content = $"{selectedPerson.Konto.Kontostand} €";
                //Felder anzeigen für Kontotransaktion
                TextBox_Betrag.Visibility = Visibility.Visible;
                Button_Einzahlen.Visibility = Visibility.Visible;
                Button_Auszahlen.Visibility = Visibility.Visible;
                Label_Kontostand.Visibility = Visibility.Visible;
                Label_Bezeichner_Kontostand.Visibility = Visibility.Visible;
                Label_Bezeichner_Geldwert.Visibility = Visibility.Visible;
                Label_Euro.Visibility = Visibility.Visible;
            }
            else
            {
                //Felder ausblenden für Kontotransaktion
                TextBox_Betrag.Visibility = Visibility.Collapsed;
                Button_Einzahlen.Visibility = Visibility.Collapsed;
                Button_Auszahlen.Visibility = Visibility.Collapsed;
                Label_Kontostand.Visibility = Visibility.Collapsed;
                Label_Bezeichner_Kontostand.Visibility = Visibility.Collapsed;
                Label_Bezeichner_Geldwert.Visibility = Visibility.Collapsed;
                Label_Euro.Visibility = Visibility.Collapsed;
                Label_Bewegung.Visibility = Visibility.Collapsed;

                MessageBox.Show("Person nicht gefunden!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void Button_Einzahlen_Click(object sender, RoutedEventArgs e)
        {
            //Eingabe als Decimal
            decimal betrag = Convert.ToDecimal(TextBox_Betrag.Text);
            if (TextBox_Betrag.Text != "")
            {
                selectedPerson.Konto.Einzahlen(betrag);
                //Anzeige von + <Betrag>
                if (betrag > 0)
                {
                    Label_Bewegung.Visibility = Visibility.Visible;
                    Label_Bewegung.Content = "+ " + TextBox_Betrag.Text;
                }
                Label_Kontostand.Content = $"{selectedPerson.Konto.Kontostand} €";
                TextBox_Betrag.Text = "";
            }
        }

        private void Button_Auszahlen_Click(object sender, RoutedEventArgs e)
        {
            //Eingabe als Decimal
            decimal betrag = Convert.ToDecimal(TextBox_Betrag.Text);
            if (TextBox_Betrag.Text != "")
            {
                //Anzeige von - <Betrag>
                //Prävention von Kontoüberziehung ohne MessageBoxHandler
                selectedPerson.Konto.Auszahlen(betrag);
                if (betrag > 0 && selectedPerson.Konto.Kontostand >= betrag)
                {
                    Label_Bewegung.Visibility = Visibility.Visible;
                    Label_Bewegung.Content = "- " + TextBox_Betrag.Text;
                }
                Label_Kontostand.Content = $"{selectedPerson.Konto.Kontostand} €";
                TextBox_Betrag.Text = "";
            }
        }
    }
}
