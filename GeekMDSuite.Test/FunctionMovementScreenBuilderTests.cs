using System;
using GeekMDSuite.Procedures;
using Xunit;

namespace GeekMDSuite.Test
{
    public class FunctionMovementScreenBuilderTests
    {
        [Fact]
        public void Builder_WithoutAllMethodsInvoked_ThrowsMissingMethodException()
        {
            Assert.Throws<MissingMethodException>(() => new FunctionalMovementScreenBuilder().Build());
        }
        
        [Fact]
        public void Builder_WithoutOneInvoked_ThrowsMissingMethodException()
        {
            var fmsBuilder = new FunctionalMovementScreenBuilder()
                .SetActiveStraightLegRaise(2, 3)
                .SetHurdleStep(1, 2)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(2, false, 2, true)
                .SetShoulderMobility(1, false, 2, false)
                .SetTrunkStabilityPuhsup(3, false);
            
            Assert.Throws<MissingMethodException>(() => fmsBuilder.Build());
        }
        [Fact]
        public void Builder_WithoutOneInvoked_ThrowsCorrectErrorMessage()
        {
            var fmsBuilder = new FunctionalMovementScreenBuilder()
                .SetActiveStraightLegRaise(2, 3)
                .SetHurdleStep(1, 2)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(2, false, 2, true)
                .SetShoulderMobility(1, false, 2, false)
                .SetTrunkStabilityPuhsup(3, false);

            var errorMessage = string.Empty;
            try
            {
                fmsBuilder.Build();
            }
            catch (MissingMethodException e)
            {
                errorMessage = e.Message;
            }
            
            Assert.Contains(nameof(FunctionalMovementScreenBuilder.SetDeepSquat), errorMessage);
            Assert.DoesNotContain(nameof(FunctionalMovementScreenBuilder.SetHurdleStep), errorMessage);
        }
    }
}