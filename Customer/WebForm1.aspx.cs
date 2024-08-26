using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Customer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataSet ds;
        int RowIndex;
        private string constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerDS"] == null)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select Custid, Name, Balance, City, Status From tblCustomer Order By Custid", constr);
                ds = new DataSet();
                da.Fill(ds, "tblCustomer");
                Session["CustomerDS"] = ds;
                Session["RowIndex"] = 0;
                ShowData(GetCbStatus());
            }
            else
            {
                ds = (DataSet)Session["CustomerDS"];
                RowIndex = (int)Session["RowIndex"];
            }
        }

        private CheckBox GetCbStatus()
        {
            return cbStatus;
        }

        private void ShowData(CheckBox cbStatus)
        {
            // Access data from DataSet
            txtId.Text = ds.Tables[0].Rows[RowIndex]["Custid"].ToString();
            txtName.Text = ds.Tables[0].Rows[RowIndex]["Name"].ToString();
            txtBalance.Text = ds.Tables[0].Rows[RowIndex]["Balance"].ToString();
            txtCity.Text = ds.Tables[0].Rows[RowIndex]["City"].ToString();

            // Check the data type of the "Status" column
            object statusValue = ds.Tables[0].Rows[RowIndex]["Status"];
            if (statusValue != DBNull.Value && statusValue is bool)
            {
                cbStatus.Checked = (bool)statusValue;
            }
            else
            {
                // Handle the case when the value cannot be cast to a boolean
                // You can display an error message, set a default value, or take any other appropriate action
                cbStatus.Checked = false; // Example: Set the checkbox to unchecked as a default value
            }

            Session["RowIndex"] = RowIndex;
        }

        protected void BtnFirst_Click(object sender, EventArgs e)
        {
            RowIndex = 0; ShowData(GetCbStatus());
        }

        protected void BtnPrev_Click(object sender, EventArgs e)
        {
            if (RowIndex > 0)
            {
                RowIndex -= 1;
                ShowData(GetCbStatus());
            }
            else
            {
                Response.Write("<script>alert('First record of the table.')</script>");
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            if (RowIndex < ds.Tables[0].Rows.Count - 1)
            {
                RowIndex += 1;
                ShowData(GetCbStatus());
            }
            else
            {
                Response.Write("<script>alert('Last record of the table.')</script>");
            }
        }

        protected void BtnLast_Click(object sender, EventArgs e)
        {
            RowIndex = ds.Tables[0].Rows.Count - 1;
            ShowData(GetCbStatus());
        }
    }
}