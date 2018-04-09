using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void Wyswietl_Wlasnosci(Decode a)
        {
           
            Console.WriteLine("Dlugosc: " + a.dlugosc);
            Console.WriteLine("Precyzja: " +a. precyzja);
            Console.WriteLine("Wysokosc: " + a.wysokosc);
            Console.WriteLine("Szerokosc: " + a.szerokosc);
            label1.Text = "Dlugosc:" + a.dlugosc;
            label2.Text = "Prezycja:" + a.precyzja;
            label3.Text = "Wysokosc:" + a.wysokosc;
            label4.Text = "Szerokosc:" + a.szerokosc;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] Obrazek = File.ReadAllBytes("picture.jpg");
            Bitmap ob=new Bitmap ("picture.jpg");
            //FFT fft=new FFT(ob);
            Decode dekoduj = new Decode();
            dekoduj.Dekoduj_Wlasnosci(Obrazek);
            Wyswietl_Wlasnosci(dekoduj);
            //fft.Displayimage();
            //fft.FFTPlot();
            //pictureBox1.Load("ob");
            pictureBox1.Image = Image.FromFile("picture.jpg");
            FFT fft = new FFT((Bitmap)pictureBox1.Image);
            fft.ForwardFFT();
            fft.FFTShift();
            fft.FFTPlot(fft.FFTShifted);

            pictureBox2.Image = (Image)fft.FourierPlot;
            pictureBox3.Image = (Image)fft.PhasePlot;
            fft.InverseFFT();
            pictureBox4.Image = fft.Obj;
            //fft.ForwardFFT();
            //fft.FFTPlot();
            //Bitmap ob1;
            //ob1 = fft.Displayimage();
            //pictureBox1.Size = new Size(dekoduj.szerokosc, dekoduj.wysokosc);
            //pictureBox1.Image = ob1;
            //Console.ReadKey();
        }
    }
}
