using System;
using System.Collections;
using System.Collections.Generic;

namespace ProgettoAlbero
{
    internal class AlberoBinarioIntero
    {
        private int val;
        private AlberoBinarioIntero sx;
        private AlberoBinarioIntero dx;

        public AlberoBinarioIntero(int val, AlberoBinarioIntero sx, AlberoBinarioIntero dx)
        {
            this.val = val;
            this.sx = sx;
            this.dx = dx;
        }

        public AlberoBinarioIntero(int v)
        {
            this.val = v;
            this.sx = null;
            this.dx = null;
        }

        public void aggiungiFiglioSx(AlberoBinarioIntero a)
        {
            this.sx = a;
        }

        public void aggiungiFiglioDx(AlberoBinarioIntero a)
        {
            this.dx = a;
        }

        public AlberoBinarioIntero getSx()
        {
            return sx;
        }

        public AlberoBinarioIntero getDx()
        {
            return dx;
        }

        public int getVal()
        {
            return val;
        }
        public void stampaRicorsivaAnticipata()
        {
            if (this.sx == null && this.dx == null)
            {
                System.Console.WriteLine(this.val);
            }
            else
            {
                System.Console.WriteLine(this.val);
                try
                {
                    this.sx.stampaRicorsivaAnticipata();
                }
                catch (Exception e) { }
                try
                {
                    this.dx.stampaRicorsivaAnticipata();
                }
                catch (Exception e) { }
            }
        }

        public void stampaRicorsivaPosticipata()
        {
            if (this.sx == null && this.dx == null)
            {
                System.Console.WriteLine(this.val);
            }
            else
            {

                try
                {
                    this.sx.stampaRicorsivaPosticipata();
                }
                catch (Exception e) { }
                try
                {
                    this.dx.stampaRicorsivaPosticipata();
                }
                catch (Exception e) { }
                System.Console.WriteLine(this.val);
            }
        }

        public void stampaRicorsivaSimmetrica()
        {
            if (this.sx == null && this.dx == null)
            {
                System.Console.WriteLine(this.val);
            }
            else
            {

                try
                {
                    this.sx.stampaRicorsivaSimmetrica();
                }
                catch (Exception e) { }
                System.Console.WriteLine(this.val);
                try
                {
                    this.dx.stampaRicorsivaSimmetrica();
                }
                catch (Exception e) { }

            }
        }

        public void stampaIterativaAnticipata()
        {
            Stack s = new Stack();
            s.Push(this);
            AlberoBinarioIntero tmp = null;
            while (s.Count != 0)
            {
                //estraggo l'elemento in cima
                tmp = s.Peek() as AlberoBinarioIntero;
                Console.WriteLine(tmp.val);
                //mi muovo sul ramo di sinistra
                while (tmp.sx != null)
                {
                    //stampo ogni radice
                    s.Push(tmp.sx);
                    tmp = tmp.sx;
                    Console.WriteLine(tmp.val);
                }

                //risalgo l'albero finchè non trovo un sottoalbero di destra
                do
                {
                    if (s.Count != 0)
                        tmp = s.Pop() as AlberoBinarioIntero;
                    else
                        return;
                } while (tmp.dx == null);
                //inserisco il sottoalbero di destra
                s.Push(tmp.dx);
            }
        }

        public void stampaIterativaPosticipata()
        {
            Stack s = new Stack();
            s.Push(this);
            AlberoBinarioIntero tmp = null;
            AlberoBinarioIntero prec = null;
            while (s.Count != 0)
            {
                //estraggo l'elemento in cima
                tmp = s.Peek() as AlberoBinarioIntero;

                //mi muovo sul ramo di sinistra
                while (tmp.sx != null)
                {
                    s.Push(tmp.sx);
                    tmp = tmp.sx;
                }

                //risalgo l'albero finchè non trovo un sottoalbero di destra
                while (tmp.dx == null || tmp.dx == prec)
                {
                    //stampo il nodo se è foglia oppure 
                    //ho già visitato il sottoalbero di destra
                    Console.WriteLine(tmp.val);
                    s.Pop();

                    //risalgo anche il precedente
                    prec = tmp;

                    //verifico che non ho stampato la radice dell'albero
                    if (s.Count != 0)
                        //ho ancora nodi da visitare
                        tmp = s.Peek() as AlberoBinarioIntero;
                    else
                        //ho visitato l'intero albero
                        return;
                }

                //il nodo considerato non è nè foglia nè radice già visitata
                //inserisco il nodo di destra nello stack per
                //poter considerare il nuovo sottoalbero
                s.Push(tmp.dx);

                //aggiorno il nodo precedente
                prec = tmp.dx;
            }
        }

