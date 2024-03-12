using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAcessLayer.Models;

namespace Project
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        ProjectEntities db = new ProjectEntities();
        private string strCart = "Cart";
        bool isDelete = false;
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
                LoadingDataToShoppingCart();
            }
        }

        private void LoadingDataToShoppingCart()
        {
            int proId;
            List<Cart> lstCart = new List<Cart>();
            decimal? totalPrice = 0;
            var check =int.TryParse(Request.QueryString["proId"],out proId);
            if(check && !isDelete)
            {
                lstCart = OrderNow(proId);
                rptProductList.DataSource = lstCart;
                rptProductList.DataBind();

                foreach(var item in lstCart)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                lblTotalPrices.Text = string.Format("{0:#,###}",Convert.ToDecimal(totalPrice.ToString()));
            }
            else
            {
                if (Session[strCart] != null)
                {
                    lstCart = (List<Cart>)Session[strCart];
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
                    lblNoData.Text = "No Data";
                }
            }
        }
        public List<Cart> OrderNow(int? id)
        {
            if (Session[strCart] == null)
            {
                List<Cart> lstCart = new List<Cart>
                {
                    new Cart(db.Products.Find(id),1)
                };
                Session[strCart] = lstCart;
            }
            else
            {
                List<Cart> lstCart = (List<Cart>)Session[strCart];
                int check = IsExistingCheck(id);
                if (check == -1)
                    lstCart.Add(new Cart(db.Products.Find(id), 1));
                else
                {
                    lstCart[check].Quantity++;
                    lstCart[check].SubTotal = lstCart[check].Price * lstCart[check].Quantity;
                }
                Session[strCart] = lstCart;
            }
            return (List<Cart>)Session[strCart];
        }
        private int IsExistingCheck(int?id)
        {
            List<Cart> lstCart = (List<Cart>)Session[strCart];
            for(int i = 0; i < lstCart.Count; i++)
            {
                if (lstCart[i].Product.ProductId == id) return i;
            }
            return -1;
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lblProductId") as Label).Text);
            int check = IsExistingCheck(productId);
            List<Cart> lstCart = (List<Cart>)Session[strCart];
            lstCart.RemoveAt(check);
            isDelete = true;
            LoadingDataToShoppingCart();
        }
    }
}