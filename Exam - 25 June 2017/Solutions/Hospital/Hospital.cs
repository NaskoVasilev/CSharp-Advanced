using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> patientsInDepartment = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> patientsOfDoctor = new Dictionary<string, List<string>>();
            Dictionary<string, Dictionary<int, List<string>>> rooms = new Dictionary<string, Dictionary<int, List<string>>>();
            string command = "";

            while ((command = Console.ReadLine()) != "Output")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string department = tokens[0];
                string doctor = tokens[1] + " " + tokens[2];
                string patient = tokens[3];

                if (!patientsInDepartment.ContainsKey(department))
                {
                    patientsInDepartment.Add(department, new List<string>());
                }
                patientsInDepartment[department].Add(patient);

                if (!patientsOfDoctor.ContainsKey(doctor))
                {
                    patientsOfDoctor.Add(doctor, new List<string>());
                }
                patientsOfDoctor[doctor].Add(patient);

                if (!rooms.ContainsKey(department))
                {
                    rooms.Add(department, new Dictionary<int, List<string>>());
                    rooms[department].Add(1, new List<string>() { patient });
                }
                else
                {
                    int lastKey = rooms[department].Keys.Max();
                    if (rooms[department][lastKey].Count == 3)
                    {
                        if (lastKey + 1 <= 20)
                        {
                            rooms[department].Add(lastKey + 1, new List<string>() { patient });
                        }
                    }
                    else
                    {
                        rooms[department][lastKey].Add(patient);
                    }
                }

            }

            string pattern = @"^[A-Za-z]+ \d+$";

            while ((command = Console.ReadLine()) != "End")
            {
                if (Regex.IsMatch(command, pattern))
                {
                    string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string department = tokens[0];
                    int roomNumber = int.Parse(tokens[1]);

                    if (rooms.ContainsKey(department) && rooms[department].ContainsKey(roomNumber))
                    {
                        foreach (var patient in rooms[department][roomNumber].OrderBy(x=>x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else if (command.Contains(" "))
                {
                    if (patientsOfDoctor.ContainsKey(command))
                    {
                        foreach (var patient in patientsOfDoctor[command].OrderBy(x=>x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else
                {
                    if (patientsInDepartment.ContainsKey(command))
                    {
                        foreach (var patient in patientsInDepartment[command])
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
            }
        }


    }
}
