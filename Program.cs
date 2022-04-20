using System;
using System.Collections;

namespace ProgettoAlbero

{
    class Program
    {
        static void Main(string[] args)
        {
            AlberoBinarioIntero sx, dx, p, fSx, fDx;

            AlberoBinarioIntero r = new AlberoBinarioIntero(69);
          
            sx = new AlberoBinarioIntero(2);
            sx.aggiungiFiglioDx(new AlberoBinarioIntero(9));
            dx = new AlberoBinarioIntero(71);
            p = new AlberoBinarioIntero(39, sx, dx);
            sx = p;
            dx = new AlberoBinarioIntero(66);
            dx.aggiungiFiglioSx(new AlberoBinarioIntero(77));
            
            r.aggiungiFiglioSx(new AlberoBinarioIntero(89, sx, dx));
            
            sx = new AlberoBinarioIntero(44);
            dx = new AlberoBinarioIntero(12);
            
            r.aggiungiFiglioDx(new AlberoBinarioIntero(28, sx, dx));
            
            //degenereSx
            AlberoBinarioIntero degSx = new AlberoBinarioIntero(1);
            sx = new AlberoBinarioIntero(2);
            degSx.aggiungiFiglioSx(sx);
            
            fSx = degSx.getSx();
            sx = new AlberoBinarioIntero(3);
            fSx.aggiungiFiglioSx(sx);

            fSx = fSx.getSx();
            sx = new AlberoBinarioIntero(4);
            fSx.aggiungiFiglioSx(sx);

            //degenereDx
            AlberoBinarioIntero degDx = new AlberoBinarioIntero(5);
            dx = new AlberoBinarioIntero(6);
            degDx.aggiungiFiglioDx(dx);

            fDx = degDx.getDx();
            dx = new AlberoBinarioIntero(7);
            fDx.aggiungiFiglioDx(dx);

            fDx = fDx.getDx();
            dx = new AlberoBinarioIntero(8);
            fDx.aggiungiFiglioDx(dx);

            //degenereGenerico
            AlberoBinarioIntero degGen = new AlberoBinarioIntero(10);
            dx = new AlberoBinarioIntero(11);
            degGen.aggiungiFiglioDx(dx);

            fDx = degGen.getDx();
            sx = new AlberoBinarioIntero(12);
            fDx.aggiungiFiglioSx(sx);

            fSx = fDx.getSx();
            dx = new AlberoBinarioIntero(13);
            fSx.aggiungiFiglioDx(dx);

            Console.WriteLine("----DegenereSx------------");
            Console.WriteLine(degSx);
            Console.WriteLine("--RicorsivaAnticipata--------------");
            degSx.stampaRicorsivaAnticipata();
            Console.WriteLine("--RicorsivaPosticipata--------------");
            degSx.stampaRicorsivaPosticipata();
            Console.WriteLine("--Degenere--------------");
            degSx.degenere();

            Console.WriteLine("----DegenereDx------------");
            Console.WriteLine(degDx);
            Console.WriteLine("--RicorsivaAnticipata--------------");
            degDx.stampaRicorsivaAnticipata();
            Console.WriteLine("--RicorsivaPosticipata--------------");
            degDx.stampaRicorsivaPosticipata();
            Console.WriteLine("--Degenere--------------");
            degDx.degenere();

            Console.WriteLine("----DegenereGen------------");
            Console.WriteLine(degGen);
            Console.WriteLine("--RicorsivaAnticipata--------------");
            degGen.stampaRicorsivaAnticipata();
            Console.WriteLine("--RicorsivaPosticipata--------------");
            degGen.stampaRicorsivaPosticipata();
            Console.WriteLine("--Degenere--------------");
            degGen.degenere();

            Console.WriteLine("----NonDegenere------------");
            Console.WriteLine(r);
            r.degenere();


            //Console.WriteLine("----ToString------------");
            //Console.WriteLine(r);
            //Console.WriteLine("--RicorsivaAnticipata--------------");
            //r.stampaRicorsivaAnticipata();
            //Console.WriteLine("--IterativaAnticipata--------------");
            //r.stampaIterativaAnticipata();
            //Console.WriteLine("--IterativaAnticipata2--------------");
            //r.stampaIterativaAnticipata2();
            //Console.WriteLine("--IterativaAnticipata3--------------");
            //r.stampaIterativaAnticipata3();
            //Console.WriteLine("--RicorsivaPosticipata--------------");
            //r.stampaRicorsivaPosticipata();
            //Console.WriteLine("--IterativaPosticipata--------------");
            //r.stampaIterativaPosticipata();
            //Console.WriteLine("--IterativaPosticipata2--------------");
            //r.stampaIterativaPosticipata2();
            //Console.WriteLine("--IterativaPosticipata3--------------");
            //r.stampaIterativaPosticipata3();
            //Console.WriteLine("--RicorsivaSimmetriva--------------");
            //r.stampaRicorsivaSimmetrica();
            //Console.WriteLine("--IterativaSimmetriva--------------");
            //r.stampaIterativaSimmetrica();

        }
    }
}
