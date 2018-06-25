//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

namespace DesignByContract
{
    using System;
    using System.Collections;

    /// <summary>
    /// Programa principal.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// El código del programa principal.
        /// </summary>
        /// <param name="args">Un vector de argumentos pasdados al programa principal.</param>
        public static void Main(string[] args)
        {
            String name;

            name = "Samba Pa Ti";
            ILikeable song = new Song(name, "Carlos Santana");
            song.Like();
            song.Like();

            // Console.WriteLine(name + " tiene " + song.Likes + " me gusta");
            Console.WriteLine("{0} tiene {1} me gusta", name, song.Likes);

            name = "John Travolta";
            ILikeable actor = new Actor(name);
            actor.Like();
            actor.Unlike();

            // Console.WriteLine(name + " tiene " + actor.Likes + " me gusta");
            Console.WriteLine("{0} tiene {1} me gusta", name, actor.Likes);
        }
    }
}
