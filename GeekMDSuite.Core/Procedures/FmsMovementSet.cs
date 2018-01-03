﻿namespace GeekMDSuite.Core.Procedures
{
    public class FmsMovementSet 
    {
        public FmsMovementSet()
        {
            Left = new FmsMovementData();
            Right = new FmsMovementData();
        }
        internal FmsMovementSet(FmsMovementData left, FmsMovementData right)
        {
            Left = left;
            Right = right;
        }
        
        public FmsMovementSet Build(FmsMovementData left, FmsMovementData right) => new FmsMovementSet(left, right);

        public FmsMovementData Left { get; set; }
        public FmsMovementData Right { get; set; }

        public int Score => Left.Score < Right.Score
            ? Left.Score
            : Right.Score;

        public override string ToString() => $"{Left}\n{Right}";
    }
}