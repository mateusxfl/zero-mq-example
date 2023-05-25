using Entity.Entities;

namespace Entity.Repository
{
    public class StudentRepository
    {
        public List<Student> Students = new List<Student>(){
            new() {Id = Guid.NewGuid(), Name = "Mateus", DisciplinesEnrolled = new DisciplineRepository().Get(new string[]{"LFA", "SD" }) },
            new() {Id = Guid.NewGuid(), Name = "Pedro", DisciplinesEnrolled = new DisciplineRepository().Get(new string[]{ "IA"})},
            new() {Id = Guid.NewGuid(), Name = "Otavio", DisciplinesEnrolled = new DisciplineRepository().Get(new string[]{ "IA", "LOGICA" })},
            new() {Id = Guid.NewGuid(), Name = "Eduardo", DisciplinesEnrolled = new DisciplineRepository().Get(new string[]{ "INGLÊS"})},
            new() {Id = Guid.NewGuid(), Name = "Deassis", DisciplinesEnrolled = new DisciplineRepository().Get(new string[]{"LFA", "SD", "INGLÊS"})}
        };

        public Student Get(string name)
        {
            return Students.FirstOrDefault(x => x.Name == name);
        }
    }
}
