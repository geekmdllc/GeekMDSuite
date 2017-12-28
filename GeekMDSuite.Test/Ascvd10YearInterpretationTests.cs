﻿using GeekMDSuite.LaboratoryData.Builder;
using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Tools.Cardiology;
using Moq;
using Xunit;

namespace GeekMDSuite.Test
{
    public class Ascvd10YearInterpretationTests
    {
        [Fact]
        public void Classfication_GivenParams_ReturnsCorrectListOfRiskFactors()
        {
            _mockPatient.Setup(p => p.Gender.Category).Returns(GenderIdentity.Male);
            _mockPatient.Setup(p => p.Age).Returns(55);

            _pooledParams
                .SetBloodPressure(130, 75)
                .SetHdlCholesterol(50)
                .SetPatient(_mockPatient.Object)
                .SetTotalCholesterol(213)
                .ConfirmDiabetic()
                .ConfirmSmoker();

            var riskFactors = new Ascvd10YearInterpretation(_pooledParams.Build(), 
                Quantitative.Serum.LowDensityLipoprotein(195)).Classification.RiskFactors;
            
            Assert.Contains(AscvdModifiableRiskFactors.BloodPressureElevated, riskFactors);
            Assert.Contains(AscvdModifiableRiskFactors.TotalCholesterolElevated, riskFactors);
            Assert.Contains(AscvdModifiableRiskFactors.Diabetes, riskFactors);
            Assert.Contains(AscvdModifiableRiskFactors.Smoker, riskFactors);
         }
        
