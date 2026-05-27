namespace stopkara;

public class Gatunek
{
    public Gatunek(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}