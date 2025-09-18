using System;
using System.Collections.Generic;


public class Palabra
{
    public Dictionary<int, char> DicPalabra { get; private set; }
    public string palabra;
    public Palabra(string contenido)
    {
        DicPalabra = new Dictionary<int, char>();
        palabra = contenido;
        for (int i = id(); i < contenido.Length; i++)
        {
            DicPalabra[i] = contenido[i];
        }
    }
    public bool arriesgarLetra(char letra)
    {
        bool devuelve = false;
        for (int i = 0; i < DicPalabra.Count; i++)
        {
            if (letra == DicPalabra[i])
            {
                devuelve = true;
            }
        }
        return devuelve;
    }
    public bool arriesgarPalabra(string letra)
    {
        bool devuelve = true;
        if (letra.Length != DicPalabra.Count)
        {
            devuelve = false;
        }
        else
        {
            for (int i = 0; i < DicPalabra.Count; i++)
            {
                if (letra[i] != DicPalabra[i])
                {
                    devuelve = false;
                }
            }
        }
        return devuelve;
    }
    private int id()
    {
        int idFinal = 0;
        int finalizo = 0;
        do
        {
            if (DicPalabra.ContainsKey(idFinal) == false)
            {
                finalizo = 1;
            }
            idFinal++;
        } while (DicPalabra.Count() > idFinal && finalizo == 0);
        if (finalizo == 1)
        {
            idFinal--;
        }
        return idFinal;
    }
}
