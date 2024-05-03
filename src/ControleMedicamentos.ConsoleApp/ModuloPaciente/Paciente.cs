using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Text.RegularExpressions;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    internal class Paciente : Entidade
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string CartaoSus { get; set; }

        public Paciente(string nome, string endereco, string telefone, string cartaoSus)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            CartaoSus = cartaoSus;
        }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (Nome.Length < 3)
                erros[contadorErros++] = "O Nome do Paciente precisa conter ao menos 3 caracteres";

            if (Endereco.Length < 5)
                erros[contadorErros++] = "O Endereço do Paciente precisa conter ao menos 5 caracteres";

            Regex regexTelefone = new Regex(@"^\d{2} \d{5}-\d{4}$");
            if (!regexTelefone.IsMatch(Telefone))
                erros[contadorErros++] = "Preencha o telefone conforme este exemplo: '49 99876-1234'";

            if (CartaoSus.Length < 15)
                erros[contadorErros++] = "O Cartão do SUS precisa conter 15 números";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}