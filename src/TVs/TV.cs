using System;

namespace DesignByContract
{
    /// <summary>
    /// Una televisión.
    /// </summary>
    public abstract class TV
    {
        /// <summary>
        /// El canal que se está viendo.
        /// </summary>
        /// <returns>El número del canal.</returns>
        /// <remarks>
        /// <c>Precondición</c> La televisión debe estar encendida para saber el canal.
        /// </remarks>
        public abstract Int32 Channel { get; }

        /// <summary>
        /// Indica si la televisión está prendida o no.
        /// </summary>
        /// <returns>True si la televisión está prendida; False en caso contrario.</returns>
        public abstract Boolean IsOn { get; }
        
        /// <summary>
        /// Pasa al siguiente canal.
        /// </summary>
        /// <remarks>
        /// <c>Precondición</c> La televisión debe estar encendida para cambiar el canal.
        /// <c>Postcondición</c> El canal debe aumentar en uno al pasar al canal siguiente.
        /// </remarks>
        public abstract void NextChannel();
        
        /// <summary>
        ///  Pasa al canal anterior.
        /// </summary>
        /// <remarks>
        /// <c>Precondición</c> La televisión debe estar encendida para cambiar el canal.
        /// <c>Postcondición</c> El canal debe bajar en uno al pasar al canal anterior.
        /// </remarks>
        public abstract void PrevChannel();

        /// <summary>
        /// Enciende la televisión.
        /// </summary>
        /// <remarks>
        /// <c>Precondición</c> La televisión debe estar apagada para ser encendida.
        /// <c>Postcondición</c> La televisión queda encendida.
        /// </remarks>
        public abstract void TurnOn();

        /// <summary>
        /// Apaga la televisión.
        /// </summary>
        /// <remarks>
        /// <c>Precondición</c> La televisión debe estar encendida para ser apagada.
        /// <c>Postcondición</c> La televisión queda apagada.
        /// </remarks>
        public abstract void TurnOff();
    }
}