using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public delegate void PoorGradeAddedDelegate(object sender, EventArgs args);
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class StudentInMemory : StudentBase
    {      
        public  override event PoorGradeAddedDelegate PoorGradeAdded;
        public override event GradeAddedDelegate GradeAdded;       

        public List<double> grades = new List<double>();

        public StudentInMemory(string name) : base(name)
        {
        }
                                                      
        public override void AddGrade(string grade)
        {                          
            switch(grade)
            {                               
                case var g when g == "1+" :                             
                grades.Add(1.5);
                PoorGradeAdded(this, new EventArgs());
                break;

                case var g when g == "2-" :
                grades.Add(1.75);
                PoorGradeAdded(this, new EventArgs());
                break;

                case var g when g == "2+" :
                grades.Add(2.5);
                PoorGradeAdded(this, new EventArgs());
                break;

                case var g when g == "3-" :
                grades.Add(2.75);
                PoorGradeAdded(this, new EventArgs());
                break;

                case var g when g == "3+" :
                grades.Add(3.5);
                GradeAdded(this, new EventArgs());
                break;

                case var g when g == "4-" :
                grades.Add(3.75);
                GradeAdded(this, new EventArgs());
                break;

                case var g when g == "4+" :
                grades.Add(4.5);
                GradeAdded(this, new EventArgs());
                break;

                case var g when g == "5-" :
                grades.Add(4.75);
                GradeAdded(this, new EventArgs());
                break;

                case var g when g == "5+" :
                grades.Add(5.5);
                GradeAdded(this, new EventArgs());
                break; 

                case var g when g == "6-" :
                grades.Add(5.75);
                GradeAdded(this, new EventArgs());           
                break;

                case var g when Convert.ToInt32(g) >= 1 && Convert.ToInt32(g) < 3 : 
                grades.Add(Convert.ToInt32(g));              
                PoorGradeAdded(this, new EventArgs());
                break; 

                case var g when Convert.ToInt32(g) >= 3 && Convert.ToInt32(g) <= 6 : 
                grades.Add(Convert.ToInt32(g));               
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

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
                for(var index = 0; index < grades.Count; index +=1)
                {
                    result.Add(grades[index]);
                }
                return result;          
        }   

        public void AddGradeTryParse(string grade)
        {    
            int result;                    
            bool succes = int.TryParse(grade, out result); 
            if(succes && result >= 1 && result <=6)
            {
                grades.Add(result);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }       
        } 
    }
}