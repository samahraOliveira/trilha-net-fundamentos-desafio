using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class VagaCarro : Vaga
    {
        public override bool VagasDisponiveis(List<string> veiculosCarro)
        {
            if (veiculosCarro.Count >= 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}