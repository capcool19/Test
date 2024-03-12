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
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        ProductLogic logic = new ProductLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FiveLatestProducts();
            }
        }

        private void FiveLatestProducts()
        {
            var products = logic.GetProductList();
            try
            {
                rptLatestProducts.DataSource = products.OrderByDescending(x=>x.ProductId).Take(5);
                rptLatestProducts.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}