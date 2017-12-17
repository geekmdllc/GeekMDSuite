using System;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.LaboratoryData.Builder;
using GeekMDSuite.PatientActivities;

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

            Console.WriteLine($"Meet our patient: {joe}\n");

            var vitals = new VitalSignsBuilder()
                .SetBloodPressure(168, 99, false)
                .SetOxygenSaturation(96)
                .SetPulseRate(105)
                .SetTemperature(101.2)
                .Build();
            Console.WriteLine($"{joe.Name.First}'s vitals: {vitals}\n");

            var bp = BloodPressure.Build(100, 66);
            Console.WriteLine($"If {joe.Name.First} used to have good blood pressure, it  was {bp}.\n");

            var bodyComposition = new BodyCompositionBuilder()
                .SetHeight(73)
                .SetHips(41)
                .SetWaist(52)
                .SetWeight(316.4)
                .Build();

            Console.WriteLine($"Simple body composition measures: {bodyComposition}\n");

            var bodyCompositionExpanded = new BodyCompositionExpandedBuilder()
                .SetBodyFatPercentage(35.6)
                .SetHeight(73)
                .SetHips(41)
                .SetVisceralFat(205)
                .SetWaist(52)
                .SetWeight(316.4)
                .Build();

            Console.WriteLine($"Expanded body composition measures: {bodyCompositionExpanded}\n");

            var quantitativeLab = Quantitative.Serum.BilirubinTotal(1.3);
            Console.WriteLine($"Quantitative Lab: {quantitativeLab.Type}, Result: {quantitativeLab.Result}.\n");
            
            var qualitativeLab = Qualitative.HepatitisCAntibody(QualitativeLabResult.Negative);
            Console.WriteLine($"Qualitative Lab: {qualitativeLab.Type}, Result: {qualitativeLab.Result}\n");

            var cardioRegimen = CardiovascularRegimen.Build(3, 98.5, ExerciseIntensity.Moderate);
            Console.WriteLine($"Cardio regimen: {cardioRegimen}\n");
            
            var stretchRegimen = StretchingRegimen.Build(1, 10, ExerciseIntensity.Low);
            Console.WriteLine($"Stretching regimen: {stretchRegimen}\n");
            
            var resistanceRegimen =  new ResistanceRegimenBuilder()
                .SetAverageSessionDuration(120)
                .SetIntensity(ExerciseIntensity.Moderate)
                .SetSecondsRestDurationPerSet(90)
                .SetSessionsPerWeek(6)
                .ConfirmLowerBodyTrained()
                .ConfirmUpperBodyTrained()
                .ConfirmPullingMovementsPerformed()
                .ConfirmPushingMovementsPerformed()
                .ConfirmRepetitionsToNearFailure()
                .Build();
            Console.WriteLine($"Resistance regimen: {resistanceRegimen}\n");

        }
    }
}