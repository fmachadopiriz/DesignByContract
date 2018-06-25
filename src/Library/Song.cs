//------------------------------------------------------------------------------
// <copyright file="Song.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace DesignByContract
{
    using System;

    /// <summary>
    /// Una canción que me puede gustar o no.
    /// </summary>
    public class Song : ILikeable
    {
        private String name;

        private String artist;

        private LikesTracker likesTracker = new LikesTracker();

        /// <summary>
        /// Crea una nueva canción con los valores pasados como parámetro.
        /// </summary>
        /// <param name="name">El nombre de la canción.</param>
        /// <param name="artist">El intérprete de la canción.</param>
        /// <returns>La canción recién creada.</returns>
        public Song(String name, String artist)
        {
            Contract.Requires(!String.IsNullOrEmpty(name), "No se puede crear una canción sin nombre");
            Contract.Requires(!String.IsNullOrEmpty(artist), "No se puede crear una canción sin intérprete");

            this.name = name;
            this.artist = artist;

            Contract.Ensures(this.Name == name, "El nombre de la canción coincide con el argumento");
            Contract.Ensures(this.Artist == artist, "El interprete de la canción coincide con el argumento");
            Contract.Check(this.Likes >= 0, "Los ♥ son mayores o iguales que cero");
        }

        /// <summary>
        /// Nombre de la canción.
        /// </summary>
        /// <returns>El nombre de la canción.</returns>
        public String Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Intérprete de la canción.
        /// </summary>
        /// <returns>El intérprete de la canción.</returns>
        public String Artist
        {
            get
            {
                return this.artist;
            }
        }

        /// <summary>
        /// Un entero que representa cuánto gusta esta canción.
        /// </summary>
        /// <returns>La diferencia entre las veces que se agregó un ♥ mediante <see cref="Actor.Like()"/> menos las
        /// veces que se quitó un ♥ mediante mediante <see cref="Actor.Unlike()"/>. Mayor o igual que cero.</returns>
        public Int32 Likes
        {
            get
            {
                return this.likesTracker.Likes;
            }
        }

        /// <summary>
        /// Permite agregar un ♥ a esta canción.
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
        /// Permite quitar un ♥ de esta canción.
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