using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    internal class Coordenada
    {
        public int Fila
        {
            get {  return Fila; }
            set {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 9.");
                }
                Fila = value;
            }
        }
        public int Columna
        {
            get { return Columna; }
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 9.");
                }
                Columna = value;
            }
        }
        public Coordenada()
        {
            Fila = 0;
            Columna = 0;
        }
        public Coordenada(int fila, int columna)
        {
            Fila = fila;
            Columna = columna;
        }
        public Coordenada(string fila, string columna)
        {

        }
        public Coordenada(Coordenada otro)
        {
            Fila=otro.Fila;
            Columna=otro.Columna;
        }
        public override string ToString()
        {
            return "("+Fila+","+Columna+")";
        }
        public GetHashCode()
        {
            return this.Fila.GetHashCode() ^ this.Columna.GetHashCode();
        }
        public equals(object x)
        public bool Equals(Coordenada coordenada)
        {
            return (Fila==other.Fila) && (Columna==other.Columna);
        }
    }
}
