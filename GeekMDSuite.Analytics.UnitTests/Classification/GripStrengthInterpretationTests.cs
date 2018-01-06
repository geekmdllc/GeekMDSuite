using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification
{
    public class GripStrengthInterpretationTests
    {
        public GripStrengthInterpretationTests()
        {
            var dateOfBirth = DateTime.Now.AddYears(-55);
            _patient = PatientBuilder.Initialize()
                .SetDateOfBirth(dateOfBirth.Year, dateOfBirth.Month, dateOfBirth.Day)
                .BuildWithoutModelValidation();
        }

        [Theory]
        [InlineData(GenderIdentity.Male, 60, 60, GripStrengthScore.Weak)]
        [InlineData(GenderIdentity.Male, 100, 100, GripStrengthScore.Normal)]
        [InlineData(GenderIdentity.Male, 150, 150, GripStrengthScore.Strong)]
        [InlineData(GenderIdentity.Male, 60, 60, GripStrengthScore.Weak)]
        public void Classification_GivenValues_ReturnsCorrectClassification(GenderIdentity gender, double left,
            double right, GripStrengthScore expected)
        {
            _patient.Gender = Gender.Build(gender);
            var gs = GripStrength.Build(left, right);

            var classification = new GripStrengthClassification(gs, _patient).Classification;

            Assert.Equal(expected, classification.WorseSide);
        }

        private readonly Patient _patient;

        [Fact]
        public void Classification_Given40yrFemale33lbsL66lbsR_ReturnsWorseSideWeakLateralityLeft()
        {
            _patient.Gender = Gender.Build(GenderIdentity.Female);
            var gs = GripStrength.Build(33, 66);

            var classification = new GripStrengthClassification(gs, _patient).Classification;

            Assert.Equal(GripStrengthScore.Weak, classification.WorseSide);
            Assert.Equal(Laterality.Left, classification.Laterality);
        }

        [Fact]
        public void Classification_Given40yrMale150lbsL50lbsR_ReturnsWorseSideWeakLateralityRight()
        {
            _patient.Gender = Gender.Build(GenderIdentity.Male);
            var gs = GripStrength.Build(150, 50);

            var classification = new GripStrengthClassification(gs, _patient).Classification;

            Assert.Equal(GripStrengthScore.Weak, classification.WorseSide);
            Assert.Equal(Laterality.Right, classification.Laterality);
        }

        [Fact]
        public void Classification_Given40yrMale50lbsL150lbsR_ReturnsWorseSideWeakLateralityLeft()
        {
            _patient.Gender = Gender.Build(GenderIdentity.Male);
            var gs = GripStrength.Build(50, 150);

            var classification = new GripStrengthClassification(gs, _patient).Classification;

            Assert.Equal(GripStrengthScore.Weak, classification.WorseSide);
            Assert.Equal(Laterality.Left, classification.Laterality);
        }

        [Fact]
        public void NullGripStrength_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new GripStrengthClassification(
                null,
                PatientBuilder.Initialize()
                    .SetGender(GenderIdentity.Male)
                    .BuildWithoutModelValidation())
            );
        }

        [Fact]
        public void NullPatient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new GripStrengthClassification(GripStrength.Build(0, 0), null));
        }
    }
}