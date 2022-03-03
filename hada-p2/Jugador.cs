using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hada //propfull
{
    class Jugador
    {
        private int maxAmonestaciones { get; set; }
        private int maxFaltas { get; set; }
        private int minEnergia { get; set; }

        public int puntos { get; set; }

        private Random rand;

        public string nombre;

        public Random _rand
        {
            private get { return rand; }
            set { rand = value; }
        }

        public string _nombre
        {
            get { return nombre; }
            private set { nombre = value; }
        }

        //También declarará las siguientes propiedades privadas 

        private int amonestaciones;

        public int _amonestaciones
        {
            get { return amonestaciones; }
            //Se comprueba si el valor a asignar es mayor que maxAmonestaciones,
            // y en caso afirmativo disparará el evento amonestacionesMaximoExcedido.
            // Si el valor a asignar es menor que cero, se asignará el valor cero
            set { 
                if(value > maxAmonestaciones){amonestacionesMaximoExcedido(this, new AmonestacionesMaximoExcedidoArgs(value));}
                else{
                    if(value < 0) { amonestaciones = 0; }
                }
            }
        }

        private int faltas;

        public int _faltas
        {
            get { return faltas; }
            //guardará el número de faltas recibidas por el jugador. En el setter
            // deberá comprobar si el valor a asignar es mayor que maxFaltas y en 
            // caso afirmativo disparará el evento faltasMaximoExcedido
            set {
                if (value > maxFaltas){ faltasMaximoExcedido(this, new FaltasMaximoExcedidoArgs(value));}
                else{faltas = value; }
            }
        }

        private int energia;

        public int _energia
        {
            get { return energia; }
            //En el setter deberá comprobar si el valor a asignar es menor que
            // minEnergia y en caso afirmativo disparará el evento energiaMinimaExcedida
            // Como se trata de un porcentaja, si el valor a asignar es menor que cero
            // se asignará el valor cero, y si es mayor que 100 , se asignará el valor 100
            set { 

                if (value < minEnergia) { energiaMinimaExcedida(this, new EnergiaMinimaExcedidoArgs(value)); }

                switch (value)
                {
                    case var e when value < minEnergia: energiaMinimaExcedida(this, new EnergiaMinimaExcedidoArgs(value)); break;
                    case var e when value < 0: energia = 0; break;
                    default: energia = 100; break; 
                }
            }
        }


        public event EventHandler<AmonestacionesMaximoExcedidoArgs> amonestacionesMaximoExcedido;
        public event EventHandler<FaltasMaximoExcedidoArgs> faltasMaximoExcedido;
        public event EventHandler<EnergiaMinimaExcedidoArgs> energiaMinimaExcedida;

    }


    public class AmonestacionesMaximoExcedidoArgs : EventArgs
    {
        public int amonestaciones { get; set; }
        public AmonestacionesMaximoExcedidoArgs(int amonestaciones)
        {
            this.amonestaciones = amonestaciones;
        }
    }

    public class FaltasMaximoExcedidoArgs : EventArgs
    {
        public int faltas {get; set;}

        public FaltasMaximoExcedidoArgs(int faltas)
        {
            this.faltas = faltas;
        }
    }

    public class EnergiaMinimaExcedidoArgs : EventArgs
    {
        public int energia{get; set;}

        public EnergiaMinimaExcedidoArgs(int energia)
        {
            this.energia = energia;
        }
    }


}
