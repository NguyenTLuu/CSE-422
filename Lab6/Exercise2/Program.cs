using Exercise2.Models;
using Exercise2.Repositories;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

string connectionString =
    "Server=localhost;Database=Lab6DB;" +
    "Trusted_Connection=True;TrustServerCertificate=True;";

services.AddTransient<IRepository<Student>>(sp =>
    new GenericRepository<Student>(
        connectionString,
        "Students",
        reader => new Student
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1)
        }
    )
);

services.AddTransient<IRepository<Teacher>>(sp =>
    new GenericRepository<Teacher>(
        connectionString,
        "Teachers",
        reader => new Teacher
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1)
        }
    )
);

using var provider = services.BuildServiceProvider();

var studentRepo =
    provider.GetRequiredService<IRepository<Student>>();

var teacherRepo =
    provider.GetRequiredService<IRepository<Teacher>>();

Console.WriteLine("Students:");
foreach (var student in studentRepo.GetAll())
{
    Console.WriteLine($"{student.Id} - {student.Name}");
}

Console.WriteLine("Teachers:");
foreach (var teacher in teacherRepo.GetAll())
{
    Console.WriteLine($"{teacher.Id} - {teacher.Name}");
}