using System;

namespace PlanYourHeist
{
    public class LockSpecialist: IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.VaultScore = bank.VaultScore - SkillLevel;
            Console.WriteLine($@"{Name}, is handling the vaults.");
            if (bank.VaultScore < 0)
            {
                Console.WriteLine($@"{Name} has gotten into the vaults.");
            }
        }
    }
}