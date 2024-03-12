using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.UserControls
{
    public partial class Menu_Left : System.Web.UI.UserControl
    {
        CategoryLogic logic = new CategoryLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataIntoRepeater();
            }
        }
        private void LoadDataIntoRepeater()
        {
            var categories = logic.CategoryList();
            try
            {
                rptCategoryMenu.DataSource = categories.OrderBy(x => x.Name);
                rptCategoryMenu.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}