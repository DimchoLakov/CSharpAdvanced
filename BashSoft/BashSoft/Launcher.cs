using System;

namespace BashSoft
{
    class Launcher
    {
        static void Main()
        {
            //Problem 1 Tests
            //IOManager.TraverseDirectory(@"D:\Downloads");

            //Problem 2 Tests
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetAllStudentsFromCourse("Unity");
            //StudentsRepository.GetStudentScoreFromCourse("Unity", "Ivan");

            //Problem 3 Tests
            //Tester.CompareContent(@".\BashSoft-Resources\test1.txt", @".\BashSoft-Resources\test2.txt");
            //Tester.CompareContent(@".\BashSoft-Resources\test1.txt", @".\BashSoft-Resources\test3.txt");

            //Problem 4 Tests
            //IOManager.CreateDirectoryInCurrentFolder("Pesho");
            //IOManager.TraverseDirectory(5);
            //IOManager.CreateDirectoryInCurrentFolder("Pesho");
            //IOManager.ChangeCurrentDirectoryRelative("Pesho");
            //IOManager.ChangeCurrentDirectoryAbsolute("Pesho");

            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);
            //Tester.CompareContent("actual", "expecter");
            //IOManager.CreateDirectoryInCurrentFolder("*2");

            InputReader.StartReadingCommands();
        }
    }
}
