using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.Binding
{
    public class ActionBindInfo
    {
        public ActionBindInfo(MethodInfo methodInfo, IEnumerable<ArgumentoNomeValor> tuplasArgumantoNomeValor)
        {
            MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));
            if(tuplasArgumantoNomeValor == null)
                throw new ArgumentNullException(nameof(tuplasArgumantoNomeValor));

            TuplasArgumantoNomeValor = new ReadOnlyCollection<ArgumentoNomeValor>(tuplasArgumantoNomeValor.ToList());
        }

        public MethodInfo MethodInfo { get; set; }
        public IReadOnlyCollection<ArgumentoNomeValor> TuplasArgumantoNomeValor { get; private set; }


        public object Invoke(object controller)
        {
            var countParametros = TuplasArgumantoNomeValor.Count;
            var possuiArgumentos = countParametros > 0;

            if (!possuiArgumentos)
                return MethodInfo.Invoke(controller, new object[0]);

            var parametrosInvoke = new object[countParametros];
            var parametrosMethosInfo = MethodInfo.GetParameters();

            for(int i = 0; i < countParametros; i++)
            {
                var parametro = parametrosMethosInfo[i];
                var parametroNome = parametro.Name;

                var argumento = TuplasArgumantoNomeValor.Single(tupla => tupla.Nome == parametroNome);
                parametrosInvoke[i] = Convert.ChangeType(argumento.Valor, parametro.ParameterType);
            }

            return MethodInfo.Invoke(controller, parametrosInvoke);
        }

    }
}
