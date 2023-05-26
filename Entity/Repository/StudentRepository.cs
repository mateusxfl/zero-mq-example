using Entity.Entities;

namespace Entity.Repository
{
    public class StudentRepository
    {
        public static List<Student> Students = new List<Student>(){
            new() { Id = Guid.NewGuid(), Name = "Mateus", DisciplinesEnrolled = DisciplineRepository.Get(new string[] { "SD", "LFA" }) },
            new() { Id = Guid.NewGuid(), Name = "Pedro",  DisciplinesEnrolled = DisciplineRepository.Get(new string[] { "SD", "EDA" }) },
            new() { Id = Guid.NewGuid(), Name = "Otavio", DisciplinesEnrolled = DisciplineRepository.Get(new string[] { "SD", "PAA" }) }
        };

        public static List<Student> GetAll()
        {
            return Students;
        }
    }
}
