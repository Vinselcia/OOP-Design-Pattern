using System;
using System.Collections.Generic;

public interface IPerson
{
    string Name { get; set; }
}

public interface ISubject
{
    string Name { get; set; }
    string SubjectCode { get; set; }
    Teacher Teacher { get; set; }
}
public class Student : IPerson
{
    public string Name { get; set; }
    public string ClassAndSection { get; set; }
}

public class Teacher : IPerson
{
    public string Name { get; set; }
    public string ClassAndSection { get; set; }
}

public class Subject : ISubject
{
    public string Name { get; set; }
    public string SubjectCode { get; set; }
    public Teacher Teacher { get; set; }
}


public class SchoolSystem
{
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Subject> Subjects { get; set; }

    public SchoolSystem()
    {
        Students = new List<Student>();
        Teachers = new List<Teacher>();
        Subjects = new List<Subject>();
    }

    public void FillDummyData()
    {
        
        Students.Add(new Student { Name = "Vinselcia", ClassAndSection = "ClassA" });
        Students.Add(new Student { Name = "Anbu", ClassAndSection = "ClassB" });

        Teachers.Add(new Teacher { Name = "Sabareesan", ClassAndSection = "ClassA" });
        Teachers.Add(new Teacher { Name = "Rajapravin", ClassAndSection = "ClassB" });

        Subjects.Add(new Subject { Name = "Cloud Computing", SubjectCode = "CC101", Teacher = Teachers[0] });
        Subjects.Add(new Subject { Name = "Science", SubjectCode = "SCI101", Teacher = Teachers[1] });
    }

    public void DisplayStudentsInClass(string className)
    {
        var studentsInClass = Students.FindAll(student => student.ClassAndSection == className);
        Console.WriteLine($"Students in {className}:");
        foreach (var student in studentsInClass)
        {
            Console.WriteLine($"- {student.Name}");
        }
    }

    public void DisplaySubjectsTaughtByTeacher(string teacherName)
    {
        var subjectsTaughtByTeacher = Subjects.FindAll(subject => subject.Teacher.Name == teacherName);
        Console.WriteLine($"Subjects taught by {teacherName}:");
        foreach (var subject in subjectsTaughtByTeacher)
        {
            Console.WriteLine($"- {subject.Name} ({subject.SubjectCode})");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SchoolSystem schoolSystem = new SchoolSystem();
        schoolSystem.FillDummyData();

        
        schoolSystem.DisplayStudentsInClass("ClassA");

        Console.WriteLine();
        schoolSystem.DisplaySubjectsTaughtByTeacher($"Sabareesan");
    }
}
