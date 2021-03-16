using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_5by5
{
    public class Endereco
    {
        //DEFININDO ATRIBUTOS
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public override string ToString()
        {
            return $"\n-----ENDEREÇO DO CLIENTE-----\nLogradoro: {Logradouro}\nBairro: {Bairro}\nLocalidade: {Cidade}\nEstado: {Estado}\nCEP: {CEP}";
        }

    }
}
