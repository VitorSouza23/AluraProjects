namespace SubstituirSubiclassePorCampos.Depois
{
    class Depois
    {
        static void Main(string[] args)
        {
            var hospital = new Hospital();
            var paciente1 = Paciente.CriarPacienteHomem();
            var paciente2 = Paciente.CriarPacienteMulher();

            hospital.Atender(paciente1);
            hospital.Atender(paciente2);

        }
    }

    public class Paciente
    {
        private const char _MASCULINO = 'M';
        private const char _FEMININO = 'F';

        private Paciente(char sexo)
        {
            Sexo = sexo;
        }

        public char Sexo { get; private set; }

        public static Paciente CriarPacienteHomem()
        {
            return new Paciente(_MASCULINO);
        }

        public static Paciente CriarPacienteMulher()
        {
            return new Paciente(_FEMININO);
        }
    }


    class Hospital
    {
        public void Atender(Paciente paciente)
        {
            //To do
        }
    }
}
