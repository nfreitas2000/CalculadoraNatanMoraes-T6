using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraNatanMoraes_T6
{
    public partial class Form1 : Form
    {
        enum Operacoes
        {
            soma,
            subtracao,
            multiplicacao,
            divisao,
            Nenhuma,
        }

        static Operacoes ultimaOperacao = Operacoes.Nenhuma;

        public Form1()
        {
            InitializeComponent();
        }

        //Tables de organização
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //Metodos
        private void FazerCalculo(Operacoes ultimaOperacao)
        {
            //Lista de números do tipo double (real)
            // Lista é um Vetor buffado
            List<double> ListaDeNumeros = new List<double>();
            switch (ultimaOperacao)
            {
                case Operacoes.soma:
                    ListaDeNumeros = textBoxDisplay.Text.Split('+').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (ListaDeNumeros[0] + ListaDeNumeros[1]).ToString();
                    break;
                case Operacoes.subtracao:
                    ListaDeNumeros = textBoxDisplay.Text.Split('-').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (ListaDeNumeros[0] - ListaDeNumeros[1]).ToString();
                    break;
                case Operacoes.multiplicacao:
                    ListaDeNumeros = textBoxDisplay.Text.Split('*').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (ListaDeNumeros[0] * ListaDeNumeros[1]).ToString();
                    break;
                case Operacoes.divisao:
                    ListaDeNumeros = textBoxDisplay.Text.Split('/').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (ListaDeNumeros[0] / ListaDeNumeros[1]).ToString();
                    break;
                case Operacoes.Nenhuma:
                    break;
                default:
                    break;
            }
        }

        //Botões de operadores
        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.divisao;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }
        private void buttonIgual_Click(object sender, EventArgs e)
        {
            if(ultimaOperacao != Operacoes.Nenhuma) 
            {
                FazerCalculo(ultimaOperacao);
            }
        }

        private void buttonSubtracaoSinal_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.subtracao;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonMultiplicacao_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.multiplicacao;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonSomaSinal_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.soma;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonPorcentagem_Click(object sender, EventArgs e)
        {

        }

        //Estruturas de Display
        private void textBoxDisplay_TextChanged(object sender, EventArgs e)
        {

        }


        //Botões de Interações
        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Clear();
            ultimaOperacao = Operacoes.Nenhuma;
        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
            if (textBoxDisplay.Text.Length > 0)
            {
                textBoxDisplay.Text = textBoxDisplay.Text.Remove(textBoxDisplay.Text.Length - 1, 1);
            }
        }

        private void buttonCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxDisplay.Text); 
        }

        //Botões de Digitos
        private void buttonNum_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma) 
            {
                textBoxDisplay.Clear();
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }
    }
}
