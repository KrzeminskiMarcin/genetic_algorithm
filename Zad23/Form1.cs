using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zad23
{
    public partial class Form1 : Form
    {
        private Algorytm ga;
        private Algorytm gb;
        private Algorytm temp;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int generacja = 0;
            lvLista.Clear();
            string text = "";
            lvLista.View = View.List;
            int dlugoscChromosomow = Decimal.ToInt32(numChromosomy.Value);
            int wielkoscPopulacji = Decimal.ToInt32(numWielkoscPopulacji.Value);
            int min = Decimal.ToInt32(numMin.Value);
            int max = Decimal.ToInt32(numMax.Value);
            int iteracje = Decimal.ToInt32(numIteracje.Value);
            double wielkoscTurnieju = decimal.ToDouble(numTurniej.Value);
            if( dlugoscChromosomow>=3)
            {
                if( iteracje >=20)
                {
                    if(wielkoscPopulacji>=9 && wielkoscPopulacji%2==1)
                    {
                        if(min==0 && max==100)
                        {
                            if (Convert.ToInt32(Math.Round((wielkoscTurnieju / 100) * wielkoscPopulacji)) >= 2)
                            {
                                ga = new Algorytm();
                                gb = new Algorytm();
                                ga.wyznaczDostepneGeny(dlugoscChromosomow);
                                ga.stworzPopulacje(wielkoscPopulacji, 2);
                                ga.dekoduj(min, max, Math.Pow(2, dlugoscChromosomow));
                                ga.ObliczPrzystosowanie();
                                ga.znajdzNajlepszego();
                                ga.obliczSredniePrzystosowanie();
                                ListViewItem item = new ListViewItem();
                                text = "najlepszy " + ga.najlepszy.ToString() + " średnia " + ga.srednia.ToString();
                                item.Text = text;
                                item.Tag = generacja;
                                lvLista.Items.Add(item);

                                for (int i = 0; i < iteracje; i++)
                                {
                                    gb.generacja = ga.StworzNowaGeneracje(wielkoscTurnieju);
                                    gb.dostepneGeny = ga.dostepneGeny;
                                    gb.dekoduj(min, max, Math.Pow(2, dlugoscChromosomow));
                                    gb.ObliczPrzystosowanie();
                                    gb.znajdzNajlepszego();
                                    gb.obliczSredniePrzystosowanie();
                                    ListViewItem ajtem = new ListViewItem();
                                    text = "najlepszy " + gb.najlepszy.ToString() + " średnia " + gb.srednia.ToString();
                                    ajtem.Text = text;
                                    ajtem.Tag = generacja;
                                    lvLista.Items.Add(ajtem);
                                    ga = gb;
                                }
                            }
                            else
                            {
                                string message = "Rozmiar turnieju minimum 2 dla zadania 1(17% dla rozmiaru populacji równemu 9)";
                                MessageBox.Show(message);
                            }
                        }
                        else
                        {
                            string message = "Przedział zmiennosci[0;100] dla zadania 1";
                            MessageBox.Show(message);
                        }
                    }
                    else
                    {
                        string message = "Wielkosc populacji większa niż 9 i nieparzysta dla zadania 1";
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    string message = "Minimum 20 iteracji dla zadania 1";
                    MessageBox.Show(message);
                }
            }
            else
            {
                string message = "Minimum 3 chromosomy na parametr dla zadania 1";
                MessageBox.Show(message);
            }
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            int generacja = 0;
            lvLista.Clear();
            string text = "";
            lvLista.View = View.List;
            int dlugoscChromosomow = Decimal.ToInt32(numChromosomy.Value);
            int wielkoscPopulacji = Decimal.ToInt32(numWielkoscPopulacji.Value);
            int min = Decimal.ToInt32(numMin.Value);
            int max = Decimal.ToInt32(numMax.Value);
            int iteracje = Decimal.ToInt32(numIteracje.Value);
            double wielkoscTurnieju = decimal.ToDouble(numTurniej.Value);
            if (dlugoscChromosomow >= 4)
            {
                if(iteracje>=100)
                {
                    if(wielkoscPopulacji==13)
                    {
                        if (Convert.ToInt32(Math.Round((wielkoscTurnieju / 100) * wielkoscPopulacji)) == 3)
                        {
                            if(min==0 && max==3)
                            {
                                ga = new Algorytm();
                                gb = new Algorytm();
                                ga.wyznaczDostepneGeny(dlugoscChromosomow);
                                ga.stworzPopulacje(wielkoscPopulacji, 3);
                                ga.dekoduj(min, max, Math.Pow(2, dlugoscChromosomow));
                                ga.Slowniczek();
                                ga.ObliczPrzystosowanie2();
                                ga.obliczSredniePrzystosowanie();
                                ga.znajdzNajlepszego2();
                                ListViewItem item = new ListViewItem();
                                text = "najlepszy " + ga.najlepszy.ToString() + " średnia " + ga.srednia.ToString();
                                item.Text = text;
                                item.Tag = generacja;
                                lvLista.Items.Add(item);
                                for (int i = 0; i < iteracje; i++)
                                {
                                    gb.generacja = ga.StworzNowaGeneracje2(wielkoscTurnieju);
                                    gb.dostepneGeny = ga.dostepneGeny;
                                    gb.sinusy = ga.sinusy;
                                    gb.dekoduj(min, max, Math.Pow(2, dlugoscChromosomow));
                                    gb.ObliczPrzystosowanie2();
                                    gb.znajdzNajlepszego2();
                                    gb.obliczSredniePrzystosowanie();
                                    ListViewItem ajtem = new ListViewItem();
                                    text = "najlepszy " + gb.najlepszy.ToString() + " średnia " + gb.srednia.ToString();
                                    ajtem.Text = text;
                                    ajtem.Tag = generacja;
                                    lvLista.Items.Add(ajtem);
                                    ga = gb;
                                }
                            }
                            else
                            {
                                string message = "Przedział zmiennosci[0;3] dla zadania 2";
                                MessageBox.Show(message);
                            }

                        }
                        else
                        {
                            string message = "Rozmiar turnieju 3 dla zadania 2(20-26%)";
                            MessageBox.Show(message);
                        }
                    }
                    else
                    {
                        string message = "Wielkosc populacji 13 dla zadania 2";
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    string message = "Minimum 100 iteracji dla zadania 2";
                    MessageBox.Show(message);
                }
            }
            else
            {
                string message = "Minimum 4 chromosomy na parametr dla zadania 2";
                MessageBox.Show(message);
            }
        }

        private void btnStart3_Click(object sender, EventArgs e)
        {
            int generacja = 0;
            lvLista.Clear();
            string text = "";
            lvLista.View = View.List;
            int dlugoscChromosomow = Decimal.ToInt32(numChromosomy.Value);
            int wielkoscPopulacji = Decimal.ToInt32(numWielkoscPopulacji.Value);
            int min = Decimal.ToInt32(numMin.Value);
            int max = Decimal.ToInt32(numMax.Value);
            int iteracje = Decimal.ToInt32(numIteracje.Value);
            double wielkoscTurnieju = decimal.ToDouble(numTurniej.Value);
            if(dlugoscChromosomow>=3)
            {
                if(iteracje>=100)
                {
                    if (wielkoscPopulacji==13)
                    {
                        if (Convert.ToInt32(Math.Round((wielkoscTurnieju / 100) * wielkoscPopulacji)) == 3)
                        {
                            if (min == -10 && max == 10)
                            {
                                ga = new Algorytm();
                                gb = new Algorytm();
                                ga.wyznaczDostepneGeny(dlugoscChromosomow);
                                ga.stworzPopulacje(wielkoscPopulacji, 9);
                                ga.dekoduj(min, max, Math.Pow(2, dlugoscChromosomow));
                                ga.wagiXOR();
                                ga.XOR();
                                ga.ObliczPrzysosowanie3();
                                ga.znajdzNajlepszego2();
                                ga.obliczSredniePrzystosowanie();
                                ListViewItem item = new ListViewItem();
                                text = "najlepszy " + ga.najlepszy.ToString() + " średnia " + ga.srednia.ToString();
                                item.Text = text;
                                item.Tag = generacja;
                                lvLista.Items.Add(item);
                                for (int i = 0; i < iteracje; i++)
                                {
                                    gb.generacja = ga.StworzNowaGeneracje3(wielkoscTurnieju);
                                    gb.dostepneGeny = ga.dostepneGeny;
                                    gb.xor = ga.xor;
                                    gb.xorWyniki = ga.xorWyniki;
                                    gb.dekoduj(min, max, Math.Pow(2, dlugoscChromosomow));
                                    gb.wagiXOR();
                                    gb.ObliczPrzysosowanie3();
                                    gb.znajdzNajlepszego2();
                                    gb.obliczSredniePrzystosowanie();
                                    ListViewItem ajtem = new ListViewItem();
                                    text = "najlepszy " + gb.najlepszy.ToString() + " średnia " + gb.srednia.ToString();
                                    ajtem.Text = text;
                                    ajtem.Tag = generacja;
                                    lvLista.Items.Add(ajtem);
                                    ga = gb;
                                }
                                string x = "";
                                var p = ga.znajdzNajlepszego2().parametryXOR;
                                var a = ga.propagacja(p, ga.xor[0]);
                                var b = ga.propagacja(p, ga.xor[1]);
                                var c = ga.propagacja(p, ga.xor[2]);
                                var d = ga.propagacja(p, ga.xor[3]);
                                x += " 0 0 = " + a[0];
                                x += " 0 1 = " + b[0];
                                x += " 1 0 = " + c[0];
                                x += " 1 1 = " + d[0];
                                MessageBox.Show("wyniki najlepszego" + x + " ");
                            }
                            else
                            {
                                string message = "Przedział zmiennosci[-10;10] dla zadania 3";
                                MessageBox.Show(message);
                            }
                        }
                        else
                        {
                            string message = "Rozmiar turnieju 3 dla zadania 3(20-26%)";
                            MessageBox.Show(message);
                        }
                    }
                    else
                    {
                        string message = "Wielkosc populacji 13 dla zadania 3";
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    string message = "Minimum 100 iteracji dla zadania 3";
                    MessageBox.Show(message);
                }
            }
            else
            {
                string message = "Minimum 3 chromosomy na parametr dla zadania 3";
                MessageBox.Show(message);
            }
        }
    }
}
