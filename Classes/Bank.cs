namespace PlanYourHeist
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public int scoreTotal { get; set; }
        public bool IsSecure()
        {
            int scoreTotal = CashOnHand + AlarmScore + VaultScore + SecurityGuardScore;
            if (scoreTotal <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}