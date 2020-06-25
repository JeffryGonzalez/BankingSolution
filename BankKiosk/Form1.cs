using BankingDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    public partial class Form1 : Form
    {
        BankAccount _bankAccount;
        public Form1()
        {
            InitializeComponent();
            _bankAccount = new BankAccount(
                new StandardBonusCalculator(
                    new SystemTime()),
                new FakeNarc());

            Text = _bankAccount.GetBalance().ToString("c");
            
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DoTransaction(_bankAccount.Deposit);
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            DoTransaction(_bankAccount.Withdraw);
        }
        private void DoTransaction(Action<decimal> op)
        {
            try
            {
                var amount = decimal.Parse(txtAmount.Text);
                op(amount);
                Text = _bankAccount.GetBalance().ToString("c");
            }
            catch (FormatException)
            {

                MessageBox.Show("Enter a number, genius");
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
            catch (OverdraftException)
            {
                MessageBox.Show("You don't have that much money!");
                txtAmount.Text = _bankAccount.GetBalance().ToString();
                txtAmount.Focus();
            }
            catch(BadAmountException)
            {
                MessageBox.Show("You are a bad person and you should feel bad about yourself.");
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
        }

      
    }

    public class FakeNarc : INarcOnAccounts
    {
        public void NotifyOfWithdrawal(BankAccount bankAccount, decimal amountToWithdraw)
        {
            MessageBox.Show("Telling the Feds!",
                "NARC ALERT",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

        }
    }
}
