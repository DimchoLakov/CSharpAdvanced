using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void OrderAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositorySorters.OrderAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }

        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }

        public static void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine($"Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitialisedException);
            }
        }

        private static void ReadData(string fileName)
        {
            string path = SessionData.currentPath + @"\" + fileName;

            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
                Regex regex = new Regex(pattern);

                string[] allInputLines = File.ReadAllLines(path);


                foreach (string line in allInputLines)
                {
                    if (!string.IsNullOrEmpty(line) && regex.IsMatch(line))
                    {
                        Match currentMatch = regex.Match(line);

                        string course = currentMatch.Groups[1].Value;
                        string student = currentMatch.Groups[2].Value;
                        int studentScoreOnTask;

                        bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out studentScoreOnTask);

                        if (hasParsedScore && studentScoreOnTask >= 0 && studentScoreOnTask <= 100)
                        {
                            if (studentsByCourse.ContainsKey(course))
                            {
                                if (studentsByCourse[course].ContainsKey(student))
                                {
                                    studentsByCourse[course][student].Add(studentScoreOnTask);
                                }
                                else
                                {
                                    studentsByCourse[course].Add(student, new List<int>() { studentScoreOnTask });
                                }
                            }
                            else
                            {
                                studentsByCourse.Add(course, new Dictionary<string, List<int>> { { student, new List<int>() { studentScoreOnTask } } });
                            }
                        }

                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine($"Data read!");
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);

            return false;
        }

        public static void GetStudentScoreFromCourse(string courseName, string studentName)
        {
            if (IsQueryForStudentPossible(courseName, studentName))
            {
                OutputWriter.DisplayStudent(new KeyValuePair<string, List<int>>(studentName, studentsByCourse[courseName][studentName]));
            }
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");

                foreach (KeyValuePair<string, List<int>> studentMarksEntry in studentsByCourse[courseName])
                {
                    OutputWriter.DisplayStudent(studentMarksEntry);
                }
            }
        }
    }
}
