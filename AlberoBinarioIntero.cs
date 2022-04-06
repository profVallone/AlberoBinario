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
                catch (Exception e) {}
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

        public void stampaIterativaAnticipata2()
        {
            Stack s = new Stack();
            s.Push(this);
            while (s.Count != 0)
            {
                //mi muovo sul ramo di sinistra
                AlberoBinarioIntero tmp = s.Pop() as AlberoBinarioIntero;
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
            while(curr != null || s.Count != 0)
            {
                if(curr != null)
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
                if(this.sx != null)
                    s += this.sx.ToString();
                if (this.dx != null)
                    s += this.dx.ToString() + ")";
            }
            return s;
        }

    }
}