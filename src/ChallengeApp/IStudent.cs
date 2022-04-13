using System;
using System.Collections.Generic;


namespace ChallengeApp
{   
    public interface IStudent
    { 
        void AddGrade(string grade);           
        Statistics GetStatistics();
        string Name {get;}  

        event GradeAddedDelegate GradeAdded;

        event PoorGradeAddedDelegate PoorGradeAdded;
           
    }
}   