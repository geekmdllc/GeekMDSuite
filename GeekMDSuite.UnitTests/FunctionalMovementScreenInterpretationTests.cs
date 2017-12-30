using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Analytics;
using GeekMDSuite.Analytics.Classification;
using Xunit;

namespace GeekMDSuite.UnitTests
{
    public class FunctionalMovementScreenInterpretationTests
    {
        [Fact]
        public void Classification_Given3DeepSquat_ReturnsCorrectScoreAndRecommendedAction()
        {
            var fms = new FunctionalMovementScreenBuilder()
                .SetActiveStraightLegRaise(3, 3)
                .SetDeepSquat(3)
                .SetHurdleStep(3, 3)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(3, 3,false)
                .SetShoulderMobility(3,true, 3,false)
                .SetTrunkStabilityPuhsup(3,false)
                .Build();
            
            var classification = new FunctionalMovementScreenClassification(fms).Classification;
            
            Assert.Equal(FmsScoreFlag.L3R3, classification.DeepSquat.Score);
            Assert.Equal(FmsScoreFlag.L3R3, classification.ActiveStraightLegRaise.Score);
            Assert.Equal(FmsRecommendedAction.Unrestricted, classification.DeepSquat.RecommendedAction);
        }
        [Fact]
        public void Classification_Given1DeepSquat_ReturnsCorrectScoreAndRecommendedAction()
        {
            var fms = new FunctionalMovementScreenBuilder()
                .SetActiveStraightLegRaise(3, 3)
                .SetDeepSquat(1)
                .SetHurdleStep(3, 3)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(3, 3,false)
                .SetShoulderMobility(3,true, 3,false)
                .SetTrunkStabilityPuhsup(3,false)
                .Build();
            
            var deepSquat = new FunctionalMovementScreenClassification(fms).Classification.DeepSquat;
            
            Assert.Equal(FmsScoreFlag.L1R1, deepSquat.Score);
            Assert.Equal(FmsRecommendedAction.Restricted, deepSquat.RecommendedAction);
        }
        [Fact]
        public void Classification_GivenL3R3ActiveStraightLegRaise_ReturnsCorrectScoreAndRecommendedAction()
        {
            var fms = new FunctionalMovementScreenBuilder()
                .SetActiveStraightLegRaise(3, 3)
                .SetDeepSquat(3)
                .SetHurdleStep(3, 3)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(3, 3,false)
                .SetShoulderMobility(3,true, 3,false)
                .SetTrunkStabilityPuhsup(3,false)
                .Build();
            
            var activeStraightLegRaise = new FunctionalMovementScreenClassification(fms).Classification.ActiveStraightLegRaise;
            
            Assert.Equal(FmsScoreFlag.L3R3, activeStraightLegRaise.Score);
            Assert.Equal(FmsRecommendedAction.Unrestricted, activeStraightLegRaise.RecommendedAction);
        }
        
        [Fact]
        public void Classification_GivenL3R1ActiveStraightLegRaise_ReturnsCorrectScoreAndRecommendedAction()
        {
            var fms = new FunctionalMovementScreenBuilder()
                .SetActiveStraightLegRaise(3, 1)
                .SetDeepSquat(3)
                .SetHurdleStep(3, 3)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(3, 3,false)
                .SetShoulderMobility(3,true, 3,false)
                .SetTrunkStabilityPuhsup(3,false)
                .Build();
            
            var activeStraightLegRaise = new FunctionalMovementScreenClassification(fms).Classification.ActiveStraightLegRaise;
            
            Assert.Equal(FmsScoreFlag.L3R1, activeStraightLegRaise.Score);
            Assert.Equal(FmsRecommendedAction.Restricted, activeStraightLegRaise.RecommendedAction);
        }
        [Fact]
        public void Classification_GivenL3R3LPainPositiveLPainNegativeRotaryStability_ReturnsCorrectScoreAndRecommendedAction()
        {
            var fms = new FunctionalMovementScreenBuilder()
                .SetActiveStraightLegRaise(3, 3)
                .SetDeepSquat(3)
                .SetHurdleStep(3, 3)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(3, 3,true)
                .SetShoulderMobility(3,false, 3,false)
                .SetTrunkStabilityPuhsup(3,false)
                .Build();
            
            var rotaryStability = new FunctionalMovementScreenClassification(fms).Classification.RotaryStability;
            
            Assert.Equal(FmsScoreFlag.L0R0, rotaryStability.Score);
            Assert.Equal(FmsRecommendedAction.MedicalAttention, rotaryStability.RecommendedAction);
        }
        
