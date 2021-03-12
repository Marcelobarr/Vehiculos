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
        List<Total> tot = new List<Total>();
        Boolean a = false;
        int c = 0;
  

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text))
            {
                agregar();
                repetidos();
                Carros f = new Carros();
                Total t = new Total();

                if (a)
                {
                    MessageBox.Show("La placa del vehiculo ya esta registrada, por favor vuelva a intentarlo");
                    textBox1.Clear();
                }
                else
                {


                    f.Placa = textBox1.Text;
                    f.Marca = textBox2.Text;
                    f.Modelo = textBox3.Text;
                    f.Color = textBox4.Text;
                    f.Precio_Km = Convert.ToInt32(textBox5.Text);
                    carro.Add(f);
                    MessageBox.Show("El vehiculo se ha registrado correctamente");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    escribir_vehiculo();

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = carro;
                    dataGridView1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("¡ERROR!, Debe llenar todos los campos");
            }
            a = false;
            c = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leer_vehiculo();
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

        void repetidos()
        {
            while (a == false && c < carro.Count)
            {
                if (carro[c].Placa.CompareTo(textBox1.Text) == 0)
                {
                    a = true;
                }
                else
                {
                    c++;
                }
            }

        }

        void escribir_total()
        {
            FileStream stream = new FileStream("Total.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);

            foreach (var d in tot)
            {
                write.WriteLine(d.Placa);
                write.WriteLine(d.Marca);
                write.WriteLine(d.Modelo);
                write.WriteLine(d.Color);
                write.WriteLine(d.Precio_km);
                write.WriteLine(d.F_devolucion);
                write.WriteLine(d.Tot);

            }
            write.Close();
        }

        void leer_total()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "Total.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);

            while (reader.Peek() > -1)
            {
                Total a = new Total();
                a.Placa = reader.ReadLine();
                a.Marca = reader.ReadLine();
                a.Modelo = reader.ReadLine();
                a.Color = reader.ReadLine();
                a.Precio_km = Convert.ToDouble(reader.ReadLine());
                a.F_devolucion = reader.ReadLine();
                a.Tot = Convert.ToDouble(reader.ReadLine());

                tot.Add(a);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = tot;
                dataGridView1.Refresh();

            }
            reader.Close();
        }
    }
}
