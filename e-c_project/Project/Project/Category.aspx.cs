using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace Project
{
    public partial class Category : System.Web.UI.Page
    {
        CategoryLogic logic = new CategoryLogic();


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
                    divAdd_Edit.Visible = false; 
                    var cat = logic.GetCategoryById(Convert.ToInt32(Request.QueryString["id"]));
                    lblName.Text = cat.Name;
                }
                //Case2: Binding data to grid view
                else
                {
                    BindingCategoryDataIntoGridview();
                    divAdd_Edit.Visible = false;
                    divContentDetail.Visible = false;
                }
            }
        }

        private void BindingCategoryDataIntoGridview()
        {
            try
            {
                var listCategory = logic.CategoryList();
                grvListCategory.DataSource = listCategory;
                grvListCategory.DataBind();
            }
            catch(Exception)
            {
                throw;
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            divAdd_Edit.Visible = true;
            divGridview.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (hiddenfile_value.Value == string.Empty)
                {
                    Insert();
                }
                else 
                {
                    Update();
                }
                Resetform();
                BindingCategoryDataIntoGridview();
            }
        }

        private void Update()
        {
            try
            {
                var strName = txtCategoryName.Text.ToString().Trim();
                var cat = new DataAcessLayer.Models.Category
                {
                    Name = strName,
                    CategoryId = Convert.ToInt32(hiddenfile_value.Value)
                };
                logic.UpdateCategory(cat);
            }
            catch (Exception ex)
            {
                lblDisplay.Visible = true;
                lblDisplay.Text = ex.Message;
            }
        }

        private void Insert()
        {
            try
            {
                var strName = txtCategoryName.Text.ToString().Trim();
                var cat = new DataAcessLayer.Models.Category
                {
                    Name = strName
                };
                logic.CreateNewCategory(cat);
            }
            catch(Exception ex)
            {
                lblDisplay.Visible = true;
                lblDisplay.Text = ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Resetform();
        }

        private void Resetform()
        {
            txtCategoryName.Text = string.Empty;
            divAdd_Edit.Visible = false;
            divContentDetail.Visible = false;
            divGridview.Visible = true;
            hiddenfile_value.Value = string.Empty;
            lblDisplay.Visible = false;
        }

        protected void grvListCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string strId = e.CommandArgument.ToString();
            string strName = e.CommandName.ToLower();
            switch(strName)
            {
                case "_edit":
                    divAdd_Edit.Visible = true;
                    divGridview.Visible = false;
                    hiddenfile_value.Value = strId;
                    LoadDataForEdit();
                    break;
                case "_delete":
                    try
                    {
                        logic.DeleteCategory(Convert.ToInt32(strId));
                        lblDisplay.Visible = false;
                        BindingCategoryDataIntoGridview();

                    }
                    catch 
                    {
                        lblDisplay.Visible = true;
                        lblDisplay.Text = "Cannot delete this record.";
                    }
                    break;
            }
        }

        private void LoadDataForEdit()
        {
            try
            {
                var cat = logic.GetCategoryById(Convert.ToInt32(hiddenfile_value.Value));
                txtCategoryName.Text = cat.Name;
            }
            catch(Exception ex)
            {
                lblDisplay.Visible = true;
                lblDisplay.Text = ex.Message;
                return;
            }
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Resetform();
            BindingCategoryDataIntoGridview();
        }
    }
}