using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloChamado
{
    public class Requisicao : Entidade
    {
        public string Descricao { get; set; }
        public Medicamento MedicamentoRequisitado { get; set; }
        public Paciente PacienteSolicitante { get; set; }

        public Requisicao(string descricao, Medicamento medicamentoRequisitado, Paciente pacienteSolicitante)
        {
            Descricao = descricao;
            MedicamentoRequisitado = medicamentoRequisitado;
            PacienteSolicitante = pacienteSolicitante;
        }

        public string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Descricao))
            {
                erros[0] = "A descrição da requisição é obrigatória";
                contadorErros++;
            }

            if (MedicamentoRequisitado == null)
            {
                erros[1] = "O medicamento requisitado é obrigatório";
                contadorErros++;
            }

            if (PacienteSolicitante == null)
            {
                erros[2] = "O paciente solicitante é obrigatório";
                contadorErros++;
            }

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}