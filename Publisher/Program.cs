using Entity.Entities;
using Entity.Repository;

/*Student student = new StudentRepository().Get("Mateus");
Teacher teacher = new TeacherRepository().Get("Bonfim");

Console.WriteLine($"{student.Name} - {student.DisciplinesEnrolled.Count}");
Console.WriteLine($"{teacher.Name} - {teacher.DisciplinesTaught.Count}");*/

// PUBLISH
for (int i = 0; i < 10; i++)
{
    Teacher randomTeacher = new TeacherRepository().GetRandom();

    Discipline discipline = new DisciplineRepository().GetDisciplineByTeacher(randomTeacher); // Topico

    Message randomMessage = new MessageRepository().GetRandom(); // Message

    // PUBLICA

    // INFORMA QUE FOI PUBLICADO
}