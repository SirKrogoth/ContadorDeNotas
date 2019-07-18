using System.Collections.Generic;


namespace ContadorDeNotas.Negocio
{
    public class BancoNegocio
    {
        public List<int> GerarNotasDisponiveisEmTerminal()
        {
            var lista = new List<int>();

            lista.Add(100);
            lista.Add(50);
            lista.Add(20);
            lista.Add(10);

            return lista;
        }

        public List<int> SacarNotasCliente(int valorParaSaque)
        {
            var listaNotasCaixaEletronico = GerarNotasDisponiveisEmTerminal();
            List<int> notasParaSaque = new List<int>();

            foreach(int nota in listaNotasCaixaEletronico)
            {
                int aux = valorParaSaque / nota;
                valorParaSaque -= aux * nota;

                if (aux > 0)
                {                    
                    for (int i = 0; i < aux; i++)
                    {
                        notasParaSaque.Add(nota);
                    }
                }
            }

            return notasParaSaque;

        }
    }
}