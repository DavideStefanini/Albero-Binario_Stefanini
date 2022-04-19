using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albero_Binario_Stefanini
{
    class Program
    {
        class AlberoBinario
        {
            private int val;
            private AlberoBinario dx;
            private AlberoBinario sx;

            public AlberoBinario()
            {
                this.val = 0;

            }

            public AlberoBinario(int val, AlberoBinario sx, AlberoBinario dx)
            {
                this.val = val;
                this.sx = sx;
                this.dx = dx;
            }

            public AlberoBinario(int v)
            {
                this.val = v;
                this.sx = null;
                this.dx = null;
            }

            public void aggiungiFiglioSx(AlberoBinario a)
            {
                this.sx = a;
            }

            public void aggiungiFiglioDx(AlberoBinario a)
            {
                this.dx = a;
            }

            public bool inserisci(int n)
            {


                if (this.val == 0)
                {
                    this.val = n;

                    return true;
                }
                else if (this.val > n)
                {
                    if (dx == null)
                    {
                        dx = new AlberoBinario();
                        sx = new AlberoBinario();
                    }

                    return sx.inserisci(n);
                }
                else if (this.val <= n)
                {
                    if (dx == null)
                    {
                        dx = new AlberoBinario();
                        sx = new AlberoBinario();
                    }

                    return dx.inserisci(n);
                }
                return false;
            }

            public override string ToString()
            {
                if (dx != null && sx != null)
                {
                    return this.val + "(" + sx + "," + dx + ")";
                }
                else if (sx == null && dx == null)
                {
                    return this.val + "";
                }
                else if (sx != null && dx == null)
                {
                    return this.val + "(" + sx + "," + 0 + ")";
                }
                else
                {
                    return this.val + "(" + 0 + "," + dx + ")";
                }
            }

            public void stampaAnticipata()
            {
                Stack<AlberoBinario> p = new Stack<AlberoBinario>();
                AlberoBinario t = this;
                p.Push(t);

                while (p.Count > 0)
                {
                    t = p.Pop();
                    Console.Write(t.val + " ");

                    if (t.dx != null)
                    {
                        p.Push(t.dx);
                    }
                    if (t.sx != null)
                    {
                        p.Push(t.sx);
                    }
                }

                Console.WriteLine();
            }

            public void stampaSimmetrica()
            {
                Queue<AlberoBinario> c = new Queue<AlberoBinario>();
                AlberoBinario t = this;
                c.Enqueue(t);

                while (c.Count > 0)
                {
                    t = c.Dequeue();
                    Console.Write(t.val + " ");

                    if (t.sx != null)
                    {
                        c.Enqueue(t.sx);
                    }
                    if (t.dx != null)
                    {
                        c.Enqueue(t.dx);
                    }
                }

                Console.WriteLine();
            }
            
            public void stampaPosticipata()
            {
                List<AlberoBinario> l = new List<AlberoBinario>();
                Stack<AlberoBinario> s = new Stack<AlberoBinario>();
                s.Push(this);
                AlberoBinario tmp = this;
                while (s.Count != 0)
                {
                    tmp = s.Peek();

                    if (tmp.dx == null && tmp.sx == null)
                    {
                        s.Pop();
                        Console.Write(tmp.val + " ");
                    }
                    else 
                    {
                        if (l.Contains(tmp))
                        {
                            Console.Write(tmp.val + " ");
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
                Console.WriteLine();
            }

            public int Profondità()
            {
                Stack<AlberoBinario> s = new Stack<AlberoBinario>();
                s.Push(this);
                AlberoBinario tmp = null;
                AlberoBinario prec = null;
                int conta = 0;
                int contaMax = 0;
                while (s.Count != 0)
                {
                    tmp = s.Peek();

                    while (tmp.sx != null)
                    {
                        s.Push(tmp.sx);
                        tmp = tmp.sx;
                        conta++;
                        Console.WriteLine(conta + " " + tmp.val);
                    }
                    if (conta > contaMax)
                    { contaMax = conta; Console.WriteLine(conta + " max"); }

                    while (tmp.dx == null || tmp.dx == prec)
                    {

                        s.Pop();
                        if (tmp.dx != null)
                        { 
                            conta--; Console.WriteLine(conta + " " + tmp.val); 
                        }
                        prec = tmp;

                        if (s.Count != 0)
                        {
                            tmp = s.Peek();
                        }
                        else
                        {
                            return contaMax;
                        }
                    }
                    s.Push(tmp.dx);
                    prec = tmp.dx;
                }
                return contaMax;
            }



            public void alberoDegeneroSxDxGen()
            {
                Stack<AlberoBinario> p = new Stack<AlberoBinario>();
                AlberoBinario t = this;
                p.Push(t);
                bool DenSx = false;
                bool DenDx = false;
                bool generico = false;

                while (p.Count > 0)
                {
                    t = p.Pop();
                    if(t.dx != null&& t.sx != null)
                    {
                        generico = true;
                    }
                    if (t.dx != null)
                    {
                        DenDx = true;
                        p.Push(t.dx);
                    }
                    if (t.sx != null)
                    {
                        DenSx = true;
                        p.Push(t.sx);
                    }
                }


                if (generico == true)
                {
                    Console.WriteLine("L'albero è generico");
                }else if(DenDx==true && DenSx == false)
                {
                    Console.WriteLine("L'albero è degenere destro");
                }
                else if (DenSx == true && DenDx == false)
                {
                    Console.WriteLine("L'albero è degenere sinistro");
                }
                else
                {
                    Console.WriteLine("L'albero è generico");
                }
            }
        }

        static void Main(string[] args)
        {
            
            AlberoBinario a = new AlberoBinario();
            
            a.inserisci(70);
            a.inserisci(99);
            a.inserisci(31);
            a.inserisci(22);
            a.inserisci(69);
            a.inserisci(52);
            a.inserisci(3);
            a.inserisci(2);
            a.inserisci(71);

            Console.WriteLine(a);
            Console.WriteLine("------------------------------------------------------------------");
            a.stampaAnticipata();
            Console.WriteLine("------------------------------------------------------------------");
            a.stampaSimmetrica();
            Console.WriteLine("------------------------------------------------------------------");
            a.stampaPosticipata();
            Console.WriteLine("------------------------------------------------------------------");
            /*
            a.aggiungiFiglioSx(new AlberoBinario(7));
            a.aggiungiFiglioSx(new AlberoBinario(6));*/
            a.alberoDegeneroSxDxGen();
            


            Console.ReadKey();
        }
    }
}