        public void stampaIterativaSimmetrica()
        {
            Stack s = new Stack();
            s.Push(this);
            AlberoBinarioIntero tmp = null;
            while (s.Count != 0)
            {
                //estraggo l'elemento in cima
                tmp = s.Peek() as AlberoBinarioIntero;
                //Console.WriteLine(tmp.val);
                //mi muovo sul ramo di sinistra
                while (tmp.sx != null)
                {
                    s.Push(tmp.sx);
                    tmp = tmp.sx;
                }

                //risalgo l'albero finchè non trovo un sottoalbero di destra
                do
                {
                    if (s.Count != 0)
                    {
                        tmp = s.Pop() as AlberoBinarioIntero;
                        Console.WriteLine(tmp.val);
                    }
                    else
                        return;
                } while (tmp.dx == null);
                //inserisco il sottoalbero di destra
                s.Push(tmp.dx);
            }
        }

        public void stampaIterativaAnticipata2()
        {
            AlberoBinarioIntero tmp = this;
            Stack s = new Stack();
            s.Push(tmp);
            while (s.Count != 0)
            {
                //mi muovo sul ramo di sinistra
                tmp = s.Pop() as AlberoBinarioIntero;
                Console.WriteLine(tmp.val);
                if (tmp.dx != null)
                    s.Push(tmp.dx);
                if (tmp.sx != null)
                    s.Push(tmp.sx);
            }
        }

        public void stampaIterativaPosticipata2()
        {
            List<AlberoBinarioIntero> l = new List<AlberoBinarioIntero>();
            Stack s = new Stack();
            s.Push(this);
            AlberoBinarioIntero tmp = this;
            while (s.Count != 0)
            {
                //considero la cima dello stack
                tmp = s.Peek() as AlberoBinarioIntero;

                //è un nodo foglia, lo stampo
                if (tmp.dx == null && tmp.sx == null)
                {
                    s.Pop();
                    Console.WriteLine(tmp.val);
                }
                else //è una radice
                {
                    //ho già visitato questa radice se è si allora
                    //vuol dire che sto risalendo e quindi la devo stampare
                    //e rimuovere dall'elenco delle radici e dallo stack
                    if (l.Contains(tmp))
                    {
                        Console.WriteLine(tmp.val);
                        l.Remove(tmp);
                        s.Pop();
                    }
                    else
                    {//è la prima volta che visito la radice
                        //vuol dire che sto scendendo
                        //aggiungo la radice alla lista ed i figli allo stack
                        l.Add(tmp);
                        if (tmp.dx != null)
                            s.Push(tmp.dx);
                        if (tmp.sx != null)
                            s.Push(tmp.sx);
                    }

                }

            }
        }


        public void stampaIterativaAnticipata3()
        {
            Stack s = new Stack();
            AlberoBinarioIntero curr = this;
            while (curr != null || s.Count != 0)
            {
                if (curr != null)
                {
                    s.Push(curr);
                    Console.WriteLine(curr.val);
                    curr = curr.sx;
                }
                else
                {
                    curr = s.Pop() as AlberoBinarioIntero;
                    curr = curr.dx;
                }
            }
        }

        public void stampaIterativaPosticipata3()
        {
            Stack s = new Stack();
            AlberoBinarioIntero curr = this;
            AlberoBinarioIntero prec = null;
            while (curr != null || s.Count != 0)
            {
                if (curr != null)
                {
                    s.Push(curr);
                    curr = curr.sx;
                }
                else
                {
                    curr = s.Peek() as AlberoBinarioIntero;
                    if (curr.dx == prec || curr.dx == null)
                    {
                        Console.WriteLine(curr.val);
                        s.Pop();
                        prec = curr;
                        curr = null;
                    }
                    else
                    {
                        curr = curr.dx;
                    }
                }
            }
        }

        public override string ToString()
        {
            string s = "";
            if (this.sx == null && this.dx == null)
            {
                return "(" + this.val + ")";
            }
            else
            {
                s += "(" + this.val;
                if (this.sx != null)
                    s += this.sx.ToString();
                if (this.dx != null)
                    s += this.dx.ToString() + ")";
                else
                    s += ")";
            }
            return s;
        }

