using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<int, List<string>>> deptRoomPatients = new Dictionary<string, Dictionary<int, List<string>>>();

            InitializeRoomsInDepts(deptRoomPatients);

            Dictionary<string, List<string>> doctorPatients = new Dictionary<string, List<string>>();

            string readPatients = Console.ReadLine();

            while (readPatients != "Output")
            {
                string[] tokens = readPatients
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string department = tokens[0];
                string patient = tokens[tokens.Length - 1];
                string doctor = string.Join(" ", tokens.Skip(1).Take(tokens.Length - 2));

                if (!deptRoomPatients.ContainsKey(department))
                {
                    IntializeNewDepartment(deptRoomPatients, department);
                }

                FillRooms(deptRoomPatients, department, patient);

                FillDoctorsList(doctorPatients, doctor, patient);

                readPatients = Console.ReadLine();
            }

            PrintResult(deptRoomPatients, doctorPatients);
        }

        static void PrintResult(Dictionary<string, Dictionary<int, List<string>>> deptRoomPatients, Dictionary<string, List<string>> doctorPatients)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string doctor = string.Join(" ", tokens.Take(tokens.Length));
                string deptOrDoctor = tokens[0];

                if (doctorPatients.ContainsKey(doctor))
                {
                    var allDoctorsPatients = doctorPatients[doctor].OrderBy(name => name);
                    StringBuilder sb = new StringBuilder();
                    foreach (string patient in allDoctorsPatients)
                    {
                        sb.AppendLine(patient);
                    }

                    Console.Write(sb.ToString());
                }
                else if (deptRoomPatients.ContainsKey(input))
                {
                    var allPatientsInDept = deptRoomPatients[input].Values.SelectMany(names => names);
                    StringBuilder sb = new StringBuilder();
                    foreach (string patient in allPatientsInDept)
                    {
                        sb.AppendLine(patient);
                    }

                    Console.Write(sb.ToString());
                }
                if (tokens.Length == 2 && deptRoomPatients.ContainsKey(deptOrDoctor))
                {
                    int room = int.Parse(tokens[1]);
                    StringBuilder sb = new StringBuilder();
                    List<string> patients = deptRoomPatients[deptOrDoctor][room].OrderBy(name => name).ToList();
                    foreach (string patient in patients)
                    {
                        sb.AppendLine(patient);
                    }

                    Console.Write(sb.ToString());
                }

                input = Console.ReadLine();
            }
        }

        static void IntializeNewDepartment(Dictionary<string, Dictionary<int, List<string>>> deptRoomPatients, string department)
        {
            deptRoomPatients.Add(department, new Dictionary<int, List<string>>());

            for (int i = 1; i <= 20; i++)
            {
                deptRoomPatients[department].Add(i, new List<string>());
            }
        }

        static void FillDoctorsList(Dictionary<string, List<string>> doctorPatients, string doctor, string patient)
        {
            if (!doctorPatients.ContainsKey(doctor))
            {
                doctorPatients.Add(doctor, new List<string>());
                doctorPatients[doctor].Add(patient);
            }
            else
            {
                doctorPatients[doctor].Add(patient);
            }
        }

        static void FillRooms(Dictionary<string, Dictionary<int, List<string>>> deptRoomPatients, string department, string patient)
        {
            for (int i = 1; i <= 20; i++)
            {
                if (deptRoomPatients[department][i].Count < 3)
                {
                    deptRoomPatients[department][i].Add(patient);
                    break;
                }
            }
        }

        static void InitializeRoomsInDepts(Dictionary<string, Dictionary<int, List<string>>> deptRoomPatients)
        {
            deptRoomPatients["Cardiology"] = new Dictionary<int, List<string>>();
            deptRoomPatients["Oncology"] = new Dictionary<int, List<string>>();
            deptRoomPatients["Emergency"] = new Dictionary<int, List<string>>();

            for (int i = 1; i <= 20; i++)
            {
                deptRoomPatients["Cardiology"].Add(i, new List<string>());

                deptRoomPatients["Oncology"].Add(i, new List<string>());

                deptRoomPatients["Emergency"].Add(i, new List<string>());
            }
        }
    }
}
