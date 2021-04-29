using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of operatives
            List<IRobber> rolodex = new List<IRobber>();

            // Add operatives to the list
            rolodex.Add(new Hacker() {
                Name = "Tony",
                SkillLevel = 6,
                PercentageCut = 20,
                });
            rolodex.Add(new Muscle() {
                Name = "Bob",
                SkillLevel = 7,
                PercentageCut = 10,
                });
            rolodex.Add(new LockSpecialist() {
                Name = "Rob",
                SkillLevel = 5,
                PercentageCut = 15,
                });
            rolodex.Add(new Hacker() {
                Name = "Cindy",
                SkillLevel = 3,
                PercentageCut = 5,
                });
            rolodex.Add(new Muscle() {
                Name = "Tim",
                SkillLevel = 5,
                PercentageCut = 20,
                });
            Console.WriteLine($@"{rolodex.Count()} operatives in the rolodex");

            Console.WriteLine("Plan Your Heist!");

            // Prompt user to enter team member's name
            Console.Write("Name: ");
            string name = Console.ReadLine();

            while (name != "")
            {
                // Prompt user to select a specialty
                Console.WriteLine("Choose a specialy: Press H for Hacker, M for Muscle, or L for Lock Specialist");
                string specialty = Console.ReadLine();

                // Prompt user for team member skill level
                Console.Write("Skill level: ");
                int skillLevel = Int32.Parse(Console.ReadLine());

                // Prompt user to enter team member's percentage cut
                Console.WriteLine("Percentage Cut: ");
                int percentageCut = Int32.Parse(Console.ReadLine());

                // Create new crew member and add to rolodex
                if (specialty == "H")
                {
                    rolodex.Add(new Hacker() {
                        Name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });
                } else if (specialty == "M")
                {
                    rolodex.Add(new Muscle() {
                        Name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });
                } else if (specialty == "L")
                {
                    rolodex.Add(new LockSpecialist() {
                        Name = name, 
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });
                }

                // Prompt for next team member's name
                Console.WriteLine("Name: ");
                name = Console.ReadLine();
            }

            // Random number generator
            Random generator = new Random();
            int zeroToHundred = generator.Next(0, 100);
            int cash = generator.Next(50000, 1000000);

            Bank bank = new Bank() {
                AlarmScore = generator.Next(0, 100),
                VaultScore = generator.Next(0, 100),
                SecurityGuardScore = generator.Next(0, 100),
                CashOnHand = cash
            };

             //var x = bank.GetType().GetProperties().Select(a => a.Name).Skip(1).Take(3).ToList();
             
            // var q = bank[$"{x[0]}"];
           // List<KeyValuePair<string, int>> bankProperties = bank.Select(x => new KeyValuePair<string, int>(){
           //     x[x.Key]
           // });

            Console.WriteLine();
            // Recon Report
            if (bank.AlarmScore > bank.VaultScore && bank.AlarmScore > bank.SecurityGuardScore)
            {
                Console.WriteLine("Most Secure: Alarm System");

            } else if (bank.VaultScore > bank.AlarmScore && bank.VaultScore > bank.SecurityGuardScore)
            {
                Console.WriteLine("Most Secure: Vault");

            } else if (bank.SecurityGuardScore > bank.VaultScore && bank.SecurityGuardScore > bank.AlarmScore)
            {
                Console.WriteLine("Most Secure: Security Guards");
            }

            if (bank.AlarmScore < bank.VaultScore && bank.AlarmScore < bank.SecurityGuardScore)
            {
                Console.WriteLine("Least Secure: Alarm System");

            } else if (bank.VaultScore < bank.AlarmScore && bank.VaultScore < bank.SecurityGuardScore)
            {
                Console.WriteLine("Least Secure: Vault");

            } else if (bank.SecurityGuardScore < bank.VaultScore && bank.SecurityGuardScore < bank.AlarmScore)
            {
                Console.WriteLine("Least Secure: Security Guards");
            }

            // Get heist report
            HeistReport report = new HeistReport();

            Console.WriteLine();
            Console.WriteLine("Heist Results:");
            Console.WriteLine($"Successes: {report.SuccessCount}");
            Console.WriteLine($"Failures: {report.FailureCount}");
            Console.WriteLine("---------------------------");
        }
    }
}
