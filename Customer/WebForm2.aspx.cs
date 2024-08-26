using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Drawing.Printing;
using System.Security.Cryptography;
namespace Customer
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con; 
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
            cmd  = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                HttpPostedFile postedFile = FileUpload1.PostedFile;
                string fileExtension = Path.GetExtension(postedFile.FileName);
                if (fileExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    fileExtension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                    fileExtension.Equals(".bmp", StringComparison.OrdinalIgnoreCase) ||
                    fileExtension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                {
                    string imgName = Path.GetFileName(postedFile.FileName);
                    string folderPath = Server.MapPath("~/Images/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    postedFile.SaveAs(folderPath + imgName);
                    imgPhoto.ImageUrl = "~/Images/" + imgName;
                    BinaryReader br = new BinaryReader(postedFile.InputStream);
                    byte[] imgData = br.ReadBytes(postedFile.ContentLength);
                    Session["PhotoName"] = imgName;
                    Session["PhotoBinary"] = imgData;
                }
                else
                {
                    Response.Write("<script>alert('Only jpg, jpeg, bmp, png files are allowed.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select a file.')</script>");
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        private void ClearData()
        {
            txtId.Text = txtName.Text = txtFee.Text = txtClass.Text = iblMsgs.Text = imgPhoto.ImageUrl = "";
            Session["PhotoName"] = Session["PhotoBinary"] = null;
        }

        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "sp_selectRecord";
                cmd.Parameters.AddWithValue("@Sid", txtId.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtName.Text = dr["Name"].ToString();
                    txtFee.Text = dr["Fees"].ToString();
                    txtClass.Text = dr["Class"].ToString();
                    if (dr["PhotoName"] != DBNull.Value)
                    {
                        imgPhoto.ImageUrl = "~/Images/" + dr["PhotoName"];
                        Session["PhotoName"] = dr["PhotoName"].ToString();
                    }
                    else
                    {
                        imgPhoto.ImageUrl = " ";
                        Session["PhotoName"] = null;
                    }
                    if (dr["PhotoBinary"] != DBNull.Value)
                    {
                        Session["PhotoBinary"] = (byte[])dr["PhotoBinary"];
                    }
                    else
                    {
                        Session["PhotoBinary"] = null;
                    }
                }
                else
                {
                    Response.Write("<script>alert('No Student record found.')</script>");
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                iblMsgs.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "sp_InsertStudent";
                AddParamerter();
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Record inserted successfully.')</script>");
                ClearData();
            }
            catch (Exception ex)
            {
                iblMsgs.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }

        }
        private void AddParamerter()
        {
            cmd.Parameters.AddWithValue("@Sid", txtId.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Fees",txtFee.Text);
            cmd.Parameters.AddWithValue("@Class", txtClass.Text);
            if (Session["PhotoName"] != null) 
            {
                cmd.Parameters.AddWithValue("@PhotoName", Session["PhotoName"].ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@PhotoName", DBNull.Value);
                cmd.Parameters["@PhotoName"].SqlDbType = SqlDbType.VarChar;
            }
            if (Session["PhotoBinary"] != null)
            {
                cmd.Parameters.AddWithValue("@PhotoBinary", (byte[])Session["PhotoBinary"]);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PhotoBinary", DBNull.Value);
                cmd.Parameters["@PhotoBinary"].SqlDbType = SqlDbType.VarBinary; 
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "sp_UpdateStudent";
                AddParamerter();
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Record Updated successfully.')</script>");
                ClearData();
            }
            catch (Exception ex)
            {
                iblMsgs.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "sp_DeleteStudent";
                cmd.Parameters.AddWithValue("@Sid", txtId.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Record Deleted successfully.')</script>");
                ClearData();
            }
            catch (Exception ex)
            {
                iblMsgs.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}

