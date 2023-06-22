﻿namespace Pragmatic.Common.Entities
{
    public class Progress
    {
        public int Id { get; set; }
        public int AccountID { get; set; }
        public decimal Lots { get; set; } = 0.01M;
        public int Steps { get; set; } = 0;
        public virtual Account Account { get; set; }
    }
}
