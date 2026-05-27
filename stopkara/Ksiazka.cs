namespace stopkara;

public class Ksiazka(int id, string tytul, int autorId, Autor autor, int gatunekId, Gatunek gatunek)
{
    public int Id { get; set; } = id;
    public string Tytul { get; set; } = tytul;
    public int autorId { get; set; } = autorId;
    public Autor Autor { get; set; } = autor;
    public int gatunekId { get; set; } = gatunekId;
    public Gatunek Gatunek { get; set; } = gatunek;
}