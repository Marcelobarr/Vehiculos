using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vehiculos
{
    public partial class Form1 : Form
    {

        List<Carros> carro = new List<Carros>();
        Boolean a = false;
        int c = 0;




        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        void agregar()
        {
            Carros a = new Carros();
            a.Placa = textBox1.Text;
            a.Marca = textBox2.Text;
            a.Modelo = textBox3.Text;
            a.Color = textBox4.Text;
            a.Precio_Km = Convert.ToDouble(textBox5.Text);
        }




    }
}
