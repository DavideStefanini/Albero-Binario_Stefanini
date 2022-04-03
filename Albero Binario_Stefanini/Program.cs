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

            //public override string ToString()
            //{
            //    if (dx != null && sx != null)
            //    {
            //        return this.val + "(" + sx + "," + dx + ")";
            //    }
            //    else if (sx == null && dx == null)
            //    {
            //        return this.val + "";
            //    }
            //    else if (sx != null && dx == null)
            //    {
            //        return this.val + "(" + sx + "," + 0 + ")";
            //    }
            //    else
            //    {
            //        return this.val + "(" + 0 + "," + dx + ")";
            //    }
            //}

            public override string ToString()
            {
                Stack<AlberoBinario> p = new Stack<AlberoBinario>();
                AlberoBinario t = this;
                string s = "";
                p.Push(t);

                while (p.Count > 0)
                {
                    t = p.Pop();
                    s += t.val + " ";

                    if(t.dx != null)
                    {
                        p.Push(t.dx);
                    }
                    if (t.sx != null)
                    {
                        p.Push(t.sx);
                    }
                }
                return s;
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

            Console.ReadKey();
        }
    }
}
