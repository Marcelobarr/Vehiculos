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
    public partial class Form3 : Form
    {
        List<Alquiler> alqui = new List<Alquiler>();
        List<Clientes> cliente = new List<Clientes>();
        List<Carros> carro = new List<Carros>();

        Boolean a = false;
        int c = 0;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                agregar();
                repetidos();
                Alquiler f = new Alquiler();

                f.Nit = comboBox1.SelectedValue.ToString();
                f.Placa = comboBox2.SelectedValue.ToString();
                f.Fecha_Alquiler = dateTimePicker1.Value.ToString();
                f.Fecha_Devolucion = dateTimePicker2.Value.ToString();
                f.K_Recorridos = Convert.ToDouble(textBox1.Text);
                alqui.Add(f);
                MessageBox.Show("Se registro correctamente el alquiler");
                textBox1.Clear();
                escribir_alquiler();
            }
            else
            {
                MessageBox.Show("Debe de llenar todos los campos");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            leer_nit();
            leer_placa();
            leer_alquiler();
        }

        void agregar()
        {
            Alquiler c = new Alquiler();
            c.Nit = comboBox1.SelectedValue.ToString();
            c.Placa = comboBox2.SelectedValue.ToString();
            c.Fecha_Alquiler = dateTimePicker1.Value.ToString();
            c.Fecha_Devolucion = dateTimePicker2.Value.ToString();
            c.K_Recorridos = Convert.ToDouble(textBox1.Text);
        }

        void escribir_alquiler()
        {
            FileStream stream = new FileStream("Alquiler.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in alqui)
            {
                write.WriteLine(d.Nit);
                write.WriteLine(d.Placa);
                write.WriteLine(d.Fecha_Alquiler);
                write.WriteLine(d.Fecha_Devolucion);
                write.WriteLine(d.K_Recorridos);
            }
            write.Close();
        }

        void leer_alquiler()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "Alquiler.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                Alquiler a = new Alquiler();
                a.Nit = reader.ReadLine();
                a.Placa = reader.ReadLine();
                a.Fecha_Alquiler = reader.ReadLine();
                a.Fecha_Devolucion = reader.ReadLine();
                a.K_Recorridos = Convert.ToDouble(reader.ReadLine());
                alqui.Add(a);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = alqui;
                dataGridView1.Refresh();
            }
            reader.Close();
        }

        void leer_placa()
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

            }
            reader.Close();

            comboBox2.DisplayMember = "Placa";
            comboBox2.ValueMember = "Modelo";

            comboBox2.DataSource = null;
            comboBox2.DataSource = carro;
            comboBox2.Refresh();
        }


        void leer_nit()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "Cliente.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                Clientes a = new Clientes();
                a.Nit = reader.ReadLine();
                a.Nombre = reader.ReadLine();
                a.Direccion = reader.ReadLine();
                cliente.Add(a);


            }
            reader.Close();

            comboBox1.DisplayMember = "NIT";
            comboBox1.ValueMember = "Nombre";

            comboBox1.DataSource = null;
            comboBox1.DataSource = cliente;
            comboBox1.Refresh();
        }

        void repetidos()
        {
            while (a == false && c < alqui.Count)
            {
                if (alqui[c].Placa.CompareTo(comboBox1.SelectedValue.ToString()) == 0)
                {
                    a = true;
                }
                else
                {
                    c++;
                }
            }
        }

        
    }
}