        [Fact]
        public void Classification_GivenL3R1LPainNegativeLPainNegativeRotaryStability_ReturnsCorrectScoreAndRecommendedAction()
        {
            var fms = new FunctionalMovementScreenBuilder()
                .SetActiveStraightLegRaise(3, 3)
                .SetDeepSquat(3)
                .SetHurdleStep(3, 3)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(3, 1,false)
                .SetShoulderMobility(3,false, 3,false)
                .SetTrunkStabilityPuhsup(3,false)
                .Build();
            
            var rotaryStability = new FunctionalMovementScreenClassification(fms).Classification.RotaryStability;
            
            Assert.Equal(FmsScoreFlag.L3R1, rotaryStability.Score);
            Assert.Equal(FmsRecommendedAction.Restricted, rotaryStability.RecommendedAction);
        }
        [Fact]
        public void Classification_Given3TrunkStability_ReturnsCorrectScoreAndRecommendedAction()
        {
            var fms = new FunctionalMovementScreenBuilder()
                .SetActiveStraightLegRaise(3, 3)
                .SetDeepSquat(3)
                .SetHurdleStep(3, 3)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(3, 3,false)
                .SetShoulderMobility(3,false, 3,false)
                .SetTrunkStabilityPuhsup(3,false)
                .Build();
            
            var trunkStabilityPushup = new FunctionalMovementScreenClassification(fms).Classification.TrunkStabilityPushup;
            
            Assert.Equal(FmsScoreFlag.L3R3, trunkStabilityPushup.Score);
            Assert.Equal(FmsRecommendedAction.Unrestricted, trunkStabilityPushup.RecommendedAction);
        }
        [Fact]
        public void Classification_Given3PainPositiveTrunkStability_ReturnsCorrectScoreAndRecommendedAction()
        {
            var fms = new FunctionalMovementScreenBuilder()
                .SetActiveStraightLegRaise(3, 3)
                .SetDeepSquat(3)
                .SetHurdleStep(3, 3)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(3, 3,false)
                .SetShoulderMobility(3,false, 3,false)
                .SetTrunkStabilityPuhsup(3,true)
                .Build();
            
            var trunkStabilityPushup = new FunctionalMovementScreenClassification(fms).Classification.TrunkStabilityPushup;
            
            Assert.Equal(FmsScoreFlag.L0R0, trunkStabilityPushup.Score);
            Assert.Equal(FmsRecommendedAction.MedicalAttention, trunkStabilityPushup.RecommendedAction);
        }
        [Fact]
        public void Classification_Given1PainNegativeTrunkStability_ReturnsCorrectScoreAndRecommendedAction()
        {
            var fms = new FunctionalMovementScreenBuilder()
                .SetActiveStraightLegRaise(3, 3)
                .SetDeepSquat(3)
                .SetHurdleStep(3, 3)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(3, 3,false)
                .SetShoulderMobility(3,false, 3,false)
                .SetTrunkStabilityPuhsup(1,false)
                .Build();
            
            var trunkStabilityPushup = new FunctionalMovementScreenClassification(fms).Classification.TrunkStabilityPushup;
            
            Assert.Equal(FmsScoreFlag.L1R1, trunkStabilityPushup.Score);
            Assert.Equal(FmsRecommendedAction.Restricted, trunkStabilityPushup.RecommendedAction);
        }

        [Fact]
        public void NullFunctionalMovementScreen_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new FunctionalMovementScreenClassificationResult(null));
        }
    }
}