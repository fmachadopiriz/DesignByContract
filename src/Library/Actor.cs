//------------------------------------------------------------------------------
// <copyright file="Actor.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace DesignByContract
{
    using System;

    /// <summary>
    /// Un actor que me puede gustar o no.
    /// </summary>
    public class Actor : ILikeable
    {
        private String name;

        private LikesTracker likesTracker = new LikesTracker();

        /// <summary>
        /// Crea un nuevo <see cref="Actor"/> con los datos pasados como argumento.
        /// </summary>
        /// <param name="name">El nombre del actor</param>
        public Actor(String name)
        {
            Contract.Requires(!String.IsNullOrEmpty(name), "No se puede crear un actor sin nombre");

            this.name = name;

            Contract.Ensures(this.Name == name, "El nombre del actor coincide con el argumento");
            Contract.Check(this.Likes >= 0, "Los ♥ son mayores o iguales que cero");
        }

        /// <summary>
        /// Nombre del actor.
        /// </summary>
        /// <returns>El nombre del actor.</returns>
        public String Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Un entero que representa cuánto gusta este actor.
        /// </summary>
        /// <returns>La diferencia entre las veces que se agregó un ♥ mediante <see cref="Actor.Like()"/> menos
        /// las veces que se quitó un ♥ mediante mediante <see cref="Actor.Unlike()"/>. Mayor o igual que
        /// cero.</returns>
        public Int32 Likes
        {
            get
            {
                return this.likesTracker.Likes;
            }
        }

        /// <summary>
        /// Permite agregar un ♥ a este actor.
        /// </summary>
        public void Like()
        {
            Contract.Check(this.Likes >= 0, "Los ♥ son mayores o iguales que cero");
            int oldLikes = this.Likes;

            this.likesTracker.Add();

            Contract.Ensures(this.Likes == oldLikes + 1, "Debe haber un ♥ más");
            Contract.Check(this.Likes >= 0, "Los ♥ son mayores o iguales que cero");
        }

        /// <summary>
        /// Permite quitar un ♥ a este actor.
        /// </summary>
        public void Unlike()
        {
            Contract.Check(this.Likes >= 0, "Los ♥ son mayores o iguales que cero");
            int oldLikes = this.Likes;

            if (this.likesTracker.Likes > 0)
            {
                this.likesTracker.Remove();
            }

            Contract.Ensures(this.Likes == oldLikes - 1 || this.Likes == 0, "Debe haber un ♥ menos si había alguno");
            Contract.Check(this.Likes >= 0, "Los ♥ son mayores o iguales que cero");
        }
    }
}