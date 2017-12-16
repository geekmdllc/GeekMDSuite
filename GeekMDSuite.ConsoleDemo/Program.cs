using System;
using System.Collections.Generic;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.LaboratoryData.Builder;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Tools.Fitness;

namespace GeekMDSuite.ConsoleDemo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var joe = new PatientBuilder()
                .SetDateOfBirth(1977, 3, 31)
                .SetGender(GenderIdentity.NonBinaryXy)
                .SetMedicalRecordNumber("1234")
                .SetName("Joe", "Bob")
                .SetRace(Race.BlackOrAfricanAmerican)
                .Build();

            var vitals = new VitalSignsBuilder()
                .SetBloodPressure(168, 99, false)
                .SetOxygenSaturation(96)
                .SetPulseRate(105)
                .SetTemperature(101.2)
                .Build();

            var bp = BloodPressure.Build(100, 66);
            
            var test = new TreadmillExerciseStressTestBuilder()
                .SetMaximumBloodPressure(185,55)
                .SetMaximumHeartRate(178)
                .SetProtocol()
                .SetSupineBloodPressure(105,63)
                .SetSupineHeartRate(63)
                .SetTime(15,33)
                .Build();

            var bodyComposition = new BodyCompositionBuilder()
                .SetHeight(73)
                .SetHips(41)
                .SetWaist(52)
                .SetWeight(304)
                .Build();

            var bodyCompositionExpanded = new BodyCompositionExpandedBuilder()
                .SetBodyFatPercentage(35.6)
                .SetHeight(75)
                .SetHips(46)
                .SetVisceralFat(205)
                .SetWaist(47)
                .SetWeight(316.4)
                .Build();

            var mets = CalculateMetabolicEquivalents.FromTreadmillStressTest(test, joe);
            var gripStrength = GripStrength.Build(153, 144);

            var bpInterpretation = new BloodPressureInterpretation(test.SupineBloodPressure);
            var gripStringInterpretation = new GripStrengthInterpretation(gripStrength, joe);
            
            Console.WriteLine($"The METS for {joe.Name.First} are {mets}.");
            Console.WriteLine($"The resting blood pressure was {bpInterpretation.Classification}.");
            Console.WriteLine($"Classification is: {gripStringInterpretation.Classification}");
            Console.WriteLine(bpInterpretation.Interpretation);

            var quantitativeLab = Quantitative.Serum.BilirubinTotal(1.3);
            var qualitativeLab = Qualitative.HepatitisCAntibody(QualitativeLabResult.Negative);

            Console.WriteLine($"Quantitative Lab Type: {quantitativeLab.Type}, Result: {quantitativeLab.Result}.");
            Console.WriteLine($"Qualitative Lab Type: {qualitativeLab.Type}, Result: {qualitativeLab.Result}");

            var cardioRegimen = CardiovascularRegimen.Build(3, 98.5, ExerciseIntensity.Moderate);
            var resistanceRegimen = new ResistanceRegimen(ExerciseRegimenParameters.Build(3, 60, ExerciseIntensity.High),
                90, new List<ResistenceRegimenFeatures>() {ResistenceRegimenFeatures.PullingMovementsPerformed});
        }
    }
}