using System.Windows;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // 3. Instanzen der Klasse Mitarbeiter erstellen und Methode aufrufen
        Mitarbeiter mitarbeiter1 = new Mitarbeiter("Max Mustermann", "Softwareentwickler", 50000);
        Mitarbeiter mitarbeiter2 = new Mitarbeiter("Erika Musterfrau", "Projektmanagerin", 60000);
        Mitarbeiter mitarbeiter3 = new Mitarbeiter("Hans Meier", "Qualitätsprüfer", 45000);

        // Beschreibung der Mitarbeiter im Textblock anzeigen
        MitarbeiterInfoTextBlock.Text = mitarbeiter1.Beschreiben() + "\n" +
                                        mitarbeiter2.Beschreiben() + "\n" +
                                        mitarbeiter3.Beschreiben();
    }
}

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