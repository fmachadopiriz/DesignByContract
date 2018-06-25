//-----------------------------------------------------------------------------------
// <copyright file="LikesTrackerTests.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-----------------------------------------------------------------------------------

namespace DesignByContract.Tests
{
    using System;
    using Xunit;

    /// <summary>
    /// Tests de la clase <see cref="LikesTracker"/>.
    /// </summary>
    public class LikesTrackerTests
    {
        /// <summary>
        /// Tests del constructor de la clase <see cref="LikesTracker"/>.
        /// </summary>
        [Fact]
        public void TestConstructor()
        {
            LikesTracker likesTracker = new LikesTracker();
            Assert.Equal(0, likesTracker.Likes);
        }

        /// <summary>
        /// Tests del método <see cref="LikesTracker.Add"/>.
        /// </summary>
        [Fact]
        public void TestAdd()
        {
            LikesTracker likesTracker = new LikesTracker();
            Assert.Equal(0, likesTracker.Likes);
            likesTracker.Add();
            Assert.Equal(1, likesTracker.Likes);
        }

        /// <summary>
        /// Tests del método <see cref="LikesTracker.Remove"/>.
        /// </summary>
        [Fact]
        public void TestUnlike()
        {
            LikesTracker likesTracker = new LikesTracker();
            Assert.Equal(0, likesTracker.Likes);
            likesTracker.Add();
            likesTracker.Remove();
            Assert.Equal(0, likesTracker.Likes);
        }
    }
}