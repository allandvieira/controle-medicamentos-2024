using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado
    {
        public RepositorioChamado repositorio = new RepositorioChamado();
        private TelaMedicamento telaMedicamento;
        private TelaPaciente telaPaciente;

        public TelaChamado(TelaMedicamento telaMedicamento, TelaPaciente telaPaciente)
        {
            this.telaMedicamento = telaMedicamento;
            this.telaPaciente = telaPaciente;
        }

        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Requisições         |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Requisição");
            Console.WriteLine("2 - Editar Requisição");
            Console.WriteLine("3 - Excluir Requisição");
            Console.WriteLine("4 - Visualizar Requisições");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public void CadastrarChamado()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Requisições         |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Cadastrando Requisição...");

            Console.WriteLine();

            Console.Write("Digite a descrição da requisição: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o ID do medicamento requisitado: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ID do paciente solicitante: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoRequisitado = (Medicamento)telaMedicamento.repositorio.SelecionarPorId(idMedicamento);
            Paciente pacienteSolicitante = (Paciente)telaPaciente.repositorio.SelecionarPorId(idPaciente);

            Requisicao novaRequisicao = new Requisicao(descricao, medicamentoRequisitado, pacienteSolicitante);

            repositorio.Cadastrar(novaRequisicao);

            Console.WriteLine("Requisição cadastrada com sucesso!");
        }

        public void EditarChamado()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Requisições         |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Editando Requisição...");

            Console.WriteLine();

            Console.Write("Digite o ID da requisição que deseja editar: ");
            int idRequisicao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a nova descrição da requisição: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o ID do novo medicamento requisitado: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ID do novo paciente solicitante: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoRequisitado = (Medicamento)telaMedicamento.repositorio.SelecionarPorId(idMedicamento);
            Paciente pacienteSolicitante = (Paciente)telaPaciente.repositorio.SelecionarPorId(idPaciente);

            Requisicao novaRequisicao = new Requisicao(descricao, medicamentoRequisitado, pacienteSolicitante);

            repositorio.Editar(idRequisicao, novaRequisicao);

            Console.WriteLine("Requisição editada com sucesso!");
        }

        public void ExcluirChamado()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Requisições         |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Excluindo Requisição...");

            Console.WriteLine();

            Console.Write("Digite o ID da requisição que deseja excluir: ");
            int idRequisicao = Convert.ToInt32(Console.ReadLine());

            repositorio.Excluir(idRequisicao);

            Console.WriteLine("Requisição excluída com sucesso!");
        }

        public void VisualizarChamados(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("|        Gestão de Requisições         |");
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();

                Console.WriteLine("Visualizando Requisições...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -10}",
                "Id", "Descrição", "Medicamento", "Paciente"
            );

            Entidade[] requisicoesCadastradas = repositorio.SelecionarTodos();

            foreach (Requisicao req in requisicoesCadastradas)
            {
                if (req == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -10}",
                    req.Id, req.Descricao, req.MedicamentoRequisitado.Nome, req.PacienteSolicitante.Nome
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
    }
}