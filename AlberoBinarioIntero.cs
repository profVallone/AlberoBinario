using System;
using System.Collections;


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

        public void stampa()
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
                    this.sx.stampa();
                }
                catch (Exception e) {}
                try
                {
                    this.dx.stampa();
                }
                catch (Exception e) { }
            }
        }

        public void stampaIterativa()
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

        public void stampaIterativa2()
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