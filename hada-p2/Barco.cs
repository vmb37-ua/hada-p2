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
            for (int i = 0; i < longitud; i++) {
                if (orientacion == 'h')
                {
                    CoordenadasBarco.Add(new Coordenada(coordenadaInicio.Fila + i, coordenadaInicio.Columna), Nombre);
                }
                else if (orientacion == 'v') {
                    CoordenadasBarco.Add(new Coordenada(coordenadaInicio.Fila, coordenadaInicio.Columna + i), Nombre);
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
                if (eventoTocado != null) {
                    eventoTocado(this, new TocadoArgs(Nombre, c));
                }
                NumDanyos++;
                if (hundido() && eventoHundido!=null) {
                    eventoHundido(this, new HundidoArgs(Nombre));
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
            cadena += "[" + Nombre + "] - DAÑOS: [" + NumDanyos + "] - HUNDIDO: ["+this.hundido()+"] - COORDENADAS:";
            foreach (var pos in CoordenadasBarco) {
                cadena += " [(" + pos.Key.Fila + "," + pos.Key.Columna + ")] :" + pos.Value + "]";
            }
            return cadena;
        }

        public event EventHandler<TocadoArgs> eventoTocado;
        public event EventHandler<HundidoArgs> eventoHundido;
    }
}
