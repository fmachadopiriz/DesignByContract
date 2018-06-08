using System;
using System.Collections.Generic;
using Xunit;

namespace DesignByContract
{
    public class TVTests
    {
        private void TestTV(TV tv)
        {
            tv.TurnOn();
            Assert.True(tv.IsOn);

            Assert.Equal(2, tv.Channel);
            tv.NextChannel();
            Assert.Equal(3, tv.Channel);

            tv.PrevChannel();
            Assert.Equal(2, tv.Channel);
            
            tv.TurnOff();
            Assert.False(tv.IsOn);
        }
        
        /// <summary>
        /// Prueba una TVSamsung.
        /// </summary>
        [Fact]
        public void TVSamsungTest()
        {
            TV tv = new TVSamsung();
            this.TestTV(tv);
        }

        /// <summary>
        /// Prueba una TVLoca.
        /// </summary>
        [Fact]
        public void TVLocaTest()
        {
            // Quitar los comentarios de las siguientes líneas de código hará que los tests fallen:
            // TV tv = new TVLoca();
            // this.TestTV(tv);
        }
    }
}
