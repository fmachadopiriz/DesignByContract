#define DEBUG

using System;
using System.Diagnostics;

namespace DesignByContract
{
    /// <summary>
    /// Una TV que no funciona como debe.
    /// </summary>
    public class TVLoca : TV
    {
        private Int32 _channel;
        /// <summary>
        /// El canal que se está viendo.
        /// </summary>
        /// <returns>El número del canal.</returns>
        /// <remarks>
        /// <c>Precondición</c> La televisión debe estar encendida para saber el canal.
        /// </remarks>
        public override Int32 Channel
        {
            get
            {
                /* Precondiciones */
                Debug.Assert(IsOn, "La televisión debe estar encendida para saber el canal.");

                return new Random().Next(1, 999);
            }
        }

        private Boolean _isOn;

        /// <summary>
        /// Indica si la televisión está prendida o no.
        /// </summary>
        /// <returns>True si la televisión está prendida; False en caso contrario.</returns>
        public override Boolean IsOn
        {
            get
            {
                return _isOn;
            }
        }

        public TVLoca()
        {
            this._channel = 2;

            /* Postcondiciones */
            Debug.Assert(
                this.Channel >= 2 && this.Channel <= 999,
                "El canal está entre 2 y 999");

        }

        /// <summary>
        /// Pasa al siguiente canal.
        /// </summary>
        /// <remarks>
        /// <c>Precondición</c> La televisión debe estar encendida para cambiar el canal.
        /// <c>Postcondición</c> El canal debe aumentar en uno al pasar al canal siguiente.
        /// </remarks>
        public override void NextChannel()
        {
            Int32 oldChannel = Channel;
            
            /* Precondiciones */
            Debug.Assert(IsOn, "La televisión debe estar encendida para cambiar de canal.");
            Debug.Assert(
                this.Channel >= 2 && this.Channel <= 999,
                "El canal está entre 2 y 999");

            _channel = new Random().Next(1, 999);

            /* Postcondiciones */
            Debug.Assert(Channel == oldChannel + 1, "El canal debe aumentar en uno al pasar al canal siguiente.");
            Debug.Assert(
                this.Channel >= 2 && this.Channel <= 999,
                "El canal está entre 2 y 999");
        }

        /// <summary>
        ///  Pasa al canal anterior.
        /// </summary>
        /// <remarks>
        /// <c>Precondición</c> La televisión debe estar encendida para cambiar el canal.
        /// <c>Postcondición</c> El canal debe bajar en uno al pasar al canal anterior.
        /// </remarks>
        public override void PrevChannel()
        {
            Int32 oldChannel = Channel;
            /* Precondiciones */
            Debug.Assert(IsOn, "La televisión debe estar encendida para cambiar de canal.");
            Debug.Assert(
                this.Channel >= 2 && this.Channel <= 999,
                "El canal está entre 2 y 999");

            _channel = new Random().Next(1, 999);

            /* Postcondiciones */
            Debug.Assert(Channel == oldChannel - 1, "El canal debe bajar en uno al pasar al canal anterior.");
            Debug.Assert(
                this.Channel >= 2 && this.Channel <= 999,
                "El canal está entre 2 y 999");
        }

        /// <summary>
        /// Enciende la televisión.
        /// </summary>
        /// <remarks>
        /// <c>Precondición</c> La televisión debe estar apagada para ser encendida.
        /// <c>Postcondición</c> La televisión queda encendida.
        /// </remarks>
        public override void TurnOn()
        {
            /* Precondiciones */
            Debug.Assert(!this.IsOn, "La televisión debe estar apagada para ser encendida.");
            Debug.Assert(
                this.Channel >= 2 && this.Channel <= 999,
                "El canal está entre 2 y 999");

            _isOn = true;

            /* Postcondiciones */
            Debug.Assert(this.IsOn, "La televisión queda encendida.");
            Debug.Assert(
                this.Channel >= 2 && this.Channel <= 999,
                "El canal está entre 2 y 999");
        }

        /// <summary>
        /// Apaga la televisión.
        /// </summary>
        /// <remarks>
        /// <c>Precondición</c> La televisión debe estar prendida para ser apagada.
        /// <c>Postcondición</c> La televisión queda apagada.
        /// </remarks>
        public override void TurnOff()
        {
            /* Precondiciones */
            Debug.Assert(this.IsOn, "La televisión debe estar prendida para ser apagada.");
            Debug.Assert(
                this.Channel >= 2 && this.Channel <= 999,
                "El canal está entre 2 y 999");

            _isOn = false;

            /* Postcondiciones */
            Debug.Assert(!this.IsOn, "La televisión queda apagada.");
            Debug.Assert(
                this.Channel >= 2 && this.Channel <= 999,
                "El canal está entre 2 y 999");
            
        }
    }
}