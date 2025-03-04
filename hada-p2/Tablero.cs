using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hada_p2;

namespace Hada
{
    internal class Tablero
    {
        public int tamTablero;
        public int TamTablero {
            get; set;
        }

        private List<Coordenada> coordenadasDisparadas;
        private List<Coordenada> coordenadasTocadas;
        private List<Barco> barcos;
        private List<Barco> barcosEliminados;
        private Dictionary<Coordenada, string> casillasTablero;

        public Tablero(int tamTablero, List<Barco> barcos) {
            this.tamTablero = tamTablero;
            this.barcos = barcos;
            coordenadasDisparadas = new List<Coordenada>();
            coordenadasTocadas = new List<Coordenada>();
            barcosEliminados = new List<Barco>();
            casillasTablero = new Dictionary<Coordenada, string>();
        }

        private void inicializaCasillasTablero() {
            foreach (var p in barcos) {
                foreach (var coord in p.CoordenadasBarco) {
                    casillasTablero.Add(coord.Key, coord.Value);
                }
            }

            for (uint i = 0; i < tamTablero; i++) {
                for (uint j = 0; j < tamTablero; j++) {
                    Coordenada nueva = new Coordenada(i, j);
                    string cadena;
                    if (!casillasTablero.TryGetValue(nueva, out cadena)) {
                        casillasTablero.Add(nueva, "AGUA");
                    }
                }
            }
        }
    }
}
