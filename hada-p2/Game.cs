using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    internal class Game
    {

        private bool finPartida;


        private void gameLoop()
        {
            Barco barco1 = new Barco("VIKT", 3, 'h', new Coordenada(4, 4));
            Barco barco2 = new Barco("KARL", 2, 'v', new Coordenada(1, 2));
            Barco barco3 = new Barco("VELD", 3, 'h', new Coordenada(3, 1));

            List<Barco> barcos = new List<Barco>();
            barcos.Add(barco1);
            barcos.Add(barco2);
            barcos.Add(barco3);

            Tablero tablero = new Tablero(9, barcos);
            tablero.eventoFinPartida += cuandoEventoFinPartida;

            string output;
            int coma;
            while (!finPartida)
            {
                Console.Write("Introduce coordenada (formato: N,N) o salir ('s'): ");
                output = Console.ReadLine();
                coma = output.IndexOf(',');
                if ((output == "s") || (output == "S"))
                {
                    finPartida = true;
                }
                else if ((coma = output.IndexOf(',')) > 0 && coma < output.Length - 1)
                {
                    string xString = output.Substring(0, coma);
                    string yString = output.Substring(coma + 1);

                    if (int.TryParse(xString, out _) && int.TryParse(yString, out _))
                    {
                        tablero.Disparar(new Coordenada(int.Parse(xString), int.Parse(yString)));
                    }

                    System.Console.WriteLine(tablero.ToString());
                }
            }
        }

        public Game()
        {
            finPartida = false;
            gameLoop();
        }

        private void cuandoEventoFinPartida(object sender, EventArgs e)
        {
            Console.WriteLine("PARTIDA FINALIZADA!!");
            finPartida = true;
        }
    }
}
