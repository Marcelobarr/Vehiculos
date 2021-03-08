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
            comboBox1.DataSource = per;
            comboBox1.Refresh();
        }

    }
}
