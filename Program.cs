using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

var people = new List<Person>
{
    new Person { Id = 1, Name = "Hoji", Age = 17, CityId = 1 },
    new Person { Id = 2, Name = "Usmon", Age = 17, CityId = 2 },
    new Person { Id = 3, Name = "Ramazon", Age = 20, CityId = 3 },
    new Person { Id = 4, Name = "Akram", Age = 20, CityId = 4 },
    new Person { Id = 5, Name = "Bekhruz", Age = 19, CityId = 5 },
    new Person { Id = 6, Name = "Abubakr", Age = 17, CityId = 6 }
};

var cities = new List<City>
{
    new City { Id = 1, Name = "Kulob"},
    new City { Id = 2, Name = "Dushanbe"},
    new City { Id = 3, Name = "Kurgan"},
    new City { Id = 4, Name = "Vahdat"},
    new City { Id = 5, Name = "Israravshan"},
    new City { Id = 6, Name = "Khujand"}
};

// Task 1
// var result = people
//     .Where(person => person.Age > 25)
//     .Select(person => new
//      {
//         person.Name,
//         person.Age                                 
//      });
// foreach (var person in result)
// {
//     Console.WriteLine($"{person.Name} - {person.Age}");
// }     

// Task 2
// var result = people 
//     .OrderBy(person => person.Age)
//     .ThenBy(person => person.Name);
// foreach(var person in result)
// {
//     Console.WriteLine($"{person.Name} - {person.Age}");
// }

// Task 3
// var result = people
//     .GroupBy(person => person.Name[0]);

// foreach (var group in result)
// {
//     System.Console.WriteLine($"Letter: {group.Key}");

// foreach (var person in group)
// {
//     System.Console.WriteLine(person.Name);
// }
// }


// Task 4
// var result = people 
//     .Join(
//         cities,
//         person => person.CityId,
//         city => city.Id,
//         (person, city) => new
//         {
//             PersonName = person.Name,
//             CityName = city.Name
//         }
//     );
//         foreach (var item in result)
//         {
//             System.Console.WriteLine($"{item.PersonName} - {item.CityName}");
//         } 


// Task 5
// var result = people
//     .Where(person => "AEIOU".Contains(person.Name[0]))
//     .Sum(person => person.Age);

// Console.WriteLine(result);


// Task 6 
// var result = people 
//     .GroupBy(person => person.Name[0])
//     .Select(group => new
//     {
//         letter = group.Key,
//         Count = group.Count()
//     });
//     foreach (var group in result)
//     {
//         System.Console.WriteLine($"{group.letter} - {group.Count}");
//     }

// Task 7
// var result = people
//     .Join(
//         cities,
//         person => person.CityId,
//         city => city.Id,
//         (person, city) => new
//         {
//             CityName = city.Name
//         })
//     .GroupBy(x => x.CityName)
//     .OrderByDescending(group => group.Count())
//     .First();

//     Console.WriteLine($"{result.Key} - {result.Count()} people");

// Task 8
// var result = people
//     .Join(
//         cities,
//         person => person.CityId,
//         city => city.Id,
//         (person, city) => new
//         {
//             PersonName = person.Name,
//             Age = person.Age,
//             CityName = city.Name
//         })
//     .Where(x => x.Age >= 2 &&
//                 x.Age <= 7 &&
//                 x.CityName.StartsWith("A"));





//                          HOMETASK

var students = new List<Student>
{
    new Student { StudentId = 1, Name = "Alice", DateOfBirth = new DateTime(2000, 5, 15) },
    new Student { StudentId = 2, Name = "Bob", DateOfBirth = new DateTime(1999, 8, 25) },
    new Student { StudentId = 3, Name = "Charlie", DateOfBirth = new DateTime(2001, 3, 10) }
};

var courses = new List<Course>
{
    new Course { CourseId = 101, Title = "Mathematics", Credits = 4 },
    new Course { CourseId = 102, Title = "Computer Science", Credits = 3 },
    new Course { CourseId = 103, Title = "Physics", Credits = 4 }
};

var enrollments = new List<Enrollment>
{
    new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 15) },
    new Enrollment { EnrollmentId = 2, StudentId = 1, CourseId = 102, EnrollmentDate = new DateTime(2023, 1, 20) },
    new Enrollment { EnrollmentId = 3, StudentId = 2, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 18) },
    new Enrollment { EnrollmentId = 4, StudentId = 3, CourseId = 103, EnrollmentDate = new DateTime(2023, 1, 22) },
    new Enrollment { EnrollmentId = 5, StudentId = 3, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 25) },
    new Enrollment { EnrollmentId = 6, StudentId = 3, CourseId = 102, EnrollmentDate = new DateTime(2023, 1, 30) }
};


