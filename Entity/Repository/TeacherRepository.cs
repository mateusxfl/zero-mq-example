using Entity.Entities;

namespace Entity.Repository
{
    public class TeacherRepository
    {
        public static List<Teacher> Teachers = new List<Teacher>(){
            new() { Id = Guid.NewGuid(), Name = "Reuber",    DisciplinesTaught = DisciplineRepository.Get(new string[] { "SD" }) },
            new() { Id = Guid.NewGuid(), Name = "Eurinardo", DisciplinesTaught = DisciplineRepository.Get(new string[] { "LFA", "EDA", "PAA" }) },
            new() { Id = Guid.NewGuid(), Name = "Bonfim",    DisciplinesTaught = DisciplineRepository.Get(new string[] { "IA", "CG" }) },
        };

        public static List<Teacher> GetAll()
        {
            return Teachers;
        }

        public static Teacher GetRandom()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            return Teachers[rand.Next(Teachers.Count)];
        }
    }
}
