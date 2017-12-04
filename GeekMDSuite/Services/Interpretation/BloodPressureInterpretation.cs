using System;
using System.Collections.Generic;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Interpretation
{
    public class BloodPressureInterpretation : IInterpretable<BloodPressureStage>
    {
        public BloodPressureInterpretation(BloodPressure parameters)
        {
            _parameters = parameters;
        }
        
        public InterpretationText Interpretation => new InterpretationBuilder()
            .SetTitle("Blood Pressure Classification")
            .SetSummary(BuildSummary())
            .AddSection(BuildOverviewSection())
            .AddSection(BuildMakingChangesSection())
            .Build();


        public BloodPressureStage Classification
        {
            get
            {
                var stage = BloodPressureStage.Normotension;
                foreach (var parameters in GetBloodPressureStageParameters())
                {
                    if (parameters.Contains(_parameters))
                        stage = parameters.Stage;
                }
                return stage;
            }
        }

        public static class LowerLimits
        {
            public static class Diastolic
            {
                public static readonly int Normotension = 60;
                public static readonly int Prehypertension = 80;
                public static readonly int Stage1Hypertension = 90;
                public static readonly int Stage2Hypertension = 100;
                public static readonly int HypertensiveUrgency = 120;
            }

            public static class Systolic
            {
                public static readonly int Normotension = 100;
                public static readonly int Prehypertension = 120;
                public static readonly int Stage1Hypertension = 140;
                public static readonly int Stage2Hypertension = 160;
                public static readonly int HypertensiveUrgency = 180;
            }
        }
        
        private readonly BloodPressure _parameters;
        
        private static List<BloodStageParameters> GetBloodPressureStageParameters()
        {
            return new List<BloodStageParameters>()
            {
                GetHypotensionStageParameters(),
                GetNormotensionStageParameters(),
                GetPrehypertensionStageParameters(),
                GetStage1HypertensionParameters(),
                GetStage2HypertensionParameters(),
                GetHypertensiveUrgencyParameters(),
                GetHypertensiveEmergencyParameters()
            };
        }
        
        private class BloodStageParameters
        {
            internal Interval<int> SystolicInterval { get; }
            internal Interval<int> DiastolicInterval { get; }
            internal BloodPressureStage Stage { get; }
            internal bool OrganDamage { get; }

            internal BloodStageParameters(Interval<int> systolicInterval, Interval<int> diastolicInterval, BloodPressureStage stage, bool organDamage)
            {
                SystolicInterval = systolicInterval;
                DiastolicInterval = diastolicInterval;
                Stage = stage;
                OrganDamage = organDamage;
            }

            internal bool Contains(BloodPressure parameters) =>
            (
                Stage == BloodPressureStage.HypertensiveEmergency &&  OrganDamage ? 
                    (SystolicInterval.ContainsRightOpen(parameters.Systolic) || DiastolicInterval.ContainsRightOpen(parameters.Diastolic)) && parameters.OrganDamage :
                    (SystolicInterval.ContainsRightOpen(parameters.Systolic) || DiastolicInterval.ContainsRightOpen(parameters.Diastolic))
            );
        }

        private static BloodStageParameters GetHypertensiveEmergencyParameters()
        {
            return DifferentiateHypertensiveUrgencyVsEmergencyByOrganDamage(true);
        }

        private static BloodStageParameters GetHypertensiveUrgencyParameters()
        {
            return DifferentiateHypertensiveUrgencyVsEmergencyByOrganDamage(false);
        }

        private static BloodStageParameters DifferentiateHypertensiveUrgencyVsEmergencyByOrganDamage(
            bool organDamagePresent)
        {
            var ceilingPressure = 500;
            return new BloodStageParameters(
                new Interval<int>(LowerLimits.Systolic.HypertensiveUrgency, ceilingPressure),
                new Interval<int>(LowerLimits.Diastolic.HypertensiveUrgency, ceilingPressure),
                organDamagePresent ? BloodPressureStage.HypertensiveEmergency : BloodPressureStage.HypertensiveUrgency,
                organDamagePresent);
        }

        private static BloodStageParameters GetStage2HypertensionParameters()
        {
            return new BloodStageParameters(
                new Interval<int>(LowerLimits.Systolic.Stage2Hypertension, LowerLimits.Systolic.HypertensiveUrgency),
                new Interval<int>(LowerLimits.Diastolic.Stage2Hypertension, LowerLimits.Diastolic.HypertensiveUrgency),
                BloodPressureStage.Stage2Hypertension,
                false);
        }

        private static BloodStageParameters GetStage1HypertensionParameters()
        {
            return new BloodStageParameters(
                new Interval<int>(LowerLimits.Systolic.Stage1Hypertension, LowerLimits.Systolic.Stage2Hypertension),
                new Interval<int>(LowerLimits.Diastolic.Stage1Hypertension, LowerLimits.Diastolic.Stage2Hypertension),
                BloodPressureStage.Stage1Hypertension,
                false);
        }

        private static BloodStageParameters GetPrehypertensionStageParameters()
        {
            return new BloodStageParameters(
                new Interval<int>(LowerLimits.Systolic.Prehypertension, LowerLimits.Systolic.Stage1Hypertension),
                new Interval<int>(LowerLimits.Diastolic.Prehypertension, LowerLimits.Diastolic.Stage1Hypertension),
                BloodPressureStage.PreHypertension,
                false);
        }

        private static BloodStageParameters GetNormotensionStageParameters()
        {
            return new BloodStageParameters(
                new Interval<int>(LowerLimits.Systolic.Normotension, LowerLimits.Systolic.Prehypertension),
                new Interval<int>(LowerLimits.Diastolic.Normotension, LowerLimits.Systolic.Prehypertension),
                BloodPressureStage.Normotension,
                false);
        }

        private static BloodStageParameters GetHypotensionStageParameters()
        {
            var floorPressure = 0;
            return new BloodStageParameters(
                new Interval<int>(floorPressure, LowerLimits.Systolic.Normotension),
                new Interval<int>(floorPressure, LowerLimits.Diastolic.Normotension),
                BloodPressureStage.Hypotension,
                false);
        }

        
        private string BuildSummary()
        {
            var bloodPressure = _parameters;
            return $"Your blood pressure is {bloodPressure.Systolic}/{bloodPressure.Diastolic} mmHg. " +
                   $"This is defined as {Classification}. " +
                   "There " + (bloodPressure.OrganDamage ? "is " : "is not ") + "evidence of current end-organ " +
                   "damage. ";
        }
        

        private  InterpretationSection BuildOverviewSection()
        {
            return new InterpretationSectionBuilder()
                .SetTitle("Overview")
                .AddParagraph("Blood pressure is one of our most important vital signs. " +
                              "Ideally, the pressures in the arteries will be at a healthy medium level " +
                              "where it is high enough to adequately deliver nutrients to vital organs, " +
                              "but not so high that the pressure is causing damage to organs which will " +
                              "predispose to the development of additional chronic diseases and adverse " +
                              "events such as heart attack and stroke. ")
                .SetTitle("Normal Values")
                .AddParagraph("Levels that are generally considered to be 'too low' will be less than " +
                              $"{LowerLimits.Systolic.Normotension}/{LowerLimits.Diastolic.Normotension} mmHg" +
                              "There are exceptions to this, which can only be determined in proper " +
                              "clinical context by a trained healthcare provider. ")
                .AddParagraph($"Ideal values are between {LowerLimits.Systolic.Normotension}-" +
                              $"{LowerLimits.Systolic.Prehypertension}/{LowerLimits.Diastolic.Normotension}-" +
                              $"{LowerLimits.Diastolic.Prehypertension} mmHg. These values are generally " +
                              "considered to be the least likely to be associated with other chronic " +
                              "disease states.")
                .AddParagraph($"Pre-hypertension is defined as {LowerLimits.Systolic.Prehypertension}-" +
                              $"{LowerLimits.Systolic.Stage1Hypertension}/{LowerLimits.Diastolic.Prehypertension}-" +
                              $"{LowerLimits.Diastolic.Stage1Hypertension}. The term 'pre-hypertension' is " +
                              "used here, however it's important to note that this does not mean that there" +
                              "is no detriment associated with these blood pressures levels. There is. " +
                              "even mild levels of blood pressure elevation are associated with increased " +
                              "risk of heart attack, stroke, and more.")
                .AddParagraph("From here, hypertension is formally staged. Each stage is successively " +
                              "worse when compared to the previous stage. Stage 1 Hypertension is " +
                              $"{LowerLimits.Systolic.Stage1Hypertension}-{LowerLimits.Systolic.Stage2Hypertension}/" +
                              $"{LowerLimits.Diastolic.Stage1Hypertension}-{LowerLimits.Diastolic.Stage2Hypertension}. " +
                              $"Stage 2 Hypertension is from {LowerLimits.Systolic.Stage2Hypertension}-" +
                              $"{LowerLimits.Systolic.HypertensiveUrgency}/{LowerLimits.Diastolic.Stage2Hypertension}-" +
                              $"{LowerLimits.Diastolic.HypertensiveUrgency}. Anything beyond these values " +
                              "is classified as either hypertensive urgency, or hypertensive emergency.")
                .AddParagraph("The difference between hypertensive urgency and hypertensive emergency is " +
                              "the presence of evidence of acute damage to an organ. This often necessitates " +
                              "two different levels of care, and therefore the distinction is made between " +
                              "the two of them despite the fact that both have very high pressures values " +
                              "associated with them.")
                .Build();
        }
        
        private  InterpretationSection BuildMakingChangesSection()
        {
            var section = new InterpretationSectionBuilder()
                .SetTitle("Making Changes")
                .AddParagraph("Making changes for blood pressure consists primary of lifestyle and medical " +
                              "interventions. Lifestyle interventions include improving body composition, " +
                              "such as reducing body fat percentage to an ideal level, increasing cardiovascular " +
                              "training, and making dietary changes. A common diet prescribed for hypertension " +
                              "is the DASH diet. When lifestyle is not enough, we include blood pressure " +
                              "medications. We understand that people often wish to avoid medications");
            if (Classification == BloodPressureStage.Hypotension)
                return section.AddParagraph("Your blood pressure is low. This case is less simple to generalize. " +
                                            "As such, it's importnat to discuss the details of this in the context of " +
                                            "your overall state of health with your clinician.").Build();

            if (Classification == BloodPressureStage.PreHypertension)
                return section.AddParagraph("Your blood pressure is elevated to a range that is most often addressable " +
                                     "via lifestyle change. Some combination of bodyfat reduction, exercise, and " +
                                     "dietary changes such as those described in the DASH diet, will likely " +
                                     "remedy this.").Build();
            if (Classification == BloodPressureStage.Stage1Hypertension)
                return section.AddParagraph("Your blood pressure is elevated to a range that is sometimes addressable " +
                                    "by lifestyle change, but often requires medication. It's reasonable to " +
                                    "have a discussion with your clinician on whether or not lifestyle change " +
                                    "is a good option for your before adding medication, or if both are " +
                                    "necessary at this point.").Build();
            if (Classification == BloodPressureStage.Stage2Hypertension)
                return section.AddParagraph("Your blood pressure is elevated to a range that requires medical management. " +
                                    "It is still possible to reduce the blood pressure via lifestyle to a degree that the " +
                                    "medication can be stopped. However, while this is a possibility, the " +
                                    "current levels are such that they should be addressed. ").Build();
            if (Classification == BloodPressureStage.HypertensiveUrgency)
                return section.AddParagraph("Your blood pressure is elevated to such a degree that action is urgent. " +
                                            "Medications are required, and it often takes as many as three medications " +
                                            "to reduce blood pressure that is this elevated to an acceptable level. " +
                                            "Improving blood pressure via medical management should be very high priority " +
                                            "and working closely with your clinician to accomplish this in a relatively " +
                                            "short period of time is strongly encouraged.").Build();
            if (Classification == BloodPressureStage.HypertensiveEmergency)
                return section.AddParagraph("Your blood pressure needs to be addressed emergently. There is evidence to " +
                    "suggest that the blood pressure elevation is causing acute, dangerous " +
                    "damage to organs of your body. This cannot be delayed. ").Build();
            

            return section.Build();
        }
        
    }
}