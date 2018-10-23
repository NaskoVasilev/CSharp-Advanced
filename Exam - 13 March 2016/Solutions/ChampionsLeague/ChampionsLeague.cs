using System;
using System.Collections.Generic;
using System.Linq;

namespace ChampionsLeague
{
    class ChampionsLeague
    {
        static Dictionary<string, List<string>> teams;
        static Dictionary<string, int> teamWins;

        static void Main(string[] args)
        {
            teams = new Dictionary<string, List<string>>();
            teamWins = new Dictionary<string, int>();
            string command = "";

            while ((command = Console.ReadLine()) != "stop")
            {
                string[] data = command.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                string firstTeamName = data[0];
                string secondTeamName = data[1];
                int firstTeamHomeGoals = int.Parse(data[2][0].ToString());
                int secondTeamGuestGoals = int.Parse(data[2][2].ToString());
                int firstTeamGusetGoals = int.Parse(data[3][2].ToString());
                int secondTeamHomeGoals = int.Parse(data[3][0].ToString());

                if (firstTeamGusetGoals + firstTeamHomeGoals > secondTeamHomeGoals + secondTeamGuestGoals)
                {
                    AddTeam(firstTeamName, secondTeamName);
                }
                else if (firstTeamGusetGoals + firstTeamHomeGoals < secondTeamHomeGoals + secondTeamGuestGoals)
                {
                    AddTeam(secondTeamName, firstTeamName);
                }
                else
                {
                    if (firstTeamGusetGoals > secondTeamGuestGoals)
                    {
                        AddTeam(firstTeamName, secondTeamName);
                    }
                    else
                    {
                        AddTeam(secondTeamName, firstTeamName);
                    }
                }
            }

            foreach (var team in teams.OrderByDescending(t => teamWins[t.Key]).ThenBy(t => t.Key))
            {
                Console.WriteLine(team.Key);
                Console.WriteLine($"- Wins: {teamWins[team.Key]}");
                Console.WriteLine($"- Opponents: {string.Join(", ", team.Value.OrderBy(x => x))}");
            }
        }

        private static void AddTeam(string teamName, string looserTeam)
        {
            if (!teams.ContainsKey(teamName))
            {
                teams.Add(teamName, new List<string>());
                teamWins.Add(teamName, 0);
            }
            teams[teamName].Add(looserTeam);
            teamWins[teamName]++;

            if (!teams.ContainsKey(looserTeam))
            {
                teams.Add(looserTeam, new List<string>());
                teamWins.Add(looserTeam, 0);
            }
            teams[looserTeam].Add(teamName);
        }
    }
}
