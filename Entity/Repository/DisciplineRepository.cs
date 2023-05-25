using Entity.Entities;

namespace Entity.Repository
{
    public class DisciplineRepository
    {
        public List<Discipline> Disciplines = new List<Discipline>(){
            new() {Id = Guid.NewGuid(), Name = "SD"},
            new() {Id = Guid.NewGuid(), Name = "LFA"},
            new() {Id = Guid.NewGuid(), Name = "EDA"},
            new() {Id = Guid.NewGuid(), Name = "PAA"},
            new() {Id = Guid.NewGuid(), Name = "IA"},
            new() {Id = Guid.NewGuid(), Name = "CG"},
            new() {Id = Guid.NewGuid(), Name = "LOGICA"},
            new() {Id = Guid.NewGuid(), Name = "INGLÊS"}
        };

        public List<Discipline> Get(string[] disciplines)
        {
            List<Discipline> result = new List<Discipline>();

            foreach (var discipline in disciplines)
            {
                result.Add(Disciplines.FirstOrDefault(x => x.Name == discipline));
            }

            return result;
        }

        public Discipline GetDisciplineByTeacher(Teacher teacher)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            return teacher.DisciplinesTaught[rand.Next(teacher.DisciplinesTaught.Count)];
        }
    }
}
