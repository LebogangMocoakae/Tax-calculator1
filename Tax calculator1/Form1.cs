using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tax_calculator1
{
    public partial class Form1 : Form
    {
        private double normalRebate =16425;
        private double above65Below75Rebate = 9000 + 16425;
        double above75Rebate = 9000+16425 + 2997;
        double taxAmountPA = 0;
        double rate = 0.18;
        double bracket2Rate = 0.26, bracket2MoneyRate = 40680, bracket3MoneyRate=73726, bracket4MoneyRate=115762, bracket5MoneyRate=170734;
        double bracket6MoneyRate = 239452, bracket7MoneyRate = 1731601;
       
        public Form1()
        {
            InitializeComponent();

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            
            int age = Convert.ToInt32(this.UserAge.Text);
            double pay = Convert.ToInt32(this.UserPay.Text);

           
           
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Bracket 1 R0 - R226000
            if ((pay*12)<=226000)
            {
                // tax rebates for people below 65 years old
                if(age<65 && (pay*12)>=91250)
                {
                    int bracket = 1;
                    bracket1Under65(age,pay);
                    TaxCal(age, pay, normalRebate, rate,bracket);
                       
                }

                // tax rebates for people below 65 years old (below threshold)
                if (age<65 && (pay * 12)<91250)
                {
                    int bracket = 1;
                    bracket1under65Threshold(age,pay);
                    TaxCalThreshold(age, pay, bracket);
                }

                // tax rebates for people Above 65 years old and below 75
                if (age>=65 && age<75 && (pay*12)>=141250)
                {
                    int bracket = 1;
                   bracket1for65to75(age,pay);
                    TaxCal(age,pay,above65Below75Rebate,rate,bracket);
                }
                // tax rebates for people Above 65 years old and below 75 (below threshold)
                if (age >= 65 && age < 75 && (pay * 12) < 141250)
                {
                    int bracket = 1;
                   bracket1for65to75Threshold(age,pay);
                    TaxCalThreshold(age,pay, bracket);
                }

                // tax rebates for people Above 75
                if (age >= 75 && (pay*12)>157900)
                {
                    int bracket = 1;
                    bracket1Above75(age, pay);
                    TaxCal(age,pay, above75Rebate,rate,bracket);

                }

                //tax rebates for people Above 75 (below threshold)
                if (age >= 75 && (pay * 12) < 157900)
                {
                    int bracket = 1;
                    bracket1above75Threshold(age, pay);
                    TaxCalThreshold(age, pay, bracket);
                }


            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Bracket 2 R226001 - R353100
            if ((pay * 12) >= 226001 && (pay * 12) <= 353100)
            {

                // tax rebates for people below 65 years old
                if (age < 65)
                {

                    double taxableIncome= (((pay * 12)*bracket2Rate)+40680)-normalRebate;
                    double monthlyTax = (taxableIncome / 12);
                    double uif = pay * 0.01;
                    double netSalary = pay - monthlyTax;
                    MessageBox.Show("Tax bracket 2 (below 65)");
                    MessageBox.Show("R " + monthlyTax);
                  
                   // MessageBox.Show("Tax Yearly Amount: R" + totalTax);

                }
                // tax rebates for people Above 65 years old and below 75
                if (age >= 65 && age < 75)
                {
                    MessageBox.Show("Tax bracket 2 (Above 65 and below 75)");
                    taxAmountPA = ((pay * 12) * rate) - above65Below75Rebate;
                    double taxedPay = 0;
                    taxedPay = ((pay * 12) - taxAmountPA) / 12;
                    MessageBox.Show("Tax Yearly Amount: R" + taxedPay);
                }

            }

            //Bracket 3
            if ((pay * 12) >= 353101 && (pay * 12) <= 488700)
            {
                MessageBox.Show("Tax bracket 3");
            }

            //bracket 4
            if ((pay * 12) >= 488701 && (pay * 12) <= 641400)
            {
                MessageBox.Show("Tax bracket 4");
            }

            //Bracket 5
            if ((pay * 12) >= 641401 && (pay * 12) <= 817600)
            {
                MessageBox.Show("Tax bracket 5");
            }

            //Bracket 6
            if ((pay * 12) >= 817601 && (pay * 12) <= 1731600)
            {
                MessageBox.Show("Tax bracket 6");
            }

            //Bracket 7
            if ((pay * 12) >= 1731601)
            {
                MessageBox.Show("Tax bracket 7");
            }





        }
        //METHODS///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // method for calculating tax for bracket 1. people below 65
        public void bracket1Under65(int age, double pay)
        {
            MessageBox.Show("Tax bracket 1 (below 65)");
            double taxAmountPA = (pay * 12);
            double tax = taxAmountPA * 0.18;
            double rebatePA = tax - normalRebate;
            double rebatePM = rebatePA / 12;
            double total = pay - rebatePM;
            double uif = pay * 0.01;
            double paye = total - uif;
            MessageBox.Show("Tax Yearly Amount: R" + paye);
        }
        // method for calculating tax for bracket 1. people below 65 below the Threshold
        public void bracket1under65Threshold(int age, double pay)
        {
            MessageBox.Show("Tax bracket 1 (below 65) and income tax does not apply: below Threshold");
            double uif = pay * 0.01;
            double paye = pay - uif;
            MessageBox.Show("Tax Yearly Amount: R" + paye);
        }

        //test methods////////////////////////////////////////////

        //Paye calculator
        public void TaxCal(int age, double pay,double rebate,double rate,int bracket)
        {
            MessageBox.Show("Tax bracket "+bracket + " Age: "+ age);
            taxAmountPA = (pay * 12);
            double tax = taxAmountPA * rate;
            double rebatePA = tax - rebate;
            double rebatePM = rebatePA / 12;
            double total = pay - rebatePM;
            double uif = pay * 0.01;
            double paye = total - uif;
            MessageBox.Show("Tax Yearly Amount: R" + paye);
        }

        //paye calculator (below threshold)
        public void TaxCalThreshold(int age,double pay,int bracket)
        {
            MessageBox.Show("Tax bracket "+ bracket +" "+ age + " years old) and income tax does not apply: below Threshold");
            double uif = pay * 0.01;
            double paye = pay - uif;
            MessageBox.Show("Tax Yearly Amount: R" + paye);
        }


        // method for people Above 65 years old and below 75 (bracket1_
        public void bracket1for65to75(int age,double pay)
        {
            MessageBox.Show("Tax bracket 1 (Above 65 years old and below 75)");
            taxAmountPA = (pay * 12);
            double tax = taxAmountPA * 0.18;
            double rebatePA = tax - above65Below75Rebate;
            double rebatePM = rebatePA / 12;
            double total = pay - rebatePM;
            double uif = pay * 0.01;
            double paye = total - uif;
            MessageBox.Show("Tax Yearly Amount: R" + paye);
        }
        // method for people Above 65 years old and below 75 (below threshold) (bracket1)
        public void bracket1for65to75Threshold(int age, double pay)
        {
            MessageBox.Show("Tax bracket 1 (65 years old and below 75) and income tax does not apply: below Threshold");
            double uif = pay * 0.01;
            double paye = pay - uif;
            MessageBox.Show("Tax Yearly Amount: R" + paye);
        }
        // method for people Above 75 (bracket1)
        public void bracket1Above75(int age,double pay)
        {
            MessageBox.Show("Tax bracket 1 (Above 75)");
            taxAmountPA = (pay * 12);
            double tax = taxAmountPA * 0.18;
            double rebatePA = tax - above75Rebate;
            double rebatePM = rebatePA / 12;
            double total = pay - rebatePM;
            double uif = pay * 0.01;
            double paye = total - uif;
            MessageBox.Show("Tax Yearly Amount: R" + paye);
        }
        // method for people Above 75 (below threshold) (bracket1)
        public void bracket1above75Threshold(int age,double pay)
        {
            MessageBox.Show("Tax bracket 1 (above 75) and income tax does not apply: below Threshold");
            double uif = pay * 0.01;
            double paye = pay - uif;
            MessageBox.Show("Tax Yearly Amount: R" + paye);
        }
    }
}
