using Entity.Entities;

namespace Entity.Repository
{
    public static class DisciplineRepository
    {
        public static List<Discipline> Disciplines = new List<Discipline>(){
            new() { Id = Guid.NewGuid(), Name = "SD" , Color = ConsoleColor.DarkMagenta },
            new() { Id = Guid.NewGuid(), Name = "LFA", Color = ConsoleColor.DarkCyan },
            new() { Id = Guid.NewGuid(), Name = "EDA", Color = ConsoleColor.DarkGreen },
            new() { Id = Guid.NewGuid(), Name = "PAA", Color = ConsoleColor.DarkYellow },
            new() { Id = Guid.NewGuid(), Name = "IA" , Color = ConsoleColor.DarkBlue },
            new() { Id = Guid.NewGuid(), Name = "CG" , Color = ConsoleColor.DarkRed }
        };

        public static List<Discipline> Get(string[] disciplines)
        {
            List<Discipline> result = new List<Discipline>();

            foreach (var discipline in disciplines)
            {
                result.Add(Disciplines.FirstOrDefault(x => x.Name == discipline));
            }

            return result;
        }

        public static Discipline GetDisciplineByName(string name)
        {
            return Disciplines.FirstOrDefault(x => x.Name == name);
        }

        public static Discipline GetDisciplineByTeacher(Teacher teacher)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            return teacher.DisciplinesTaught[rand.Next(teacher.DisciplinesTaught.Count)];
        }
    }
}
