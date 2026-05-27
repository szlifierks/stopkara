using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace stopkara;

public partial class MainWindow : Window
{
    private static readonly ObservableCollection<Autor> autorzy = new()
    {
        new Autor(1, "John Doe1"),
        new Autor(2, "John Doe2"),
        new Autor(3, "John Doe3")
    };

    private static readonly ObservableCollection<Gatunek> gatunki = new()
    {
        new Gatunek(1, "gowno"),
        new Gatunek(2, "gowno2"),
        new Gatunek(3, "gowno3")
    };

    private static readonly ObservableCollection<Ksiazka> ksiazki = new()
    {
        new Ksiazka(1, "sraka", 1, autorzy[0], 1, gatunki[0]),
        new Ksiazka(2, "sraka23", 2, autorzy[1], 2, gatunki[1])
    };

    private readonly ObservableCollection<Gatunek> _filtrGatunki = new()
    {
        new Gatunek(0, "Wszystkie")
    };

    private readonly ICollectionView _ksiazkiView;

    public MainWindow()
    {
        InitializeComponent();

        lista.ItemsSource = ksiazki;

        foreach (var g in gatunki)
            _filtrGatunki.Add(g);

        wybor.ItemsSource = _filtrGatunki;
        wybor.SelectedIndex = 0;

        _ksiazkiView = CollectionViewSource.GetDefaultView(ksiazki);
        _ksiazkiView.Filter = FiltrujPoGatunku;
    }

    private bool FiltrujPoGatunku(object obj)
    {
        if (wybor.SelectedItem is not Gatunek g)
            return true;

        if (g.Id == 0)
            return true;

        if (obj is not Ksiazka k)
            return false;

        return k.Gatunek?.Id == g.Id;
    }

    private void Wybor_OnSelected(object sender, SelectionChangedEventArgs e)
    {
        _ksiazkiView?.Refresh();
    }

    private void Usun_OnClick(object sender, RoutedEventArgs e)
    {
        if (lista.SelectedItem is Ksiazka k)
            ksiazki.Remove(k);
    }

    private void Dodaj_OnClick(object sender, RoutedEventArgs e)
    {
        var okno = new AddBookWindow(autorzy, gatunki);
        if (okno.ShowDialog() == true && okno.NowaKsiazka != null)
            ksiazki.Add(okno.NowaKsiazka);
    }
}