using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
    public class StudentSaved : StudentBase
    {    
        public override event GradeAddedDelegate GradeAdded;

        public override event PoorGradeAddedDelegate PoorGradeAdded; 
        
        public List<double> grades; 

        const string fileName = "Grades.txt";
        
        public StudentSaved(string name) : base(name)
        {
            grades = new List<double>();                               
        }

        public override void AddGrade(string grade)
        {           
            using(var writer = File.AppendText(string.Concat(Name, fileName)))
            using(var writeGradeAndDate = File.AppendText($"{Name}Audit.txt")) 
            {                         
                switch(grade)
                {                               
                    case var g when g == "1+" :                             
                    grades.Add(1.5);
                    writer.WriteLine(1.5);
                    writeGradeAndDate.WriteLine($"Grade: {g} , added: {DateTime.UtcNow}");
                    PoorGradeAdded(this, new EventArgs());
                    break;

                    case var g when g == "2-" :
                    grades.Add(1.75);
                    writer.WriteLine(1.75);
                    writeGradeAndDate.WriteLine($"Grade: {g} , added: {DateTime.UtcNow}");
                    PoorGradeAdded(this, new EventArgs());
                    break;

                    case var g when g == "2+" :
                    grades.Add(2.5);
                    writer.WriteLine(2.5);
                    writeGradeAndDate.WriteLine($"Grade: {g} , added: {DateTime.UtcNow}");
                    PoorGradeAdded(this, new EventArgs());
                    break;

                    case var g when g == "3-" :
                    grades.Add(2.75);
                    writer.WriteLine(2.75);
                    writeGradeAndDate.WriteLine($"Grade: {g} , added: {DateTime.UtcNow}");
                    PoorGradeAdded(this, new EventArgs());
                    break;

                    case var g when g == "3+" :
                    grades.Add(3.5);
                    GradeAdded(this, new EventArgs());
                    writer.WriteLine(3.5);
                    writeGradeAndDate.WriteLine($"Grade: {g} , added: {DateTime.UtcNow}");
                    break;
                    
                    case var g when g == "4-" :
                    grades.Add(3.75);
                    GradeAdded(this, new EventArgs());
                    writer.WriteLine(3.75);
                    writeGradeAndDate.WriteLine($"Grade: {g} , added: {DateTime.UtcNow}");
                    break;  

                    case var g when g == "4+" :
                    grades.Add(4.5);
                    writer.WriteLine(4.5);
                    writeGradeAndDate.WriteLine($"Grade: {g} , added: {DateTime.UtcNow}");
                    break;  

                    case var g when g == "5-" :
                    grades.Add(4.75);
                    GradeAdded(this, new EventArgs());
                    writer.WriteLine(4.75);
                    writeGradeAndDate.WriteLine($"Grade: {g} , added: {DateTime.UtcNow}");
                    break;

                    case var g when g == "5+" :
                    grades.Add(5.5);
                    GradeAdded(this, new EventArgs());
                    writer.WriteLine(5.5);
                    writeGradeAndDate.WriteLine($"Grade: {g} , added: {DateTime.UtcNow}");
                    break; 

                    case var g when g == "6-" :
                    grades.Add(5.75);
                    GradeAdded(this, new EventArgs());
                    writer.WriteLine(5.75);
                    writeGradeAndDate.WriteLine($"Grade: {g} , added: {DateTime.UtcNow}");
                    break;

                    case var g when Convert.ToInt32(g) >= 1 && Convert.ToInt32(g) < 3 : 
                    grades.Add(Convert.ToInt32(g));
                    writer.WriteLine(grade);
                    writeGradeAndDate.WriteLine($"Grade: {grade} , added: {DateTime.UtcNow}");  
                    PoorGradeAdded(this, new EventArgs());
                    break;   

                    case var g when Convert.ToInt32(g) >= 3 && Convert.ToInt32(g) <= 6 : 
                    grades.Add(Convert.ToInt32(g));
                    writer.WriteLine(grade);
                    writeGradeAndDate.WriteLine($"Grade: {grade} , added: {DateTime.UtcNow}");  
                    GradeAdded(this, new EventArgs());
                    break;

                    case var g when Convert.ToInt32(g) < 1: 
                    Console.WriteLine("Invalid value!");
                    break; 

                    case var g when Convert.ToInt32(g) > 6: 
                    Console.WriteLine("Invalid value!");
                    break;                                                          
                }  
            }                           
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
           
            using (var reader = File.OpenText(string.Concat(Name, fileName)))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                   var number = double.Parse(line);
                   result.Add(number);
                   line = reader.ReadLine();
                }
            }
         
            return result;
        }
     
    }
}