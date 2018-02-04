using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(wantedData, x => x >= 5, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, x => x >= 3.5 && x < 5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter,
            int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var userName_Points in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                double averageScore = userName_Points.Value.Average();
                double percetageOfFullfilment = averageScore / 100d;
                double mark = percetageOfFullfilment * 4 + 2;
                if (givenFilter(mark))
                {
                    OutputWriter.DisplayStudent(userName_Points);
                    counterForPrinted++;
                }
            }
        }

        //private static bool ExcellentFilter(double mark)
        //{
        //    return mark >= 5.0;
        //}
        //
        //private static bool AverageFilter(double mark)
        //{
        //    return mark < 5.0 && mark >= 3.5;
        //}
        //
        //private static bool PoorFilter(double mark)
        //{
        //    return mark < 3.5;
        //}

        //private static double Average(List<int> scoresOnTask)
        //{
        //    int totalScore = 0;
        //    foreach (int score in scoresOnTask)
        //    {
        //        totalScore += score;
        //    }
        //
        //    double percentageOfAll = totalScore / (scoresOnTask.Count * 100.0);
        //    double mark = percentageOfAll * 4 + 2;
        //
        //    return mark;
        //}
    }
}
