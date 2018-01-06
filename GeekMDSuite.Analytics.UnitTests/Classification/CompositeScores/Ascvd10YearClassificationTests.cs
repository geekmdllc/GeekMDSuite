using System;
using System.Collections.Generic;
using GeekMDSuite.Analytics.Classification.CompositeScores;
using GeekMDSuite.Analytics.Tools.Cardiology;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Builders.LaboratoryData;
using GeekMDSuite.Core.Models;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification.CompositeScores
{
    public class Ascvd10YearClassificationTests
    {
        [Fact]
        public void Classfication_GivenParams_ReturnsCorrectListOfRiskFactors()
        {
            _patient.Comorbidities.AddRange(new List<ChronicDisease>(){ChronicDisease.Diabetes, ChronicDisease.TobaccoSmoker });
            var ascvd = new AscvdClassification(AscvdParameters.Build(_patient, BloodPressure.Build(130, 75), Quantitative.Serum.CholesterolTotal(213), Quantitative.Serum.LowDensityLipoprotein(195), Quantitative.Serum.HighDensityLipoprotein(50)));

            var riskFactors = ascvd.Classification.RiskFactors;
                
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
            _patient.Gender = Gender.Build(genderIdentity);
            _patient.DateOfBirth = SetDateOfBirthMinusYears(age);
            
            if (diabetic) _patient.Comorbidities.Add(ChronicDisease.Diabetes);
            if (antiHypertensive) _patient.Comorbidities.Add(ChronicDisease.HypertensionTreated);
            if (smoker) _patient.Comorbidities.Add(ChronicDisease.TobaccoSmoker);
            if (ascvdPresent) _patient.Comorbidities.Add(ChronicDisease.DiagnosedCardiovascularDisease);
            
            var ascvdClassification = new AscvdClassification(AscvdParameters.Build(_patient, BloodPressure.Build(systolic, 75), Quantitative.Serum.CholesterolTotal(totalCholesterol), Quantitative.Serum.LowDensityLipoprotein(ldl), Quantitative.Serum.HighDensityLipoprotein(hdl)));
            
            Assert.Equal(expected, ascvdClassification.Classification.StatinRecommendation);
         }
        
        [Theory]
        [InlineData(GenderIdentity.Male, 110, 50, 170, 100, false, false, false, false, AscvdRiskClassification.Low)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, false, false, false, true, AscvdRiskClassification.Borderline)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, true, false, false, false, AscvdRiskClassification.Elevated)]
        public void Classification_GivenParams_ReturnsCorrectAscvdRiskClassification(GenderIdentity genderIdentity, int systolic, double hdl, double totalCholesterol, double ldl, 
            bool diabetic, bool antiHypertensive, bool smoker, bool ascvdPresent, AscvdRiskClassification expected)
        {
            _patient.Gender = Gender.Build(genderIdentity);
            
            if (diabetic) _patient.Comorbidities.Add(ChronicDisease.Diabetes);
            if (antiHypertensive) _patient.Comorbidities.Add(ChronicDisease.HypertensionTreated);
            if (smoker) _patient.Comorbidities.Add(ChronicDisease.TobaccoSmoker);
            if (ascvdPresent) _patient.Comorbidities.Add(ChronicDisease.DiagnosedCardiovascularDisease);
            
            var ascvdClassification = new AscvdClassification(AscvdParameters.Build(_patient, BloodPressure.Build(systolic, 75), Quantitative.Serum.CholesterolTotal(totalCholesterol), Quantitative.Serum.LowDensityLipoprotein(ldl), Quantitative.Serum.HighDensityLipoprotein(hdl)));
            
            Assert.Equal(expected, ascvdClassification.Classification.RiskClassification);
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
            _patient.Gender = Gender.Build(genderIdentity);
            _patient.DateOfBirth = SetDateOfBirthMinusYears(age);
            
            if (diabetic) _patient.Comorbidities.Add(ChronicDisease.Diabetes);
            if (antiHypertensive) _patient.Comorbidities.Add(ChronicDisease.HypertensionTreated);
            if (smoker) _patient.Comorbidities.Add(ChronicDisease.TobaccoSmoker);
            if (ascvdPresent) _patient.Comorbidities.Add(ChronicDisease.DiagnosedCardiovascularDisease);
            
            var ascvdClassification = new AscvdClassification(AscvdParameters.Build(_patient, BloodPressure.Build(systolic, 75), Quantitative.Serum.CholesterolTotal(totalCholesterol), Quantitative.Serum.LowDensityLipoprotein(ldl), Quantitative.Serum.HighDensityLipoprotein(hdl)));

            
            Assert.Equal(expected, ascvdClassification.Classification.AspirinRecommendation);
            
        }
        
        [Theory]
        [InlineData(GenderIdentity.Male, 110, 50, 170, 100, false, false, false, false, AscvdStatinCandidacy.LikelyNotCandidate)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, false, false, false, true, AscvdStatinCandidacy.PossibleCandidate)]
        [InlineData(GenderIdentity.Male, 120, 50, 213, 130, true, false, false, false, AscvdStatinCandidacy.Candidate)]
        public void Classification_GivenParams_ReturnsCorrectStatinCandicacy(GenderIdentity genderIdentity, int systolic, double hdl, double totalCholesterol, double ldl, 
            bool diabetic, bool antiHypertensive, bool smoker, bool ascvdPresent, AscvdStatinCandidacy expected)
        {
            _patient.Gender = Gender.Build(genderIdentity);
            
            if (diabetic) _patient.Comorbidities.Add(ChronicDisease.Diabetes);
            if (antiHypertensive) _patient.Comorbidities.Add(ChronicDisease.HypertensionTreated);
            if (smoker) _patient.Comorbidities.Add(ChronicDisease.TobaccoSmoker);
            if (ascvdPresent) _patient.Comorbidities.Add(ChronicDisease.DiagnosedCardiovascularDisease);
            
            var ascvdClassification = new AscvdClassification(AscvdParameters.Build(_patient, BloodPressure.Build(systolic, 75), Quantitative.Serum.CholesterolTotal(totalCholesterol), Quantitative.Serum.LowDensityLipoprotein(ldl), Quantitative.Serum.HighDensityLipoprotein(hdl)));
            
            Assert.Equal(expected, ascvdClassification.Classification.StatinCandidacy);
        }

        [Fact]
        public void ToString_ReturnsNonEmptyString()
        {
            var riskFactors = new AscvdClassification(AscvdParameters.Build(PatientBuilder.Initialize().SetGender(GenderIdentity.Male).BuildWithoutModelValidation(), BloodPressure.Build(0, 0), Quantitative.Serum.CholesterolTotal(0), Quantitative.Serum.LowDensityLipoprotein(0), Quantitative.Serum.HighDensityLipoprotein(0)));
            
            Assert.NotEmpty(riskFactors.ToString());
        }
        
        public Ascvd10YearClassificationTests()
        {
            _pooledParams = PooledCohortEquationParametersBuilder.Initialize();
            _patient = PatientBuilder.Initialize()
                .SetDateOfBirth(SetDateOfBirthMinusYears(55))
                .SetGender(GenderIdentity.Male)
                .BuildWithoutModelValidation();
        }
        
        public static DateTime SetDateOfBirthMinusYears(int years)
        {
            return DateTime.Now.AddYears(-years);
        }

        private readonly PooledCohortEquationParametersBuilder _pooledParams;
        private readonly Patient _patient;

    }
}