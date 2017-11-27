using System;
using System.Collections.Generic;
using GeekMDSuite.Calculations;
using GeekMDSuite.Common;
using GeekMDSuite.Common.Models;
using GeekMDSuite.Common.Tools;

namespace GeekMDSuite.Interpretation
{
    public  class BloodPressureInterpretation
    {
        public BloodPressureInterpretation()
        {
            
        }
        public Interpretation Interpretation(BloodPressureParameters parameters)
        {
            return new InterpretationBuilder()
                .SetTitle("Blood Pressure Interpretation")
                .SetSummary(BuildSummary(parameters))
                .AddSection(BuildOverviewSection())
                .AddSection(BuildMakingChangesSection(parameters))
                .Build();
        }

        private string BuildSummary(BloodPressureParameters parameters)
        {
            return $"Your blood pressure is {parameters.Systolic}/{parameters.Diastolic} mmHg. " +
                   $"This is defined as {Stage(parameters)}. " +
                   "There " + (parameters.OrganDamage ? "is " : "is not ") + "evidence of current end-organ " +
                   "damage. ";
        }


        public  BloodPressureStages Stage(BloodPressureParameters parameters)
        {
            var stage = BloodPressureStages.Normotension;
            foreach (var description in GetBloodPressureStageDescriptions())
            {
                if (description.Contains(parameters))
                    stage = description.Stage;
            }
            return stage;
        }
        private  InterpretationSection BuildMakingChangesSection(BloodPressureParameters parameters)
        {
            var stage = Stage(parameters);
            var section = new InterpretationSectionBuilder()
                .SetTitle("Making Changes")
                .AddParagraph("Making changes for blood pressure consists primary of lifestyle and medical " +
                              "interventions. Lifestyle interventions include improving body composition, " +
                              "such as reducing body fat percentage to an ideal level, increasing cardiovascular " +
                              "training, and making dietary changes. A common diet prescribed for hypertension " +
                              "is the DASH diet. When lifestyle is not enough, we include blood pressure " +
                              "medications. We understand that people often wish to avoid medications");
            if (stage == BloodPressureStages.Hypotension)
                return section.AddParagraph("Your blood pressure is low. This case is less simple to generalize. " +
                                            "As such, it's importnat to discuss the details of this in the context of " +
                                            "your overall state of health with your clinician.").Build();

            if (stage == BloodPressureStages.PreHypertension)
                return section.AddParagraph("Your blood pressure is elevated to a range that is most often addressable " +
                                     "via lifestyle change. Some combination of bodyfat reduction, exercise, and " +
                                     "dietary changes such as those described in the DASH diet, will likely " +
                                     "remedy this.").Build();
            if (stage == BloodPressureStages.Stage1Hypertension)
                return section.AddParagraph("Your blood pressure is elevated to a range that is sometimes addressable " +
                                    "by lifestyle change, but often requires medication. It's reasonable to " +
                                    "have a discussion with your clinician on whether or not lifestyle change " +
                                    "is a good option for your before adding medication, or if both are " +
                                    "necessary at this point.").Build();
            if (stage == BloodPressureStages.Stage2Hypertension)
                return section.AddParagraph("Your blood pressure is elevated to a range that requires medical management. " +
                                    "It is still possible to reduce the blood pressure via lifestyle to a degree that the " +
                                    "medication can be stopped. However, while this is a possibility, the " +
                                    "current levels are such that they should be addressed. ").Build();
            if (stage == BloodPressureStages.HypertensiveUrgency)
                return section.AddParagraph("Your blood pressure is elevated to such a degree that action is urgent. " +
                                            "Medications are required, and it often takes as many as three medications " +
                                            "to reduce blood pressure that is this elevated to an acceptable level. " +
                                            "Improving blood pressure via medical management should be very high priority " +
                                            "and working closely with your clinician to accomplish this in a relatively " +
                                            "short period of time is strongly encouraged.").Build();
            if (stage == BloodPressureStages.HypertensiveEmergency)
                return section.AddParagraph("Your blood pressure needs to be addressed emergently. There is evidence to " +
                    "suggest that the blood pressure elevation is causing acute, dangerous " +
                    "damage to organs of your body. This cannot be delayed. ").Build();

            return section.Build();
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
                              $"{SystolicLowerLimitOfNormal}/{DiastolicLowerLimitOfNormal} mmHg" +
                              "There are exceptions to this, which can only be determined in proper " +
                              "clinical context by a trained healthcare provider. ")
                .AddParagraph($"Ideal values are between {SystolicLowerLimitOfNormal} to " +
                              $"{SystolicLowerLimitOfPrehypertension}/{DiastolicLowerLimitOfNormal} to " +
                              $"{DiastolicLowerLimitOfPrehypertension} mmHg. These values are generally " +
                              "considered to be the least likely to be associated with other chronic " +
                              "disease states.")
                .AddParagraph($"Pre-hypertension is defined as {SystolicLowerLimitOfPrehypertension} to " +
                              $"{SystolicLowerLimitOfStage1Hypertension} / {DiastolicLowerLimitOfPrehypertension} to " +
                              $"{DiastolicLowerLimitOfStage1Hypertension}. The term 'pre-hypertension' is " +
                              "used here, however it's important to note that this does not mean that there" +
                              "is no detriment associated with these blood pressures levels. There is. " +
                              "even mild levels of blood pressure elevation are associated with increased " +
                              "risk of heart attack, stroke, and more.")
                .AddParagraph("From here, hypertension is formally staged. Each stage is successively " +
                              "worse when compared to the previous stage. Stage 1 Hypertension is " +
                              $"{SystolicLowerLimitOfStage1Hypertension} to {SystolicLowerLimitOfStage2Hypertension}/" +
                              $"{DiastolicLowerLimitOfStage1Hypertension} to {DiastolicLowerLimitOfStage2Hypertension}. " +
                              $"Stage 2 Hypertension is from {SystolicLowerLimitOfStage2Hypertension} to " +
                              $"{SystolicLowerLimitofHypertensiveUrgency}/{DiastolicLowerLimitOfStage2Hypertension} to " +
                              $"{DiastolicLowerLimitOfHypertensiveUrgency}. Anything beyond these values " +
                              "is classified as either hypertensive urgency, or hypertensive emergency.")
                .AddParagraph("The difference between hypertensive urgency and hypertensive emergency is " +
                              "the presence of evidence of acute damage to an organ. This often necessitates " +
                              "two different levels of care, and therefore the distinction is made between " +
                              "the two of them despite the fact that both have very high pressures values " +
                              "associated with them.")
                .Build();
        }
        
