using System;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.LaboratoryData.Builder;
using GeekMDSuite.PatientActivities;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Services.Interpretation.PatientActivities;
using GeekMDSuite.Tools.Cardiology;
using GeekMDSuite.Tools.Fitness;
using static System.Environment;

namespace GeekMDSuite.ConsoleDemo
{
    public static class Demo
    {
        public static void Main(string[] args)
        {
            var patient = PatientBuilder
                .Initialize()
                .SetDateOfBirth(1952, 3, 31)
                .SetGender(GenderIdentity.NonBinaryXy)
                .SetMedicalRecordNumber("1234")
                .SetName("Joe", "Bob")
                .SetRace(Race.BlackOrAfricanAmerican)
                .Build();

            Console.WriteLine($"Meet our patient: {patient}{NewLine}");

            var vitals = VitalSignsBuilder.Initialize()
                .SetBloodPressure(168, 99, false)
                .SetOxygenSaturation(96)
                .SetPulseRate(105)
                .SetTemperature(101.2)
                .Build();
            Console.WriteLine($"{patient.Name.First}'s vitals: {vitals}{NewLine}");

            var bp = BloodPressure.Build(100, 66);
            Console.WriteLine($"If {patient.Name.First} used to have good blood pressure, it  was {bp}.{NewLine}");

            var bodyComposition = BodyCompositionBuilder
                .Initialize()
                .SetHeight(70.9)
                .SetHips(40)
                .SetWaist(34)
                .SetWeight(193)
                .Build();

            Console.WriteLine($"Simple body composition measures: {bodyComposition}{NewLine}");

            var bodyCompositionExpanded = BodyCompositionExpandedBuilder
                .Initialize()
                .SetBodyFatPercentage(16.5)
                .SetHeight(bodyComposition.Height.Inches)
                .SetHips(bodyComposition.Hips.Inches)
                .SetVisceralFat(70)
                .SetWaist(bodyComposition.Waist.Inches)
                .SetWeight(bodyComposition.Weight.Pounds)
                .Build();

            Console.WriteLine($"Expanded body composition measures: {bodyCompositionExpanded}{NewLine}");

            var quantitativeLabChoesterol = Quantitative.Serum.CholesterolTotal(300);
            Console.WriteLine($"Quantitative Lab: {quantitativeLabChoesterol.Type}, Result: {quantitativeLabChoesterol.Result}.{NewLine}");
            
            var quantitativeLabHdlC = Quantitative.Serum.CholesterolTotal(35);
            Console.WriteLine($"Quantitative Lab: {quantitativeLabHdlC.Type}, Result: {quantitativeLabHdlC.Result}.{NewLine}");
            
            var qualitativeLab = Qualitative.HepatitisCAntibody(QualitativeLabResult.Negative);
            Console.WriteLine($"Qualitative Lab: {qualitativeLab.Type}, Result: {qualitativeLab.Result}{NewLine}");

            var cardioRegimen = CardiovascularRegimen.Build(3, 98.5, ExerciseIntensity.Moderate);
            Console.WriteLine($"Cardio regimen: {cardioRegimen}{NewLine}");
            
            var stretchRegimen = StretchingRegimen.Build(1, 10, ExerciseIntensity.Low);
            Console.WriteLine($"Stretching regimen: {stretchRegimen}{NewLine}");
            
            var resistanceRegimen =  ResistanceRegimenBuilder
                .Initialize()
                .SetAverageSessionDuration(120)
                .SetIntensity(ExerciseIntensity.Moderate)
                .SetSecondsRestDurationPerSet(90)
                .SetSessionsPerWeek(6)
                .ConfirmUpperBodyTrained()
                .ConfirmPullingMovementsPerformed()
                .ConfirmPushingMovementsPerformed()
                .ConfirmRepetitionsToNearFailure()
                .Build();
            Console.WriteLine($"Resistance regimen: {resistanceRegimen}{NewLine}");

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
            Console.WriteLine($"Audiogram{NewLine}{audiogram}{NewLine}");

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

            Console.WriteLine($"Carotid US{NewLine}{carotidUs}{NewLine}");

            var centralBp = CentralBloodPressureBuilder
                .Initialize()
                .SetAugmentedIndex(25)
                .SetAugmentedPressure(4)
                .SetCentralSystolicPressure(113)
                .SetPulsePressure(16)
                .SetPulseWaveVelocity(7.9)
                .SetReferenceAge(43)
                .Build();

            Console.WriteLine($"Central BP: {centralBp}{NewLine}");

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

            Console.WriteLine($"Functional Movement Screen{NewLine}{functionalMovementScreen}{NewLine}");

            var gripStrength = GripStrength.Build(123, 135);
            Console.WriteLine($"Grip strength {gripStrength}{NewLine}");

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
            Console.WriteLine($"Ocular pressure: {ocularPressure}{NewLine}");

            var peripheralVision = PeripheralVision.Build(85, 85);
            Console.WriteLine($"Peripheral vision: {peripheralVision}{NewLine}");

            var pushups = Pushups.Build(35);
            Console.WriteLine($"Pushups: {pushups}{NewLine}");

            var sitAndReach = SitAndReach.Build(13);
            Console.WriteLine($"Sit & Reach: {sitAndReach}{NewLine}");

            var situps = Situps.Build(55);
            Console.WriteLine($"Situps: {situps}{NewLine}");

            var spirometry = SpirometryBuilder
                .Initialize()
                .SetForcedVitalCapacity(6.3)
                .SetForcedExpiratoryVolume1Second(5.5)
                .SetForcedExpiratoryFlow25To75(6.3)
                .SetForcedExpiratoryTime(7.5)
                .SetPeakExpiratoryFlow(9.3)
                .Build();

            Console.WriteLine($"Spirometry: {spirometry}{NewLine}");

            var treadmillStressTest = TreadmillExerciseStressTestBuilder
                .Initialize()
                .SetMaximumBloodPressure(205, 95)
                .SetMaximumHeartRate(183)
                .SetProtocol()
                .SetResult(TmstResult.Normal)
                .SetSupineBloodPressure(133, 82)
                .SetSupineHeartRate(66)
                .SetTime(11, 33)
                .Build();

            Console.WriteLine($"Treadmill: {treadmillStressTest}{NewLine}");

            var visualAcuity = VisualAcuity.Build(20, 20, 20);
            Console.WriteLine($"Visual acuity: {visualAcuity}{NewLine}");

            var predictedMaxHrStd = PredictMaximumHeartRate.Standard(patient.Age);
            Console.WriteLine($"Joes predicted max HR (standard formula): {predictedMaxHrStd} bpm{NewLine}");

            var predictedMaxHrRevisited = PredictMaximumHeartRate.Revisited(patient.Age);
            Console.WriteLine($"Joes predicted max HR (revisted formula): {predictedMaxHrRevisited} bpm{NewLine}");

            var vo2Max = CalculateVo2Max.FromTreadmillStressTest(treadmillStressTest, patient);
            Console.WriteLine($"Joes VO2Max as calculated from his treadmill stress test: {vo2Max}{NewLine}");

            var metsTreadmill = CalculateMetabolicEquivalents.FromTreadmillStressTest(treadmillStressTest, patient);
            Console.WriteLine($"Joes METS as calculated from his treadmill stress test: {metsTreadmill}{NewLine}");

            var metsVo2Max = CalculateMetabolicEquivalents.FromVo2Max(vo2Max);
            Console.WriteLine($"Joes METS as calcualted from his VO2Max: {metsVo2Max}{NewLine}");

            var cardioIniterp = new CardiovascularRegimenInterpretation(cardioRegimen);
            Console.WriteLine($"Cardio Regimen: {cardioIniterp}{NewLine}");
            
            var resistanceInterp = new ResistanceRegimenInterpretation(resistanceRegimen);
            Console.WriteLine($"Resistance Regimen: {resistanceInterp}{NewLine}");

            var stretchingInterp = new StretchingRegimenInterpretation(stretchRegimen);
            Console.WriteLine($"Stretching Regimen: {stretchingInterp}{NewLine}");
            
            var audiogramInterpretation = new AudiogramInterpretation(audiogram);
            Console.WriteLine($"Audiogram Classification: {audiogramInterpretation}{NewLine}");
            
            var bpInterpretation = new BloodPressureInterpretation(vitals.BloodPressure);
            Console.WriteLine($"BP Classification: {bpInterpretation}{NewLine}");
            
            var bodyCompInterp = new BodyCompositionInterpretation(bodyCompositionExpanded, patient);
            Console.WriteLine($"Body comp: {bodyCompInterp}{NewLine}");
            
            var bodyCompExpandedInterp = new BodyCompositionExpandedInterpretation(bodyCompositionExpanded, patient);
            Console.WriteLine($"Body comp expanded: {bodyCompExpandedInterp}{NewLine}");
            
            var bmiInterp = new BodyMassIndexInterpretation(bodyComposition, patient);
            Console.WriteLine($"BMI: {bmiInterp}{NewLine}");
            
            var carotidUsInterp = new CarotidUltrasoundInterpretation(carotidUs);
            Console.WriteLine($"Carotid US: {carotidUsInterp}{NewLine}");
            
            var centralBpInterp = new CentralBloodPressureInterpretation(centralBp, patient);
            Console.WriteLine($"Central BP: {centralBpInterp}{NewLine}");
            
            var fitScoreInterp = new FitTreadmillScoreInterpretation(treadmillStressTest, patient);
            Console.WriteLine($"FIT Score: {fitScoreInterp}{NewLine}");
            
            var fmsInterpretation = new FunctionalMovementScreenInterpretation(functionalMovementScreen);
            Console.WriteLine($"FMS{NewLine}{fmsInterpretation}{NewLine}");
            
            var gripInterp = new GripStrengthInterpretation(gripStrength, patient);
            Console.WriteLine($"Grip strength: {gripInterp}{NewLine}");
            
            var hipToWaistInterp = new HipToWaistInterpretation(bodyCompositionExpanded, patient);
            Console.WriteLine($"Hip to Waist: {hipToWaistInterp}{NewLine}");
            
            var ishiharaSixInterp = new IshiharaSixPlateInterpretation(ishiharaSix);
            Console.WriteLine($"Ishihara 6 Plate: {ishiharaSixInterp}{NewLine}");
            
            var ocularPressureInterp = new OcularPressureInterpretation(ocularPressure);
            Console.WriteLine($"Ocular Pressure: {ocularPressureInterp}{NewLine}");
            
            var percentBodyFatInterp = new PercentBodyFatInterpretation(bodyCompositionExpanded, patient);
            Console.WriteLine($"Percent BF: {percentBodyFatInterp}{NewLine}");

            var peripheralVisionInterp = new PeripheralVisionInterpreation(peripheralVision);
            Console.WriteLine($"Peripheral Vision: {peripheralVisionInterp}{NewLine}");
            
            var pushupsInterp = new PushupsInterpretation(pushups, patient);
            Console.WriteLine($"Pushups: {pushupsInterp}{NewLine}");
            
            var qualitativeLabInterp = new QualitativeLabInterpretation(qualitativeLab, patient);
            Console.WriteLine($"Qualitative Lab: {qualitativeLabInterp}{NewLine}");
            
            var quantLabInterpTotalChol = new QuantitativeLabInterpretation(quantitativeLabChoesterol, patient);
            Console.WriteLine($"Quantitative Lab: {quantLabInterpTotalChol}{NewLine}");
            
            var quantLabInterpHdlC = new QuantitativeLabInterpretation(quantitativeLabChoesterol, patient);
            Console.WriteLine($"Quantitative Lab: {quantLabInterpHdlC}{NewLine}");
            
            var sitAndReachInterp = new SitAndReachInterpretation(sitAndReach, patient);
            Console.WriteLine($"Sit & Reach: {sitAndReachInterp}{NewLine}");
            
            var situpsInterp = new SitupsInterpretation(situps, patient);
            Console.WriteLine($"Situps: {situpsInterp}{NewLine}");
            
            var spirometryInterp = new SpirometryInterpretation(spirometry, patient, bodyComposition);
            Console.WriteLine($"Spirometry: {spirometryInterp}{NewLine}");
            
            var visceralFatInterp = new VisceralFatInterpretation(bodyCompositionExpanded);
            Console.WriteLine($"Visceral fat: {visceralFatInterp}{NewLine}");
            
            var visualAcuityInterp = new VisualAcuityInterpretation(visualAcuity);
            Console.WriteLine($"Visual Acuity: {visualAcuityInterp}{NewLine}");
            
            var vo2MaxInterp = new Vo2MaxInterpretation(vo2Max, patient);
            Console.WriteLine($"VO2 Max: {vo2MaxInterp}{NewLine}");
            
            var waistToHeightInterp = new WaistToHeightRatioInterpretation(bodyComposition, patient);
            Console.WriteLine($"Waist to Height: {waistToHeightInterp}{NewLine}");
            
            var ascvdCalc = new PooledCohortsEquation(patient, vitals.BloodPressure, quantitativeLabChoesterol, quantitativeLabHdlC, true, false, false);
            Console.WriteLine($"ASCVD 10yr-Risk%: {ascvdCalc.AscvdRiskPercentOver10Years()}{NewLine}");
        }
    }
}