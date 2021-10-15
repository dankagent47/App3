using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App3
{
    public partial class Form1 : Form
    {
        private double Factorial(int x)
        {
            return x <= 1 ? x : x * Factorial(x - 1);
        }
            
        private double TaylorSeries(double x, int N) //should be SinTaylorSeries
        {
            double result = x;
            for (int n = 1; n < N; n++)
            {
                result += Math.Pow(-1, n) * Math.Pow(x, 2 * n + 1) / this.Factorial(2 * n + 1);
            }
            return result;
            
        }

        public Form1()
        {
            InitializeComponent();
            this.textBoxResult.Multiline = true;
            this.textBoxResult.WordWrap = false;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
                        
                int n = 16;
                double x_n, x_k, h;
                x_n = 0.1;
                x_k = 1;
                h = (x_k - x_n) / (double)n;

                string header = String.Format("Лаб. раб. 3 N1 Ст. гр. 10702220 Григелевича С. Т.\r\n" +                    
                    "N = {0}\r\n" +
                    "H = {1}\r\n\r\n", 
                    n, h);

                string results = "";

                for (double x_i = x_n; x_i <= x_k + h; x_i += h)
                {
                    double resultSin, resultSinTaylorSeries;
                    resultSin = Math.Round(Math.Sin(x_i), 3);
                    resultSinTaylorSeries = Math.Round(this.TaylorSeries(x_i, n), 3);
                    string result = String.Format("при x = {0:N3}  Y(x) = {1:N3}  S(x) = {2:N3}\r\n", x_i, resultSin, resultSinTaylorSeries);
                    results += result;
                }

                textBoxResult.Text = header + results;            
        }
        
    }
    
}
