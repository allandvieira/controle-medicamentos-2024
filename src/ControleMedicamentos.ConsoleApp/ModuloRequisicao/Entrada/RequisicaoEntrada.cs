using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada
{
    internal class RequisicaoEntrada : EntidadeBase
    {
        public Medicamento Medicamento { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeRequisitada { get; set; }

        public RequisicaoEntrada(Medicamento medicamentoSelecionado, Funcionario funcionarioSelecionado, int quantidade)
        {
            Medicamento = medicamentoSelecionado;
            Funcionario = funcionarioSelecionado;
            QuantidadeRequisitada = quantidade;

            DataRequisicao = DateTime.Now;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (Medicamento == null)
                erros.Add("O medicamento precisa ser preenchido");

            if (Funcionario == null)
                erros.Add("O funcionário cadastrante precisa ser informado");

            if (QuantidadeRequisitada < 1)
                erros.Add("Por favor informe uma quantidade válida");

            return erros;
        }

        public void ReporMedicamento()
        {
            Medicamento.Quantidade += QuantidadeRequisitada;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            RequisicaoEntrada novasInformacoes = (RequisicaoEntrada)novoRegistro;

            this.Medicamento = novasInformacoes.Medicamento;
            this.Funcionario = novasInformacoes.Funcionario;
            this.DataRequisicao = novasInformacoes.DataRequisicao;
            this.QuantidadeRequisitada = novasInformacoes.QuantidadeRequisitada;
        }
    }
}