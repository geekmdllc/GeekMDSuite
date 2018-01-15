using System;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class FunctionalMovementScreenStubFromUser
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }  
        public FmsMovementData DeepSquat { get; set; }
        public FmsMovementSet HurdleStep { get; set; }
        public FmsMovementSet InlineLunge { get; set; }
        public FmsMovementSet ShoulderMobility { get; set; }
        public FmsMovementSet ActiveStraightLegRaise { get; set; }
        public FmsMovementData TrunkStabilityPushup { get; set; }
        public FmsMovementSet RotaryStability { get; set; }

        public FunctionalMovementScreenStubFromUser()
        {
            DeepSquat = new FmsMovementData();
            HurdleStep = new FmsMovementSet();
            InlineLunge = new FmsMovementSet();
            ShoulderMobility = new FmsMovementSet();
            ActiveStraightLegRaise = new FmsMovementSet();
            TrunkStabilityPushup = new FmsMovementData();
            RotaryStability = new FmsMovementSet();
        }
    }
}