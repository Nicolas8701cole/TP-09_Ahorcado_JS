
public static class Contenido
{
    public static Dictionary<int, Palabra> DicPalabras { get; private set; }
    public static int intentos { get; private set; }
    public static Dictionary<int, char> DicLetrasUsadas { get; private set; }
    public static int PalabraActualId { get; private set; }
    public static void InicializarContenido()
    {
        DicLetrasUsadas = new Dictionary<int, char>();
        DicPalabras = new Dictionary<int, Palabra>();
        DicPalabras.Add(id(), new Palabra("confetti"));
        DicPalabras.Add(id(), new Palabra("modongo"));
        DicPalabras.Add(id(), new Palabra("rusia"));
        DicPalabras.Add(id(), new Palabra("velocirraptor"));
        DicPalabras.Add(id(), new Palabra("computadora"));
        DicPalabras.Add(id(), new Palabra("transgenero"));
        DicPalabras.Add(id(), new Palabra("diciembre"));
        DicPalabras.Add(id(), new Palabra("carcajada"));
        DicPalabras.Add(id(), new Palabra("elefante"));
        DicPalabras.Add(id(), new Palabra("invierno"));
        DicPalabras.Add(id(), new Palabra("cordoba"));
        DicPalabras.Add(id(), new Palabra("medieval"));
        DicPalabras.Add(id(), new Palabra("lanzaguisantes"));
        DicPalabras.Add(id(), new Palabra("girasol"));
        DicPalabras.Add(id(), new Palabra("zombie"));
        DicPalabras.Add(id(), new Palabra("arcoiris"));
        DicPalabras.Add(id(), new Palabra("estereotipo"));
        DicPalabras.Add(id(), new Palabra("saturno"));
        DicPalabras.Add(id(), new Palabra("andres"));
        DicPalabras.Add(id(), new Palabra("hipopotomonstrosesquipedaliofobia"));
    }
    public static void iniciarJuego()
    {
        InicializarContenido();
        Random numeroRandom = new Random();
        PalabraActualId = numeroRandom.Next(0, DicPalabras.Count);  //Palabra actual id me lo marca como "Palabra"
        DicLetrasUsadas.Clear();
        intentos = 0;
    }
    public static string obtenerPalabraMedioEcha()
    {
        var palabra = DicPalabras[PalabraActualId];
        string resultado = "";

        foreach (var letra in palabra.DicPalabra)
        {
            if (DicLetrasUsadas.ContainsValue(letra.Value))
            {
                resultado += letra.Value + " ";
            }
            else
            {
                resultado += "_ ";
            }
        }
        return resultado.Trim();  //.Trim elimina espacios al inicio y al final.
    }
    public static void sumarIntentos()
    {
        intentos++;
    }
    public static string sumarLetrasErroneas()
    {
        var palabra = DicPalabras[PalabraActualId];
        string errores = "";

        foreach (var letra in DicLetrasUsadas.Values)
        {
            if (!palabra.DicPalabra.ContainsValue(letra))  // No funciona y nose el porque.
            {
                errores += letra + " ";
            }
        }

        return errores.Trim();
    }
    private static int id()
    {
        int idFinal = 0;
        int finalizo = 0;
        do
        {
            if (DicPalabras.ContainsKey(idFinal) == false)
            {
                finalizo = 1;
            }
            idFinal++;
        } while (DicPalabras.Count() > idFinal && finalizo == 0);
        if (finalizo == 1)
        {
            idFinal--;
        }
        return idFinal;
    }
}
