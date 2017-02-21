using System;
using System.Drawing;
using System.Windows.Forms;

namespace KolkoIKrz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            wyczyscPlansze();

        }
        public int Kolejka = 0;
        int[,] plansza = new int[3, 3];
        int sumaPrzekotna1;
        int sumaPrzekotna2;
        private void button_Click(object sender, EventArgs e)
        {

            if (sender is Button)
            {
                Button button = (Button)sender;
                string[] rozbitaNazwa = button.Name.Split('_');
                int wiersz = int.Parse(rozbitaNazwa[1]);
                int kolumna = int.Parse(rozbitaNazwa[2]);

                if (button.Text == "" && Kolejka % 2 == 0)
                {
                    button.Text = "o";
                    Kolejka++;
                    button.Enabled = false;
                    button.BackColor = Color.FromArgb(255, 0, 0);
                    plansza[wiersz, kolumna] = 3;

                }
                else if (button.Text == "" && Kolejka % 2 != 0)
                {
                    button.Text = "x";
                    Kolejka++;
                    button.Enabled = false;
                    button.BackColor = Color.LightSkyBlue;
                    plansza[wiersz, kolumna] = 10;
                }
                else
                {
                    MessageBox.Show("Bład");
                }
            }
            sumaPrzekotna1 = plansza[0, 0] + plansza[1, 1] + plansza[2, 2];
            sumaPrzekotna2 = plansza[2, 0] + plansza[1, 1] + plansza[0, 2];
            for (int i = 0; i < 3; i++)
            {
                int sumaWiersze = 0;
                int sumaKolumny = 0;
                for (int j = 0; j < 3; j++)
                {
                    sumaWiersze += plansza[i, j];
                    sumaKolumny += plansza[i, j];
                }
                if (sumaWiersze == 9 || sumaKolumny == 9 || sumaPrzekotna1 == 9 || sumaPrzekotna2 == 9)
                {
                    MessageBox.Show("wygral o");
                    wyczyscPlansze();
                }
                else if (sumaWiersze == 30 || sumaKolumny == 30 || sumaPrzekotna1 == 30 || sumaPrzekotna2 ==30)
                {                   
                    MessageBox.Show("wygral x");
                    wyczyscPlansze();
                }
                else if(Kolejka == 9)
                {
                    MessageBox.Show("Nikt nie wygrał");
                    wyczyscPlansze();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            wyczyscPlansze();
        }

        private void wyczyscPlansze()
        {
            foreach (Control kontrolka in this.Controls)
            {
                if (kontrolka is Button)
                {
                    if (kontrolka.Text != "Wyczysc")
                    {
                        kontrolka.Enabled = true;
                        kontrolka.Text = "";
                        kontrolka.BackColor = Color.White;
                    }
                }
            }
            Array.Clear(plansza, 0, plansza.Length);
            sumaPrzekotna1 = 0;
            sumaPrzekotna2 = 0;
            Kolejka = 0;
        }
    }
}
