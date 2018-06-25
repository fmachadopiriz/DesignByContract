//------------------------------------------------------------------------------
// <copyright file="LikesTracker.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace DesignByContract
{
    using System;

    /// <summary>
    /// Un ayudante para llevar la cuenta de ♥ de algo.
    /// </summary>
    public class LikesTracker
    {
        private Int32 likes;

        /// <summary>
        /// Un entero que representa cuánto gusta.
        /// </summary>
        /// <returns>La diferencia entre las veces que se agregó un ♥ mediante <see cref="LikesTracker.Add"/> menos
        /// las veces que se quitó un ♥ mediante mediante <see cref="LikesTracker.Remove"/>. Mayor o igual que cero.
        /// </returns>
        public Int32 Likes
        {
            get
            {
                return this.likes;
            }
        }

        /// <summary>
        /// Aumenta <see cref="LikesTracker.Likes"/> en uno.
        /// </summary>
        public void Add()
        {
            Contract.Check(this.Likes >= 0, "Los ♥ son mayores o iguales que cero");
            int oldLikes = this.Likes;

            this.likes = this.likes + 1;

            Contract.Ensures(this.Likes == oldLikes + 1, "Debe haber un ♥ más");
            Contract.Check(this.Likes >= 0, "Los ♥ son mayores o iguales que cero");
        }

        /// <summary>
        /// Disminuye <see cref="LikesTracker.Likes"/> en uno.
        /// </summary>
        public void Remove()
        {
            Contract.Check(this.Likes >= 0, "Los ♥ son mayores o iguales que cero");
            Contract.Requires(this.Likes > 0, "Debe haber al menos un ♥ para poder quitarlo");
            int oldLikes = this.Likes;

            this.likes = this.likes - 1;

            Contract.Ensures(this.Likes == oldLikes - 1, "Debe haber un ♥ menos");
            Contract.Check(this.Likes >= 0, "Los ♥ son mayores o iguales que cero");
        }
    }
}