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
        List<Total> tot = new List<Total>();

        Boolean q = false;
        int cont_p = 0;

        Boolean x = false;
        int cont2 = 0;

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
                Total t = new Total();

                f.Nit = comboBox1.SelectedValue.ToString();
                f.Placa = comboBox2.SelectedValue.ToString();
                f.Fecha_Alquiler = dateTimePicker1.Value.ToString();
                f.Fecha_Devolucion = dateTimePicker2.Value.ToString();
                f.K_Recorridos = Convert.ToDouble(textBox1.Text);
                alqui.Add(f);
                MessageBox.Show("Se registro correctamente el alquiler");
                
                escribir_alquiler();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = alqui;
                dataGridView1.Refresh();

                    
                if (alqui.Count >= 1)
                {
                    ordenar();

                }

                buscar_combo();
                buscar_placa();
                if (x && q)
                {
                    t.Nombre = cliente[cont2].Nombre;
                    t.Placa = carro[cont_p].Placa;
                    t.Marca = carro[cont_p].Marca;
                    t.Modelo = carro[cont_p].Modelo;
                    t.Color = carro[cont_p].Color;
                    t.Precio_km = carro[cont_p].Precio_Km;
                    t.F_devolucion = dateTimePicker2.Value.ToString();
                    t.Tot = carro[cont_p].Precio_Km * Convert.ToDouble(textBox1.Text);
                    

                    tot.Add(t);

                    escribir_total();

                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = tot;
                    dataGridView2.Refresh();

                    q = false;
                    x = false;
                    cont_p = 0;
                    cont2 = 0;

                    textBox1.Clear();

                }
                else
                {
                    cont2 = 0;
                }

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
            leer_total();
           

            if (alqui.Count >= 1)
            {
                ordenar();

            }

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
            comboBox2.ValueMember = "Placa";

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

            comboBox1.DisplayMember = "Nit";
            comboBox1.ValueMember = "Nit";

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

        void ordenar()
        {
            label7.Text.Remove(0);
            alqui = alqui.OrderByDescending(a => a.K_Recorridos).ToList();
            label7.Text = Convert.ToString(alqui[0].K_Recorridos);

        }

        void escribir_total()
        {
            FileStream stream = new FileStream("Total.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);

            foreach (var d in tot)
            {
                write.WriteLine(d.Nombre);
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
                a.Nombre = reader.ReadLine();
                a.Placa = reader.ReadLine();
                a.Marca = reader.ReadLine();
                a.Modelo = reader.ReadLine();
                a.Color = reader.ReadLine();
                a.Precio_km = Convert.ToDouble(reader.ReadLine());
                a.F_devolucion = reader.ReadLine();
                a.Tot = Convert.ToDouble(reader.ReadLine());

                tot.Add(a);
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = tot;
                dataGridView2.Refresh();

            }
            reader.Close();

        }

        void buscar_combo()
        {
            while (x == false && cont2 < cliente.Count)
            {
                if (cliente[cont2].Nit.CompareTo(comboBox1.SelectedValue) == 0)
                {
                    x = true;
                }
                else
                {
                    cont2++;
                }
            }
        }

        void buscar_placa()
        {
            while (q == false && cont_p < carro.Count)
            {
                if (carro[cont_p].Placa.CompareTo(comboBox2.SelectedValue) == 0)
                {
                    q = true;
                }
                else
                {
                    cont_p++;
                }
            }
        }
    }
}
