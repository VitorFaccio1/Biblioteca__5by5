using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_5by5
{
    public class Cliente
    {
        //DEFININDO ATRIBUTOS
        public long IdCliente { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }    
        public string Telefone { get; set; }
        public Endereco endereco { get; set; }

        public override string ToString()
        {
            return $"\n-----DADOS DO CLIENTE-----\nId: {IdCliente}\nCpf: {Cpf}\nNome: {Nome}\nData de nascimento: {DataNascimento}\nTelefone: {Telefone}\n{endereco}";
        }
    }
}
