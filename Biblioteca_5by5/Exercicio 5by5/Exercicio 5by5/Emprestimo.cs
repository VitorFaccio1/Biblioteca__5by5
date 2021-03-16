using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_5by5
{
    public class Emprestimo
    {
        //DEFININDO ATRIBUTOS
        public long IdCliente { get; set; }

        public long NumeroTombo { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataDevolucao { get; set; }

        public int StatusEmprestimos { get; set; }

        public override string ToString()
        {
            return $"-----DADOS EMPRESTIMOS-----\nId do cliente: {IdCliente}\nNumero tombo do livro: {NumeroTombo}\nData de empréstimo: {DataEmprestimo}\nData devolução: {DataDevolucao}";
        }
    }
}
