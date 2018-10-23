using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageGrades
{
    class AverageGrades
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                double grade = double.Parse(tokens[1]);

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<double>());
                }
                grades[name].Add(grade);
            }

            foreach (var student in grades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(' ',student.Value.Select(g=>g.ToString("F2")))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}
