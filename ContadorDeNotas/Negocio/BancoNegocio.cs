using System.Collections.Generic;


namespace ContadorDeNotas.Negocio
{
    public class BancoNegocio
    {
        public IEnumerator<int> GerarNotasDisponiveisEmTerminal()
        {
            var lista = new List<int>();

            lista.Add(100);
            lista.Add(50);
            lista.Add(20);
            lista.Add(10);

            return lista.GetEnumerator();
        }

        public List<int> SacarNotasCliente(int valorParaSaque, IEnumerator<int> cedulasDisponiveisParaSaque)
        {
            List<int> notasParaSaque = new List<int>();

            while (cedulasDisponiveisParaSaque.MoveNext())
            {
                var nota = cedulasDisponiveisParaSaque.Current;
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

            cedulasDisponiveisParaSaque.Reset();

            return notasParaSaque;

        }
    }
}