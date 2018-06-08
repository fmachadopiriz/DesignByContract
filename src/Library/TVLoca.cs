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
            
            /* Precondición */
            Debug.Assert(IsOn, "La televisión debe estar encendida para cambiar de canal.");

            _channel = new Random().Next(1, 999);

            /* Postcondición */
            Debug.Assert(Channel == oldChannel + 1, "El canal debe aumentar en uno al pasar al canal siguiente.");
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
            /* Precondición */
            Debug.Assert(IsOn, "La televisión debe estar encendida para cambiar de canal.");

            _channel = new Random().Next(1, 999);

            /* Postcondición */
            Debug.Assert(Channel == oldChannel - 1, "El canal debe bajar en uno al pasar al canal anterior.");
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
            /* Precondición */
            Debug.Assert(!this.IsOn, "La televisión debe estar apagada para ser encendida.");

            _isOn = true;

            /* Postcondición */
            Debug.Assert(this.IsOn, "La televisión queda encendida.");
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
            /* Precondición */
            Debug.Assert(this.IsOn, "La televisión debe estar prendida para ser apagada.");

            _isOn = false;

            /* Postcondición */
            Debug.Assert(!this.IsOn, "La televisión queda apagada.");
        }
    }
}