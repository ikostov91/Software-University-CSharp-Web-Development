using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>[]> departments = new Dictionary<string, List<string>[]>(); 
            Dictionary<string,List<string>> doctors = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Output")
            {
                string[] hospitalInfo = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                string department = hospitalInfo[0];
                string doctor = hospitalInfo[1] + " " + hospitalInfo[2];
                string patient = hospitalInfo[3];

                departments = AddPatientToHospital(departments, department, patient);
                doctors = AddPatientToDoctor(doctors, doctor, patient);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                string[] infoToPrint = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                if (infoToPrint.Length == 1)
                {
                    string department = infoToPrint[0];
                    PrintAllPatientsFromDepartment(departments, department);
                }
                else
                {

                    if (doctors.ContainsKey(infoToPrint[0] + " " + infoToPrint[1]))
                    {
                        string doctor = infoToPrint[0] + " " + infoToPrint[1];
                        PrintAllOfTheDoctorsPatients(doctors, doctor);
                    }
                    else
                    {
                        string department = infoToPrint[0];
                        int roomNumber = int.Parse(infoToPrint[1]) - 1;
                        PrintAllPatientsFromRoom(departments, department, roomNumber);
                    }
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintAllPatientsFromRoom(Dictionary<string, List<string>[]> departments, string department, int roomNumber)
        {
            if (departments[department][roomNumber].Any())
            {
                departments[department][roomNumber].Sort();
                Console.WriteLine(String.Join(Environment.NewLine, departments[department][roomNumber]));
            }
        }

        private static void PrintAllPatientsFromDepartment(Dictionary<string, List<string>[]> departments, string department)
        {
            foreach (var room in departments[department].Where(x => x.Count != 0))
            {
                Console.WriteLine(String.Join(Environment.NewLine, room));
            }
        }

        private static void PrintAllOfTheDoctorsPatients(Dictionary<string, List<string>> doctors, string doctor)
        {
            doctors[doctor].Sort();
            Console.WriteLine(String.Join(Environment.NewLine, doctors[doctor]));
        }

        private static Dictionary<string, List<string>[]> AddPatientToHospital(Dictionary<string, List<string>[]> departments, string department, string patient)
        {
            if (!departments.ContainsKey(department))
            {
                departments.Add(department, new List<string>[20]);
                for (int i = 0; i < 20; i++)
                {
                    departments[department][i] = new List<string>();
                }
                departments[department][0].Add(patient);
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    if (departments[department][i].Count < 3)
                    {
                        departments[department][i].Add(patient);
                        break;
                    }
                }
            }
            return departments;
        }

        private static Dictionary<string, List<string>> AddPatientToDoctor(Dictionary<string, List<string>> doctors, string doctor, string patient)
        {
            if (!doctors.ContainsKey(doctor))
            {
                doctors.Add(doctor, new List<string>());
                doctors[doctor].Add(patient);
            }
            else
            {
                doctors[doctor].Add(patient);
            }

            return doctors;
        }
    }
}
