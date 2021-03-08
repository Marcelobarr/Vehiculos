using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    class Carros
    {
        string placa;
        string marca;
        string modelo;
        string color;
        double precio_km;

        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public double Precio_Km { get => precio_km; set => precio_km = value; }

    }
}
