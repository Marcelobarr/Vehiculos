using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    class Alquiler
    {
        string nit;
        string placa;
        string fecha_alquiler;
        string fecha_devolucion;
        double k_recorridos;

        public string Nit { get => nit; set => nit = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Fecha_Alquiler { get => fecha_alquiler; set => fecha_alquiler = value; }
        public string Fecha_Devolucion { get => fecha_devolucion; set => fecha_devolucion = value; }
        public double K_Recorridos { get => k_recorridos; set => k_recorridos = value; }
        
        
    }
}
