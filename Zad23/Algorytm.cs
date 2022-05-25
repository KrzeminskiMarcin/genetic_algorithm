using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Algorytm
{
    public Dictionary<int, List<byte>> dostepneGeny = new Dictionary<int, List<byte>>();
    public List<DNA> generacja;
    public double najlepszy;
    public double srednia;
    public Random random = new Random((int)DateTime.Now.Ticks);
    public Dictionary<double, double> sinusy = new Dictionary<double, double>();
    public List<List<double>> xor = new List<List<double>>();
    public double[] xorWyniki = new double[4] { 0, 1, 1, 0 };
    
    public void XOR()
    {
        List<double> cos = new List<double>();
        cos.Add(0);
        cos.Add(0);
        xor.Add(cos);
        cos = new List<double>();
        cos.Add(0);
        cos.Add(1);
        xor.Add(cos);
        cos = new List<double>();
        cos.Add(1);
        cos.Add(0);
        xor.Add(cos);
        cos = new List<double>();
        cos.Add(1);
        cos.Add(1);
        xor.Add(cos);

    }
    public void wyznaczDostepneGeny(int dlugoscParametru)
    {
        for ( int i=0; i<Math.Pow(2,dlugoscParametru);i++)
        {
            List<byte> geny = new List<byte>();
            string s = Convert.ToString(i, 2);
            geny = s.PadLeft(dlugoscParametru, '0').Select(c => byte.Parse(c.ToString())).ToList();
            dostepneGeny.Add(i, geny);

        }
    }
    public List<DNA> stworzPopulacje(int wielkosc, int parametry)
    {
        generacja = new List<DNA>();
        //random = new Random();
        for (int i=0;i<wielkosc;i++)
        { 
            DNA czlonek = new DNA();
            for (int j = 0; j < dostepneGeny.First().Value.Count*parametry; j++)
            {
                byte x = Convert.ToByte(random.Next() % 2);
                czlonek.geny.Add(x);
            }
            generacja.Add(czlonek);
        }
        return generacja;
    }
    public void dekoduj(int min, int max, double wielkosc)
    {
        int dlugosc = dostepneGeny.First().Value.Count;
        double skok = (max - min) / (wielkosc-1);
        foreach(var x in generacja)
        {
            x.parametry = new List<double>();
            int c = x.geny.Count / dlugosc;
            for(int i=0;i<c;i++)
            {
                List<byte> parametr = x.geny.GetRange(dlugosc * i, dlugosc);
                foreach( var y in dostepneGeny)
                {
                    int m = 0;
                    for(int j=0;j<y.Value.Count;j++)
                    {
                        if(parametr[j] == y.Value[j])
                        {
                            m++;
                        }

                    }
                    if (m == dlugosc)
                    {
                        x.parametry.Add(min+(y.Key * skok));
                    }
                }

            }
        }
    }
    public void ObliczPrzystosowanie()
    {
        foreach(var x in generacja)
        {
            x.przystosowanie = Math.Sin(x.parametry[0] * 0.05) + Math.Sin(x.parametry[1] * 0.05) + 0.4 * Math.Sin(x.parametry[0] * 0.15) * Math.Sin(x.parametry[1] * 0.15);
        }
    }
    public void ObliczPrzystosowanie2()
    {
        foreach (var x in generacja)
        {
            x.przystosowanie = 0;
            foreach(var y in sinusy)
            {
                x.przystosowanie += Math.Pow(y.Value - (x.parametry[0] * Math.Sin(x.parametry[1] * y.Key + x.parametry[2])),2);
            }
            
        }
    }
    public DNA znajdzNajlepszego()
    {
        DNA best = new DNA();
        double max = 0;
        foreach(var x in generacja)
        {
            if( x.przystosowanie > max)
            {
                najlepszy = x.przystosowanie;
                max = najlepszy;
                best = x;

            }

        }
        return best;
    }
    public DNA znajdzNajlepszego2()
    {
        DNA best = new DNA();
        double min = 1000;
        foreach(var x in generacja)
        {
            if( x.przystosowanie < min)
            {
                najlepszy = x.przystosowanie;
                min = najlepszy;
                best = x;
            }
        }


        return best;
    }
    public void obliczSredniePrzystosowanie()
    {
        double i = 0;
        foreach( var x in generacja)
        {
            i += x.przystosowanie;
        }
        srednia = i / generacja.Count;

    }
    public DNA turniej(double wielkosc)
    {
        double iluUczestnikow = (wielkosc / 100) * generacja.Count;
        int ilu = Convert.ToInt32(Math.Round(iluUczestnikow));

        Console.WriteLine($"Rozmiar turnieju: {ilu},");
        List<DNA> turniej = new List<DNA>();
        DNA zwyciezca = new DNA();
        DNA zwyciezca2 = new DNA();
        int c = 0;
        int[] kto = new int[ilu];
        for(int j=0; j<ilu;j++)
        {
            kto[j] = 999;
        }
        for (int i=0; i<ilu;i++)
        {
            //random = new Random();
            int x = random.Next(generacja.Count);

            if(!kto.Contains(x))
            {
                Console.Write(x.ToString() + " ");
                turniej.Add(generacja[x]);
                kto[c] = x;
                c++;
            }
            else
            {
                i--;
            }
        }
        double max = double.MinValue;
        foreach(var p in turniej)
        {
            if(p.przystosowanie >max)
            {
                zwyciezca = p;
                max = p.przystosowanie;
            }
        }
        foreach(var x in zwyciezca.geny)
        {
            zwyciezca2.geny.Add(x);
        }
        return zwyciezca2;
    }
    public DNA turniej2(double wielkosc)
    {
        double iluUczestnikow = (wielkosc / 100) * generacja.Count;
        int ilu = Convert.ToInt32(Math.Round(iluUczestnikow));
        Console.Write($"Rozmiar turnieju: {ilu} ");
        List<DNA> turniej = new List<DNA>();
        DNA zwyciezca = new DNA();
        DNA zwyciezca2 = new DNA();
        int c = 0;
        int[] kto = new int[ilu];
        for (int i = 0; i < ilu; i++)
        {
            //random = new Random();
            int x = random.Next(generacja.Count);
            if (!kto.Contains(x))
            {
                Console.Write($"{x} ");
                turniej.Add(generacja[x]);
                kto[c] = x;
                c++;
            }
            else
            {
                i--;
            }
        }
        Console.WriteLine(" ");
        double max = double.MaxValue;

        //var wynik = turniej.OrderBy(p => p.przystosowanie).First();


        foreach (var p in turniej)
        {
            if (p.przystosowanie < max)
            {
                zwyciezca = p;
                max = p.przystosowanie;
            }
        }
        foreach (var x in zwyciezca.geny)
        {
            zwyciezca2.geny.Add(x);
        }
        return zwyciezca2;
    }
    public DNA Mutacja(DNA czlonek)
    {
        //random = new Random();
        int x = random.Next(czlonek.geny.Count);
        czlonek.geny[x] = Convert.ToByte((Convert.ToInt32(czlonek.geny[x]) + 1) % 2);
        return czlonek;
    }
    public void krzyzowanie(DNA rodzic1,DNA rodzic2)
    {
        //random = new Random();
        int x = random.Next(generacja.First().geny.Count);
        Console.WriteLine(x);
        DNA dziecko1 = new DNA();
        DNA dziecko2 = new DNA();
        for (int i=0;i<generacja.First().geny.Count; i++)
        {
            if(i<=x)
            {
                dziecko1.geny.Add(rodzic1.geny[i]);
                dziecko2.geny.Add(rodzic2.geny[i]);
            }
            else
            {
                dziecko1.geny.Add(rodzic2.geny[i]);
                dziecko2.geny.Add(rodzic1.geny[i]);
            }
        }
        rodzic1 = dziecko1;
        rodzic2 = dziecko2;
        
    }
    public List<DNA> StworzNowaGeneracje(double wielkoscTurnieju)
    {
        DNA najlepszy = znajdzNajlepszego();
        DNA najlepszy2 = new DNA();
        foreach (var x in najlepszy.geny)
        {
            najlepszy2.geny.Add(x);
        }
        List<DNA> nowaGeneracja = new List<DNA>();
        for (int i = 0; i < generacja.Count - 1; i++)
        {
            nowaGeneracja.Add(turniej(wielkoscTurnieju));
        }
        foreach( var x in nowaGeneracja)
        {
            Mutacja(x);
        }
        nowaGeneracja.Add(najlepszy2);
        return nowaGeneracja;
    }
    public List<DNA> StworzNowaGeneracje2(double wielkoscTurnieju)
    {
        DNA najlepszy = znajdzNajlepszego2();
        DNA najlepszy2 = new DNA();
        foreach (var x in najlepszy.geny)
        {
            najlepszy2.geny.Add(x);
        }
        List<DNA> nowaGeneracja = new List<DNA>();
        for (int i = 0; i < generacja.Count - 1; i++)
        {
            nowaGeneracja.Add(turniej2(wielkoscTurnieju));
        }
        krzyzowanie(nowaGeneracja[0], nowaGeneracja[1]);
        krzyzowanie(nowaGeneracja[2], nowaGeneracja[3]);
        krzyzowanie(nowaGeneracja[8], nowaGeneracja[9]);
        krzyzowanie(nowaGeneracja[10], nowaGeneracja[11]);
        for( int j=5;j<nowaGeneracja.Count;j++)
        {
            Mutacja(nowaGeneracja[j]);
        }
        nowaGeneracja.Add(najlepszy2);
        return nowaGeneracja;
    }
    public List<DNA> StworzNowaGeneracje3(double wielkoscTurnieju)
    {
        DNA najlepszy = znajdzNajlepszego2();
        DNA najlepszy2 = new DNA();
        foreach (var x in najlepszy.geny)
        {
            najlepszy2.geny.Add(x);
        }
        List<DNA> nowaGeneracja = new List<DNA>();
        for (int i = 0; i < generacja.Count - 1; i++)
        {
            nowaGeneracja.Add(turniej2(wielkoscTurnieju));
        }
        krzyzowanie(nowaGeneracja[0], nowaGeneracja[1]);
        krzyzowanie(nowaGeneracja[2], nowaGeneracja[3]);
        krzyzowanie(nowaGeneracja[8], nowaGeneracja[9]);
        krzyzowanie(nowaGeneracja[10], nowaGeneracja[11]);
        for (int j = 5; j < nowaGeneracja.Count; j++)
        {
            Mutacja(nowaGeneracja[j]);
        }
        nowaGeneracja.Add(najlepszy2);
        return nowaGeneracja;
    }
    public void Slowniczek()
    {
        sinusy.Add(-1.00000, 0.59554);
        sinusy.Add(-0.80000, 0.58813);
        sinusy.Add(-0.60000, 0.64181);
        sinusy.Add(-0.40000, 0.68587);
        sinusy.Add(-0.20000, 0.44783);
        sinusy.Add(0.00000, 0.40836);
        sinusy.Add(0.40000, -0.05933);
        sinusy.Add(0.60000, -0.12478);
        sinusy.Add(0.80000, -0.36847);
        sinusy.Add(1.00000, -0.39935);
        sinusy.Add(1.20000, -0.50881);
        sinusy.Add(1.40000, -0.63435);
        sinusy.Add(1.60000, -0.59979);
        sinusy.Add(1.80000, -0.64107);
        sinusy.Add(2.00000, -0.51808);
        sinusy.Add(2.20000, -0.38127);
        sinusy.Add(2.40000, -0.12349);
        sinusy.Add(2.60000, -0.09624);
        sinusy.Add(2.80000, 0.27893);
        sinusy.Add(3.00000, 0.48965);
        sinusy.Add(3.20000, 0.33089);
        sinusy.Add(3.40000, 0.70615);
        sinusy.Add(3.60000, 0.53342);
        sinusy.Add(3.80000, 0.43321);
        sinusy.Add(4.00000, 0.64790);
        sinusy.Add(4.20000, 0.48834);
        sinusy.Add(4.40000, 0.18440);
        sinusy.Add(4.60000, -0.02389);
        sinusy.Add(4.80000, -0.10261);
        sinusy.Add(5.00000, -0.33594);
        sinusy.Add(5.20000, -0.35101);
        sinusy.Add(5.40000, -0.62027);
        sinusy.Add(5.60000, -0.55719);
        sinusy.Add(5.80000, -0.66377);
        sinusy.Add(6.00000, -0.62740);
    }
    public void wagiXOR()
    {
        foreach (var x in generacja)
        {
            List<List<List<double>>> xor = new List<List<List<double>>>();
            List<List<double>> temp = new List<List<double>>();
            List<double> tmp = new List<double>();
            for(int i=0;i<x.parametry.Count;i++)
            {
                if(tmp.Count<3)
                {
                    tmp.Add(x.parametry[i]);
                }
                else
                {
                    temp.Add(tmp);
                    tmp = new List<double>();
                    i--;
                }
                if(temp.Count>=2)
                {
                    xor.Add(temp);
                    temp = new List<List<double>>();

                }
            }
            temp.Add(tmp);
            xor.Add(temp);
            x.parametryXOR = xor;
        }
    }
    public void ObliczPrzysosowanie3()
    {
        foreach(var x in generacja)
        {
            double sum = 0;
            for (int i = 0; i < xorWyniki.Length; i++)
            {
                List<double> tmp = propagacja(x.parametryXOR, xor[i]);
                sum += Math.Pow((xorWyniki[i] - tmp[0]), 2);
            }
            x.przystosowanie = sum;
        }  
    }
    public List<double> propagacja(List<List<List<double>>> parametry, List<double> wejscie)
    {
        List<double> input = wejscie;
        foreach(var x in parametry)
        {
            List<double> new_inpt = new List<double>();
            foreach(var y in x)
            {
                double aktywacja = aktywuj(y, input);
                double wyjscie = 1 / (1 + Math.Exp(-aktywacja));
                new_inpt.Add(wyjscie);
            }
            input = new_inpt;
        }
        return input;
    }
    public double aktywuj(List<double> parametr, List<double> wejscie)
    {
        double aktywacja = parametr.Last();
        for(int i=0; i<parametr.Count-1;i++)
        {
            aktywacja += parametr[i] * wejscie[i];
        }
        return aktywacja;
    }
}
