using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Text;
using System.IO;
using System.Data.OleDb;

namespace HomeAlertsAdmin.Admin
{
    public partial class ServiceReminder : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMonth.SelectedValue = Convert.ToString(DateTime.Today.Month);
                ddlYear.SelectedValue = Convert.ToString(DateTime.Today.Year);
                #region Calendar
                txtMonth.Text = ddlMonth.SelectedItem.Text;
                txtYear.Text = ddlYear.SelectedItem.Text;
                string month = txtMonth.Text;
                int yearofMonth = Convert.ToInt32(txtYear.Text);
                DateTime dateTime = Convert.ToDateTime(yearofMonth + "-" + month + "-" + "01");
                DataRow dr;
                DataTable dt = new DataTable();
                dt.Columns.Add("Sunday");
                dt.Columns.Add("Monday");
                dt.Columns.Add("Tuesday");
                dt.Columns.Add("Wednesday");
                dt.Columns.Add("Thursday");
                dt.Columns.Add("Friday");
                dt.Columns.Add("Saturday");

                dr = dt.NewRow();
                for (int i = 0; i < DateTime.DaysInMonth(dateTime.Year, dateTime.Month); i += 1)
                {
                    txtMonth.Text = Convert.ToDateTime(DateTime.Today.AddDays(0)).ToString("dddd");
                    txtmth.Text = Convert.ToDateTime(DateTime.Today.AddMonths(0)).ToString("MMM");
                    if (Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd") == "Sunday")
                    {
                        dr["Sunday"] = i + 1;
                    }
                    if (Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd") == "Monday")
                    {
                        dr["Monday"] = i + 1;
                    }
                    if (dateTime.AddDays(i).ToString("dddd") == "Tuesday")
                    {
                        dr["Tuesday"] = i + 1;
                    }
                    if (dateTime.AddDays(i).ToString("dddd") == "Wednesday")
                    {
                        dr["Wednesday"] = i + 1;

                    }
                    if (dateTime.AddDays(i).ToString("dddd") == "Thursday")
                    {
                        dr["Thursday"] = i + 1;
                    }
                    if (dateTime.AddDays(i).ToString("dddd") == "Friday")
                    {
                        dr["Friday"] = i + 1;
                    }
                    if (dateTime.AddDays(i).ToString("dddd") == "Saturday")
                    {
                        dr["Saturday"] = i + 1;
                        dt.Rows.Add(dr);
                        dr = dt.NewRow();
                        continue;
                    }
                    if (i == DateTime.DaysInMonth(dateTime.Year, dateTime.Month) - 1)
                    {
                        dt.Rows.Add(dr);
                        dr = dt.NewRow();

                    }

                }
                ViewState["dt"] = dt;
                gvgrid.DataSource = dt;
                gvgrid.DataBind();


                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {

                        String cellText = row[i].ToString();



                        if (cellText != "")
                        {
                            string dateText = "";
                            if (cellText.Count() == 1)
                            {
                                dateText = "0" + cellText;
                            }
                            else
                            {
                                dateText = cellText;
                            }
                            string date = Convert.ToDateTime(yearofMonth + "-" + month + "-" + dateText).ToShortDateString();

                            DataSet ds = objBs.NextServiceDetails(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue));

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                {
                                    //TableCell cell = e.Row.Cells[i];

                                    DateTime NextServiceDate = Convert.ToDateTime(ds.Tables[0].Rows[j]["NextServiceDate"]);
                                    if (NextServiceDate.ToShortDateString() == date)
                                    {
                                        DataSet ds_Date = objBs.NextServiceDetails_Bydate(NextServiceDate.ToString("yyyy-MM-dd"));
                                        if (ds_Date.Tables[0].Rows.Count > 0)
                                        {



                                            string TotalBooked = "";
                                            for (int k = 0; k < ds_Date.Tables[0].Rows.Count; k++)
                                            {

                                                TotalBooked += ds_Date.Tables[0].Rows[k]["customername"].ToString() + " " + ds_Date.Tables[0].Rows[k]["productname"].ToString() + Environment.NewLine + " , ";
                                                // row[i] = text + Environment.NewLine + " " + ds.Tables[0].Rows[k]["Name"].ToString() + " " + ds.Tables[0].Rows[k]["Purpose"].ToString();
                                            }
                                            string text = cellText;
                                            row[i] = text + "\r\n" + TotalBooked.Replace("\n", Environment.NewLine);
                                        }
                                    }
                                    else
                                    {
                                    }
                                }
                            }
                        }
                    }
                }

                gvgrid.DataSource = dt;
                gvgrid.DataBind();
                for (int i = 0; i < gvgrid.Rows.Count; i++)
                {
                    for (int j = 0; j < gvgrid.Rows[i].Cells.Count; j++)
                    {
                        string gvtext = gvgrid.Rows[i].Cells[j].Text;
                        if (gvtext.Contains(","))
                        {
                            gvgrid.Rows[i].Cells[j].BackColor = System.Drawing.Color.LightGreen;
                            gvtext = gvtext.Replace(",", "<br/>");
                            gvgrid.Rows[i].Cells[j].Text = gvtext;
                        }
                        gvgrid.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
                        if (gvtext.Contains("Hall"))
                        {
                            gvgrid.Rows[i].Cells[j].BackColor = System.Drawing.Color.Pink;
                        }
                    }

                }
                #endregion
                #region Today Ticket Grid
                DataSet dsOwner1;
                dsOwner1 = objBs.NextServiceDetails_Bydate(DateTime.Today.ToString("yyyy-MM-dd"));

                StringBuilder spList1 = new StringBuilder();
                for (int i = 0; i < dsOwner1.Tables[0].Rows.Count; i++)
                {
                    string customerid = dsOwner1.Tables[0].Rows[i]["customerid"].ToString();
                    string customername = dsOwner1.Tables[0].Rows[i]["customername"].ToString();
                    string productname = dsOwner1.Tables[0].Rows[i]["productname"].ToString();

                    spList1.Append("			    	   <tr >" +
                      "  <td  style='display:none'>" +
                                               " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                    "<input type='checkbox' class='checkboxes' value='1' />" +
                                                    "<span></span>" +
                                                "</label>" +
                                           " </td>" +

                                        "                       <td>" + customername + "</td>" +
                                       "			    		<td>" + productname + "</td>" +

                           "			    		<td>" +
                        " <div class='btn-group'>" +
                                                          "<button class='btn btn-xs green dropdown-toggle' type='button' data-toggle='dropdown' aria-expanded='false'> Actions" +
                                                              "<i class='fa fa-angle-down'></i>" +
                        " </button>" +

                                                    " <ul class='dropdown-menu pull-left' role='menu'>" +
                            "<li>" +
                                "<a href=ticket.aspx?customerid=" + customerid + ">" +
                                    "<i class='fa fa-pencil'></i> Create Ticket </a>" +
                            "</li>" +
                        //"<li>" +
                        //    "<a><asp:LinkButton ID='btndelete' runat='server' onclick=Delete('" + customerid + "','" + customerid + "')> " +
                        //        "<i class='fa fa-trash-o'></i> Delete </a>" +
                        //"</li>" +
                               " </ul>" +
                        "</div>" +
                            "			    		</td>" +

                                    "			    	</tr>");

                }


                lblReminder.Text = spList1.ToString();
                #endregion
            }
            
        }
        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMonth.Text = ddlMonth.SelectedItem.Text;
            txtYear.Text = ddlYear.SelectedItem.Text;
            string month = txtMonth.Text;
            int yearofMonth = Convert.ToInt32(txtYear.Text);
            DateTime dateTime = Convert.ToDateTime(yearofMonth + "-" + month + "-" + "01");
            DataRow dr;
            DataTable dt = new DataTable();
            dt.Columns.Add("Sunday");
            dt.Columns.Add("Monday");
            dt.Columns.Add("Tuesday");
            dt.Columns.Add("Wednesday");
            dt.Columns.Add("Thursday");
            dt.Columns.Add("Friday");
            dt.Columns.Add("Saturday");

            dr = dt.NewRow();
            for (int i = 0; i < DateTime.DaysInMonth(dateTime.Year, dateTime.Month); i += 1)
            {
                txtMonth.Text = Convert.ToDateTime(DateTime.Today.AddDays(0)).ToString("dddd");
                txtmth.Text = Convert.ToDateTime(DateTime.Today.AddMonths(0)).ToString("MMM");
                if (Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd") == "Sunday")
                {
                    dr["Sunday"] = i + 1;
                }
                if (Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd") == "Monday")
                {
                    dr["Monday"] = i + 1;
                }
                if (dateTime.AddDays(i).ToString("dddd") == "Tuesday")
                {
                    dr["Tuesday"] = i + 1;
                }
                if (dateTime.AddDays(i).ToString("dddd") == "Wednesday")
                {
                    dr["Wednesday"] = i + 1;

                }
                if (dateTime.AddDays(i).ToString("dddd") == "Thursday")
                {
                    dr["Thursday"] = i + 1;
                }
                if (dateTime.AddDays(i).ToString("dddd") == "Friday")
                {
                    dr["Friday"] = i + 1;
                }
                if (dateTime.AddDays(i).ToString("dddd") == "Saturday")
                {
                    dr["Saturday"] = i + 1;
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    continue;
                }
                if (i == DateTime.DaysInMonth(dateTime.Year, dateTime.Month) - 1)
                {
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();

                }

            }
            ViewState["dt"] = dt;
            gvgrid.DataSource = dt;
            gvgrid.DataBind();


            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    String cellText = row[i].ToString();



                    if (cellText != "")
                    {
                        string dateText = "";
                        if (cellText.Count() == 1)
                        {
                            dateText = "0" + cellText;
                        }
                        else
                        {
                            dateText = cellText;
                        }
                        string date = Convert.ToDateTime(yearofMonth + "-" + month + "-" + dateText).ToShortDateString();

                        DataSet ds = objBs.NextServiceDetails(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue));

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                //TableCell cell = e.Row.Cells[i];

                                DateTime NextServiceDate = Convert.ToDateTime(ds.Tables[0].Rows[j]["NextServiceDate"]);
                                if (NextServiceDate.ToShortDateString() == date)
                                {
                                    DataSet ds_Date = objBs.NextServiceDetails_Bydate(NextServiceDate.ToString("yyyy-MM-dd"));
                                    if (ds_Date.Tables[0].Rows.Count > 0)
                                    {



                                        string TotalBooked = "";
                                        for (int k = 0; k < ds_Date.Tables[0].Rows.Count; k++)
                                        {

                                            TotalBooked += ds_Date.Tables[0].Rows[k]["customername"].ToString() +" - "+ds_Date.Tables[0].Rows[k]["productname"].ToString() + Environment.NewLine + " , ";
                                            // row[i] = text + Environment.NewLine + " " + ds.Tables[0].Rows[k]["Name"].ToString() + " " + ds.Tables[0].Rows[k]["Purpose"].ToString();
                                        }
                                        string text = cellText;
                                      //  StringBuilder sb = new StringBuilder();
                                       // sb.Append("<h3>" + text + "</h3>");
                                      //  string caldate = sb.ToString();
                                        row[i] = text + ") "+ Environment.NewLine + "\r\n" + TotalBooked.Replace("\n", Environment.NewLine);
                                    }
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                }
            }

            gvgrid.DataSource = dt;
            gvgrid.DataBind();
            for (int i = 0; i < gvgrid.Rows.Count; i++)
            {
                for (int j = 0; j < gvgrid.Rows[i].Cells.Count; j++)
                {
                    string gvtext = gvgrid.Rows[i].Cells[j].Text;
                    if (gvtext.Contains(","))
                    {
                        gvgrid.Rows[i].Cells[j].BackColor = System.Drawing.Color.LightGreen;
                        gvtext = gvtext.Replace(",", "<br/>");
                        gvgrid.Rows[i].Cells[j].Text = gvtext;
                    }
                    gvgrid.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
                    if (gvtext.Contains("Hall"))
                    {
                        gvgrid.Rows[i].Cells[j].BackColor = System.Drawing.Color.Pink;
                    }
                }

            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMonth.Text = ddlMonth.SelectedItem.Text;
            txtYear.Text = ddlYear.SelectedItem.Text;
            string month = txtMonth.Text;
            int yearofMonth = Convert.ToInt32(txtYear.Text);
            DateTime dateTime = Convert.ToDateTime(yearofMonth + "-" + month + "-" + "01");
            DataRow dr;
            DataTable dt = new DataTable();
            dt.Columns.Add("Sunday");
            dt.Columns.Add("Monday");
            dt.Columns.Add("Tuesday");
            dt.Columns.Add("Wednesday");
            dt.Columns.Add("Thursday");
            dt.Columns.Add("Friday");
            dt.Columns.Add("Saturday");

            dr = dt.NewRow();
            for (int i = 0; i < DateTime.DaysInMonth(dateTime.Year, dateTime.Month); i += 1)
            {
                txtMonth.Text = Convert.ToDateTime(DateTime.Today.AddDays(0)).ToString("dddd");
                txtmth.Text = Convert.ToDateTime(DateTime.Today.AddMonths(0)).ToString("MMM");
                if (Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd") == "Sunday")
                {
                    dr["Sunday"] = i + 1;
                }
                if (Convert.ToDateTime(dateTime.AddDays(i)).ToString("dddd") == "Monday")
                {
                    dr["Monday"] = i + 1;
                }
                if (dateTime.AddDays(i).ToString("dddd") == "Tuesday")
                {
                    dr["Tuesday"] = i + 1;
                }
                if (dateTime.AddDays(i).ToString("dddd") == "Wednesday")
                {
                    dr["Wednesday"] = i + 1;

                }
                if (dateTime.AddDays(i).ToString("dddd") == "Thursday")
                {
                    dr["Thursday"] = i + 1;
                }
                if (dateTime.AddDays(i).ToString("dddd") == "Friday")
                {
                    dr["Friday"] = i + 1;
                }
                if (dateTime.AddDays(i).ToString("dddd") == "Saturday")
                {
                    dr["Saturday"] = i + 1;
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    continue;
                }
                if (i == DateTime.DaysInMonth(dateTime.Year, dateTime.Month) - 1)
                {
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();

                }

            }
            ViewState["dt"] = dt;
            gvgrid.DataSource = dt;
            gvgrid.DataBind();


            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    String cellText = row[i].ToString();



                    if (cellText != "")
                    {
                        string dateText = "";
                        if (cellText.Count() == 1)
                        {
                            dateText = "0" + cellText;
                        }
                        else
                        {
                            dateText = cellText;
                        }
                        string date = Convert.ToDateTime(yearofMonth + "-" + month + "-" + dateText).ToShortDateString();

                        DataSet ds = objBs.NextServiceDetails(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue));

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                //TableCell cell = e.Row.Cells[i];

                                DateTime NextServiceDate = Convert.ToDateTime(ds.Tables[0].Rows[j]["NextServiceDate"]);
                                if (NextServiceDate.ToShortDateString() == date)
                                {
                                    DataSet ds_Date = objBs.NextServiceDetails_Bydate(NextServiceDate.ToString("yyyy-MM-dd"));
                                    if (ds_Date.Tables[0].Rows.Count > 0)
                                    {



                                        string TotalBooked = "";
                                        for (int k = 0; k < ds_Date.Tables[0].Rows.Count; k++)
                                        {

                                            TotalBooked += ds_Date.Tables[0].Rows[k]["customername"].ToString() + " " + ds_Date.Tables[0].Rows[k]["productname"].ToString() + Environment.NewLine + " , ";
                                            // row[i] = text + Environment.NewLine + " " + ds.Tables[0].Rows[k]["Name"].ToString() + " " + ds.Tables[0].Rows[k]["Purpose"].ToString();
                                        }
                                        string text = cellText;
                                        row[i] = text + "\r\n" + TotalBooked.Replace("\n", Environment.NewLine);
                                    }
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                }
            }

            gvgrid.DataSource = dt;
            gvgrid.DataBind();
            for (int i = 0; i < gvgrid.Rows.Count; i++)
            {
                for (int j = 0; j < gvgrid.Rows[i].Cells.Count; j++)
                {
                    string gvtext = gvgrid.Rows[i].Cells[j].Text;
                    if (gvtext.Contains(","))
                    {
                        gvgrid.Rows[i].Cells[j].BackColor = System.Drawing.Color.LightGreen;
                        gvtext = gvtext.Replace(",", "<br/>");
                        gvgrid.Rows[i].Cells[j].Text = gvtext;
                    }
                    gvgrid.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;
                    if (gvtext.Contains("Hall"))
                    {
                        gvgrid.Rows[i].Cells[j].BackColor = System.Drawing.Color.Pink;
                    }
                }

            }
        }

        protected void gvgrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        //    //  e.Row.Cells[0].Attributes["onclick"] = "alert('" + e.Row.Cells[0].Text + "')";
        //    for (int i = 0; i < gvgrid.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < gvgrid.Rows[i].Cells.Count; j++)
        //        {
        //            string gvtext = gvgrid.Rows[i].Cells[j].Text;

        //            if (gvtext.Contains(" , "))
        //            {
        //                gvgrid.Rows[i].Cells[j].BackColor = System.Drawing.Color.LightGreen;
        //                gvtext = gvtext.Replace(",", Environment.NewLine);
        //            }

        //            if (gvtext.Contains("AC"))
        //            {
        //                //gvtext = System.Drawing.Color.Red;
        //                gvgrid.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Red;
        //            }
        //            else if (gvtext.Contains("Non AC"))
        //            {
        //                gvgrid.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Orange;
        //            }

        //            else if (gvtext.Contains("Hall"))
        //            {
        //                gvgrid.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Purple;
        //            }
        //            else if (gvtext.Contains("Total Bookings"))
        //            {
        //                // Button btnShow = (Button)gvgrid.Rows[i].Cells[j].FindControl("btnShow");
        //                //btnShow.Visible = true;

        //                //Button ButtonChange = new Button();

        //                //ButtonChange.Text = "Check in details";
        //                //ButtonChange.ID = "Check_" + i.ToString();
        //                //ButtonChange.Font.Size = FontUnit.Point(7);
        //                //ButtonChange.ControlStyle.CssClass = "button";
        //                //ButtonChange.Click += new System.EventHandler(test);
        //                //gvgrid.Rows[i].Cells[j].Controls.Add(ButtonChange);


        //                //LinkButton lnkButton = new LinkButton();
        //                //lnkButton.ID = "lnkdynamicbutton"; //Don't add DateTime.Now instead of that generate some random id
        //                //lnkButton.Text = "Click Me";
        //                //lnkButton.CssClass = "link_line";
        //                //lnkButton.Click += new System.EventHandler(lnkButton_Click);
        //                //gvgrid.Rows[i].Cells[j].Controls.Add(lnkButton);
        //                gvtext = gvtext.Replace(",", Environment.NewLine);
        //            }
        //            gvgrid.Rows[i].Cells[j].ForeColor = System.Drawing.Color.Black;


        //        }
        //    }
            
        }
    }
}