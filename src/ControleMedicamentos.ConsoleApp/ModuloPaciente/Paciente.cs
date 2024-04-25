using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : Entidade
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public Paciente(string nome, string endereco)
        {
            Nome = nome;
            Endereco = endereco;
        }

        public string[] Validar()
        {
            string[] erros = new string[2];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Nome))
            {
                erros[0] = "O nome do paciente é obrigatório";
                contadorErros++;
            }

            if (string.IsNullOrEmpty(Endereco))
            {
                erros[1] = "O endereço do paciente é obrigatório";
                contadorErros++;
            }

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}