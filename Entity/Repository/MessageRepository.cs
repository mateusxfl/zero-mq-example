using Entity.Entities;

namespace Entity.Repository
{
    public class MessageRepository
    {
        public static List<Message> Messages = new List<Message>(){
            new() { Title = "AULA CANCELADA",  Content = $"A aula do dia { DateTime.Now.AddDays(3).ToString("dd/MM/yyyy") } foi cancelada." },
            new() { Title = "NOVA TAREFA",     Content = $"Uma nova tarefa foi inserida, prazo para entrega: { DateTime.Now.AddDays(3).ToString("dd/MM/yyyy") }." },
            new() { Title = "ARQUIVO ENVIADO", Content = $"Os slides da aula ministrada hoje já foram inseridos!" }
        };

        public static Message GetRandom()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            Messages[rand.Next(Messages.Count)].Date = DateTime.Now;

            return Messages[rand.Next(Messages.Count)];
        }
    }
}
