using System;
using System.Windows.Forms;

public class CaixaEletronico : Form
{
    private double saldoC = 0;
    private double saldoP = 0;
    private double saldoCD = 0;
    private string extratoC = "";
    private TextBox txtValorDeposito;
    private TextBox txtValorSaque;
    private TextBox txtValorTransferencia;
    private TextBox txtValorInvestimento;
    private TextBox txtCpf;
    private TextBox txtSenha;
    private Label lblSaldo;
    private Label lblExtrato;

    public CaixaEletronico()
    {
        // Configurações do Formulário
        Text = "Caixa Eletrônico";
        Size = new System.Drawing.Size(450, 700);
        StartPosition = FormStartPosition.CenterScreen;

        // CPF
        Label lblCpf = new Label() { Text = "CPF:", Top = 20, Left = 20, Width = 100 };
        txtCpf = new TextBox() { Top = 20, Left = 130, Width = 280 };

        // Senha
        Label lblSenha = new Label() { Text = "Senha:", Top = 60, Left = 20, Width = 100 };
        txtSenha = new TextBox() { Top = 60, Left = 130, Width = 280, PasswordChar = '*' };

        // Saldo
        lblSaldo = new Label() { Text = "Saldo: R$0.00", Top = 100, Left = 20, Width = 350 };

        // Extrato
        lblExtrato = new Label() { Text = "Extrato:", Top = 140, Left = 20, Width = 400, Height = 300, AutoSize = true };

        // Depósito
        Label lblDeposito = new Label() { Text = "Valor Depósito:", Top = 450, Left = 20, Width = 100 };
        txtValorDeposito = new TextBox() { Top = 450, Left = 130, Width = 100, PasswordChar = '*' };
        Button btnDeposito = new Button() { Text = "Depositar", Top = 450, Left = 250 };
        btnDeposito.Click += (sender, e) => RealizarDeposito();

        // Botão para alternar a visibilidade dos depósitos
        Button btnToggleDeposito = new Button() { Text = "Mostrar", Top = 450, Left = 370 };
        btnToggleDeposito.Click += (sender, e) => ToggleVisibility(txtValorDeposito, btnToggleDeposito);

        // Saque
        Label lblSaque = new Label() { Text = "Valor Saque:", Top = 490, Left = 20, Width = 100 };
        txtValorSaque = new TextBox() { Top = 490, Left = 130, Width = 100, PasswordChar = '*' };
        Button btnSaque = new Button() { Text = "Sacar", Top = 490, Left = 250 };
        btnSaque.Click += (sender, e) => RealizarSaque();

        // Botão para alternar a visibilidade dos saques
        Button btnToggleSaque = new Button() { Text = "Mostrar", Top = 490, Left = 370 };
        btnToggleSaque.Click += (sender, e) => ToggleVisibility(txtValorSaque, btnToggleSaque);

        // Transferência
        Label lblTransferencia = new Label() { Text = "Valor Transferência:", Top = 530, Left = 20, Width = 120 };
        txtValorTransferencia = new TextBox() { Top = 530, Left = 150, Width = 100, PasswordChar = '*' };
        Button btnTransferir = new Button() { Text = "Transferir", Top = 530, Left = 260 };
        btnTransferir.Click += (sender, e) => RealizarTransferencia();

        // Botão para alternar a visibilidade das transferências
        Button btnToggleTransferencia = new Button() { Text = "Mostrar", Top = 530, Left = 370 };
        btnToggleTransferencia.Click += (sender, e) => ToggleVisibility(txtValorTransferencia, btnToggleTransferencia);

        // Investimentos
        Label lblInvestimento = new Label() { Text = "Valor Investimento:", Top = 570, Left = 20, Width = 120 };
        txtValorInvestimento = new TextBox() { Top = 570, Left = 150, Width = 100, PasswordChar = '*' };
        Button btnInvestirPoupanca = new Button() { Text = "Investir Poupança", Top = 570, Left = 260 };
        btnInvestirPoupanca.Click += (sender, e) => InvestirPoupanca();

        Button btnInvestirCDB = new Button() { Text = "Investir CDB", Top = 570, Left = 370 };
        btnInvestirCDB.Click += (sender, e) => InvestirCDB();

        // Extrato
        Button btnExtrato = new Button() { Text = "Mostrar Extrato", Top = 610, Left = 20 };
        btnExtrato.Click += (sender, e) => MostrarExtrato();

        // Adiciona os controles ao formulário
        Controls.Add(lblCpf);
        Controls.Add(txtCpf);
        Controls.Add(lblSenha);
        Controls.Add(txtSenha);
        Controls.Add(lblSaldo);
        Controls.Add(lblExtrato);
        Controls.Add(lblDeposito);
        Controls.Add(txtValorDeposito);
        Controls.Add(btnDeposito);
        Controls.Add(btnToggleDeposito);
        Controls.Add(lblSaque);
        Controls.Add(txtValorSaque);
        Controls.Add(btnSaque);
        Controls.Add(btnToggleSaque);
        Controls.Add(lblTransferencia);
        Controls.Add(txtValorTransferencia);
        Controls.Add(btnTransferir);
        Controls.Add(btnToggleTransferencia);
        Controls.Add(lblInvestimento);
        Controls.Add(txtValorInvestimento);
        Controls.Add(btnInvestirPoupanca);
        Controls.Add(btnInvestirCDB);
        Controls.Add(btnExtrato);
    }

