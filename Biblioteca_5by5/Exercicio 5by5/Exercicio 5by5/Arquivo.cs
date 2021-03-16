using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Exercicio_5by5
{
    public class Arquivo
    {
        public static void EscreverNoArquivoLivro(List<Livro> livros)
        {
            //FUNÇAO CRIADA PARA ESCREVER NO ARQUIVO DADOS DOS LIVROS CADASTRADOS
            using (StreamWriter escreverLivros = new StreamWriter("LIVRO.CSV"))
            {
                escreverLivros.WriteLine("Numero Tombo;ISBN;Titulo;Genero;Data de publicacao;Autor");
                //percorre a lista de livros escrevendo os dados que estao abaixo separados por ;, pois ai o excel muda de linha dps de um ;
                //e é writeLine para quebrar a coluna assim que concluir e ir pra proxima
                foreach (Livro item in livros)
                {
                    escreverLivros.WriteLine(item.NumeroTombo + ";" + item.ISBN + ";" + item.Titulo + ";" + item.Genero + ";" + item.DataPublicacao.ToString("dd/MM/yyyy") + ";" + item.Autor);
                }
            }
        }

        public static void LerArquivoLivro(List<Livro> livros)
        {
            //FUNCAO CRIADA PARA LER O ARQUIVO QUE ARMAZENA OS DADOS DOS LIVROS CADASTRADOS            
            //VERIFICA SE O ARQUIVO EXISTE
            if (File.Exists("LIVRO.CSV"))
            {
                using (StreamReader lerLivros = new StreamReader("LIVRO.CSV"))
                {
                    Livro livro;
                    //PERCORRE O ARQUIVO ATE O FINAL 
                    while (!lerLivros.EndOfStream)
                    {
                        //ARMAZENA OS DADOS DO ARQUIVO NO ARRAY DE STRING LINHA[POSICAO]
                        string[] linha = lerLivros.ReadLine().Split(';');

                        if(linha[0] != "Numero Tombo")
                        {                            
                             Console.WriteLine();

                             livro = new Livro
                             {                            
                                NumeroTombo = long.Parse(linha[0]),
                                ISBN = linha[1],
                                Titulo = linha[2],
                                Genero = linha[3],
                                DataPublicacao = DateTime.Parse(linha[4]),
                                Autor = linha[5]
                             };

                            livros.Add(livro); //ADICIONA NA LISTA DOS LIVROS
                        }        
                        
                       
                    }
                }
            }            
        }        

        public static void EscreverNoArquivoCliente(List<Cliente> clientes)
        {
            //FUNCAO CRIADA PARA ESCREVER OS CLIENTES NO ARQUVIVO DOS CLIENTES
            using (StreamWriter escreverClientesArquivo = new StreamWriter("CLIENTE.CSV"))
            {
                escreverClientesArquivo.WriteLine("Id do Cliente;CPF;Nome;Data de nascimento;Telefone;Logradouro;Bairro;Cidade;Estado;CEP");
                //percorre as lista de clientes adicionando os valores abaixo separados por ;, pois o excel faz com que mude de linha dps de um ;
                //e quebra a coluna dps que acaba pra ir para os proximos dados
                foreach (Cliente item in clientes)
                {
                    escreverClientesArquivo.WriteLine(item.IdCliente + ";" + item.Cpf + ";" + item.Nome + ";" + item.DataNascimento.ToString("dd/MM/yyyy")
                        + ";" + item.Telefone + ";" + item.endereco.Logradouro + ";" + item.endereco.Bairro + ";" + item.endereco.Cidade
                        + ";" + item.endereco.Estado + ";" + item.endereco.CEP);
                }
            }
        }

        public static void LerArquivoCliente(List<Cliente> clientes)
        {
            //VERIFICA SE EXISTE O ARQUIVO CLIENTE.CSV
            if (File.Exists("CLIENTE.CSV"))
            {
                using (StreamReader lerArquivosClientes = new StreamReader("CLIENTE.CSV"))
                {
                    Cliente cliente;
                    
                    //PERCORRE O ARQUVIO CLIENTE ATE O FIM 
                    while (!lerArquivosClientes.EndOfStream)
                    {
                        string[] linha = lerArquivosClientes.ReadLine().Split(';');

                        //ADICIONA AS INFORMAÇOES DO ARQUIVO DE DETERMINADA POSIÇÃO NA POSICÃO ESPECIFICADA DO ARRAY LINHA

                        if(linha[0] != "Id do Cliente")
                        {
                            Console.WriteLine();

                            cliente = new Cliente
                            {
                                IdCliente = long.Parse(linha[0]),
                                Cpf = linha[1],
                                Nome = linha[2],
                                DataNascimento = DateTime.Parse(linha[3]),
                                Telefone = linha[4],

                                endereco = new Endereco
                                {
                                    Logradouro = linha[5],
                                    Bairro = linha[6],
                                    Cidade = linha[7],
                                    Estado = linha[8],
                                    CEP = linha[9]
                                }
                            };
                            clientes.Add(cliente); //ADICIONA NA LISTA CLIENTE 
                        }                        
                    }
                }

            }
        }       

        public static void EscreverNoArquivoEmprestimo(List<Emprestimo> listaEmprestimo)
        {
            //FUNCAO CRIADA PARA ESCREVER OS DADOS DE EMPRESTISMO DE LIVROS
            using (StreamWriter escreverEmprestimo = new StreamWriter("EMPRESTIMO.CSV"))
            {
                escreverEmprestimo.WriteLine("Id do Cliente;Numero de tombo do livro;Data do emprestimo do livro;Data de devolucao do livro;Status");
                //PERCORRE A LISTA EMPRESTIMOS ESCREVENDO OS DADOS ABAIXO SEPARDOS POR ; PARA O EXCEL QUEBRAR DE LINHA
                //É WRITE LINE PARA QUEBRAR A COLUNA ASSIM QUE ACABAR DE INSERIR OS DADOS, PARA ASSIM VIR NOVOS!
                foreach (Emprestimo item in listaEmprestimo)
                {
                    escreverEmprestimo.WriteLine(item.IdCliente + ";" + item.NumeroTombo + ";" + item.DataEmprestimo.ToString("dd/MM/yyyy") + ";" + item.DataDevolucao.ToString("dd/MM/yyyy") + ";" + item.StatusEmprestimos);
                }
            }
        }        

        public static void LerArquivoEmprestimo(List<Emprestimo> listaEmprestimo)
        {
            if(File.Exists("EMPRESTIMO.CSV"))
            {
                using (StreamReader lerArquivosEmprestimo = new StreamReader("EMPRESTIMO.CSV"))
                {
                    Emprestimo emprestimo;


                    while (!lerArquivosEmprestimo.EndOfStream)
                    {
                        string[] linha = lerArquivosEmprestimo.ReadLine().Split(';');

                        if(linha[0] != "Id do Cliente")
                        {
                            Console.WriteLine();
                            emprestimo = new Emprestimo
                            {
                                IdCliente = long.Parse(linha[0]),
                                NumeroTombo = long.Parse(linha[1]),
                                DataEmprestimo = DateTime.Parse(linha[2]),
                                DataDevolucao = DateTime.Parse(linha[3]),
                                StatusEmprestimos = int.Parse(linha[4]),
                            };
                            listaEmprestimo.Add(emprestimo);
                        }                       
                    }
                }
            }
            
        }        
        
    }
}