        public void degenere()
        {
            AlberoBinarioIntero curr = this;
            //degenereSx??
            if (curr.sx != null && curr.dx == null)
            {
                while (curr.sx != null && curr.dx == null)
                {
                    curr = curr.sx;
                }
                if (curr.dx == null)
                {
                    Console.WriteLine("Albero degenere sx");
                    return;
                }
                else
                {
                    curr = curr.dx;
                }
            }
            //degenereDx??
            else if (curr.sx == null && curr.dx != null)
            {
                while (curr.sx == null && curr.dx != null)
                {
                    curr = curr.dx;
                }
                if (curr.sx == null)
                {
                    Console.WriteLine("Albero degenere dx");
                    return;
                }
                else
                {
                    curr = curr.sx;
                }
            }
            else if (curr.sx != null && curr.dx != null)
            {
                Console.WriteLine("Albero non degenere");
                return;
            }
            //mi trovo nel caso in cui stavo scendendo tutto a sx
            // o tutto a dx ma poi trovo un nodo con un figlio dall'altra parte
            while (!(curr.dx == null && curr.sx == null))
            {
                if (curr.sx != null && curr.dx == null)
                    curr = curr.sx;
                else if (curr.sx == null && curr.dx != null)
                    curr = curr.dx;
                else
                {
                    Console.WriteLine("Albero non degenere");
                    return;
                }
            }
            Console.WriteLine("Albero degenere generico");
            return;  

        }
        public int radiceMaggiore_Caruso()
        {
            int somma = 0;
            if (sx != null || dx != null)
            {

                if (this.sx != null)
                    somma += this.sx.radiceMaggiore_Caruso();
                if (this.dx != null)
                    somma += this.dx.radiceMaggiore_Caruso();
                if (this.val > somma)
                {
                    Console.WriteLine(this.val);
                }
            }
            return somma + this.val;
        }

        public void radiceMaggiore()
        {
            if (!this.foglia())
            {
                int somma = 0;
                if (this.sx != null)
                    somma += this.sx.sommaAlbero();
                if (this.dx != null)
                    somma += this.dx.sommaAlbero();
                if (this.val > somma)
                {
                    Console.WriteLine(this.val);
                }
                if (this.sx != null)
                    this.sx.radiceMaggiore();
                if (this.dx != null)
                    this.dx.radiceMaggiore();
            }
        }

        private bool foglia()
        {
            return this.sx == null && this.dx == null;
        }

        public int sommaAlbero()
        {
            if(this.foglia())
            {
                return this.val;
            }
            else
            {
                int somma = 0;
                if (this.sx != null)
                    somma += this.sx.sommaAlbero();
                if (this.dx != null)
                    somma += this.dx.sommaAlbero();
                return  somma + this.val;
            }
        }

        public bool ricerca_errata(int val)
        {
            if (this.val == val)
                return true;
            else
            {
                if (sx != null)
                    sx.ricerca(val);
                if (dx != null)
                    dx.ricerca(val);
            }
            return false;
        }

        public bool ricerca(int val)
        {
            bool trovato = false;
            if (this.val == val)
                trovato = true;
            else
            {
                if (sx != null && sx.ricerca(val) == true)
                    {
                        trovato = true;
                    } 
                else if (dx != null && dx.ricerca(val) == true)
                    {
                        trovato = true;
                    }
            }
            return trovato;
        }

        public bool ricercaBinariaRicorsiva(int val)
        {
           
            if (this.val == val)
                return true;
            else
            {
                if (this.val > val && dx != null)
                {
                    return dx.ricercaBinariaRicorsiva(val);
                }
                else if (this.val < val && sx != null)
                {
                    return sx.ricercaBinariaRicorsiva(val);
                }
            }
            return false;
        }

        public int sommaFoglieRicorsiva()
        {
            int somma = 0;
            if (this.foglia())
            {
                somma += this.val;
            }
            else 
            {
                if(sx != null)
                    somma += sx.sommaFoglieRicorsiva();
                if(dx!=null)
                    somma += dx.sommaFoglieRicorsiva();
            }
            return somma;
        }

        public int SommaFoglieIterativa()
        {
            AlberoBinarioIntero tmp = this;
            Stack s = new Stack();
            int somma = 0;
            s.Push(tmp);
            while (s.Count != 0)
            {
                //mi muovo sul ramo di sinistra
                tmp = s.Pop() as AlberoBinarioIntero;
                if (tmp.foglia())
                    somma += tmp.val;
                Console.WriteLine(tmp.val);
                if (tmp.dx != null)
                    s.Push(tmp.dx);
                if (tmp.sx != null)
                    s.Push(tmp.sx);
            }
            return somma;
        }

    }

}