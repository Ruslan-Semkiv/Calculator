using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double result = 0;
        String operation = null;
        bool enter_value = false;
        String firstNum,secondNum;

        static String emptyHstrLbl = "History is empty ...";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numbers_Only(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if ((txtDisplay.Text == "0") || (enter_value)){
                txtDisplay.Text = "";
                enter_value = false;
            }
            if(b.Text == ".")
            {
                if (!txtDisplay.Text.Contains(".")) {
                    txtDisplay.Text += b.Text;
                }
            }
            else{
                txtDisplay.Text += b.Text;
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void operators_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (result != 0)
            {
                btnEquals.PerformClick();
                enter_value = true;
                operation = b.Text;
                lblShowOps.Text = System.Convert.ToString(result)
                    + " "
                    + operation;
            }
            else
            {
                operation = b.Text;
                result = Double.Parse(txtDisplay.Text);
                txtDisplay.Text = "";
                lblShowOps.Text = System.Convert.ToString(result)
                    + " "
                    + operation;
            }
            firstNum = lblShowOps.Text;

        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            secondNum = txtDisplay.Text;
            lblShowOps.Text = "";
            switch (operation){
                case "+": 
                    txtDisplay.Text = (result + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (result - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (result * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (result / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(txtDisplay.Text);
            operation = "";

            btnClearHistory.Visible = true;
            rtbDisplayHistory.AppendText(firstNum + " " + secondNum + " = " + " \n");
            rtbDisplayHistory.AppendText("\n\t" + txtDisplay.Text + "\n\n");
            labelEmptyHistory.Text = "";
        }

        private void DeleteButtton_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length > 0){
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
            if(txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        private void BtnClearHistory_Click(object sender, EventArgs e)
        {
            rtbDisplayHistory.Clear();
            if(labelEmptyHistory.Text == "")
            {
                labelEmptyHistory.Text = emptyHstrLbl;
            }
            btnClearHistory.Visible = false;
            rtbDisplayHistory.ScrollBars = 0;
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (treeView1.Visible == true)
            {
                treeView1.Visible = false;
            }
            else
            {
                treeView1.Visible = true;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblTitle.Text = e.Node.Text;
            treeView1.Visible = false;
        }

        private void labelEmptyHistory_Click(object sender, EventArgs e)
        {

        }

        private void labelHistory_Click(object sender, EventArgs e)
        {

        }

        private void CancelAllButton_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            result = 0;
        }
    }
}
