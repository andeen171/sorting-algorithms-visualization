using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Pratica5 {
    public partial class FormOrdenacao : Form {
        int[] vet = new int[1000]; // vetor interno para a animação

        public FormOrdenacao() {
            InitializeComponent();
            panel.Paint += new PaintEventHandler(panel_Paint);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel, new object[] { true });
        }

        private void panel_Paint(object sender, PaintEventArgs e) {
            for (int i = 0; i < vet.Length; i++) {
                e.Graphics.DrawLine(Pens.Brown, i, 299, i, 299 - vet[i]);
            }
        }

        private void bolhaToolStripMenuItem_Click(object sender, EventArgs e) {
            iniciaAnimacao(() => OrdenacaoGrafica.Bolha(vet, panel));
        }

        // TODO: animação e estatísticas dos demais métodos de ordenação

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e) {
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

        private void iniciaAnimacao(Action a) {
            if (bgw.IsBusy != true) {
                Preenchimento.Aleatorio(vet, 300);
                bgw.RunWorkerAsync(a);
            }
            else {
                MessageBox.Show(this,
                   "Aguarde o fim da execução atual...",
                   "Prática 5 2022/1 - Métodos de Ordenação",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e) {
            Action a = (Action)e.Argument;
            a();
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            MessageBox.Show(this,
               "Animação concluída!",
               "Prática 5 2022/1 - Métodos de Ordenação",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void seleçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Selecao(vet, panel));
        }

        private void inserçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Insercao(vet, panel));
        }

        private void shellsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.ShellSort(vet, panel));
        }

        private void heapsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.HeapSort(vet, panel));
        }

        private void quicksortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.QuickSort(vet, panel));
        }

        private void mergesortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.MergeSort(vet, panel));
        }

        private void bolhaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

            int[] vetor = new int[10000]; // TODO (tamanho deverá ser escolhido pelo usuário)
            Preenchimento.Aleatorio(vetor, 1000); // TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.Bolha(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: 100000" +
                  "\nOrdenação inicial: Aleatorio" +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t,
                  "Estatísticas do Método Bolha",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void inserçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] vetor = new int[10000]; // TODO (tamanho deverá ser escolhido pelo usuário)
            Preenchimento.Aleatorio(vetor, 1000); // TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.Insercao(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: 10000" +
                  "\nOrdenação inicial: Aleatorio" +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t,
                  "Estatísticas do Método Inserção",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void seleçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] vetor = new int[10000]; // TODO (tamanho deverá ser escolhido pelo usuário)
            Preenchimento.Aleatorio(vetor, 1000); // TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.Selecao(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: 10000" +
                  "\nOrdenação inicial: Aleatorio" +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t,
                  "Estatísticas do Método Seleção",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void shellsortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] vetor = new int[10000]; // TODO (tamanho deverá ser escolhido pelo usuário)
            Preenchimento.Aleatorio(vetor, 1000); // TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.ShellSort(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: 10000" +
                  "\nOrdenação inicial: Aleatorio" +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t,
                  "Estatísticas do Método Shellsort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void heapsortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] vetor = new int[10000]; // TODO (tamanho deverá ser escolhido pelo usuário)
            Preenchimento.Aleatorio(vetor, 1000); // TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.HeapSort(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: 10000" +
                  "\nOrdenação inicial: Aleatorio" +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t,
                  "Estatísticas do Método HeapSort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void quicksortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] vetor = new int[10000]; // TODO (tamanho deverá ser escolhido pelo usuário)
            Preenchimento.Aleatorio(vetor, 1000); // TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.QuickSort(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: 10000" +
                  "\nOrdenação inicial: Aleatorio" +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t,
                  "Estatísticas do Método QuickSort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void mergesortToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int[] vetor = new int[10000]; // TODO (tamanho deverá ser escolhido pelo usuário)
            Preenchimento.Aleatorio(vetor, 1000); // TODO (preenchimento inicial deverá ser escolhido pelo usuário)
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // inicia cronômetro
            OrdenacaoEstatistica.MergeSort(vetor);
            stopwatch.Stop(); // interrompe cronômetro
            long elapsed_time = stopwatch.ElapsedMilliseconds; // calcula o tempo decorrido
            MessageBox.Show(this,
                  "Tamanho do vetor: 10000" +
                  "\nOrdenação inicial: Aleatorio" +
                  "\n\nTempo de execução: " + String.Format("{0:F4} seg", elapsed_time / 1000.0) +
                  "\nNº de comparações: " + OrdenacaoEstatistica.cont_c +
                  "\nNº de trocas: " + OrdenacaoEstatistica.cont_t,
                  "Estatísticas do Método MergeSort",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }
    }
}
