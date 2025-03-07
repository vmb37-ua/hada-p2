using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

            for (int i = 0; i < tamTablero; i++) {
                for (int j = 0; j < tamTablero; j++) {
                    Coordenada nueva = new Coordenada(i, j);
                    string cadena;
                    if (!casillasTablero.TryGetValue(nueva, out cadena)) {
                        casillasTablero.Add(nueva, "AGUA");
                    }
                }
            }
        }

        public void Disparar(Coordenada c) {
            if (c.Fila >= tamTablero || c.Columna >= tamTablero) {
                System.Console.WriteLine("La coordenada (" + c.Fila + "," + c.Columna + ") está fuera de las dimensiones del tablero."); 
            }
            foreach (Barco barco in barcos) {
                barco.Disparo(c);
            }
            coordenadasDisparadas.Add(c);
        }

        public string DibujarTablero() {
            string resultado = "";
            for (int i = 0; i < tamTablero; i++) {
                for (int j = 0; j < tamTablero; j++) {
                    Coordenada c = new Coordenada(i,j);
                    string cadena;
                    resultado+="["+casillasTablero.TryGetValue(c, out cadena)+"]";
                }
                resultado += '\n';
            }
            return resultado;
        }

        public override string ToString() {
            string res = "";

            foreach (Barco barco in barcos) {
                res += barco.ToString()+'\n';
            }
            res += "Coordenadas disparadas: ";
            foreach (Coordenada coord in coordenadasDisparadas) {
                res += coord.ToString() + " ";
            }
            res += "\nCoordenadas tocadas: ";
            foreach (Coordenada coord in coordenadasTocadas){
                res += coord.ToString() + " ";
            }
            res += "\n\nCASILLAS TABLERO\n-------------------\n" + this.ToString();

            return res;
        }

        private void cuandoEventoTocado(Barco sender, TocadoArgs e) {
            casillasTablero[e.CoordenadaImpacto] = sender.Nombre + "_T";
            System.Console.WriteLine("TABLERO: Barco ["+ sender.Nombre+"] tocado en:");
            System.Console.WriteLine("Coordenada: [(" + e.CoordenadaImpacto.Fila + "," + e.CoordenadaImpacto.Columna + ")]");
        }

        private void cuandoEventoHundido(Barco sender, HundidoArgs e) {
            System.Console.WriteLine("TABLERO: Barco [" + sender.Nombre + "] hundido!!");
            bool encontrado_flote = false;
            foreach (Barco b in barcos) {
                if (!b.hundido()) { 
                    encontrado_flote = true;
                    break;
                }
            }

            if (!encontrado_flote && eventoFinPartida!=null) {
                eventoFinPartida(this, null);
            }
        }

        public event EventHandler<EventArgs> eventoFinPartida;
    }
}
