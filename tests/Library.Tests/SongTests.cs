//---------------------------------------------------------------------------
// <copyright file="SongTests.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------

namespace DesignByContract.Tests
{
    using System;
    using Xunit;

    /// <summary>
    /// Tests de la clase <see cref="Song"/>.
    /// </summary>
    public class SongTests
    {
        /// <summary>
        /// Tests del constructor de la clase <see cref="Song"/>.
        /// </summary>
        [Fact]
        public void TestConstructor()
        {
            const string name = "`Aong";
            const string artist = "Artist";
            Song song = new Song(name, artist);
            Assert.Equal(name, song.Name);
            Assert.Equal(artist, song.Artist);
            Assert.Equal(0, song.Likes);
        }

        /// <summary>
        /// Tests del método <see cref="Song.Like"/>.
        /// </summary>
        [Fact]
        public void TestLike()
        {
            Song song = new Song("Song", "Artist");
            Assert.Equal(0, song.Likes);
            song.Like();
            Assert.Equal(1, song.Likes);
        }

        /// <summary>
        /// Tests del método <see cref="Song.Unlike"/>.
        /// </summary>
        [Fact]
        public void TestUnlike()
        {
            Song song = new Song("Song", "Artist");
            Assert.Equal(0, song.Likes);
            song.Like();
            song.Unlike();
            Assert.Equal(0, song.Likes);
            song.Unlike();
            Assert.Equal(0, song.Likes);
        }
    }
}