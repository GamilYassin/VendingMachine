using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachine.FormsUI
{
	public partial class VendingMachineWindow : Form
	{
		public VendingMachineWindow()
		{
			InitializeComponent();
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void VendingMachineWindow_Load(object sender, EventArgs e)
		{
			StringBuilder custBalance = new StringBuilder();
			custBalance.Append("Cent = 12\t\t");
			custBalance.Append("Nikle = 10\t\t");
			custBalance.AppendLine();
			custBalance.Append("Dime = 8\t\t");
			custBalance.Append("Quarter = 8\t\t");
			custBalance.AppendLine();
			custBalance.Append("Dollar = 8\t\t");
			custBalance.Append("5 Dollar = 8\t\t");
			custBalance.AppendLine();
			custBalance.Append("10 Dollar = 8\t");
			custBalance.Append("20 Dollar = 8\t\t");

			txtCustomerBalance.Text = custBalance.ToString();
			txtMainDisplay.Text = custBalance.ToString();
		}
	}
}