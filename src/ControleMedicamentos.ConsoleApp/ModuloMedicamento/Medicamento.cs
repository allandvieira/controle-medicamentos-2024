using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public Medicamento(string nome, string descricao, int quantidade)
        {
            Nome = nome;
            Descricao = descricao;
            Quantidade = quantidade;
        }

        public string[] Validar()
        {
            string[] erros = new string[2];
            int contadorErros = 0;

            if (Nome.Length < 3)
            {
                erros[0] = "O Nome do Medicamento precisa conter ao menos 3 caracteres";
                contadorErros++;
            }

            if (Descricao.Length < 3)
            {
                erros[1] = "A Descrição do Medicamento precisa conter ao menos 3 caracteres";
                contadorErros++;
            }

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}