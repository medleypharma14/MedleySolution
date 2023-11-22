using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class OrderGoodsPicking : System.Web.UI.Page
    {

        BSClass dbObj = new BSClass();
        int iPoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (iSupplierID != 0)
                //{

                //    DataSet dsEmplyId = new DataSet();
                //    dsEmplyId = dbObj.selectsuplier_bysuplierid(iSupplierID);
                //    ViewState["vssupl"] = iSupplierID;


                //}
                #region Load Po
                DataSet dsPO = new DataSet();
                dsPO = dbObj.Select_Goodspicking();
                if (dsPO.Tables[0].Rows.Count > 0)
                {
                    gvgoodspic.DataSource = dsPO.Tables[0];
                    gvgoodspic.DataBind();
                }
                #endregion

                #region Dropdown Approver
                DataSet dsApprovar = new DataSet();
                dsApprovar = dbObj.Select_Employeename();
                if (dsApprovar.Tables[0].Rows.Count > 0)
                {
                    ddlSelectapprover.DataSource = dsApprovar;
                    ddlSelectapprover.DataTextField = "EmployeeName";
                    ddlSelectapprover.DataValueField = "EmployeeID";
                    ddlSelectapprover.DataBind();
                    ddlSelectapprover.Items.Insert(0, "Select Approver");
                }
                #endregion
            }
        }
    }
}