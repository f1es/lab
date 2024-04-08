namespace GrpcWorkerService
{
    public class Worker
    {
        private string _name;
        private int _age;
        private string _speciality;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Age
        {
            get => _age;
            set => _age = value;
        }
        public string Speciality
        {
            get => _speciality;
            set => _speciality = value;
        }

        public Worker(string name, int age, string speciality)
        {
            _name = name;
            _age = age;
            _speciality = speciality;
        }
        public void Introduce()
        {
            //Console.WriteLine($"Hi my name's {_name}. I'm {_age} y.o. and i'm {_speciality}");
            Console.WriteLine($"Работник месяца(четырёх секунд) {_name}, Возраст: {_age} лет, специальность: {_speciality}");
        }
    }
}
