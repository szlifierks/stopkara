using System.Collections.ObjectModel;
using System.Windows;

namespace stopkara;

public partial class AddBookWindow : Window
{
    private readonly ObservableCollection<Autor> _autorzy;
    private readonly ObservableCollection<Gatunek> _gatunki;

    public AddBookWindow(ObservableCollection<Autor> autorzy, ObservableCollection<Gatunek> gatunki)
    {
        InitializeComponent();
        _autorzy = autorzy;
        _gatunki = gatunki;

        AutorBox.ItemsSource = _autorzy;
        GatunekBox.ItemsSource = _gatunki;
    }

    public Ksiazka? NowaKsiazka { get; private set; }

    private void Anuluj_OnClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void Zapisz_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TytulBox.Text) ||
            AutorBox.SelectedItem is not Autor autor ||
            GatunekBox.SelectedItem is not Gatunek gatunek)
            return;

        var nextId = 1;
        if (Application.Current.MainWindow is MainWindow)
            nextId = 1;

        NowaKsiazka = new Ksiazka(nextId, TytulBox.Text.Trim(), 1, autor, 1, gatunek);
        DialogResult = true;
        Close();
    }
}