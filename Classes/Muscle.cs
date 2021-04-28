using System;

namespace PlanYourHeist
{
    public class Muscle: IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
            Console.WriteLine($@"{Name}, is handling the security guards.");
            if (bank.SecurityGuardScore < 0)
            {
                Console.WriteLine($@"{Name} has taken down the security guards.");
            }
        }
    }
}