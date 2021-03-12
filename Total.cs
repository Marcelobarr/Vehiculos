using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    class Total
    {
        string nombre;
        string placa;
        string marca;
        string modelo;
        string color;
        double precio_km;
        string f_devolucion;
        double tot;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public double Precio_km { get => precio_km; set => precio_km = value; }
        public string F_devolucion { get => f_devolucion; set => f_devolucion = value; }
        public double Tot { get => tot; set => tot = value; }
        
    }
}
