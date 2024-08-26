using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Customer
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = Convert.ToDouble(TextBox1.Text);
                double num2 = Convert.ToDouble(TextBox2.Text);
                string operation = DropDownList1.SelectedValue;

                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            LabelResult.Text = "Error: Division by zero";
                            return;
                        }
                        result = num1 / num2;
                        break;
                }

                LabelResult.Text = $"Result: {result}";
            }
            catch (Exception ex)
            {
                LabelResult.Text = $"Error: {ex.Message}";
            }

        }
    }
}