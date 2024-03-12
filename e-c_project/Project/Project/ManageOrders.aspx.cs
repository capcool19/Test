using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace Project
{
    public partial class ManageOrders : System.Web.UI.Page
    {
        OrderLogic logic = new OrderLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                //Case1: check detail view
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    divContentDetail.Visible = true;
                    var order = logic.GetOrderById(Convert.ToInt32(Request.QueryString["id"]));
                    lblOrderId.Text = order.OrderId.ToString();
                    lblCustomerName.Text = order.CustomerName;
                    lblCustomerPhone.Text = order.CustomerPhone;
                    lblCustomerEmail.Text = order.CustomerEmail;
                    lblCustomerAddress.Text = order.CustomerAddress;
                    lblOrderDate.Text = order.OrderDate.ToString();

                }
                //Case2: Binding data to grid view
                else
                {
                    BindingDataIntoGridview();
                    divContentDetail.Visible = false;
                }
            }
        }
        private void Resetform()
        {
            divContentDetail.Visible = false;
            divGridview.Visible = true;
            hiddenfile_value.Value = string.Empty;
            lblDisplay.Visible = false;
        }
        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Resetform();
            BindingDataIntoGridview();
        }

        private void BindingDataIntoGridview()
        {
            try
            {
                var listData = logic.GetOrderList();
                grvListData.DataSource = listData;
                grvListData.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void grvListData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string strId = e.CommandArgument.ToString();
            string strName = e.CommandName.ToLower();
            switch (strName)
            {
                case "_delete":
                    try
                    {
                        logic.DeleteOrder(Convert.ToInt32(strId));
                        lblDisplay.Visible = false;
                        BindingDataIntoGridview();

                    }
                    catch
                    {
                        lblDisplay.Visible = true;
                        lblDisplay.Text = "Cannot delete this record.";
                    }
                    break;
            }
        }
    }
}