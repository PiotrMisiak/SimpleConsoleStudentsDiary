using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Hello, this is a program to get student's grades and make statistics.\nPlease follow instructions.");         
            var student = new StudentInMemory("student");
            student.PoorGradeAdded += OnPoorGradeAdded;
            student.GradeAdded += OnGradeAdded;            
            AddStudentName(student);                                  
            ChangeStudentName(student);            
            EnterGrade(student);
                                    
        }
        private static void OnPoorGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Oh no poor grade is added! We should inform student’s parents about this fact.\n(press 'q' if all grades are added)\n");
        }
        private static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("New grade is added.\n(press 'q' if all grades are added)\n");
        }

        public static void AddStudentName(StudentInMemory student)
        { 
            Console.WriteLine("\nAdd name of student, please.");    
            while(true)
            {
                var name = Console.ReadLine();
                bool result = true;                    
                foreach(char c in name)
                {   
                    if(char.IsDigit(c))
                    {
                        result = false;
                    }                                                                                                                                                                                     
                }  
                if(result)
                {                      
                    student.Name = name;
                    break;
                }  
                else
                Console.WriteLine("\nName cannot have numbers!!! Try again.");
            }                                               
        }

          public static void ChangeStudentName(StudentInMemory student)
        {   
            Console.WriteLine(
            $"\nName of student is: {student.Name}. Do you want to change student name?\n(press 'y' if yes, or 'n' if no)");                           
            var choose = Console.ReadLine();

            while(true)
            {
                if(choose != "y" && choose != "n")
                {
                Console.WriteLine("\nInvalid value. Press 'y' for change name or 'n' if you don't want to change."); 
                choose = Console.ReadLine();  
                }                                                                                                                                 
                else if (choose == "n")
                {                   
                    break;                  
                } 
                else if (choose == "y")
                { 
                    Console.WriteLine("\nAdd new name:"); 
                    while(true) 
                    {                                                      
                        var name = Console.ReadLine();
                        bool result = true;                    
                        foreach(char c in name)
                        {   
                            if(char.IsDigit(c))
                            {
                                result = false;
                            }                                                                                                                                                                                     
                        }                
                    if(result)
                    {                      
                        student.Name = name;
                        break;
                    }              
                    else
                    Console.WriteLine("\nName cannot have numbers!!! Try again.");
                    }
                break;
                } 
            }                             
        }      
        private static void EnterGrade(StudentInMemory student)
        {
            Console.WriteLine(
            $"\nAdd grades of student {student.Name} please.\nPossible grades are from 1 to 6, also grades with '+' and '-' are possible (for example '4+').\nProgram show You: High, Low and Average values.\n(press 'q' if all grades are added)\n");

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {                                                  
                    student.AddGrade(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid value!");
                }
            }            
            if (student.grades.Count == 0)
            {
                Console.WriteLine("\nYou didn't add grade.");                                                  
            }
            else 
            {
                var stat = student.GetStatistics();
                Console.WriteLine($"\nStudent {student.Name} grades:\nLow grade is: {stat.Low}\nHigh grade is: {stat.High}\nAverage is: {Math.Round(stat.Average, 2)} {stat.Letter}");             
            }
            Console.WriteLine("\nThank You for using our program.");                           
        }
    }
}
