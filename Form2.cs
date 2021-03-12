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
    public partial class Form2 : Form
    {
        List<Clientes> persona = new List<Clientes>();
        Boolean c = false;
        int cont = 0;


        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                agregar();
                repetidos();
                Clientes f = new Clientes();
                if (c)
                {
                    MessageBox.Show("El NIT introducido ya esta en uso");
                    textBox1.Clear();

                    c = false;
                    cont = 0;
                }
                else
                {
                    f.Nit = textBox1.Text;
                    f.Nombre = textBox2.Text;
                    f.Direccion = textBox3.Text;
                    persona.Add(f);
                    MessageBox.Show("El cliente se ha registrado correctamente");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    escribir_cliente();

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = persona;
                    dataGridView1.Refresh();

                    cont = 0;
                }
            }
            else
            {
                MessageBox.Show("¡ERROR!, Debe de llenar todos los campos");
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            leer_cliente();
        }

        void agregar()
        {
            Clientes x = new Clientes();
            
            x.Nit = textBox1.Text;
            x.Nombre = textBox2.Text;
            x.Direccion = textBox3.Text;

        }

        void escribir_cliente()
        {
            FileStream stream = new FileStream("Cliente.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in persona)
            {
                write.WriteLine(d.Nit);
                write.WriteLine(d.Nombre);
                write.WriteLine(d.Direccion);
            }
            write.Close();
        }

        void leer_cliente()
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
                persona.Add(a);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = persona;
                dataGridView1.Refresh();
            }
            reader.Close();
        }

        void repetidos()
        {
            while (c == false && cont < persona.Count)
            {
                if (persona[cont].Nit.CompareTo(textBox1.Text) == 0)
                {
                    c = true;
                }
                else
                {
                    cont++;
                }
            }
        }

       
    }
}
