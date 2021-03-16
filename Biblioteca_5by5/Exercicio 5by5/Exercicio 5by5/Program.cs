using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_5by5
{
    class Program
    {
        static void Main(string[] args)
        {
            //INSTANCIANDO AS LISTAS
            List<Cliente> listaCliente = new List<Cliente>();
            List<Livro> listaLivros = new List<Livro>();
            List<Emprestimo> listaEmprestimo = new List<Emprestimo>();

            //LER ARQUIVOS PARA JA PUXAR OS DADOS PARA O PROGRAMA
            Arquivo.LerArquivoCliente(listaCliente);
            Arquivo.LerArquivoLivro(listaLivros);
            Arquivo.LerArquivoEmprestimo(listaEmprestimo);

            //CHAMADA DA FUNCAO MENU
            Console.Clear();
            Menu(listaCliente, listaLivros, listaEmprestimo);
        }

        static void Menu(List<Cliente> listaCliente, List<Livro> listaLivros, List<Emprestimo> listaEmprestimo)
        {
            /*FUNCAO CRIADA PARA CRIAR A INTERFACE DE MENU*/

            string escolha;
            do
            {
                Console.WriteLine("1)Cadastro de cliente\n2)Cadastro de livro\n3)Empréstimo de livro\n4)Devolução de livro" +
                    "\n5)Relatório de empréstimo e devoluções\n6)Sair");
                Console.Write("\nInforme o que você quer fazer: ");
                escolha = Console.ReadLine();
                Console.Clear();

                //SWITCH ATE A PESSOA APERTAR O 6 QUE É PRA SAIR
                switch (escolha)
                {
                    //FAZ O CADASTRO DOS CLIENTES CHAMA A FUNCAO DE CADASTRO DOS CLIENTE, ESCREVE NO ARQUIVO O CADASTRO E PUXA OS DADOS JA CADASTRADOS CASO ABRA O PROGRAMA
                    case "1":
                        Console.WriteLine("------CADASTRO DE CLIENTE------");
                        listaCliente = CadastrarCliente(listaCliente);
                        Arquivo.EscreverNoArquivoCliente(listaCliente);
                        Console.WriteLine("\nAPERTE QUALQUER TECLA PARA SAIR");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    //FAZ O CADASTRO DOS LIVROS CHAMA A FUNCAO DE CADASTRO DE LIVROS, ESCREVE NO ARQUIVO O CADASTRO E PUXA OS DADOS JA CADASTRADOS CASO ABRA O PROGRAMA
                    case "2":
                        Console.WriteLine("------CADASTRO DE LIVRO------");
                        listaLivros = CadastrarLivro(listaLivros);
                        Arquivo.EscreverNoArquivoLivro(listaLivros);
                        Console.WriteLine("\nAPERTE QUALQUER TECLA PARA SAIR");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    //FAZ O CADASTRO DOS EMPRESTIMOS CHAMA A FUNCAO DE CADASTRO DOS EMPRESTIMOS, ESCREVE NO ARQUIVO O CADASTRO E PUXA OS DADOS JA CADASTRADOS CASO ABRA O PROGRAMA
                    case "3":
                        Console.WriteLine("------CADASTRO DE EMPRESTIMOS------");
                        EmprestimoLivro(listaLivros, listaCliente, listaEmprestimo);
                        Console.WriteLine("\nAPERTE QUALQUER TECLA PARA SAIR");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    //FAZ O CADASTRO DAS DEVOLUÇÕES, CHAMA A FUNCAO DE CADASTRO DAS DEVOLUÇÕES, ESCREVE NO ARQUIVO O CADASTRO E PUXA OS DADOS JA CADASTRADOS CASO ABRA O PROGRAMA
                    case "4":
                        Console.WriteLine("------CADASTRO DE DEVOLUÇÕES------");
                        DevolucaoLivro(listaEmprestimo);
                        Console.WriteLine("\nAPERTE QUALQUER TECLA PARA SAIR");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    //FAZ RELATORIO E LE O RELATORIO JA ESCRITO CASO ABRA O PROGRAMA
                    case "5":
                        Console.WriteLine("------RELATÓRIOS------");
                        Relatorio(listaLivros, listaCliente, listaEmprestimo);
                        Console.WriteLine("\nAPERTE QUALQUER TECLA PARA SAIR");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (escolha != "6");
        }

        static List<Cliente> CadastrarCliente(List<Cliente> listaClientes)
        {
            //FUNCAO CRIADA PARA FAZER O CADASTRO DE CLIENTES
            string bairro, logradouro, cidade, estado, cep, telefone, nome, cpf;
            DateTime data;
            long id = 1;
            int contador = 0;

            Cliente client = new Cliente();
            Console.WriteLine("Informe o cpf do cliente: ");
            cpf = Console.ReadLine();

            //FOREACH PRA PASSAR POR TODA LISTA DE CLIENTES E VERIFICAR SE TEM UM CPF JA CADASTRADO!
            foreach (Cliente clienteCadastrado in listaClientes)
            {
                if (cpf == clienteCadastrado.Cpf)
                {
                    Console.WriteLine("\nEste cliente já possui cadastro!!!\n");
                    contador++;
                    break;
                }
            }

            if (contador == 0)
            {
                //SE NAO ENTRAR DENTRO DO IF DO FOR EACH, ACONTECE O CADASTRO DO CLIENTE
                Console.WriteLine("Informe o nome do cliente: ");
                nome = Console.ReadLine();
                do
                {
                    Console.WriteLine("Informe a data de nascimento do cliente (dd/mm/aaaa): ");
                    data = DateTime.Parse(Console.ReadLine());
                    if(data > DateTime.Now)
                    {
                        Console.WriteLine("Insira uma data menor do que a de hoje!");
                    }
                } while (data > DateTime.Now);
                Console.WriteLine("Informe o telefone do cliente: ");
                telefone = Console.ReadLine();
                Console.WriteLine("Informe o Logradouro do cliente: ");
                logradouro = Console.ReadLine();
                Console.WriteLine("Informe o bairro do cliente: ");
                bairro = Console.ReadLine();
                Console.WriteLine("Informe a cidade do cliente: ");
                cidade = Console.ReadLine();
                Console.WriteLine("Informe o estado do cliente: ");
                estado = Console.ReadLine();
                Console.WriteLine("Informe o Cep: ");
                cep = Console.ReadLine();
                Console.Clear();               

                client = new Cliente
                {
                    IdCliente = listaClientes.Last().IdCliente + 1,
                    Cpf = cpf,
                    Nome = nome,
                    DataNascimento = data,
                    Telefone = telefone,
                    endereco = new Endereco
                    {
                        Logradouro = logradouro,
                        Bairro = bairro,
                        Cidade = cidade,
                        Estado = estado,
                        CEP = cep,
                    }
                };

                listaClientes.Add(client);
                Console.WriteLine("O id do cliente é: " + client.IdCliente);
                Console.WriteLine("\nCliente cadastrado com sucesso!!!!!\n");
            }


            return listaClientes;

        }

        static List<Livro> CadastrarLivro(List<Livro> listaLivros)
        {
            //FUNCAO CRIADA PARA FAZER O CADASTRO DE LIVROS
            string isbn, titulo, genero, autor;
            int contador = 0;
            long numtombo = 1;
            DateTime dataPublicacao;


            Console.WriteLine("Informe o isbn do livro: "); isbn = Console.ReadLine();

            //FOREACH CRIADO PARA PERCORRER A LISTA DE LIVROS VERIFICANDO SE TEM ALGUM ISBN REPETIDO PARA NAO PODER CADASTRAR DNV!
            foreach (Livro livroCadastrado in listaLivros)
            {
                if (isbn == livroCadastrado.ISBN)
                {
                    Console.WriteLine("\nJá possuimos um livro com esse ISBN\n");
                    contador++;
                    break;
                }
            }

            //SE NAO ENTRAR DENTRO DO IF DO FOREACH ELE CADASTRA O RESTO DO LIVRO
            if (contador == 0)
            {
                Console.WriteLine("Informe o titulo do livro: "); titulo = Console.ReadLine();
                Console.WriteLine("Informe o genero do livro: "); genero = Console.ReadLine();
                do
                {
                    Console.WriteLine("Informe a data de publicação do livro(dd/mm/aaaa): "); dataPublicacao = DateTime.Parse(Console.ReadLine());
                    if (dataPublicacao > DateTime.Now)
                    {
                        Console.WriteLine("Insira uma data menor do que a de hoje!");
                    }
                } while (dataPublicacao > DateTime.Now);
                Console.WriteLine("Informe o autor do livro: "); autor = Console.ReadLine();
                Livro book = new Livro();

                

                book = new Livro
                {
                    NumeroTombo = listaLivros.Last().NumeroTombo + 1,
                    ISBN = isbn,
                    Titulo = titulo,
                    Genero = genero,
                    DataPublicacao = dataPublicacao,
                    Autor = autor,
                };

                listaLivros.Add(book);
                Console.WriteLine("\nO numero tombo deste livro é: " + book.NumeroTombo);
                Console.WriteLine("\nLivro cadastrado com sucesso!!!\n");
            }

            return listaLivros;
        }

        static void EmprestimoLivro(List<Livro> listaLivros, List<Cliente> listaClientes, List<Emprestimo> listaEmprestimos)
        {
            //FUNCAO CRIADA PARA FAZER OS CADASTRO DOS EMPRESTIMOS DOS LIVROS
            Livro livroencontrado = new Livro();
            Cliente clienteEncontrado = new Cliente();
            Emprestimo livroEmprestado = new Emprestimo();

            long NumTombo;
            int contador = 0;
            string escolha, cpf, respostaCadastro;
            DateTime dataDevolucao;

            //VERIFICANDO SE A LISTA DE LIVROS ESTA VAZIA
            if (listaLivros.Count == 0)
            {
                Console.WriteLine("\nCadastre livros primeiro antes de emprestá-los\n");
            }
            //SE NAO ESTIVER VAZIA ELE ENTRA NO ELSE
            else
            {
                Console.WriteLine("Informe o numero de tombo do livro: ");
                NumTombo = long.Parse(Console.ReadLine());

                //PERCORRENDO A LISTA PARA VER SE ACHA O LIVRO COM O NUMERO DE TOMBO DIGITADO E ARMAZENANDO NUMA VARIAVEL
                livroencontrado = listaLivros.Find(i => i.NumeroTombo == NumTombo);

                //VERIFICA SE TEM O LIVRO
                if (livroencontrado == null)
                {
                    Console.WriteLine("\nA biblioteca não possui esse livro!!!\n");
                }
                //SE TIVER ELE VEM PRO ELSE
                else
                {

                    Console.WriteLine("\n-----O livro foi encontrado-----\n" + livroencontrado.ToString());

                    //PERCORRE A LISTA DOS EMPRESTIMOS PARA VER SE O LIVRO JA ESTA SENDO EMPRESTADO OU NAO COM O NUMERO DE TOMBO DO LIVRO
                    livroEmprestado = listaEmprestimos.Find(x => x.NumeroTombo == NumTombo);

                    //FAZ A VERIFICACAO SE TIVER O LIVRO E SE ELE ESTIVER COM STATUS DE EMPRESTADO ENTRA NO IF
                    if (livroEmprestado != null && livroEmprestado.StatusEmprestimos == 1)
                    {
                        Console.WriteLine("\nO livro já esta sendo emprestado no momento!!!\n");
                        contador++;
                    }
                    else
                    {
                        //SE O CONTADOR FOR IGUAL A ZERO OQ SIGNFIICA QUE ELE NAO ESTA SENDO EMPRESTADO E QUE O LIVRO EXISTE ELE FAZ O RESTO DO PROCESSO
                        if (contador == 0)
                        {
                            Console.WriteLine("\nVocê deseja emprestar esse livro para qual cliente? Digite o cpf do cliente: ");
                            cpf = Console.ReadLine();

                            //PERCORRE A LISTA PROCURANDO PELO CPF DO CLIENTE QUE DESEJA O LIVRO
                            clienteEncontrado = listaClientes.Find(x => x.Cpf == cpf);

                            //VERIFICA SE O CLIENTE NAO FOI ENCONTRADO, SE ELE NAO FOI! CHAMAMOS A FUNCAO DE CADASTRO
                            if (clienteEncontrado == null)
                            {
                                Console.WriteLine("\nCliente não cadastrado!!!\n");
                                do
                                {
                                    Console.WriteLine("Deseja cadastrar esse cliente? s(sim) ou n(nao)");
                                    respostaCadastro = Console.ReadLine();
                                    if (respostaCadastro.ToLower() == "n")
                                    {
                                        break;
                                    }
                                } while (respostaCadastro.ToLower() != "s");                                
                                
                                if (respostaCadastro.ToLower() == "s")
                                {
                                    CadastrarCliente(listaClientes); //CHAMANDO FUNCAO DE CADASTRO
                                    Arquivo.EscreverNoArquivoCliente(listaClientes);//ESCREVENDO NO ARQUIVO DE CLIENTES O CLIENTE QUE ACABA DE SER CADASTRADO
                                    do
                                    {
                                        Console.WriteLine("\nDeseja realmente emprestar esse livro? s(sim) ou n(nao)");
                                        escolha = Console.ReadLine();
                                        if (escolha.ToLower() == "n")
                                        {
                                            break;
                                        }
                                    } while (escolha.ToLower() != "s");


                                    //VERIFICANDO SE A BIBLIOTECARIA REALMENTE DESEJA EMPRESTAR ESSE LIVRO
                                    if (escolha.ToLower() == "s")
                                    {

                                        do
                                        {
                                            Console.WriteLine("Informe a data de devolução (dd/mm/aaaa): "); dataDevolucao = DateTime.Parse(Console.ReadLine());
                                            if(dataDevolucao <= DateTime.Now)
                                            {
                                                Console.WriteLine("Informe uma data maior do que hoje!");
                                            }
                                        } while (dataDevolucao <= DateTime.Now);

                                        //INFORMA O ID DO CLIENTE E A DATA QUE ELE TEM QUE DEVOLVER

                                        livroEmprestado = new Emprestimo
                                        {
                                            IdCliente = clienteEncontrado.IdCliente,
                                            DataEmprestimo = DateTime.Now,
                                            DataDevolucao = dataDevolucao,
                                            NumeroTombo = NumTombo,
                                            StatusEmprestimos = 1
                                        };

                                        listaEmprestimos.Add(livroEmprestado);
                                        Arquivo.EscreverNoArquivoEmprestimo(listaEmprestimos); //ADICIONA NA LISTA DE EMPRESTIMO E ESCREVE NO ARQUIVO EMPRESTIMO
                                        Console.WriteLine("\nLivro emprestado com sucesso!!!\n");
                                    }
                                }
                            }
                            //SE EXISTIR O CLIENTE E NAO PRECISAR FAZER O CADASTRO ELE ENTRA AQUI
                            else
                            {
                                Console.WriteLine(clienteEncontrado.ToString());
                                do
                                {
                                    Console.WriteLine("\nDeseja realmente emprestar esse livro? s(sim) ou n(nao)");
                                    escolha = Console.ReadLine();
                                    if(escolha.ToLower() == "n")
                                    {
                                        break;
                                    }
                                } while (escolha.ToLower() != "s");

                                //VERIFICA SE REALEMNTE DESEJA EMRPESTAR O LIVRO
                                if (escolha.ToLower() == "s")
                                {
                                    do
                                    {
                                        Console.WriteLine("Informe a data de devolução(dd/mm/aaaa): "); dataDevolucao = DateTime.Parse(Console.ReadLine());
                                        if(dataDevolucao <= DateTime.Now)
                                        {
                                            Console.WriteLine("Informe uma data maior do que hoje!");
                                        }
                                    } while (dataDevolucao < DateTime.Now);

                                    //INFORMA O ID DO CLIENTE E INFORMA A DATA QUE ELE TEM QUE DEVOLVER O LIVRO

                                    livroEmprestado = new Emprestimo
                                    {
                                        IdCliente = clienteEncontrado.IdCliente,
                                        DataEmprestimo = DateTime.Now,
                                        DataDevolucao = dataDevolucao,
                                        NumeroTombo = NumTombo,
                                        StatusEmprestimos = 1,
                                    };

                                    listaEmprestimos.Add(livroEmprestado);
                                    Arquivo.EscreverNoArquivoEmprestimo(listaEmprestimos); //ADCIONA NA LISTA DE EMPRESTIMO E ESCREVE NO ARQUIVO
                                    Console.WriteLine("\nLivro emprestado com sucesso!!!\n");
                                }
                            }
                        }
                    }

                }

            }
        }

        static void DevolucaoLivro(List<Emprestimo> listaEmprestimos)
        {
            //DECLARACAO DE VARIAVEIS
            long numTombo;
            string resposta;
            int contador = 0;
            int saldoDevedor = 0;
            Emprestimo encontrado;

            //VERIFICA SE TEM ALGUM LIVRO SENDO EMPRESTADO PARA FAZER A DEVOLUÇÃO
            if (listaEmprestimos.Count == 0)
            {
                Console.WriteLine("\nNão tem nenhum livro emprestado ainda\n");
            }
            //SE TIVER ALGUM LIVRO EMPRESTADO ENTRA NO ELSE
            else
            {
                Console.WriteLine("\nQual livro o cliente quer devolver? Insira o numero de tombo do livro: \n");
                numTombo = long.Parse(Console.ReadLine());

                //PERCORRE A LISTA DE EMPRESTIMOS E ARMAZENA NA VARIAVEL ENCONTRADO CASO ACHE O LIVRO
                encontrado = listaEmprestimos.Find(x => x.NumeroTombo == numTombo);

                //VERFIFCA SE O LIVRO FOI ENCOTRADO
                if (encontrado == null)
                {
                    Console.WriteLine("\nNão possuimos esse livro emprestado!!!\n");
                }
                //SE O LIVRO FOI EMPRESTADO ENTRA NO ELSE
                else
                {
                    //MOSTRA OS DADOS DO LIVRO
                    Console.WriteLine(encontrado.ToString());

                    //PERCORRE A LISTA DE EMPRESTIMO E VERIFICA SE O LIVRO JA FOI DEVOLVIDO
                    foreach (Emprestimo emprestimoLivros in listaEmprestimos)
                    {
                        if (encontrado.StatusEmprestimos == 2)
                        {
                            Console.WriteLine("\nEsse livro já foi devolvido!!!\n");
                            contador++;
                            break;
                        }
                    }
                    //SE TEM O LIVRO NAO FOI DEVOLVIDO AINDA ELE ENTRA NESSE IF
                    if (contador == 0)
                    {
                        do
                        {
                            Console.WriteLine("\nTem certeza que deseja que o cliente deseja devolver? s(sim) ou n (não)");
                            resposta = Console.ReadLine();
                            if (resposta.ToLower() == "n")
                            {
                                break;
                            }
                        } while (resposta.ToLower() != "s");
                        

                        //VERIFICA SE O CLIENTE REALMENTE DESEJA DEVOLVER
                        if (resposta.ToLower() == "s")
                        {
                            //FAZ A SUBTRAÇÃO DA DATA DO SISTEMA COM A DATA DEFINIDA PARA DEVOLUÇÃO DO LIVRO, TRASNFORMA EM DIAS QUE PASSA SER INTEIRO E ARMAZENA
                            //NA VARIAVEL SALDO DEVEDOR
                            saldoDevedor = (int)DateTime.Now.Subtract(encontrado.DataDevolucao).TotalDays;
                            //VERIFICA SE A SUBTRACAO DE CIMA É MAIOR DO QUE ZERO PARA EFETUAR A MULTA E SE FOR ENTRA NO IF
                            if (saldoDevedor > 0)
                            {
                                Console.WriteLine("O cliente deve por atraso: R$" + saldoDevedor * 0.10);
                                //FAZ A CONTA DE 10 CENTAVOS POR CADA DIA DE ATRASO E MOSTRA PRO USUARIO O VALOR FINAL QUE ELE DEVE

                            }
                            encontrado.StatusEmprestimos = 2;
                            encontrado.DataDevolucao = DateTime.Now; //ALTERA O STATUS DO LIVRO PARA 2(DEVOLVIDO) E COLOCA A DATA DE DEVOLUÇÃO IGUAL A DO SISTEMA

                            //ESCREVE NO ARQUIVO DE EMPRESTIMO
                            Arquivo.EscreverNoArquivoEmprestimo(listaEmprestimos);

                            Console.WriteLine("\nLivro devolvido com sucesso\n");
                        }
                    }
                }

            }
        }

        static void Relatorio(List<Livro> listaLivros, List<Cliente> listaClientes, List<Emprestimo> listaEmprestimos)
        {
            foreach (Emprestimo itemEmprestimo in listaEmprestimos)
            {
                //PERCORRE A LISTA DE CLIENTES E COLOCA O CPF COMO PRIMEIRO DADO
                //É USADO O WRITE PARA NAO QUEBRAR A LINHA, POIS AINDA NAO ACABOU DE INSERIR OS DADOS DO RELATORIO
                foreach (Cliente itemCliente in listaClientes)
                {
                    //VERIFICA SE O ID DO CLIENTE É O MESMO DO EMPRESTIMO PARA NAO DAR ERRO
                    if (itemCliente.IdCliente == itemEmprestimo.IdCliente)
                    {
                        Console.Write("CPF do cliente: " + itemCliente.Cpf + "\n");
                    }
                }
                //PERCORRE A LISTA DE LIVROS E COLOCA O TITULO COMO SEGUNDO DADO
                //É USADO O WRITE PARA NAO QUEBRAR A LINHA, POIS AINDA NAO ACABOU DE INSERIR OS DADOS DO RELATORIO
                foreach (Livro itemLivro in listaLivros)
                {
                    //VERIFICA SE O NUMERO DE TOMBO DO LIVRO É IGUAL DO IMPRESTIMO PARA NAO DAR ERRO
                    if (itemLivro.NumeroTombo == itemEmprestimo.NumeroTombo)
                    {
                        Console.Write("Titulo: " + itemLivro.Titulo + "\n");
                    }
                }
                //É USADO O WRITLELINE PORQUE DEPOIS DESSES DADOS QUE SÃO OS DADOS FINAIS DA PRIMEIRA COLUNA ELE QUEBRE A LINHA
                //COLOCA OS ITENS ABAIXO COMO DADOS DA PRIMEIRA COLUNA
                Console.WriteLine("Status do emprestimo: " + itemEmprestimo.StatusEmprestimos + "\n" + "Data do Empréstimo: " + itemEmprestimo.DataEmprestimo.ToString("dd/MM/yyyy")
                    + "\n" + "Data de devolução: " + itemEmprestimo.DataDevolucao.ToString("dd/MM/yyyy") + "\n--------------------------------");

            }
        }
    }

}