using ByteBank.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ByteBank.Core.Service
{
    public class ContaClienteService
    {
        public string ConsolidarMovimentacoes(ContaCliente conta)
        {
            return ConsolidarMovimentacoes(conta, CancellationToken.None);
        }

        public string ConsolidarMovimentacoes(ContaCliente conta, CancellationToken ct)
        {
            var soma = 0m;

            foreach (var movimento in conta.Movimentacoes)
            {
                soma += movimento.Valor * FatorDeMultiplicacao(movimento.Data);
                ct.ThrowIfCancellationRequested();
            }

            ct.ThrowIfCancellationRequested();
            AtualizarInvestimentos(conta);

            return $"Cliente {conta.NomeCliente} tem saldo atualizado de R${soma.ToString("#00.00")}";
        }

        private static void AtualizarInvestimentos(ContaCliente conta)
        {
            const decimal CTE_BONIFICACAO_MOV = 1m / (10m * 5m);
            conta.Investimento *= CTE_BONIFICACAO_MOV;
        }

        private static decimal FatorDeMultiplicacao(DateTime dataMovimento)
        {
            const decimal CTE_FATOR = 1.00000000005m;

            var diasCorridosDesdeDataMovimento = (dataMovimento - new DateTime(1900, 1, 1)).Days;
            var resultado = 1m;

            for (int i = 0; i < diasCorridosDesdeDataMovimento * 2; i++)
                resultado *= CTE_FATOR;

            return resultado;
        }
    }
}
