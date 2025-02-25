using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hada_p2;

namespace Hada
{
    internal class Barco
    {
        public Dictionary<Coordenada, String> CoordenadasBarco;
        public string Nombre;
        public int NumDanyos;

        public Barco(string nombre, int longitud, char orientacion, Coordenada coordenadaInicio) {
            Nombre = nombre;
            NumDanyos = 0;
            for (uint i = 0; i < longitud; i++) {
                if (orientacion == 'h')
                {
                    //CoordenadasBarco.Add(coordenadaInicio.Fila+i, Nombre);
                }
                else if (orientacion == 'v') {
                    //CoordenadasBarco.Add(coordenadaInicio.Columna + i, Nombre);
                }
            }
            
            
        }

        public void Disparo(Coordenada c) {
            string algo;
            bool encontrado;
            encontrado = CoordenadasBarco.TryGetValue(c, out algo);
            if (encontrado)
            {
                CoordenadasBarco[c] = Nombre+"_T";
                //Lanzar evento
                NumDanyos++;
                if (hundido()) { 
                    //Llamar evento
                }
            }
        }

        public bool hundido() {
            bool aFlote = false;
            foreach (var pos in CoordenadasBarco)
            {
                if (pos.Value != Nombre+"_T")
                {
                    aFlote = true;
                }
            }
            return !aFlote;
        }

        public override string ToString() {
            string cadena = "";

            //PENDIENTE ACABAR---------------------------------------------------------
            cadena += "[" + Nombre + "] - DAÑOS: [" + NumDanyos + "]";
        }
    }
}