        private  List<StageDescription> GetBloodPressureStageDescriptions()
        {
            var floorPressure = 0;
            var ceilingPressure = 500;
            return new List<StageDescription>()
            {
                new StageDescription(
                    new Interval<int>(floorPressure, SystolicLowerLimitOfNormal),
                    new Interval<int>(floorPressure, DiastolicLowerLimitOfNormal),
                    BloodPressureStages.Hypotension,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitOfNormal, SystolicLowerLimitOfPrehypertension),
                    new Interval<int>(DiastolicLowerLimitOfNormal, DiastolicLowerLimitOfPrehypertension),
                    BloodPressureStages.Normotension,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitOfPrehypertension, SystolicLowerLimitOfStage1Hypertension),
                    new Interval<int>(DiastolicLowerLimitOfPrehypertension, DiastolicLowerLimitOfStage1Hypertension),
                    BloodPressureStages.PreHypertension,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitOfStage1Hypertension, SystolicLowerLimitOfStage2Hypertension),
                    new Interval<int>(DiastolicLowerLimitOfStage1Hypertension, DiastolicLowerLimitOfStage2Hypertension),
                    BloodPressureStages.Stage1Hypertension,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitOfStage2Hypertension, SystolicLowerLimitofHypertensiveUrgency),
                    new Interval<int>(DiastolicLowerLimitOfStage2Hypertension, DiastolicLowerLimitOfHypertensiveUrgency),
                    BloodPressureStages.Stage2Hypertension,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitofHypertensiveUrgency, ceilingPressure),
                    new Interval<int>(DiastolicLowerLimitOfHypertensiveUrgency, ceilingPressure),
                    BloodPressureStages.HypertensiveUrgency,
                    false),
                new StageDescription(
                    new Interval<int>(SystolicLowerLimitofHypertensiveUrgency, ceilingPressure),
                    new Interval<int>(DiastolicLowerLimitOfHypertensiveUrgency, ceilingPressure),
                    BloodPressureStages.HypertensiveEmergency,
                    true)
            };
        }
        
        private class StageDescription
        {
            public Interval<int> SystolicInterval { get; }
            public Interval<int> DiastolicInterval { get; }
            public BloodPressureStages Stage { get; }
            public bool OrganDamage { get; }

            public StageDescription(Interval<int> systolicInterval, Interval<int> diastolicInterval, BloodPressureStages stage, bool organDamage)
            {
                SystolicInterval = systolicInterval;
                DiastolicInterval = diastolicInterval;
                Stage = stage;
                OrganDamage = organDamage;
            }

            public bool Contains(BloodPressureParameters parameters) =>
            (
                Stage == BloodPressureStages.HypertensiveEmergency &&  OrganDamage ? 
                    (SystolicInterval.ContainsRightOpen(parameters.Systolic) || DiastolicInterval.ContainsRightOpen(parameters.Diastolic)) && parameters.OrganDamage :
                    (SystolicInterval.ContainsRightOpen(parameters.Systolic) || DiastolicInterval.ContainsRightOpen(parameters.Diastolic))
            );
        }
        
        // API consumer likely to need access to these values when developing user interfaces.
        public  readonly int SystolicLowerLimitOfNormal = 100;
        public  readonly int SystolicLowerLimitOfPrehypertension = 120;
        public  readonly int SystolicLowerLimitOfStage1Hypertension = 140;
        public  readonly int SystolicLowerLimitOfStage2Hypertension = 160;
        public  readonly int SystolicLowerLimitofHypertensiveUrgency = 180;
        public  readonly int DiastolicLowerLimitOfNormal = 60;
        public  readonly int DiastolicLowerLimitOfPrehypertension = 80;
        public  readonly int DiastolicLowerLimitOfStage1Hypertension = 90;
        public  readonly int DiastolicLowerLimitOfStage2Hypertension = 100;
        public  readonly int DiastolicLowerLimitOfHypertensiveUrgency = 120;
        
    }
}