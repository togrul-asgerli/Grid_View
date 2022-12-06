using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_Web_App
{
    public partial class Index : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-SQ9BA76\\SQLEXPRESS;Integrated Security=True; Database=Northwind;");
        SqlCommand cmd;
        bool TextChange = false;
        DataTable dt=new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                this.DataBind();
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {  
                if(TextChange)
            {
                Session["data"] = null;
            }
                this.BindGrid();
               TextChange = false;
        }


        private void BindGrid()
        {
            if (Session["data"] == null)
            {
                con.Open();
                cmd = new SqlCommand("Search", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txt_input.Text);
                cmd.Parameters.Add(new SqlParameter()
                {
                    Direction = ParameterDirection.Output,
                    ParameterName = "@result",
                    SqlDbType = SqlDbType.Int
                });
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@result"].Value.ToString() == "1")
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    Session["data"] = dt;
                    lbl_mes.Text = "";
                }
                else
                {

                    lbl_mes.Text = "Data not found!";
                    datagrid.DataSource = null;
                    datagrid.DataBind();
                }
                con.Close();
            }
                
            
                datagrid.DataSource = Session["data"];
                datagrid.DataBind();
            }
        

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            datagrid.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void txt_input_TextChanged(object sender, EventArgs e)
        {
            TextChange = true;
        }
    }
}