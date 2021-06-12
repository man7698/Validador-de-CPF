using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Validar_CPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };// primeiro vetor para 1º multiplicação
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };//segundo vetor para 2º multiplicação
            string CPF = txtvalor.Text;// recebe o cpf
            string auxCPF;
            string Digito;
            int soma;
            int resto;


            CPF = CPF.Trim();//remove todos espaçoes em branco se tiver, tanto no começo como no final
            CPF = CPF.Replace(".", "").Replace("-", "");//remove todos pontos ou traços e substitui por nada no lugar

            auxCPF = CPF.Substring(0, 9);//aux do cpf pega todos 9 primeiros digitos do valor digitado
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                //vai multiplicando e somando ao mesmo tempo para economizar linha com vetor multiplicador1
                soma += int.Parse(auxCPF[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;//descobre o resto de divisão

            if (resto < 2)
            {
                resto = 0;// se menor que 2 vai valer 0
            }
            else
            {
                resto = 11 - resto; // senao é 11 menos o resto
            }

            Digito = resto.ToString(); // guarda o primeiro digito
            auxCPF = auxCPF + Digito; // passa pra aux do cpf

            soma = 0;

            for (int i = 0; i < 10; i++)//conta 10 porque tem um digito a mais agora
            {
                //vai multiplicando e somando ao mesmo tempo pelo vetor multiplicador2 que é a segunda tabelinha
                soma += int.Parse(auxCPF[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;//pega o resto da divisao


            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }


            auxCPF = auxCPF + resto;// passa o ultimo digito restante pra comparar


            if (CPF == auxCPF)//se o digitado no campo de texto for igual ao que foi processado aqui é porque é valido
            {
                MessageBox.Show("O CPF é Valido !!");
            }
            else
            {
                MessageBox.Show("O CPF não é Valido !!");
            }


        }
    }
}
