namespace GeekMDSuite.Procedures
{
    public class FmsMovement
    {
        //TODO: Remove this unecessary wrapping of data
        internal FmsMovement(FmsMovementData data)
        {
            Data = data;
        }
        public FmsMovementData Data { get; }
    }
}