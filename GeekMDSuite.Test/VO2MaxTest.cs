using System;
using GeekMDSuite.Tools;
using GeekMDSuite.Tools.Math.Fitness;
using GeekMDSuite.Tools.MeasurementUnits;
using Xunit;

namespace GeekMDSuite.Test
{
    public class Vo2MaxTest
    {

        private readonly TimeDuration _timeDuration = new TimeDuration(11,33);
        private const GenderIdentity _male = GenderIdentity.Male;
        private readonly GenderIdentity _female = GenderIdentity.Female;
        private readonly TreadmillProtocol _protocol = TreadmillProtocol.Bruce;
        private readonly TreadmillProtocol _unsupportedProtocol =
            TreadmillProtocol.Balke3Point0;
        
        [Fact]
        public void MaleResultInRange()
        {            
            var result = Vo2Max.FromTreadmillStressTest(_protocol, _timeDuration, _male);
            Assert.InRange(result, 40,41); 
        }
        
        [Fact]
        public void FemaleResultInRange()
        {            
            var result = Vo2Max.FromTreadmillStressTest(_protocol, _timeDuration, _female);
            Assert.InRange(result, 46,47); 
        }

        [Fact]
        public void UnsupportedProtocolThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() =>
                Vo2Max.FromTreadmillStressTest(_unsupportedProtocol, _timeDuration, _male));
        }
    }
}