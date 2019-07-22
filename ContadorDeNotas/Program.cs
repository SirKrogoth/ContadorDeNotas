using System;
using System.Collections.Generic;
using ContadorDeNotas.Negocio;
using ContadorDeNotas.Validacao;

namespace ContadorDeNotas
{
    class Program
    {
        static void Main(string[] args)
        {
            BancoNegocio bancoNegocio = new BancoNegocio();
            BancoValidacao bancoValidacao = new BancoValidacao();
            IEnumerator<int> cedulasDisponiveisParaSaque;

            do
            {
                Console.Clear();

                //Questiona usuário quanto ao número de notas à serem sacadas do caixa eletrônico
                Console.Write("Informe o valor que deseja sacar: ");
                var retorno = Console.ReadLine();                

                int valorParaSaque;

                cedulasDisponiveisParaSaque = bancoNegocio.GerarNotasDisponiveisEmTerminal();

                //Caso o valor apresentado seja válido
                if (int.TryParse(retorno, out valorParaSaque))
                {
                    valorParaSaque = Convert.ToInt32(retorno);                    

                    bool analiseCedulas = bancoValidacao.VerificarCedulasDisponiveis(valorParaSaque, cedulasDisponiveisParaSaque);

                    if (analiseCedulas == true)
                    {
                        var lista = bancoNegocio.SacarNotasCliente(valorParaSaque, cedulasDisponiveisParaSaque);

                        Console.WriteLine($"Valor para saque é de: R$ {valorParaSaque},00");

                        foreach (var item in lista)
                        {
                            Console.WriteLine($"R$ {item},00");
                        }
                    }
                    else
                    {
                        //Sistema irá entrar nessa condição caso o usuário selecione um valor que não é válido conforme notas
                        //ex. 815, 15, 912, 12, 31
                        Console.Clear();                        
                        ExibirRetornoDeValorInvalido(valorParaSaque.ToString(), cedulasDisponiveisParaSaque);
                    }                    
                }
                else
                {
                    //Sistema irá entrar nessa condição caso o usuário selecione um valor que não seja padrão para o tipo de nota informado
                    //ex. 10,90, 10.90, 1.99, 20.00, 20,00
                    ExibirRetornoDeValorInvalido(retorno, cedulasDisponiveisParaSaque);
                }

                //Verifica se usuário deseja realizar novo saque
                Console.Write("Precione ENTER para sair, ou aperte qualquer tecla para realizar novo saque...");
                //novoSaque = Console.ReadLine();
            } while (Console.ReadKey().Key != ConsoleKey.Enter);            
        }
        public static void ExibirRetornoDeValorInvalido(string valorParaSaque, IEnumerator<int> cedulasDisponiveisParaSaque)
        {
            Console.WriteLine($"O valor solicitado de R$ {valorParaSaque}, não é válido neste terminal.");
            Console.WriteLine($"Este terminal trabalha apenas com notas abaixo: ");

            while (cedulasDisponiveisParaSaque.MoveNext())
            {
                var item = cedulasDisponiveisParaSaque.Current;
                Console.WriteLine($"R$ {item},00");
            }
        }
    }
}