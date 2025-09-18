public class Partida
{
    public string Palabra { get; set; }
    public char[] PalabraParcial { get; set; }
    public int Intentos { get; set; }
    public List<char> LetrasUsadas { get; set; } = new List<char>();
    public List<char> LetrasErroneas { get; set; } = new List<char>();
    public Partida(){}
}
