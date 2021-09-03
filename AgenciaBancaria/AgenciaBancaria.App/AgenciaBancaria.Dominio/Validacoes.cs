using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public static class Validacoes  //eh preciso criar uma classe static para funcionar esse tipo de metodo
    {
        public static string ValidaStringVazia(this string text)  //this faz o metodo ser de extencao
        {
            return string.IsNullOrWhiteSpace(text) ? throw new Exception("Propriedade precisa ser preenchida") : text;
        }
    }
}
