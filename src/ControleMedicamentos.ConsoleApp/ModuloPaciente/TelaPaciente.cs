using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    internal class TelaPaciente : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Pacientes...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -15} | {4, -15}",
                "Id", "Nome", "Endereco", "Telefone", "Cartão do SUS"
            );

            Entidade[] pacientesCadastrados = repositorio.SelecionarTodos();

            foreach (Paciente paciente in pacientesCadastrados)
            {
                if (paciente == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -15} | {4, -15}",
                    paciente.Id, paciente.Nome, paciente.Endereco, paciente.Telefone, paciente.CartaoSus
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override Entidade ObterRegistro()
        {
            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o endereço do paciente: ");
            string endereco = Console.ReadLine();

            Console.Write("Digite o telefone do paciente ('49 98765-4321': ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o cartão do SUS do paciente (15 números): ");
            string cartaoSus = Console.ReadLine();

            Paciente novoPaciente = new Paciente(nome, endereco, telefone, cartaoSus);

            return novoPaciente;
        }

        public void CadastrarEntidadeTeste()
        {
            Paciente paciente = new Paciente("Jota Silva", "Rua J5", "49 99876-5432", "123456789012345");

            repositorio.Cadastrar(paciente);
        }
    }
}