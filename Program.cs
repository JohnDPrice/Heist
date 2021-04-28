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
            }

            // Team Members
            List<TeamMember> team = new List<TeamMember>();

            //Prompt user for bank difficulty
            Console.Write("Bank Difficulty: ");
            int bankDifficulty = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // Run this code while name input is not empty
            // while (name != "")
            // {
            //     // Prompt user for team member courage factor
            //     Console.Write("Courage factor: ");
            //     string courageFactor = Console.ReadLine();

            //     // Create a single team member
            //     TeamMember member = new TeamMember();
            //     member.Name = name;
            //     member.SkillLevel = int.Parse(skillLevel);
            //     member.CourageFactor = double.Parse(courageFactor);

            //     // Add team member to team List
            //     team.Add(member);

            //     Console.WriteLine();

            //     // Prompt user to enter next team member's name
            //     Console.Write("Name> ");
            //     name = Console.ReadLine();
            // }

            Console.WriteLine($"Team Size: {team.Count}");

            // Prompt user for number of trial runs
            Console.WriteLine();
            Console.WriteLine("Enter number of trial runs:");
            int trialRunCount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int teamSkill = 0;

            // Add each team member's skill level to get the total team skill level
            foreach (TeamMember member in team)
            {
                teamSkill += member.SkillLevel;
            }

            // Get heist report
            HeistReport report = new HeistReport();

            for (int i = 0; i < trialRunCount; i++)
            {
                // Create a random number between -10 and 10 for the heist's luck value. Add this number to the bank's difficulty level.
                Random generator = new Random();
                int luckValue = generator.Next(-10, 11);
                int trialRunBankDifficulty = bankDifficulty + luckValue;

                // Display team's combined skill level and the bank's difficulty level
                Console.WriteLine($"Team Skill Level: {teamSkill}");
                Console.WriteLine($"Bank Difficulty Level: {trialRunBankDifficulty}");

                // If bank difficulty is greater than the team skill add to failure count in heist report, else add to success count.
                if (trialRunBankDifficulty > teamSkill)
                {
                    report.FailureCount++;
                }
                else
                {
                    report.SuccessCount++;
                }

                Console.WriteLine("---------------------------");
            }

            Console.WriteLine();
            Console.WriteLine("Heist Results:");
            Console.WriteLine($"Successes: {report.SuccessCount}");
            Console.WriteLine($"Failures: {report.FailureCount}");
            Console.WriteLine("---------------------------");
        }
    }
}
