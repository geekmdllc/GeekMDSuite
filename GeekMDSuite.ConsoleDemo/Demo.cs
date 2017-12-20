using System;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.LaboratoryData.Builder;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Tools.Cardiology;
using GeekMDSuite.Tools.Fitness;

namespace GeekMDSuite.ConsoleDemo
{
    public static class Demo
    {
        public static void Main(string[] args)
        {
            var joe = PatientBuilder
                .Initialize()
                .SetDateOfBirth(1977, 3, 31)
                .SetGender(GenderIdentity.NonBinaryXy)
                .SetMedicalRecordNumber("1234")
                .SetName("Joe", "Bob")
                .SetRace(Race.BlackOrAfricanAmerican)
                .Build();

            Console.WriteLine($"Meet our patient: {joe}\n");

            var vitals = VitalSignsBuilder.Initialize()
                .SetBloodPressure(168, 99, false)
                .SetOxygenSaturation(96)
                .SetPulseRate(105)
                .SetTemperature(101.2)
                .Build();
            Console.WriteLine($"{joe.Name.First}'s vitals: {vitals}\n");

            var bp = BloodPressure.Build(100, 66);
            Console.WriteLine($"If {joe.Name.First} used to have good blood pressure, it  was {bp}.\n");

            var bodyComposition = BodyCompositionBuilder
                .Initialize()
                .SetHeight(73)
                .SetHips(41)
                .SetWaist(52)
                .SetWeight(316.4)
                .Build();

            Console.WriteLine($"Simple body composition measures: {bodyComposition}\n");

            var bodyCompositionExpanded = BodyCompositionExpandedBuilder
                .Initialize()
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
            
            var resistanceRegimen =  ResistanceRegimenBuilder
                .Initialize()
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

            var audiogramDataLeft = AudiogramDatasetBuilder
                .Initialize()
                .Set125HertzDataPoint(10)
                .Set125HertzDataPoint(20)
                .Set500HertzDataPoint(30)
                .Set1000HertzDataPoint(10)
                .Set2000HertzDataPoint(25)
                .Set3000HertzDataPoint(45)
                .Set4000HertzDataPoint(40)
                .Set6000HertzDataPoint(50)
                .Set8000HertzDataPoint(70)
                .Build();
            
            var audiogramDataRight = AudiogramDatasetBuilder
                .Initialize()
                .Set125HertzDataPoint(10)
                .Set125HertzDataPoint(20)
                .Set500HertzDataPoint(30)
                .Set1000HertzDataPoint(10)
                .Set2000HertzDataPoint(25)
                .Set3000HertzDataPoint(45)
                .Set4000HertzDataPoint(40)
                .Set6000HertzDataPoint(50)
                .Set8000HertzDataPoint(90)
                .Build();
            
            var audiogram = Audiogram.Build(audiogramDataLeft, audiogramDataRight);
            Console.WriteLine($"Audiogram\n{audiogram}\n");

            var carotidLeft = CarotidUltrasoundResultBuilder
                .Initialize()
                .SetIntimaMediaThickeness(0.693)
                .Build();

            var carotidRight = CarotidUltrasoundResultBuilder
                .Initialize()
                .SetIntimaMediaThickeness(0.732)
                .SetImtGrade(CarotidIntimaMediaThicknessGrade.Mild)
                .SetPercentStenosisGrade(CarotidPercentStenosisGrade.Nominal)
                .SetPlaqueCharacter(CarotidPlaqueCharacter.EarlyBuildup)
                .Build();

            var carotidUs = CarotidUltrasound.Build(carotidLeft, carotidRight);

            Console.WriteLine($"Carotid US\n{carotidUs}\n");

            var centralBp = CentralBloodPressureBuilder
                .Initialize()
                .SetAugmentedIndex(25)
                .SetAugmentedPressure(4)
                .SetCentralSystolicPressure(113)
                .SetPulsePressure(16)
                .SetPulseWaveVelocity(7.9)
                .SetReferenceAge(43)
                .Build();

            Console.WriteLine($"Central BP: {centralBp}\n");

            var functionalMovementScreen = FunctionalMovementScreenBuilder
                .Initialize()
                .SetActiveStraightLegRaise(2, 3)
                .SetDeepSquat(3)
                .SetHurdleStep(2, 2)
                .SetInlineLunge(3, 3)
                .SetRotaryStability(2, true, 2, false)
                .SetShoulderMobility(2, false, 2, false)
                .SetTrunkStabilityPuhsup(2, false)
                .Build();

            Console.WriteLine($"Functional Movement Screen\n{functionalMovementScreen}\n");

            var gripStrength = GripStrength.Build(123, 135);
            Console.WriteLine($"Grip strength {gripStrength}\n");

            var ishiharaSix = IshiharaSixPlateScreenBuilder
                .Initialize()
                .SetPlate1(IshiharaAnswerResult.NormalVision)
                .SetPlate2(IshiharaAnswerResult.ColorVisionDefict)
                .SetPlate3(IshiharaAnswerResult.NormalVision)
                .SetPlate4(IshiharaAnswerResult.NormalVision)
                .SetPlate5(IshiharaAnswerResult.NormalVision)
                .SetPlate6(IshiharaAnswerResult.ColorVisionDefict)
                .Build();

            Console.WriteLine("Ishihara Six Plate Screener");
            foreach (var plate in ishiharaSix) Console.WriteLine(plate);
            Console.WriteLine();

            var ocularPressure = OcularPressure.Build(15, 13);
            Console.WriteLine($"Ocular pressure: {ocularPressure}\n");

            var peripheralVision = PeripheralVision.Build(85, 85);
            Console.WriteLine($"Peripheral vision: {peripheralVision}\n");

            var pushups = Pushups.Build(35);
            Console.WriteLine($"Pushups: {pushups}\n");

            var sitAndReach = SitAndReach.Build(13);
            Console.WriteLine($"Sit & Reach: {sitAndReach}\n");

            var situps = Situps.Build(55);
            Console.WriteLine($"Situps: {situps}\n");

            var spirometry = SpirometryBuilder
                .Initialize()
                .SetForcedVitalCapacity(6.3)
                .SetForcedExpiratoryVolume1Second(5.5)
                .SetForcedExpiratoryFlow25To75(6.3)
                .SetForcedExpiratoryTime(7.5)
                .SetPeakExpiratoryFlow(9.3)
                .Build();

            Console.WriteLine($"Spirometry: {spirometry}\n");

            var treadmillStressTest = TreadmillExerciseStressTestBuilder
                .Initialize()
                .SetMaximumBloodPressure(205, 95)
                .SetMaximumHeartRate(183)
                .SetProtocol()
                .SetResult(TreadmillExerciseStressTestResultClassification.Normal)
                .SetSupineBloodPressure(133, 82)
                .SetSupineHeartRate(66)
                .SetTime(11, 33)
                .Build();

            Console.WriteLine($"Treadmill: {treadmillStressTest}\n");

            var visualAcuity = VisualAcuity.Build(20, 20, 20);
            Console.WriteLine($"Visual acuity: {visualAcuity}\n");

            var predictedMaxHrStd = PredictMaximumHeartRate.Standard(joe.Age);
            Console.WriteLine($"Joes predicted max HR (standard formula): {predictedMaxHrStd} bpm\n");

            var predictedMaxHrRevisited = PredictMaximumHeartRate.Revisited(joe.Age);
            Console.WriteLine($"Joes predicted max HR (revisted formula): {predictedMaxHrRevisited} bpm\n");

            var vo2Max = CalculateVo2Max.FromTreadmillStressTest(treadmillStressTest, joe);
            Console.WriteLine($"Joes VO2Max as calculated from his treadmill stress test: {vo2Max}\n");

            var metsTreadmill = CalculateMetabolicEquivalents.FromTreadmillStressTest(treadmillStressTest, joe);
            Console.WriteLine($"Joes METS as calculated from his treadmill stress test: {metsTreadmill}\n");

            var metsVo2Max = CalculateMetabolicEquivalents.FromVo2Max(vo2Max);
            Console.WriteLine($"Joes METS as calcualted from his VO2Max: {metsVo2Max}\n");
            
            var audiogramInterpretation = new AudiogramInterpretation(audiogram);
            Console.WriteLine($"Audiogram Classification: {audiogramInterpretation}\n");
            
            var bpInterpretation = new BloodPressureInterpretation(vitals.BloodPressure);
            Console.WriteLine($"BP Classification: {bpInterpretation}\n");
            
            var bodyCompExpandedInterp = new BodyCompositionBaseExpandedInterpretation(bodyCompositionExpanded);
            Console.WriteLine($"Body comp: ${bodyCompExpandedInterp}\n");
        }
    }
}