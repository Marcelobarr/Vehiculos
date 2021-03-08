using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        void escribir_vehiculo()
        {
            FileStream stream = new FileStream("Carro.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in carro)
            {
                write.WriteLine(d.Placa);
                write.WriteLine(d.Marca);
                write.WriteLine(d.Modelo);
                write.WriteLine(d.Color);
                write.WriteLine(d.Precio_Km);
            }
            write.Close();
        }

        void leer_vehiculo()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "Carro.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                Carros a = new Carros();
                a.Placa = reader.ReadLine();
                a.Marca = reader.ReadLine();
                a.Modelo = reader.ReadLine();
                a.Color = reader.ReadLine();
                a.Precio_Km = Convert.ToDouble(reader.ReadLine());
                carro.Add(a);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = carro;
                dataGridView1.Refresh();
            }
            reader.Close();
        }


    }
}
