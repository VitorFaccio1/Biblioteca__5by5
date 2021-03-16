using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_5by5
{
    public class Livro
    {
        //DEFININDO ATRIBUTOS
        public long NumeroTombo { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Autor { get; set; }
        public override string ToString()
        {
            return $"Numero de tombo: {NumeroTombo}\nIsbn: {ISBN}\nTitulo: {Titulo}\nGenero: {Genero}\nData da publicação: {DataPublicacao}\nAutor: {Autor}\n";
        }
    }
}
