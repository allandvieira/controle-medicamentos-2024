using ControleMedicamentos.ConsoleApp.ModuloChamado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            TelaMedicamento telaMedicamento = new TelaMedicamento();
            TelaPaciente telaPaciente = new TelaPaciente();
            TelaChamado telaChamado = new TelaChamado(telaMedicamento, telaPaciente);

            telaMedicamento.SetTelaChamado(telaChamado);

            bool opcaoSairEscolhida = false;

            while (!opcaoSairEscolhida)
            {
                char opcaoPrincipalEscolhida = ApresentarMenuPrincipal();

                switch (opcaoPrincipalEscolhida)
                {
                    case '1':
                        char operacaoMedicamentoEscolhida = telaMedicamento.ApresentarMenu();

                        if (operacaoMedicamentoEscolhida == '1')
                            telaMedicamento.CadastrarMedicamento();

                        else if (operacaoMedicamentoEscolhida == '2')
                            telaMedicamento.EditarMedicamento();

                        else if (operacaoMedicamentoEscolhida == '3')
                            telaMedicamento.ExcluirMedicamento();

                        else if (operacaoMedicamentoEscolhida == '4')
                            telaMedicamento.VisualizarMedicamentos(true);

                        break;

                    case '2':
                        char operacaoChamadoEscolhida = telaChamado.ApresentarMenu();

                        if (operacaoChamadoEscolhida == '1')
                            telaChamado.CadastrarChamado();

                        else if (operacaoChamadoEscolhida == '2')
                            telaChamado.EditarChamado();

                        else if (operacaoChamadoEscolhida == '3')
                            telaChamado.ExcluirChamado();

                        else if (operacaoChamadoEscolhida == '4')
                            telaChamado.VisualizarChamados(true);

                        break;

                    case '3':
                        char operacaoPacienteEscolhida = telaPaciente.ApresentarMenu();

                        if (operacaoPacienteEscolhida == '1')
                            telaPaciente.CadastrarPaciente();

                        else if (operacaoPacienteEscolhida == '2')
                            telaPaciente.EditarPaciente();

                        else if (operacaoPacienteEscolhida == '3')
                            telaPaciente.ExcluirPaciente();

                        else if (operacaoPacienteEscolhida == '4')
                            telaPaciente.VisualizarPacientes(true);

                        break;

                    default: opcaoSairEscolhida = true; break;
                }
            }

            Console.ReadLine();
        }

        private static char ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Medicamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Gerência de Medicamentos");
            Console.WriteLine("2 - Gerência de Requisições");
            Console.WriteLine("3 - Gerência de Pacientes");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }

        public static void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }
    }
}