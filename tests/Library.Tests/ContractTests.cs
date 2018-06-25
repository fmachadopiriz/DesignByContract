//--------------------------------------------------------------------------------
// <copyright file="ContractsTests.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace DesignByContract.Tests
{
    using System;
    using Xunit;

    /// <summary>
    /// Tests de la clase <see cref="Contract"/>.
    /// </summary>
    public class ContractTests
    {
        /// <summary>
        /// Tests del metodo <see cref="Contract.Check(bool)"/>.
        /// </summary>
        [Fact]
        public void TestCheck()
        {
            Assert.ThrowsAny<Exception>(() => Contract.Check(false));
            Contract.Check(true);
        }

        /// <summary>
        /// Tests del metodo <see cref="Contract.Requires(bool)"/>.
        /// </summary>
        [Fact]
        public void TestRequires()
        {
            Assert.ThrowsAny<Exception>(() => Contract.Requires(false));
            Contract.Requires(true);
        }

        /// <summary>
        /// Tests del metodo <see cref="Contract.Ensures(bool)"/>.
        /// </summary>
        [Fact]
        public void TestEnsures()
        {
            Assert.ThrowsAny<Exception>(() => Contract.Ensures(false));
            Contract.Ensures(true);
        }
    }
}