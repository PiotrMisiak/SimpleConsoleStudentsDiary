using System;
using Xunit;
using ChallengeApp;
using System.Collections.Generic;

namespace challenge.tests
{
    public class StudentTests
    {
       [Fact]
       public void Test1()
       {
           // arrange
             var stud = new StudentInMemory("student");
             stud.grades.Add(6);
             stud.grades.Add(1);
             stud.grades.Add(5);


             // act
             var result = stud.GetStatistics();

             // assert 
              Assert.Equal(4, result.Average);
              Assert.Equal(6, result.High);
              Assert.Equal(1, result.Low);
            
        }     
      
    }
  }
