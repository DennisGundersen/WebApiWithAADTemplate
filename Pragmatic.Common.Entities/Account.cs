namespace Pragmatic.Common.Entities
{
    public class Account
    {
        public Account()
        {
            Alerts = new HashSet<Alert>();
            Orders = new HashSet<Order>();
            Results = new HashSet<Result>();
            Progresses = new HashSet<Progress>();
        }

        public int Id { get; set; }
        public int StrategyId { get; set; }
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string BrokerName { get; set; }
        public string Symbol { get; set; }
        public decimal StepGrowthFactor { get; set; }
        public decimal StartingBalance { get; set; }
        public int StartFactor { get; set; }
        public decimal Commission { get; set; }
        public bool IsLive { get; set; }
        public string AccountCurrency { get; set; }
        public DateTime RegisteredTime { get; set; }
        public virtual ICollection<Alert> Alerts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Progress> Progresses { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual Projection Projection { get; set; }
        public virtual Status Status { get; set; }
        public virtual Variables Variables { get; set; }
    }
}
