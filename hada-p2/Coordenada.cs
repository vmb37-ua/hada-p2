using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    internal class Coordenada
    {
        private int fila;
        private int columna;
        public int Fila
        {
            get {  return fila; }
            set {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 9.");
                }
                fila = value;
            }
        }
        public int Columna
        {
            get { return columna; }
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 9.");
                }
                columna = value;
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
            Fila = int.Parse(fila);
            Columna = int.Parse(columna);
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
        public override int GetHashCode()
        {
            return this.Fila.GetHashCode() ^ this.Columna.GetHashCode();
        }
        public override bool Equals(object other)
        {
            return (Fila==((Coordenada)other).Fila) && (Columna== ((Coordenada)other).Columna);
        }
        public bool Equals(Coordenada coordenada)
        {
            return (Fila== coordenada.Fila) && (Columna== coordenada.Columna);
        }
    }
}
