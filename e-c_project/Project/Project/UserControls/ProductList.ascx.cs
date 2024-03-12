using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using DataAcessLayer;

namespace Project.UserControls
{
    public partial class ProductList : System.Web.UI.UserControl
    {
        ProductLogic logic = new ProductLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProductListing();
            }
        }

        private void GetProductListing()
        {
            List<DataAcessLayer.Models.Product> products = new List<DataAcessLayer.Models.Product>();
            string category = Request.QueryString["cat"];
            if (!string.IsNullOrEmpty(category))
            {
                var check = int.TryParse(category, out int cat);
                if (check)
                {
                    products = logic.GetProductList(cat);
                }
                else
                    products = logic.GetProductList();
            }
            else
                products = logic.GetProductList();
            try
            {
                if (products.Count > 0)
                {
                    rptProductList.DataSource = products.OrderByDescending(x => x.ProductId);
                    rptProductList.DataBind();
                }
                else
                    lblNoData.Text = "No data";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}