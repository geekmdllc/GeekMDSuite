﻿using Xunit;

namespace GeekMDSuite.Test
{
    public class StretchingRegimenInterpretationTests
    {
        
        [Fact]
        public void Calculate_GivenLowIntensityAnd150Minutes_ReturnsInsufficient()
        {
            var result = StretchingRegimenInterpretation.Interpret(
                new StretchingRegimen(new ExerciseRegimenBase(3, 50, ExerciseIntensity.Low)));
            
            Assert.Equal(ExerciseRegimenClassification.Insufficient, result);
        }
        
        [Fact]
        public void Calculate_GivenModerateIntensityAnd7Minutes_ReturnsAdequate()
        {
            var result = StretchingRegimenInterpretation.Interpret(
                new StretchingRegimen(new ExerciseRegimenBase(3, 10, ExerciseIntensity.Moderate)));
            
            Assert.Equal(ExerciseRegimenClassification.Adequate, result);
        }
        
        [Fact]
        public void Calculate_GivenHighIntensityAnd20Minutes_ReturnsAspirational()
        {
            var result = StretchingRegimenInterpretation.Interpret(
                new StretchingRegimen(new ExerciseRegimenBase(3, 20, ExerciseIntensity.High)));
            
            Assert.Equal(ExerciseRegimenClassification.Aspirational, result);
        }
        
        [Fact]
        public void RegimenPercentOfGoalAchieved_GivenHighIntensityStretchingAnd40Minutes_Returns200()
        {
            var result =
                StretchingRegimenInterpretation.DurationPercentOfGoalAchieved(
                    new StretchingRegimen(new ExerciseRegimenBase(4, 10, ExerciseIntensity.High)));
            
            Assert.Equal(200, result);
        }

        [Fact]
        public void IntensityIsAdequate_GivenModerateIntensityStretchingAnd30Minutes_ReturnsTrue()
        {
            var result = StretchingRegimenInterpretation.IntensityIsAdequate(
                new StretchingRegimen(new ExerciseRegimenBase(3, 10, ExerciseIntensity.Moderate)));
            
            Assert.True(result);
        }

        [Fact]
        public void DurationIsAdequate_GivenModerateIntensityStretchingAnd30Minutes_ReturnsTrue()
        {
            var result = StretchingRegimenInterpretation.IntensityIsAdequate(
                new StretchingRegimen(new ExerciseRegimenBase(3, 10, ExerciseIntensity.Moderate)));
            
            Assert.True(result);
        }
        
        [Fact]
        public void RegimenIsAdequate_GivenModerateIntensityStretchingAnd30Minutes_ReturnsTrue()
        {
            var result = StretchingRegimenInterpretation.RegimenIsAdequate(
                new StretchingRegimen(new ExerciseRegimenBase(3, 30, ExerciseIntensity.Moderate)));
            
            Assert.True(result);
        }
    }
}