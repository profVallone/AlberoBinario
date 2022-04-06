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
            sx.aggiungiFiglioDx(new AlberoBinarioIntero(9));
            dx = new AlberoBinarioIntero(71);
            p = new AlberoBinarioIntero(39, sx, dx);
            sx = p;
            dx = new AlberoBinarioIntero(66);
            dx.aggiungiFiglioDx(new AlberoBinarioIntero(77));
            
            r.aggiungiFiglioSx(new AlberoBinarioIntero(89, sx, dx));
            
            sx = new AlberoBinarioIntero(44);
            dx = new AlberoBinarioIntero(12);
            dx.aggiungiFiglioDx(new AlberoBinarioIntero(58));
            
            r.aggiungiFiglioDx(new AlberoBinarioIntero(28, sx, dx));

            r.stampaRicorsivaAnticipata();
            Console.WriteLine("----------------");
            Console.WriteLine(r);
            Console.WriteLine("--RicorsivaAnticipata--------------");
            r.stampaRicorsivaAnticipata();
            Console.WriteLine("--IterativaAnticipata--------------");
            r.stampaIterativaAnticipata();
            Console.WriteLine("--IterativaAnticipata2--------------");
            r.stampaIterativaAnticipata2();
            Console.WriteLine("--IterativaAnticipata3--------------");
            r.stampaIterativaAnticipata3();
            Console.WriteLine("--RicorsivaPosticipata--------------");
            r.stampaRicorsivaPosticipata();
            Console.WriteLine("--IterativaPosticipata--------------");
            r.stampaIterativaPosticipata();
            Console.WriteLine("--IterativaPosticipata2--------------");
            r.stampaIterativaPosticipata2();
            Console.WriteLine("--IterativaPosticipata3--------------");
            r.stampaIterativaPosticipata3();








        }
    }
}
