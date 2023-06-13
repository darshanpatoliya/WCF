using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFInventoryConsumer.ServiceReferenceInsert;

namespace WCFInventoryConsumer
{
    public partial class Salesman : System.Web.UI.Page
    {
        WCFInsertServiceClient serviceClient = new WCFInsertServiceClient("BasicHttpBinding_IWCFInsertService");
        private string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            try
            {
                conn.Open();
                string selectQuery = "SELECT * FROM salesman;";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    gvSalesman.DataSource = dt;
                    gvSalesman.DataBind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message, ex);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var nameOfSalesman = txtSalesmanName.Text;
            var cityOfSalesman = txtCity.Text;
            var commissionOfSalesman = decimal.Parse(txtCommission.Text);

            SalesmanBO newSalesman = new SalesmanBO()
            {
                NameOfSalesman = nameOfSalesman,
                CityOfSalesman = cityOfSalesman,
                CommissionOfSalesman = commissionOfSalesman
            };

            int result = serviceClient.InsertNewSalesman(newSalesman);

            ClearFields();
            BindGridView();

        }
        private void ClearFields()
        {
            txtCity.Text = string.Empty;
            txtCommission.Text = string.Empty;
            txtSalesmanName.Text = string.Empty;
        }
    }
}