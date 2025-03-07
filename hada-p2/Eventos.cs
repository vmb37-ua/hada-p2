using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    internal class TocadoArgs : EventArgs
    {
        private string nombre;
        private Coordenada coordenadaImpacto;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Coordenada CoordenadaImpacto
        {
            get { return coordenadaImpacto; }
            set { coordenadaImpacto = value; }
        }
        public TocadoArgs(string nombre, Coordenada coordenadaImpacto)
        {
            Nombre = nombre;
            CoordenadaImpacto = coordenadaImpacto;
        }
    }
    internal class HundidoArgs : EventArgs
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public HundidoArgs(string nombre)
        {
            Nombre = nombre;
        }
    }
}
