using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao.Saida;

namespace ControleMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();

            TelaFuncionario telaFuncionario = new TelaFuncionario();
            telaFuncionario.tipoEntidade = "Funcionário";
            telaFuncionario.repositorio = repositorioFuncionario;

            telaFuncionario.CadastrarEntidadeTeste();

            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();

            TelaPaciente telaPaciente = new TelaPaciente();
            telaPaciente.tipoEntidade = "Paciente";
            telaPaciente.repositorio = repositorioPaciente;

            telaPaciente.CadastrarEntidadeTeste();

            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();

            TelaFornecedor telaFornecedor = new TelaFornecedor();
            telaFornecedor.tipoEntidade = "Fornecedor";
            telaFornecedor.repositorio = repositorioFornecedor;

            telaFornecedor.CadastrarEntidadeTeste();

            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();

            TelaMedicamento telaMedicamento = new TelaMedicamento();
            telaMedicamento.tipoEntidade = "Medicamento";

            telaMedicamento.repositorio = repositorioMedicamento;
            telaMedicamento.repositorioFornecedor = repositorioFornecedor;

            telaMedicamento.telaFornecedor = telaFornecedor;

            telaMedicamento.CadastrarEntidadeTeste();

            RepositorioRequisicaoSaida repositorioRequisicaoSaida = new RepositorioRequisicaoSaida();

            TelaRequisicaoSaida telaRequisicaoSaida = new TelaRequisicaoSaida();
            telaRequisicaoSaida.repositorio = repositorioRequisicaoSaida;
            telaRequisicaoSaida.tipoEntidade = "Requisição de Saída";

            telaRequisicaoSaida.telaPaciente = telaPaciente;
            telaRequisicaoSaida.telaMedicamento = telaMedicamento;

            telaRequisicaoSaida.repositorioPaciente = repositorioPaciente;
            telaRequisicaoSaida.repositorioMedicamento = repositorioMedicamento;

            RepositorioRequisicaoEntrada repositorioRequisicaoEntrada = new RepositorioRequisicaoEntrada();

            TelaRequisicaoEntrada telaRequisicaoEntrada = new TelaRequisicaoEntrada();
            telaRequisicaoEntrada.repositorio = repositorioRequisicaoEntrada;
            telaRequisicaoEntrada.tipoEntidade = "Requisição de Entrada";

            telaRequisicaoEntrada.telaMedicamento = telaMedicamento;
            telaRequisicaoEntrada.telaFuncionario = telaFuncionario;

            telaRequisicaoEntrada.repositorioMedicamento = repositorioMedicamento;
            telaRequisicaoEntrada.repositorioFuncionario = repositorioFuncionario;

            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaPaciente;

                else if (opcaoPrincipalEscolhida == '2')
                    tela = telaFornecedor;

                else if (opcaoPrincipalEscolhida == '3')
                    tela = telaMedicamento;

                else if (opcaoPrincipalEscolhida == '4')
                    tela = telaFuncionario;

                else if (opcaoPrincipalEscolhida == '5')
                    tela = telaRequisicaoEntrada;

                else if (opcaoPrincipalEscolhida == '6')
                    tela = telaRequisicaoSaida;

                char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);
            }
        }
    }
}