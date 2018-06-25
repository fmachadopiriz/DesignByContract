//----------------------------------------------------------------------------
// <copyright file="ActorTests.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//----------------------------------------------------------------------------

namespace DesignByContract.Tests
{
    using System;
    using Xunit;

    /// <summary>
    /// Tests de la clase <see cref="Actor"/>.
    /// </summary>
    public class ActorTests
    {
        /// <summary>
        /// Test del constructor de la clase <see cref="Actor"/>.
        /// </summary>
        [Fact]
        public void TestConstructor()
        {
            const string name = "Actor";
            Actor actor = new Actor(name);
            Assert.Equal(name, actor.Name);
            Assert.Equal(0, actor.Likes);
        }

        /// <summary>
        /// Test del método <see cref="Actor.Like"/>.
        /// </summary>
        [Fact]
        public void TestLike()
        {
            Actor actor = new Actor("Actor");
            Assert.Equal(0, actor.Likes);
            actor.Like();
            Assert.Equal(1, actor.Likes);
        }

        /// <summary>
        /// Test del método <see cref="Actor.Unlike"/>.
        /// </summary>
        [Fact]
        public void TestUnlike()
        {
            Actor actor = new Actor("Actor");
            Assert.Equal(0, actor.Likes);
            actor.Unlike();
            Assert.Equal(0, actor.Likes);
            actor.Like();
            actor.Unlike();
            Assert.Equal(0, actor.Likes);
        }
    }
}