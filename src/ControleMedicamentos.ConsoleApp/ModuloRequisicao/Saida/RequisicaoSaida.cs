using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Saida
{
    internal class RequisicaoSaida : EntidadeBase
    {

        public Medicamento Medicamento { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeRetirada { get; set; }

        public RequisicaoSaida(Medicamento medicamentoSelecionado, Paciente pacienteSelecionado, int quantidade)
        {
            Medicamento = medicamentoSelecionado;
            Paciente = pacienteSelecionado;

            DataRequisicao = DateTime.Now;
            QuantidadeRetirada = quantidade;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (Medicamento == null)
                erros.Add("O medicamento precisa ser preenchido");

            if (Paciente == null)
                erros.Add("O paciente precisa ser informado");

            if (QuantidadeRetirada < 1)
                erros.Add("Por favor informe uma quantidade válida");

            return erros;
        }

        public bool RetirarMedicamento()
        {
            if (Medicamento.Quantidade < QuantidadeRetirada)
                return false;

            Medicamento.Quantidade -= QuantidadeRetirada;
            return true;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            RequisicaoSaida novasInformacoes = (RequisicaoSaida)novoRegistro;

            this.Medicamento = novasInformacoes.Medicamento;
            this.Paciente = novasInformacoes.Paciente;
            this.DataRequisicao = novasInformacoes.DataRequisicao;
            this.QuantidadeRetirada = novasInformacoes.QuantidadeRetirada;
        }
    }
}