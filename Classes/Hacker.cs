using System;

namespace PlanYourHeist
{
    public class Hacker: IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore = bank.AlarmScore - SkillLevel;
            Console.WriteLine($@"{Name}, is handling the security system.");
            if (bank.AlarmScore < 0)
            {
                Console.WriteLine($@"{Name} has disabled the security system.");
            }
        }
    }
}