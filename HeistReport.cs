namespace PlanYourHeist
{
    public class HeistReport
    {
        public HeistReport() {
            SuccessCount = 0;
            FailureCount = 0;
        }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
    }
}