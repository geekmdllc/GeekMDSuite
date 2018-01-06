using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Analytics.Interpretation.Builder;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Interpretation
{
    public class BloodPressureInterpretation : Interpretable
    {
        private readonly BloodPressure _parameters;

        private readonly BloodPressureStage _stage;

        public BloodPressureInterpretation(BloodPressure parameters)
        {
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
            _stage = new BloodPressureClassification(_parameters).Classification.Stage;
        }

        public override InterpretationText Interpretation => InterpretationTextBuilder
            .Initialize()
            .SetTitle("Blood Pressure Classification")
            .SetSummary(BuildSummary())
            .AddSection(BuildOverviewSection())
            .AddSection(BuildMakingChangesSection())
            .Build();

        private string BuildSummary()
        {
            var bloodPressure = _parameters;
            return $"Your blood pressure is {bloodPressure.Systolic}/{bloodPressure.Diastolic} mmHg. " +
                   $"This is defined as {_stage}. " +
                   "There " + (bloodPressure.OrganDamage ? "is " : "is not ") + "evidence of current end-organ " +
                   "damage. ";
        }


        private InterpretationSection BuildOverviewSection()
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
                              $"{BloodPressureClassification.LowerLimits.Systolic.Normal}/{BloodPressureClassification.LowerLimits.Diastolic.Normal} mmHg" +
                              "There are exceptions to this, which can only be determined in proper " +
                              "clinical context by a trained healthcare provider. ")
                .AddParagraph($"Ideal values are between {BloodPressureClassification.LowerLimits.Systolic.Normal}-" +
                              $"{BloodPressureClassification.LowerLimits.Systolic.Elevated}/<{BloodPressureClassification.LowerLimits.Diastolic.Stage1Hypertension} mmHg. These values are generally " +
                              "considered to be the least likely to be associated with other chronic " +
                              "disease states.")
                .AddParagraph(
                    $"Pre-hypertension is defined as {BloodPressureClassification.LowerLimits.Systolic.Elevated}-" +
                    $"{BloodPressureClassification.LowerLimits.Systolic.Stage1Hypertension}/<{BloodPressureClassification.LowerLimits.Diastolic.Stage1Hypertension} mmHg. " +
                    "The term 'pre-hypertension' is " +
                    "used here, however it's important to note that this does not mean that there" +
                    "is no detriment associated with these blood pressures levels. There is. " +
                    "even mild levels of blood pressure elevation are associated with increased " +
                    "risk of heart attack, stroke, and more.")
                .AddParagraph("From here, hypertension is formally staged. Each stage is successively " +
                              "worse when compared to the previous stage. Stage 1 Hypertension is " +
                              $"{BloodPressureClassification.LowerLimits.Systolic.Stage1Hypertension}-{BloodPressureClassification.LowerLimits.Systolic.Stage2Hypertension}/" +
                              $"{BloodPressureClassification.LowerLimits.Diastolic.Stage1Hypertension}-{BloodPressureClassification.LowerLimits.Diastolic.Stage2Hypertension} mmHg. " +
                              $"Stage 2 Hypertension is from {BloodPressureClassification.LowerLimits.Systolic.Stage2Hypertension}-" +
                              $"{BloodPressureClassification.LowerLimits.Systolic.HypertensiveUrgency}/{BloodPressureClassification.LowerLimits.Diastolic.Stage2Hypertension}-" +
                              $"{BloodPressureClassification.LowerLimits.Diastolic.HypertensiveUrgency} mmHg. Anything beyond these values " +
                              "is classified as either hypertensive urgency, or hypertensive emergency.")
                .AddParagraph("The difference between hypertensive urgency and hypertensive emergency is " +
                              "the presence of evidence of acute damage to an organ. This often necessitates " +
                              "two different levels of care, and therefore the distinction is made between " +
                              "the two of them despite the fact that both have very high pressures values " +
                              "associated with them.")
                .Build();
        }

        private InterpretationSection BuildMakingChangesSection()
        {
            var section = new InterpretationSectionBuilder()
                .SetTitle("Making Changes")
                .AddParagraph("Making changes for blood pressure consists primary of lifestyle and medical " +
                              "interventions. Lifestyle interventions include improving body composition, " +
                              "such as reducing body fat percentage to an ideal level, increasing cardiovascular " +
                              "training, and making dietary changes. A common diet prescribed for hypertension " +
                              "is the DASH diet. When lifestyle is not enough, we include blood pressure " +
                              "medications. We understand that people often wish to avoid medications");
            if (_stage == BloodPressureStage.Low)
                return section.AddParagraph("Your blood pressure is low. This case is less simple to generalize. " +
                                            "As such, it's importnat to discuss the details of this in the context of " +
                                            "your overall state of health with your clinician.").Build();

            if (_stage == BloodPressureStage.Elevated)
                return section.AddParagraph(
                    "Your blood pressure is elevated to a range that is most often addressable " +
                    "via lifestyle change. Some combination of bodyfat reduction, exercise, and " +
                    "dietary changes such as those described in the DASH diet, will likely " +
                    "remedy this.").Build();
            if (_stage == BloodPressureStage.Stage1Hypertension)
                return section.AddParagraph(
                    "Your blood pressure is elevated to a range that is sometimes addressable " +
                    "by lifestyle change, but often requires medication. It's reasonable to " +
                    "have a discussion with your clinician on whether or not lifestyle change " +
                    "is a good option for your before adding medication, or if both are " +
                    "necessary at this point.").Build();
            if (_stage == BloodPressureStage.Stage2Hypertension)
                return section.AddParagraph(
                    "Your blood pressure is elevated to a range that requires medical management. " +
                    "It is still possible to reduce the blood pressure via lifestyle to a degree that the " +
                    "medication can be stopped. However, while this is a possibility, the " +
                    "current levels are such that they should be addressed. ").Build();
            if (_stage == BloodPressureStage.HypertensiveUrgency)
                return section.AddParagraph("Your blood pressure is elevated to such a degree that action is urgent. " +
                                            "Medications are required, and it often takes as many as three medications " +
                                            "to reduce blood pressure that is this elevated to an acceptable level. " +
                                            "Improving blood pressure via medical management should be very high priority " +
                                            "and working closely with your clinician to accomplish this in a relatively " +
                                            "short period of time is strongly encouraged.").Build();
            if (_stage == BloodPressureStage.HypertensiveEmergency)
                return section.AddParagraph(
                    "Your blood pressure needs to be addressed emergently. There is evidence to " +
                    "suggest that the blood pressure elevation is causing acute, dangerous " +
                    "damage to organs of your body. This cannot be delayed. ").Build();


            return section.Build();
        }
    }
}