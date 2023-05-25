using Entity.Entities;

namespace Entity.Repository
{
    public class TeacherRepository
    {
        public List<Teacher> Teachers = new List<Teacher>(){
            new() { Id = Guid.NewGuid(), Name = "Reuber", DisciplinesTaught = new DisciplineRepository().Get(new string[]{ "SD" }) },
            new() { Id = Guid.NewGuid(), Name = "Eurinardo", DisciplinesTaught = new DisciplineRepository().Get(new string[] { "LFA", "EDA", "PAA" }) },
            new() { Id = Guid.NewGuid(), Name = "Bonfim", DisciplinesTaught = new DisciplineRepository().Get(new string[] { "IA", "CG" }) },
            new() { Id = Guid.NewGuid(), Name = "Alexandre", DisciplinesTaught = new DisciplineRepository().Get(new string[] { "LOGICA" }) },
            new() { Id = Guid.NewGuid(), Name = "Leticia", DisciplinesTaught = new DisciplineRepository().Get(new string[] { "INGLÊS" }) }
        };

        public Teacher Get(string name)
        {
            return Teachers.FirstOrDefault(x => x.Name == name);
        }

        public Teacher GetRandom()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            return Teachers[rand.Next(Teachers.Count)];
        }
    }
}
