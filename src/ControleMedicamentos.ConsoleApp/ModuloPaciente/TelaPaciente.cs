using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente
    {
        public RepositorioPaciente repositorio = new RepositorioPaciente();

        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Pacientes           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Paciente");
            Console.WriteLine("2 - Editar Paciente");
            Console.WriteLine("3 - Excluir Paciente");
            Console.WriteLine("4 - Visualizar Pacientes");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public void CadastrarPaciente()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Pacientes           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Cadastrando Paciente...");

            Console.WriteLine();

            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o endereço do paciente: ");
            string endereco = Console.ReadLine();

            Paciente novoPaciente = new Paciente(nome, endereco);

            repositorio.Cadastrar(novoPaciente);

            Console.WriteLine("Paciente cadastrado com sucesso!");
        }

        public void EditarPaciente()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Pacientes           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Editando Paciente...");

            Console.WriteLine();

            Console.Write("Digite o ID do paciente que deseja editar: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o novo nome do paciente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o novo endereço do paciente: ");
            string endereco = Console.ReadLine();

            Paciente novoPaciente = new Paciente(nome, endereco);

            repositorio.Editar(idPaciente, novoPaciente);

            Console.WriteLine("Paciente editado com sucesso!");
        }

        public void ExcluirPaciente()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Pacientes           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Excluindo Paciente...");

            Console.WriteLine();

            Console.Write("Digite o ID do paciente que deseja excluir: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            repositorio.Excluir(idPaciente);

            Console.WriteLine("Paciente excluído com sucesso!");
        }

        public void VisualizarPacientes(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("|        Gestão de Pacientes           |");
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();

                Console.WriteLine("Visualizando Pacientes...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15}",
                "Id", "Nome", "Endereço"
            );

            Entidade[] pacientesCadastrados = repositorio.SelecionarTodos();

            foreach (Paciente pac in pacientesCadastrados)
            {
                if (pac == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15}",
                    pac.Id, pac.Nome, pac.Endereco
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
    }
}