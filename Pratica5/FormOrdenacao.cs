using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Pratica5
{
    public partial class FormOrdenacao : Form
    {
        int[] vet = new int[500]; // vetor interno para a animação

        public FormOrdenacao()
        {
            InitializeComponent();
            panel.Paint += new PaintEventHandler(panel_Paint);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel, new object[] { true });
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < vet.Length; i++)
            {
                e.Graphics.DrawLine(Pens.Brown, i, 499, i, 499 - vet[i]);
            }
        }

        public bool selectOrdemVisualization(int index, Action a)
        {
            vet = new int[500];
            switch (index)
            {
                case 0:
                    Preenchimento.Aleatorio(vet, 500);
                    break;
                case 1:
                    Preenchimento.Crescente(vet);
                    break;
                case 2:
                    Preenchimento.Decrescente(vet);
                    break;
                default:
                    break;
            }
            a();
            return true;
        }

        private void bolhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visualizacao visualizacao = new Visualizacao((int i) => selectOrdemVisualization(i, () => iniciaAnimacao(() => OrdenacaoGrafica.Bolha(vet, panel))));
            visualizacao.Show();
        }

        // TODO: animação e estatísticas dos demais métodos de ordenação

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
                "Prática 5 2022/1 - Métodos de Ordenação\n\n" +
                "Desenvolvido por:\n72200456 - Anderson Ribeiro Lopes\n" +
                "Prof. Virgílio Borges de Oliveira\n\n" +
                "Algoritmos e Estruturas de Dados\n" +
                "Faculdade COTEMIG\n" +
                "Apenas para fins didáticos.",
                "Sobre o trabalho...",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void iniciaAnimacao(Action a)
        {
            if (bgw.IsBusy != true)
            {
                bgw.RunWorkerAsync(a);
            }
            else
            {
                MessageBox.Show(this,
                   "Aguarde o fim da execução atual...",
                   "Prática 5 2022/1 - Métodos de Ordenação",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Action a = (Action)e.Argument;
            a();
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(this,
               "Animação concluída!",
               "Prática 5 2022/1 - Métodos de Ordenação",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void seleçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visualizacao visualizacao = new Visualizacao((int i) => selectOrdemVisualization(i, () => iniciaAnimacao(() => OrdenacaoGrafica.Selecao(vet, panel))));
            visualizacao.Show();
        }

        private void inserçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visualizacao visualizacao = new Visualizacao((int i) => selectOrdemVisualization(i, () => iniciaAnimacao(() => OrdenacaoGrafica.Insercao(vet, panel))));
            visualizacao.Show();
        }

        private void shellsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visualizacao visualizacao = new Visualizacao((int i) => selectOrdemVisualization(i, () => iniciaAnimacao(() => OrdenacaoGrafica.ShellSort(vet, panel))));
            visualizacao.Show();
        }

        private void heapsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visualizacao visualizacao = new Visualizacao((int i) => selectOrdemVisualization(i, () => iniciaAnimacao(() => OrdenacaoGrafica.HeapSort(vet, panel))));
            visualizacao.Show();
        }

        private void quicksortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visualizacao visualizacao = new Visualizacao((int i) => selectOrdemVisualization(i, () => iniciaAnimacao(() => OrdenacaoGrafica.QuickSort(vet, panel))));
            visualizacao.Show();
        }

        private void mergesortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visualizacao visualizacao = new Visualizacao((int i) => selectOrdemVisualization(i, () => iniciaAnimacao(() => OrdenacaoGrafica.MergeSort(vet, panel))));
            visualizacao.Show();
        }

        public bool selectEstatistica(int ordemIndex, int sizeIndex, string metodo, Action a)
        {
            int size = 10000;
            string ordem = "Aleatoria";
            switch (sizeIndex)
            {
                case 0:
                    vet = new int[size];
                    break;
                case 1:
                    size = 50000;
                    vet = new int[size];
                    break;
                case 2:
                    size = 100000;
                    vet = new int[size];
                    break;
                case 3:
                    size = 500000;
                    vet = new int[size];
                    break;
                default:
                    break;
            }
            switch (ordemIndex)
            {
                case 0:
                    Preenchimento.Aleatorio(vet, 500);
                    break;
                case 1:
                    metodo = "Crescente";
                    Preenchimento.Crescente(vet);
                    break;
                case 2:
                    metodo = "Decrescente";
                    Preenchimento.Decrescente(vet);
                    break;
                default:
                    break;
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            a();
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: " + size.ToString() +
                  "\nOrdenação inicial: " + ordem +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t,
                  "Estatísticas do Método " + metodo,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            return true;
        }

        private void bolhaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Estatistica estatistica = new Estatistica((ordem, size) => selectEstatistica(ordem, size, "Bolha", () => OrdenacaoEstatistica.Bolha(vet)));
            estatistica.Show();
        }

        private void inserçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Estatistica estatistica = new Estatistica((ordem, size) => selectEstatistica(ordem, size, "Inserção", () => OrdenacaoEstatistica.Insercao(vet)));
            estatistica.Show();
        }

        private void seleçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Estatistica estatistica = new Estatistica((ordem, size) => selectEstatistica(ordem, size, "SeleçãoSort", () => OrdenacaoEstatistica.Selecao(vet)));
            estatistica.Show();
        }

        private void shellsortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Estatistica estatistica = new Estatistica((ordem, size) => selectEstatistica(ordem, size, "ShellSort", () => OrdenacaoEstatistica.ShellSort(vet)));
            estatistica.Show();
        }

        private void heapsortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Estatistica estatistica = new Estatistica((ordem, size) => selectEstatistica(ordem, size, "HeapSort", () => OrdenacaoEstatistica.HeapSort(vet)));
            estatistica.Show();
        }

        private void quicksortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Estatistica estatistica = new Estatistica((ordem, size) => selectEstatistica(ordem, size, "QuickSort", () => OrdenacaoEstatistica.QuickSort(vet)));
            estatistica.Show();
        }

        private void mergesortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Estatistica estatistica = new Estatistica((ordem, size) => selectEstatistica(ordem, size, "MergeSort", () => OrdenacaoEstatistica.MergeSort(vet)));
            estatistica.Show();
        }
    }
}
