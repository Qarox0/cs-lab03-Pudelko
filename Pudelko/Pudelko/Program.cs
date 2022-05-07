using Pudelkolibrary;

public static class Program
{
    public static void Main(string[] args)
    {

    }

    public static Pudelko Kompresuj(this Pudelko p)
    {
        double edge = Math.Cbrt(p.Objetosc);
        return new Pudelko(edge, edge, edge);
    }
}