        [Theory]
        [InlineData(GenderIdentity.Male, 110, 50, 170, 100, false, false, false, false, 55, AscvdStatinRecommendation.LikelyNotBeneficial)]
        [InlineData(GenderIdentity.Male, 110, 50, 200, 190, false, false, false, false, 55, AscvdStatinRecommendation.HighIntensity)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, false, false, false, true, 55, AscvdStatinRecommendation.HighIntensity)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, true, false, false, false, 55, AscvdStatinRecommendation.HighIntensity)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, false, false, false, false, 65, AscvdStatinRecommendation.ModerateToHighIntensity)]
        [InlineData(GenderIdentity.Male, 110, 60, 170, 50, false, false, false, true, 76, AscvdStatinRecommendation.ModerateIntensity)]
        [InlineData(GenderIdentity.Male, 110, 60, 170, 50, false, false, false, false, 76, AscvdStatinRecommendation.PossiblyBeneficial)]
        public void Classfication_GivenParams_ReturnsCorrectStatinRecommendation(GenderIdentity genderIdentity, int systolic, 
            double hdl, double totalCholesterol, double ldl, 
            bool diabetic, bool antiHypertensive, bool smoker, bool ascvdPresent, 
            int age, AscvdStatinRecommendation expected)
        {
            _mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);
            _mockPatient.Setup(p => p.Age).Returns(age);

            _pooledParams
                .SetBloodPressure(systolic, 75)
                .SetHdlCholesterol(hdl)
                .SetPatient(_mockPatient.Object)
                .SetTotalCholesterol(totalCholesterol)
                .ConfirmDiabetic(diabetic)
                .ConfirmOnAntiHypertensiveMedication(antiHypertensive)
                .ConfirmSmoker(smoker);

            var ascvdClassification = new Ascvd10YearInterpretation(_pooledParams.Build(), Quantitative.Serum.LowDensityLipoprotein(ldl),
                ascvdPresent).Classification;
            
            Assert.Equal(expected, ascvdClassification.StatinRecommendation);
         }
        
        [Theory]
        [InlineData(GenderIdentity.Male, 110, 50, 170, 100, false, false, false, false, AscvdRiskClassification.Low)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, false, false, false, true, AscvdRiskClassification.Borderline)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, true, false, false, false, AscvdRiskClassification.Elevated)]
        public void Classification_GivenParams_ReturnsCorrectAscvdRiskClassification(GenderIdentity genderIdentity, int systolic, double hdl, double totalCholesterol, double ldl, 
            bool diabetic, bool antiHypertensive, bool smoker, bool ascvdPresent, AscvdRiskClassification expected)
        {
            _mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);

            _pooledParams
                .SetBloodPressure(systolic, 75)
                .SetHdlCholesterol(hdl)
                .SetPatient(_mockPatient.Object)
                .SetTotalCholesterol(totalCholesterol)
                .ConfirmDiabetic(diabetic)
                .ConfirmOnAntiHypertensiveMedication(antiHypertensive)
                .ConfirmSmoker(smoker);

            var ascvdClassification = new Ascvd10YearInterpretation(_pooledParams.Build(), Quantitative.Serum.LowDensityLipoprotein(ldl),
                ascvdPresent).Classification;
            
            Assert.Equal(expected, ascvdClassification.RiskClassification);
        }
        
        [Theory]
        [InlineData(GenderIdentity.Male, 110, 50, 170, 100, false, false, false, false, 55, AscvdAspirinRecommendation.InsufficientEvidenceLikelyNotBeneficial)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, false, false, false, true, 55, AscvdAspirinRecommendation.InsufficientEvidenceLikelyNotBeneficial)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, true, false, false, false, 55, AscvdAspirinRecommendation.Beneficial)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, true, false, false, false, 65, AscvdAspirinRecommendation.BeneficialWithReservation)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, true, false, false, false, 70, AscvdAspirinRecommendation.InsufficientEvidenceLikelyBeneficial)]
        public void Classfication_GivenParams_ReturnsCorrectAscvdAspirinRecommendation(GenderIdentity genderIdentity, int systolic, double hdl, double totalCholesterol, double ldl, 
            bool diabetic, bool antiHypertensive, bool smoker, bool ascvdPresent, int age, AscvdAspirinRecommendation expected)
        {
            _mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);
            _mockPatient.Setup(p => p.Age).Returns(age);

            _pooledParams
                .SetBloodPressure(systolic, 75)
                .SetHdlCholesterol(hdl)
                .SetPatient(_mockPatient.Object)
                .SetTotalCholesterol(totalCholesterol)
                .ConfirmDiabetic(diabetic)
                .ConfirmOnAntiHypertensiveMedication(antiHypertensive)
                .ConfirmSmoker(smoker);

            var ascvdClassification = new Ascvd10YearInterpretation(_pooledParams.Build(), Quantitative.Serum.LowDensityLipoprotein(ldl),
                ascvdPresent).Classification;
            
            Assert.Equal(expected, ascvdClassification.AspirinRecommendation);
            
        }
        
        [Theory]
        [InlineData(GenderIdentity.Male, 110, 50, 170, 100, false, false, false, false, AscvdStatinCandidacy.LikelyNotCandidate)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, false, false, false, true, AscvdStatinCandidacy.PossibleCandidate)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, true, false, false, false, AscvdStatinCandidacy.Candidate)]
        public void Classification_GivenParams_ReturnsCorrectStatinCandicacy(GenderIdentity genderIdentity, int systolic, double hdl, double totalCholesterol, double ldl, 
            bool diabetic, bool antiHypertensive, bool smoker, bool ascvdPresent, AscvdStatinCandidacy expected)
        {
            _mockPatient.Setup(p => p.Gender.Category).Returns(genderIdentity);

            _pooledParams
                .SetBloodPressure(systolic, 75)
                .SetHdlCholesterol(hdl)
                .SetPatient(_mockPatient.Object)
                .SetTotalCholesterol(totalCholesterol)
                .ConfirmDiabetic(diabetic)
                .ConfirmOnAntiHypertensiveMedication(antiHypertensive)
                .ConfirmSmoker(smoker);

            var ascvdClassification = new Ascvd10YearInterpretation(_pooledParams.Build(), Quantitative.Serum.LowDensityLipoprotein(ldl),
                ascvdPresent).Classification;
            
            Assert.Equal(expected, ascvdClassification.StatinCandidacy);
        }
        public Ascvd10YearInterpretationTests()
        {
            _mockPatient = new Mock<IPatient>();
            _mockPatient.Setup(p => p.Age).Returns(55);
            _pooledParams = PooledCohortEquationParametersBuilder.Initialize();
        }

        private readonly Mock<IPatient> _mockPatient;
        private readonly PooledCohortEquationParametersBuilder _pooledParams;
    }
}