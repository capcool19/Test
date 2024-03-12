using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace Project
{
    public partial class Product : System.Web.UI.Page
    {
        ProductLogic logic = new ProductLogic();
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
                    var product = logic.GetProductById(Convert.ToInt32(Request.QueryString["id"]));
                    lblProductName.Text = product.ProductName;
                    lblImage.Text = product.Image;
                    lblPrice.Text = product.Price.ToString();
                    lblCategory.Text = product.CategoryId.ToString();
                }
                //Case2: Binding data to grid view
                else
                {
                    BindingDataIntoGridview();
                    BindCategoryDataToDropdownList();
                    divAdd_Edit.Visible = false;
                    divContentDetail.Visible = false;
                }
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            BindCategoryDataToDropdownList();
            divAdd_Edit.Visible = true;
            divGridview.Visible = false;
        }

        protected void BindCategoryDataToDropdownList()
        {
            try
            {
                var cats = logic.GetCategoryList();
                drdlCategory.DataValueField = "CategoryId";
                drdlCategory.DataTextField = "Name";
                drdlCategory.DataSource = cats;
                drdlCategory.DataBind();
            }
            catch (Exception)
            {

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (IsValid)
            {
                if (hiddenfile_value.Value == string.Empty)
                {
                    check=Insert();
                }
                else
                {
                    Update();
                }
                if (check)
                {
                    Resetform();
                    BindingDataIntoGridview();
                }
            }
        }

        private bool Insert()
        {
            string imageServerPath = string.Empty;
            string imageFolderPath = "~/images/Products";
            string imageFilename = string.Empty;
            try
            {
                if(FileUpload1.HasFile)
                {
                    string fileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
                    String[] allowedExtensions = { ".jpg", ".gif", ".png",".webp" };
                    int maxSize = 1024000;
                    bool isValidFile = false;

                    try
                    {
                        for(int i=0;i<allowedExtensions.Length;i++)
                        {
                            if(fileExtention.ToLower()==allowedExtensions[i])
                            {
                                isValidFile = true;
                                break;
                            }
                        }

                        if (isValidFile)
                        {
                            if(FileUpload1.PostedFile.ContentLength< maxSize)
                            {
                                imageFilename = Path.GetFileName(FileUpload1.FileName);
                                imageServerPath = String.Format("{0}{1}", Server.MapPath(imageFolderPath),imageFilename);
                                FileUpload1.SaveAs(imageServerPath);
                            }
                            else
                            {
                                lblDisplay.Visible = true;
                                lblDisplay.Text = "The file has to be less than 1mb.";
                                return false;
                            }
                        }
                        else
                        {
                            lblDisplay.Visible = true;
                            lblDisplay.Text = "Invalid file,please try again.";
                            return false;
                        }
                    }
                    catch(Exception)
                    {
                        lblDisplay.Visible = true;
                        lblDisplay.Text = "The filecould not be uploaded.";
                        return false;
                    }
                }
                var strProductName = txtProductName.Text.Trim();
                var strImage = String.Format("{0}{1}",imageFolderPath,imageFilename);
                var strPrice = txtPrice.Text.Trim();
                var categoryID = drdlCategory.SelectedValue;
                var product = new DataAcessLayer.Models.Product
                {
                    ProductName = strProductName,
                    Image = strImage,
                    Price = Convert.ToDecimal(strPrice),
                    UserId=1,
                    CategoryId=Convert.ToInt32(categoryID)
                };
                logic.CreateNewProduct(product);
                return true;
            }
            catch (Exception ex)
            {
                lblDisplay.Visible = true;
                lblDisplay.Text = ex.Message;
                return false;
            }
        }

        private void Update()
        {
            try
            {
                var strProductName = txtProductName.Text.Trim();
                var strImage = String.Empty;//txtImage.Text.Trim()
                var strPrice = txtPrice.Text.Trim();
                var categoryID = drdlCategory.SelectedValue;
                var product = new DataAcessLayer.Models.Product
                {
                    ProductName = strProductName,
                    Image = strImage,
                    Price = Convert.ToDecimal(strPrice),
                    UserId = 1,
                    CategoryId = Convert.ToInt32(categoryID),
                    ProductId = Convert.ToInt32(hiddenfile_value.Value)
                };
                logic.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                lblDisplay.Visible = true;
                lblDisplay.Text = ex.Message;
            }
        }

        private void Resetform()
        {
            txtProductName.Text = string.Empty;
            //txtImage.Text = string.Empty;
            txtPrice.Text = string.Empty;
            divAdd_Edit.Visible = false;
            divContentDetail.Visible = false;
            divGridview.Visible = true;
            hiddenfile_value.Value = string.Empty;
            lblDisplay.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Resetform();
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
                var listData = logic.GetProductList();
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
                case "_edit":
                    divAdd_Edit.Visible = true;
                    divGridview.Visible = false;
                    hiddenfile_value.Value = strId;
                    LoadDataForEdit();
                    break;
                case "_delete":
                    try
                    {
                        logic.DeleteProduct(Convert.ToInt32(strId));
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
        private void LoadDataForEdit()
        {
            try
            {
                BindCategoryDataToDropdownList();
                var product = logic.GetProductById(Convert.ToInt32(hiddenfile_value.Value));
                txtProductName.Text = product.ProductName;
                //txtImage.Text = product.Image;
                txtPrice.Text = product.Price.ToString();
                drdlCategory.SelectedValue = product.CategoryId.ToString();
            }
            catch (Exception ex)
            {
                lblDisplay.Visible = true;
                lblDisplay.Text = ex.Message;
                return;
            }
        }
    }
}