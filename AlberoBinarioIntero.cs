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
            AlberoBinarioIntero tmp = this;
            while (s.Count != 0)
            {
                //mi muovo sul ramo di sinistra
                do
                {
                    System.Console.WriteLine(tmp.val);
                    s.Push(tmp);
                    tmp = tmp.sx;
                } while (tmp != null);
                
                //risalgo l'albero finchè non trovo un sottoalbero di destra
                do 
                {
                    tmp = s.Pop() as AlberoBinarioIntero;
                } while (tmp.dx == null);
                //aggiorno il nodo temporaneo
                tmp = tmp.dx;
            }  
        }

        public void stampaIterativaPosticipata()
        {
            Stack s = new Stack();
            s.Push(this);
            AlberoBinarioIntero tmp = this;
            AlberoBinarioIntero prec = null;
            while (s.Count != 0)
            {
                //mi muovo sul ramo di sinistra
                while (tmp.sx != null)
                {
                    s.Push(tmp.sx);
                    tmp = tmp.sx;
                } 
                //estraggo l'elemento in cima
                tmp = s.Pop() as AlberoBinarioIntero;

                //risalgo l'albero finchè non trovo un sottoalbero di destra
                while(tmp.dx == null || tmp.dx == prec)
                {
                    //stampo il nodo se è foglia oppure 
                    //ho già visitato il sottoalbero di destra
                    Console.WriteLine(tmp.val);
                    
                    //risalgo anche il precedente
                    prec = tmp;
                    
                    //verifico che non ho stampato la radice dell'albero
                    if (s.Count != 0)
                        //ho ancora nodi da visitare
                        tmp = s.Pop() as AlberoBinarioIntero;
                    else
                        //ho visitato l'intero albero
                        return;
                }

                //il nodo considerato non è nè foglia nè radice già visitata
                //reinserisco il nodo nella pila e scendo a destra
                s.Push(tmp);
                
                tmp = tmp.dx;
                s.Push(tmp);
                
                //aggiorno il nodo precedente
                prec = tmp;
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
                tmp = s.Peek() as AlberoBinarioIntero;
                if (tmp.dx == null && tmp.sx == null)
                {
                    s.Pop();
                    Console.WriteLine(tmp.val);
                }
                else
                {
                    if (l.Contains(tmp))
                    {
                        Console.WriteLine(tmp.val);
                        l.Remove(tmp);
                        s.Pop();
                    }
                    else
                    {
                        l.Add(tmp);
                        if (tmp.dx != null)
                            s.Push(tmp.dx);
                        if (tmp.sx != null)
                            s.Push(tmp.sx);
                    }
                    
                }
              
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