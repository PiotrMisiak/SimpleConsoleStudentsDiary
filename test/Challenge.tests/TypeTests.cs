using System;
using Xunit;
using ChallengeApp;

namespace challenge.tests
{
    public class TypeTests
    {
      [Fact]
      public void GetStudentReturnsDifferentsObjects()
      {
          var stud1 = GetStudent("Marek");
          var stud2 = GetStudent("Jan");      

      Assert.NotSame(stud1, stud2);
      Assert.False(object.ReferenceEquals(stud1, stud2));
      Assert.False(StudentInMemory.Equals(stud1, stud2));

      }

      [Fact]
      public void TwoVarsCanRefferenceSameObject()
      {
        var stud1 = GetStudent("Marek");
        var stud2 = stud1;      

        Assert.Same(stud1, stud2);
        Assert.True(object.ReferenceEquals(stud1, stud2));
        
      }


      [Fact]
      public void CanSetNameFromRefference()
      {
          var stud1 = GetStudent("Piotr");
          this.SetName(stud1, "NewName");
          Assert.Equal("NewName", stud1.Name);
            
      }

      private void SetName(StudentInMemory student, string name)
      {
        student.Name = name;
      }

      private StudentInMemory GetStudent(string name)
      {
          return new StudentInMemory("");
      }     
    }
}
