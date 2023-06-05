using Entity.Entities;
using Entity.Repository;
using Entity.Utils;
using NetMQ;
using NetMQ.Sockets;

List<Thread> subscriberThreads = new List<Thread>();

// Iniciando diversos assinantes em threads separadas.
foreach (Student student in StudentRepository.GetAll())
{
    subscriberThreads.Add(new Thread(Subscriber));
    subscriberThreads.Last().Start(student);
}

foreach (Thread thread in subscriberThreads)
{
    thread.Join();
}

static void Subscriber(object entity)
{
    Student student = (Student)entity;

    using (var subscriber = new SubscriberSocket())
    {
        subscriber.Connect("tcp://localhost:5555");

        foreach (Discipline discipline in student.DisciplinesEnrolled)
        {
            string topic = discipline.Name;

            subscriber.Subscribe(topic);

            Utils.WriteLineWithColor($"Subscriber {student.Name} joined the channel {discipline.Name} at {DateTime.Now.ToString("HH:mm:ss.fff")}. \n", discipline.Color);
        }

        while (true)
        {
            string messageTopicReceived = subscriber.ReceiveFrameString();
            string messageReceived = subscriber.ReceiveFrameString();

            Utils.WriteLineWithColor($"Subscriber [{DateTime.Now.ToString("HH:mm:ss.fff")}]: [{student.Name}] - [{messageTopicReceived}] - {messageReceived} \n", 
                DisciplineRepository.GetDisciplineByName(messageTopicReceived).Color);
        }
    }
}