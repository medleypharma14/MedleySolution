using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class testpage : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataSet dsUnits1 = new DataSet();
            //dsUnits1 = dbObj.Select_Units1();
            //if (dsUnits1.Tables[0].Rows.Count > 0)
            //{
            //    ddUnits1.DataSource = dsUnits1.Tables[0];
            //    ddUnits1.DataBind();
            //}
            //DataSet dsUnits2 = new DataSet();
            //dsUnits2 = dbObj.Select_Units2();
            //if (dsUnits2.Tables[0].Rows.Count > 0)
            //{
            //    ddUnits2.DataSource = dsUnits2.Tables[0];
            //    ddUnits2.DataBind();
            //}
            //DataSet dsUnits3 = new DataSet();
            //dsUnits3 = dbObj.Select_Units3();
            //if (dsUnits3.Tables[0].Rows.Count > 0)
            //{
            //    ddUnits3.DataSource = dsUnits3.Tables[0];
            //    ddUnits3.DataBind();
            //}
            //DataSet dsUnits4 = new DataSet();
            //dsUnits4 = dbObj.Select_Units4();
            //if (dsUnits4.Tables[0].Rows.Count > 0)
            //{
            //    ddUnits4.DataSource = dsUnits4.Tables[0];
            //    ddUnits4.DataBind();
            //}

           
        }
        protected void ddRoomListSecond_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            int count = ddUnits1.Items.Count;
            //foreach (DataListItem dl in ddRoomListALL.Items)
            // for (int i = 0; i < count; i++)
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Button btn = (Button)e.Item.FindControl("btns1");

                if (btn.CommandName == "1")
                {
                    btn.BackColor = System.Drawing.Color.Red;
                    btn.ForeColor = System.Drawing.Color.White;
                }
                else if (btn.CommandName == "2")
                {
                    btn.BackColor = System.Drawing.Color.Blue;
                    btn.ForeColor = System.Drawing.Color.White;

                    //btn.Enabled = false;
                }
                else if (btn.CommandName == "3")
                {
                    btn.BackColor = System.Drawing.Color.Green;
                    btn.ForeColor = System.Drawing.Color.White;

                    //btn.Enabled = false;
                }
                else
                {
                    btn.BackColor = System.Drawing.Color.Yellow;
                    btn.ForeColor = System.Drawing.Color.White;

                    //btn.Enabled = false;
                }

            }
        }
        protected void btnClick(object sender, EventArgs e)
        {

            //    Button cat = (sender as Button);
            //

            //    if (cat.BackColor == System.Drawing.Color.Blue)
            //    {
            //        ScriptManager.RegisterStartupScript(upan, upan.GetType(), "myFunctions", "myFunctions();", true);
            //        Button roomNo = (sender as Button);
            //string testRoomNo = Convert.ToString(roomNo.Text);
            ////string result = testRoomNo.Substring(0, testRoomNo.IndexOf("-"));
            //string result = testRoomNo;
            //DataSet ds = Rmc.UnCleanedRoomsToCleanedRooms(result);
            //Response.Redirect("Reception.aspx");
            //    };

            Button Btn = (sender as Button);
            Session["UnitId"] = Btn.CommandArgument.ToString();
            DataSet dsUnit = dbObj.Select_UnitsCheck(Convert.ToInt32(Session["UnitId"].ToString()));
            if (dsUnit.Tables[0].Rows.Count > 0)
            {
                lblFloor.Text = dsUnit.Tables[0].Rows[0]["Floor"].ToString();
                lblUnit.Text = dsUnit.Tables[0].Rows[0]["Unitname"].ToString();
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            switch (ddlNumberoffloors.SelectedValue)
            {
                case "1":
                    DataSet dsUnits1 = new DataSet();
                    dsUnits1 = dbObj.Select_Units1();
                    if (dsUnits1.Tables[0].Rows.Count > 0)
                    {
                        ddUnits1.DataSource = dsUnits1.Tables[0];
                        ddUnits1.DataBind();
                    }
                    break;
                case "2":
                    DataSet dsUnits2 = new DataSet();
                    dsUnits2 = dbObj.Select_Units2();
                    if (dsUnits2.Tables[0].Rows.Count > 0)
                    {
                        ddUnits2.DataSource = dsUnits2.Tables[0];
                        ddUnits2.DataBind();
                    }
                    break;
                case "3":
                    DataSet dsUnits3 = new DataSet();
                    dsUnits3 = dbObj.Select_Units3();
                    if (dsUnits3.Tables[0].Rows.Count > 0)
                    {
                        ddUnits3.DataSource = dsUnits3.Tables[0];
                        ddUnits3.DataBind();
                    }
                    break;
                case "4":
                    DataSet dsUnits4 = new DataSet();
                    dsUnits4 = dbObj.Select_Units4();
                    if (dsUnits4.Tables[0].Rows.Count > 0)
                    {
                        ddUnits4.DataSource = dsUnits4.Tables[0];
                        ddUnits4.DataBind();
                    }
                    break;

            }
        }
    }
}