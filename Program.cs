using System;
using System.Collections;

namespace ProgettoAlbero

{
    class Program
    {
        static void Main(string[] args)
        {
            AlberoBinarioIntero sx;
            AlberoBinarioIntero dx;
            AlberoBinarioIntero p;
            AlberoBinarioIntero r = new AlberoBinarioIntero(69);
          
            sx = new AlberoBinarioIntero(2);
            dx = new AlberoBinarioIntero(71);
            p = new AlberoBinarioIntero(39, sx, dx);
            sx = p;
            dx = new AlberoBinarioIntero(66);
            dx.aggiungiFiglioDx(new AlberoBinarioIntero(77));
            
            r.aggiungiFiglioSx(new AlberoBinarioIntero(89, sx, dx));
            
            sx = new AlberoBinarioIntero(44);
            dx = new AlberoBinarioIntero(12);
            
            r.aggiungiFiglioDx(new AlberoBinarioIntero(28, sx, dx));

            r.stampa();
            Console.WriteLine("----------------");
            Console.WriteLine(r);
            Console.WriteLine("--Iterativa--------------");
            r.stampaIterativa();
            Console.WriteLine("--Iterativa2--------------");
            r.stampaIterativa2();








        }
    }
}
