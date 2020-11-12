using ByteBank.Core.Model;
using ByteBank.Core.Repository;
using ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByteBank.View
{
    public partial class Form1 : Form
    {

        private readonly ContaClienteRepository r_Repository;
        private readonly ContaClienteService r_Servico;
        private CancellationTokenSource _cts;

        public Form1()
        {
            InitializeComponent();

            r_Repository = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private async void BtnProcessar_Click(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            BtnProcessar.Enabled = false;
            BtnCancelar.Enabled = true;
            var contas = r_Repository.GetContaClientes();

            PsgProgresso.Maximum = contas.Count();

            LimparView();

            var inicio = DateTime.Now;

            var progress = new Progress<string>(srt =>
            {
                PsgProgresso.Value++;
                ListResultados.Items.Add(srt);
            });

            try
            {
                var resultado = await ConsolidarContas(contas, progress, _cts.Token);
                var fim = DateTime.Now;
                AtualizarView(resultado.ToList(), fim - inicio);
            }
            catch (OperationCanceledException)
            {
                TxtTempo.Text = "Operação cancelada pelo usuário!";
            }
            finally
            {
                BtnProcessar.Enabled = true;
                BtnCancelar.Enabled = false;
            }
        }

        private async Task<string[]> ConsolidarContas(IEnumerable<ContaCliente> contas, IProgress<string> reportadorDeProgresso, CancellationToken ct)
        {
            var tasks = contas.Select(conta =>
                Task.Factory.StartNew(() =>
                {
                    ct.ThrowIfCancellationRequested();
                    var result = r_Servico.ConsolidarMovimentacoes(conta, ct);
                    reportadorDeProgresso.Report(result);
                    ct.ThrowIfCancellationRequested();
                    return result;
                }, ct)
            );
            return await Task.WhenAll(tasks);
        }

        private void AtualizarView(List<string> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{elapsedTime.Seconds}.{elapsedTime.Milliseconds} segundos!";
            var message = $"Processamento de  {result.Count} clientes em {tempoDecorrido}";
            TxtTempo.Text = message;
        }

        private void LimparView()
        {
            ListResultados.Items.Clear();
            TxtTempo.Text = string.Empty;
            PsgProgresso.Value = 0;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            BtnCancelar.Enabled = false;
            _cts.Cancel();
        }
    }
}