// Task 1
// var result = students
//     .Join(
//         enrollments,
//         student => student.StudentId,
//         enrollment => enrollment.StudentId,
//         (student, enrollment) => new
//         {
//             student,
//             enrollment
//         })
//     .Join(
//         courses,
//         x => x.enrollment.CourseId,
//         course => course.CourseId,
//         (x, course) => new
//         {
//             StudentName = x.student.Name,
//             CourseName = course.Title
//         })
//     .Where(x => x.CourseName == "Mathematics");
// foreach (var item in result)
// {
//     Console.WriteLine($"{item.StudentName} - {item.CourseName}");
// }


// Task 2
// var result = students
//     .Where(student => student.Name == "Charlie")
//     .Join(
//         enrollments,
//         student => student.StudentId,
//         enrollment => enrollment.StudentId,
//         (student, enrollment) => enrollment.CourseId)
//     .Join(
//         courses,
//         courseId => courseId,
//         course => course.CourseId,
//         (courseId, course) => course.Title);
// foreach (var course in result)
// {
//     Console.WriteLine(course);
// }

// TAsk 3
// var result = students
//     .SelectMany(
//         student => enrollments
//             .Where(enrollment => enrollment.StudentId == student.StudentId)
//             .Select(enrollment => new
//             {
//                 Student = student,
//                 Enrollment = enrollment
//             }))
//     .GroupBy(x => x.Student.StudentId)
//     .Where(group => group.Count() > 1)
//     .Select(group => group.First().Student);
// foreach (var student in result)
// {
//     Console.WriteLine(student.Name);
// }

// task 4
// var result = students
//     .SelectMany(
//         student => enrollments
//             .Where(enrollment => enrollment.StudentId == student.StudentId)
//             .Join(
//                 courses,
//                 enrollment => enrollment.CourseId,
//                 course => course.CourseId,
//                 (enrollment, course) => new
//                 {
//                     Student = student,
//                     Course = course
//                 }))
//     .GroupBy(x => new
//     {
//         AgeRange =
//             DateTime.Now.Year - x.Student.DateOfBirth.Year < 20
//                 ? "Under 20"
//                 : "20 and older",
//         Course = x.Course.Title
//     })
//     .Select(group => new
//     {
//         group.Key.AgeRange,
//         group.Key.Course,
//         AverageAge = group.Average(x =>
//             DateTime.Now.Year - x.Student.DateOfBirth.Year)
//     });
// foreach (var item in result)
// {
//     Console.WriteLine(
//         $"{item.AgeRange} - {item.Course} - Average age: {item.AverageAge}");
// }

// task 5
// var result = students
//     .Join(
//         enrollments,
//         student => student.StudentId,
//         enrollment => enrollment.StudentId,
//         (student, enrollment) => new
//         {
//             student,
//             enrollment
//         })
//     .Join(
//         courses,
//         x => x.enrollment.CourseId,
//         course => course.CourseId,
//         (x, course) => new
//         {
//             StudentName = x.student.Name,
//             EnrollmentDate = x.enrollment.EnrollmentDate,
//             CourseName = course.Title,
//             Credits = course.Credits
//         })
//     .Where(x =>
//         x.EnrollmentDate >= new DateTime(2023, 1, 20)
//         && x.Credits >= 4);
// foreach (var item in result)
// {
//     Console.WriteLine(
//         $"{item.StudentName} - {item.CourseName} - {item.EnrollmentDate} - {item.Credits}");
// }

// task 6
// var result = students
//     .Join(
//         enrollments,
//         student => student.StudentId,
//         enrollment => enrollment.StudentId,
//         (student, enrollment) => new
//         {
//             student,
//             enrollment
//         })
//     .Join(
//         courses,
//         x => x.enrollment.CourseId,
//         course => course.CourseId,
//         (x, course) => new
//         {
//             StudentName = x.student.Name,
//             Credits = course.Credits
//         })
//     .GroupBy(x => x.StudentName)
//     .Select(group => new
//     {
//         StudentName = group.Key,
//         TotalCredits = group.Sum(x => x.Credits)
//     });
// foreach (var item in result)
// {
//     Console.WriteLine($"{item.StudentName} - {item.TotalCredits}");
// }

// Task 7
// var result = courses
//     .Join(
//         enrollments,
//         course => course.CourseId,
//         enrollment => enrollment.CourseId,
//         (course, enrollment) => new
//         {
//             CourseName = course.Title,
//             StudentId = enrollment.StudentId
//         })
//     .GroupBy(x => x.CourseName)
//     .Select(group => new
//     {
//         CourseName = group.Key,
//         StudentCount = group.Select(x => x.StudentId).Distinct().Count()
//     });
// foreach (var item in result)
// {
//     Console.WriteLine($"{item.CourseName} - {item.StudentCount}");
// }

// task 8
// var bobCourses = enrollments
//     .Where(enrollment =>
//         students.Any(student =>
//             student.StudentId == enrollment.StudentId &&
//             student.Name == "Bob"))
//     .Select(enrollment => enrollment.CourseId);

// var result = courses
//     .Where(course => !bobCourses.Contains(course.CourseId));
// foreach (var course in result)
// {
//     Console.WriteLine(course.Title);
// }