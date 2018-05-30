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

            tv.NextChannel();
            Assert.Equal(1, tv.Channel);

            tv.PrevChannel();
            Assert.Equal(0, tv.Channel);
            
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
            TV tv = new TVLoca();
            this.TestTV(tv);
        }
    }
}
