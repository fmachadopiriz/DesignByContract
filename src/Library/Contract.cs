//------------------------------------------------------------------------------
// <copyright file="Contract.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace DesignByContract
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Un ayudante para simular diseño por contrato.
    /// </summary>
    /// <remarks>
    /// Los predicados en diseño por contrato deberían ser declarativos y la correccion del código respecto de estos
    /// enunciados debería ser comprobada en tiempo de compilación y en tiempo de ejecución. C# no tiene esta
    /// funcionalidad. Para emularlo usamos código que evalúa una condición y levanta una excepción si la condición
    /// no se cumple. Obviamente esto sólo funciona en tiempo de ejecución. Además no podemos tener código en las
    /// interfaces, sólo en las clases.
    /// </remarks>
    public class Contract
    {
        private const String DefaultMessage = "Contract failed";

        /// <summary>
        /// Comprueba una condición y levanta una excepción con el mensaje recibido como argumento. Usamos este
        /// método para simular invariates.
        /// </summary>
        /// <param name="condition">La invariante.</param>
        /// <param name="message">El mensaje que describe la invariante.</param>
        public static void Check(Boolean condition, String message)
        {
            if (!condition)
            {
                throw new ContractException(message);
            }
        }

        /// <summary>
        /// Comprueba una condición y levanta una excepción con un mensaje predeterminado. Usamos este método para
        /// simular invariates.
        /// </summary>
        /// <param name="condition">La invariante.</param>
        /// <param name="message">El mensaje que describe la invariante.</param>
        public static void Check(Boolean condition) => Contract.Check(condition, DefaultMessage);

        /// <summary>
        /// Comprueba una condición y levanta una excepción con un mensaje predeterminado. Usamos este método para
        /// simular precondiciones.
        /// </summary>
        /// <param name="condition">La invariante.</param>
        /// <param name="message">El mensaje que describe la precondición.</param>
        public static void Requires(Boolean condition) => Contract.Check(condition);

        /// <summary>
        /// Comprueba una condición y levanta una excepción con el mensaje recibido como argumento. Usamos este
        /// método para simular precondiciones.
        /// </summary>
        /// <param name="condition">La invariante.</param>
        /// <param name="message">El mensaje que describe la precondición.</param>
        public static void Requires(Boolean condition, String message) => Contract.Check(condition, message);

        /// <summary>
        /// Comprueba una condición y levanta una excepción con un mensaje predeterminado.
        /// </summary>
        /// <param name="condition">La invariante.</param>
        /// <param name="message">El mensaje que describe la postcondiciones.</param>
        public static void Ensures(Boolean condition) => Contract.Check(condition);

        /// <summary>
        /// Comprueba una condición y levanta una excepción con el mensaje recibido como argumento. Usamos este
        /// método para simular postcondiciones.
        /// </summary>
        /// <param name="condition">La invariante.</param>
        /// <param name="message">El mensaje que describe la postcondiciones.</param>
        public static void Ensures(Boolean condition, String message) => Contract.Check(condition, message);

        // La excepción que se levanta cuando no se cumple una condición de un contrato. La clase es interna y
        // privada para que solamente esta clase puede crear estas excepciones.
        private class ContractException : Exception
        {
            public ContractException(String message)
                : base(message)
            {
                // Intentionally left blank
            }
        }
    }
}