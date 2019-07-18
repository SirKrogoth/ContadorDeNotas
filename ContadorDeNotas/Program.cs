using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ContadorDeNotas.Negocio;

namespace ContadorDeNotas
{
    class Program
    {
        static void Main(string[] args)
        {
            int novoSaque = 1;
            BancoNegocio bancoNegocio = new BancoNegocio();

            do
            {
                //Questiona usuário quanto ao número de notas à serem sacadas do caixa eletrônico
                Console.Write("Informe o valor que deseja sacar: ");
                var valorParaSaque = Convert.ToInt32(Console.ReadLine());

                var lista = bancoNegocio.SacarNotasCliente(valorParaSaque);

                Console.Clear();
                Console.WriteLine("Realizando a contagem das cédulas...");
                Thread.Sleep(3000);

                Console.WriteLine($"Valor para saque é de: R$ {valorParaSaque}");
                foreach (var item in lista)
                {
                    Console.WriteLine(item);
                }

                //Verifica se usuário deseja realizar novo saque
                Console.Write("Deseja realizar um novo saque? {1} Sim | {2} Não : ");
                novoSaque = Convert.ToInt32(Console.ReadLine());

            } while (novoSaque == 1);
        }
    }
}
