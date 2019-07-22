using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContadorDeNotas.Negocio;
using System.Threading.Tasks;

namespace ContadorDeNotas.Validacao
{
    public class BancoValidacao
    {
        public bool VerificarCedulasDisponiveis(int valorParaSaque, IEnumerator<int> cedulasDisponiveisParaSaque)
        {
            BancoNegocio bancoNegocio = new BancoNegocio();

            while (cedulasDisponiveisParaSaque.MoveNext())
            {
                var nota = cedulasDisponiveisParaSaque.Current;
                int aux = valorParaSaque / nota;
                valorParaSaque -= aux * nota;
            }

            cedulasDisponiveisParaSaque.Reset();

            if (valorParaSaque != 0)
                return false;
            else
                return true;
        }
    }
}
