using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using DataAcessLayer;
using DataAcessLayer.Models;

namespace Project
{
    public partial class Purchase : System.Web.UI.Page
    {
        ProjectEntities db = new ProjectEntities();
        ShoppingCartLogic logic = new ShoppingCartLogic();
        private string strCart = "Cart";

        protected void Page_Load(object sender, EventArgs e)
        {
            divProductList.Visible = true;
            divClientInfo.Visible = true;
            if (!IsPostBack)
            {
                LoadingDataToShoppingCart();
            }
            if (Session["user"] != null)
            {

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void LoadingDataToShoppingCart()
        {
            List<Cart> lstCart = new List<Cart>();
            decimal? totalPrice = 0;
            if (Session[strCart] != null)
            {
                lstCart = (List<Cart>)Session[strCart];
                if (lstCart.Count > 0)
                {
                    rptProductList.DataSource = Session[strCart];
                    rptProductList.DataBind();

                    foreach (var item in lstCart)
                    {
                        totalPrice += item.Price * item.Quantity;
                    }
                    lblTotalPrices.Text = string.Format("{0:#,###}", Convert.ToDecimal(totalPrice.ToString()));
                    lblNoData.Visible = false;
                }
                else
                {
                    Response.Redirect("~/ShoppingCart.aspx");
                } 
            }
            else
            {
                Response.Redirect("~/ShoppingCart.aspx");
            }
            
        }
    

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
            Order order = new Order()
            {
                CustomerName = txtName.Text.Trim(),
                CustomerPhone = txtPhone.Text.Trim(),
                CustomerEmail = txtEmail.Text.Trim(),
                CustomerAddress = txtAddress.Text.Trim()
            };
            var check = logic.CheckOut(order, (List<Cart>)Session[strCart]);
            if (check)
            {
                Session.Remove(strCart);
                lblNoData.Visible = true;
                lblNoData.Text = "Thank you for shopping with us.";
                divProductList.Visible = false;
                divClientInfo.Visible = false;
                ResetForm();
            }
            else
            {
                lblNoData.ForeColor = System.Drawing.Color.Red;
                lblNoData.Text = "cannot save the order, due to some errors. Try again";
            }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
    }
}