    private void ToggleVisibility(TextBox textBox, Button button)
    {
        if (textBox.PasswordChar == '*')
        {
            textBox.PasswordChar = '\0'; // Mostra os números
            button.Text = "Ocultar";
        }
        else
        {
            textBox.PasswordChar = '*'; // Oculta os números
            button.Text = "Mostrar";
        }
    }

    private void RealizarDeposito()
    {
        if (double.TryParse(txtValorDeposito.Text, out double deposito) && deposito > 0)
        {
            saldoC += deposito;
            extratoC += $"Depósito: R${deposito:F2}\n";
            lblSaldo.Text = $"Saldo: R${saldoC:F2}";
            txtValorDeposito.Clear();
        }
        else
        {
            MessageBox.Show("Valor inválido para depósito!");
        }
    }

    private void RealizarSaque()
    {
        if (double.TryParse(txtValorSaque.Text, out double saque) && saque > 0)
        {
            if (saque <= saldoC)
            {
                saldoC -= saque;
                extratoC += $"Saque: R${saque:F2}\n";
                lblSaldo.Text = $"Saldo: R${saldoC:F2}";
                txtValorSaque.Clear();
            }
            else
            {
                MessageBox.Show("Saldo insuficiente!");
            }
        }
        else
        {
            MessageBox.Show("Valor inválido para saque!");
        }
    }

    private void RealizarTransferencia()
    {
        if (double.TryParse(txtValorTransferencia.Text, out double transferencia) && transferencia > 0)
        {
            if (transferencia <= saldoC)
            {
                saldoC -= transferencia;
                extratoC += $"Transferência: R${transferencia:F2}\n";
                lblSaldo.Text = $"Saldo: R${saldoC:F2}";
                txtValorTransferencia.Clear();
                MessageBox.Show("Transferência realizada com sucesso!");
            }
            else
            {
                MessageBox.Show("Saldo insuficiente para transferência!");
            }
        }
        else
        {
            MessageBox.Show("Valor inválido para transferência!");
        }
    }

    private void InvestirPoupanca()
    {
        if (double.TryParse(txtValorInvestimento.Text, out double investimento) && investimento > 0)
        {
            if (investimento <= saldoC)
            {
                saldoP += investimento + (investimento * 0.05); // 5% de rendimento
                saldoC -= investimento;
                extratoC += $"Investido em Poupança: R${investimento:F2}\n";
                lblSaldo.Text = $"Saldo: R${saldoC:F2}, Poupança: R${saldoP:F2}";
                txtValorInvestimento.Clear();
                MessageBox.Show("Investimento em Poupança realizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Saldo insuficiente para investir!");
            }
        }
        else
        {
            MessageBox.Show("Valor inválido para investimento!");
        }
    }

    private void InvestirCDB()
    {
        if (double.TryParse(txtValorInvestimento.Text, out double investimento) && investimento > 0)
        {
            if (investimento <= saldoC)
            {
                saldoCD += investimento + (investimento * 0.09); // 9% de rendimento
                saldoC -= investimento;
                extratoC += $"Investido em CDB: R${investimento:F2}\n";
                lblSaldo.Text = $"Saldo: R${saldoC:F2}, CDB: R${saldoCD:F2}";
                txtValorInvestimento.Clear();
                MessageBox.Show("Investimento em CDB realizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Saldo insuficiente para investir!");
            }
        }
        else
        {
            MessageBox.Show("Valor inválido para investimento!");
        }
    }

    private void MostrarExtrato()
    {
        if (string.IsNullOrEmpty(extratoC))
        {
            MessageBox.Show("Nenhuma transação realizada.");
        }
        else
        {
            MessageBox.Show(extratoC, "Extrato");
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new CaixaEletronico());
    }
}
