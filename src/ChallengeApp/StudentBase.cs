using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public abstract class StudentBase : StudentParameters, IStudent
    {
        public StudentBase(string name) : base(name)
        {
         
        }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract event PoorGradeAddedDelegate PoorGradeAdded;
        public abstract void AddGrade(string grade);           
        public abstract Statistics GetStatistics();
          
    }
}   