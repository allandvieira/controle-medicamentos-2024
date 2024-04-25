using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloChamado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento
    {
        public RepositorioMedicamento repositorio = new RepositorioMedicamento();
        private TelaChamado telaChamado;

        public void SetTelaChamado(TelaChamado telaChamado)
        {
            this.telaChamado = telaChamado;
        }

        public TelaMedicamento()
        {
            Medicamento medTest = new Medicamento("Paracetamol", "Analgésico e antipirético", 100);

            repositorio.Cadastrar(medTest);
        }

        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Medicamento");
            Console.WriteLine("2 - Editar Medicamento");
            Console.WriteLine("3 - Excluir Medicamento");
            Console.WriteLine("4 - Visualizar Medicamentos");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public void CadastrarMedicamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Cadastrando Medicamento...");

            Console.WriteLine();

            Medicamento medicamento = ObterMedicamento();

            string[] erros = medicamento.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            repositorio.Cadastrar(medicamento);

            Program.ExibirMensagem("O medicamento foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        private void ApresentarErros(string[] erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
                Console.WriteLine(erros[i]);

            Console.ResetColor();
            Console.ReadLine();
        }

        public void EditarMedicamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Editando Medicamento...");

            Console.WriteLine();

            VisualizarMedicamentos(false);

            Console.Write("Digite o ID do medicamento que deseja editar: ");
            int idMedicamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.Existe(idMedicamentoEscolhido))
            {
                Program.ExibirMensagem("O medicamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();

            Medicamento medicamento = ObterMedicamento();

            string[] erros = medicamento.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuEditar = repositorio.Editar(idMedicamentoEscolhido, medicamento);

            if (!conseguiuEditar)
            {
                Program.ExibirMensagem("Houve um erro durante a edição de medicamento", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O medicamento foi editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirMedicamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Excluindo Medicamento...");

            Console.WriteLine();

            VisualizarMedicamentos(false);

            Console.Write("Digite o ID do medicamento que deseja excluir: ");
            int idMedicamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.Existe(idMedicamentoEscolhido))
            {
                Program.ExibirMensagem("O medicamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = repositorio.Excluir(idMedicamentoEscolhido);

            if (!conseguiuExcluir)
            {
                Program.ExibirMensagem("Houve um erro durante a exclusão do medicamento", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O medicamento foi excluído com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarMedicamentos(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("|        Gestão de Medicamentos        |");
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();

                Console.WriteLine("Visualizando Medicamentos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -10}",
                "Id", "Nome", "Descrição", "Quantidade"
            );

            Entidade[] medicamentosCadastrados = repositorio.SelecionarTodos();

            foreach (Medicamento med in medicamentosCadastrados)
            {
                if (med == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -10}",
                    med.Id, med.Nome, med.Descricao, med.Quantidade
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        private Medicamento ObterMedicamento()
        {
            Console.Write("Digite o nome do medicamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição do medicamento: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a quantidade do medicamento: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamento = new Medicamento(nome, descricao, quantidade);
            return medicamento;
        }

        public void RequisitarMedicamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Requisitando Medicamento...");

            Console.WriteLine();

            VisualizarMedicamentos(false);

            Console.Write("Digite o ID do medicamento que deseja requisitar: ");
            int idMedicamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.Existe(idMedicamentoEscolhido))
            {
                Program.ExibirMensagem("O medicamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Medicamento medicamento = (Medicamento)repositorio.SelecionarPorId(idMedicamentoEscolhido);

            if (medicamento.Quantidade <= 10)
            {
                Program.ExibirMensagem("A quantidade do medicamento está baixa! Por favor, abra um novo chamado para solicitar a reposição do estoque com o fornecedor.", ConsoleColor.Yellow);
                telaChamado.CadastrarChamado();
            }

            // Baixa no medicamento requisitado
            medicamento.Quantidade--;
            repositorio.Editar(idMedicamentoEscolhido, medicamento);
        }

        public void VisualizarMedicamentosMensal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Visualizando Medicamentos Mais Retirados e com Baixo Estoque...");

            Console.WriteLine();

            // Visualizar os medicamentos mais retirados pela comunidade e os medicamentos que estão com baixo estoque
            Entidade[] medicamentosCadastrados = repositorio.SelecionarTodos();

            foreach (Medicamento med in medicamentosCadastrados)
            {
                if (med == null)
                    continue;

                if (med.Quantidade <= 10)
                {
                    Console.WriteLine(
                        "{0, -10} | {1, -15} | {2, -15} | {3, -10}",
                        med.Id, med.Nome, med.Descricao, med.Quantidade
                    );
                }
            }
        }
    }
}