using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace Project
{
    
    public partial class User : System.Web.UI.Page
    {
        UserLogic logic = new UserLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Case1: check detail view
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    divContentDetail.Visible = true;
                    divAdd_Edit.Visible = false;
                    var user = logic.GetUserById(Convert.ToInt32(Request.QueryString["id"]));
                    lblUsername.Text = user.Username;
                }
                //Case2: Binding data to grid view
                else
                {
                    BindingDataIntoGridview();
                    divAdd_Edit.Visible = false;
                    divContentDetail.Visible = false;
                }
            }
        }

        private void BindingDataIntoGridview()
        {
            try
            {
                var listData = logic.GetUserList();
                grvListData.DataSource = listData;
                grvListData.DataBind();
            }
            catch (Exception)
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
                BindingDataIntoGridview();
            }
        }

        private void Insert()
        {
            try
            {
                var strName = txtUsername.Text.ToString().Trim();
                var strPassword = txtPassword.Text.ToString().Trim();
                var user = new DataAcessLayer.Models.User
                {
                    Username = strName,
                    Password = strPassword
                };
                logic.CreateNewUser(user);
            }
            catch (Exception ex)
            {
                lblDisplay.Visible = true;
                lblDisplay.Text = ex.Message;
            }
        }

        private void Update()
        {
            try
            {
                var strName = txtUsername.Text.ToString().Trim();
                var strPassword = txtPassword.Text.ToString().Trim();
                var user = new DataAcessLayer.Models.User
                {
                    Username = strName,
                    Password = strPassword,
                    UserId = Convert.ToInt32(hiddenfile_value.Value)
                };
                logic.UpdateUser(user);
            }
            catch (Exception ex)
            {
                lblDisplay.Visible = true;
                lblDisplay.Text = ex.Message;
            }
        }

        private void Resetform()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
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
                        logic.DeleteUser(Convert.ToInt32(strId));
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
                var user = logic.GetUserById(Convert.ToInt32(hiddenfile_value.Value));
                txtUsername.Text = user.Username;
                txtPassword.Text = user.Password;
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