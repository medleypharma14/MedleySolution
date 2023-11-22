using DataLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public class BSClass
    {

        #region User Defined Objects
        DBAccess dbObj = null;
        #endregion

        #region Constructors
        public BSClass()
        {
            dbObj = new DBAccess();
        }
        #endregion

        #region select category master
        public DataSet selectcategorymaster()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblcategory order by category desc ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet selectcategorymaster(string BtnName)
        {
            string sQry;
            DataSet ds = new DataSet();
            if (BtnName == "Save")
            {
                sQry = "select * from tblcategory where IsActive='Yes'";

            }
            else
            {
                sQry = "select * from tblcategory";
            }
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet selectjobcarddesign(string jobcard)
        {
            string sQry;
            DataSet ds = new DataSet();
            sQry = "select tbltransJobcard.* from tbltransJobcard where jobcardid='" + jobcard + "'";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet selectallcarddesign(string job)
        {
            string sQry;
            DataSet ds = new DataSet();
            sQry = "select tbltransJobcard.* from tbltransJobcard where jobcardid='" + job + "' ";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet selectallcarddesignforworkorder(string job)
        {
            string sQry;
            DataSet ds = new DataSet();
            // sQry = "select tbltransworkorder.* from tbltransworkorder where workorderid='" + job + "' ";
            sQry = "select tw.*,p.* from tbltransworkorder as tw inner join tblPrice as p on p.priceid=tw.price where workorderid='" + job + "'";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet selectallcarddesignforpacking(string job)
        {
            string sQry;
            DataSet ds = new DataSet();
            // sQry = "select tbltransworkorder.* from tbltransworkorder where workorderid='" + job + "' ";
            sQry = "select tw.*,p.* from tbltranspacking as tw inner join tblPrice as p on p.priceid=tw.price where packingid='" + job + "'";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet bindalldesandjob()
        {
            string sQry;
            DataSet ds = new DataSet();
            sQry = "select Design,Jobcardno,transid from tblJobWork as jw inner join tblTransJobWork as tjw on tjw.JWid=jw.JWid ";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet selectcategorymaster(int iCat)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblcategory  where isdelete=0 and categoryid='" + iCat + "' ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet SelectDefinition(int isucCat)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblCategoryUser where CategoryUserID='" + isucCat + "' ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet selectcategorymaster_Dealer(string sStockTable)
        {
            DataSet ds = new DataSet();
            string sQry = "select b.category,b.categoryid from " + sStockTable + " a,tblcategory b where a.CategoryID=b.categoryid";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Unit
        public DataSet Select_UnitProduct()
        {
            DataSet ds = new DataSet();
            string sQry = "select distinct p.Productname,p.productid from tblunit u inner join tblProduct p on u.ProductId=p.ProductID";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Unitdetail(int Prodid)
        {
            DataSet ds = new DataSet();
            string sQry = "select u.unitname,u.Batchnumber,u.Expirydate,u.TotalQty,u.Status from tblunit u inner join tblProduct p on u.ProductId=p.ProductID where u.ProductId='"+Prodid+"'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Unitbatchname(int Prodid)
        {
            DataSet ds = new DataSet();
            string sQry = "select distinct u.Batchnumber from tblunit u inner join tblProduct p on u.ProductId=p.ProductID where u.ProductId='"+Prodid+"'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_UnitBatchdetail(int Prodid,string Batchno)
        {
            DataSet ds = new DataSet();
            string sQry = "select u.unitname,u.Batchnumber,u.Expirydate,u.TotalQty,u.Status from tblunit u inner join tblProduct p on u.ProductId=p.ProductID where u.ProductId='"+Prodid+"' and u.Batchnumber='"+ Batchno + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_UnitsCheck(int iId)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblunit where unitId=" + iId + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Units1()
        {
            DataSet ds = new DataSet();
            //string sQry = "select * from tblunit where floor=1 Order By UnitId";
            string sQry = "select * from tblunit Order By UnitId";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Units_Green_Number(int numbers)
        {
            DataSet ds = new DataSet();
            //string sQry = "select * from tblunit where floor=1 Order By UnitId";
            string sQry = "select top(" + numbers + ")* from tblunit where Isempty =1  Order By UnitId";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Units_Green_Numberforedit(int numbers,string unitname)
        {
            DataSet ds = new DataSet();
            //string sQry = "select * from tblunit where floor=1 Order By UnitId";
            string sQry = "select top(" + numbers + ")* from tblunit where Isempty =1  and Unitname<>'"+unitname+"'  Order By UnitId";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Units2()
        {
            DataSet ds = new DataSet();
            //string sQry = "select * from tblunit where floor=2 Order By UnitId";
            string sQry = "select * from tblunit where Isempty =1 Order By UnitId";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Units3()
        {
            DataSet ds = new DataSet();
            //string sQry = "select * from tblunit where floor=3 Order By UnitId";
            string sQry = "select * from tblunit where Isempty =1 Order By UnitId";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Units4()
        {
            DataSet ds = new DataSet();
            //string sQry = "select * from tblunit where floor=4 Order By UnitId";
            string sQry = "select * from tblunit where Isempty =1 Order By UnitId";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region select category ID
        public DataSet selectcategoryID(int iCategory)
        {
            DataSet ds = new DataSet();
            string sQry = "select category from tblcategory where categoryid=" + iCategory + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region select category master Description
        public DataSet selectcategorydecription(int iCategory)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblcategoryuser where categoryid=" + iCategory + "  and isdelete=0 ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet selectjabcode(int iCategory)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblfinishedgoods where categoryid=" + iCategory + "  and isdelete=0 ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet selectcategorydecriptionforDealer(int iCategory)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblcategoryuser where categoryid=" + iCategory + " and isdelete=0 ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }


        public int insertpurchase(string tblPurchase, string tblDayBook, string tblPO_, int DebtorId, string CreditorID, int VendorID, int DC_NO1, DateTime DC_Date, string Bill_NO, DateTime Bill_date, string SubTotal, double Discount, double Tax5, double Tax14, double TotalAmount, double dCst, double dExcise, int PurchaseType, string POOrderNo, string PayMode, int BankId, int ChequeNo, string Narration, string vendorname, string tblAuditMaster, string userid, string BtnName, string PurchaseTypename)
        {
            int isucess = 0;
            string sQry1;
            string DC_NO = string.Empty;

            DataSet ds = new DataSet();
            if (BtnName == "Save")
            {
                string sqry2 = "select MAX(DC_NO)+1 as DC_NO from  " + tblPurchase + "";
                ds = dbObj.InlineExecuteDataSet(sqry2);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["DC_NO"].ToString() == "")
                    {
                        DC_NO = "1";
                    }
                    else
                    {
                        DC_NO = ds.Tables[0].Rows[0]["DC_NO"].ToString();
                    }

                }

                string sqry = "insert into " + tblDayBook + "(TransDate,DebtorId,CreditorId,Narration,RefNo,Type,Amount)values('" + Convert.ToDateTime(DC_Date).ToString("yyyy/MM/dd") + "'," + DebtorId + ",'" + CreditorID + "','" + Narration + "'," + DC_NO + ",'Purchase','" + Convert.ToDouble(TotalAmount) + "')";
                isucess = dbObj.InlineExecuteNonQuery(sqry);

                string sQry = "select Max(TransNo) as TransNo from " + tblDayBook + "";
                ds = dbObj.InlineExecuteDataSet(sQry);

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string DayBookID = ds.Tables[0].Rows[0]["TransNo"].ToString();

                        string sqry1 = "insert into " + tblPurchase + "(VendorID,DC_NO,DC_Date,Bill_NO,Bill_date,SubTotal,Discount,Tax5,Tax14,TotalAmount,CST,Excise,PurchaseType,PurchaseOrderNO,PaymentMode,BankId,ChequeNo,Narration,DayBookTransNo)values('" + VendorID + "'," + DC_NO + ",'" + Convert.ToDateTime(DC_Date).ToString("yyyy/MM/dd") + "','" + Bill_NO + "','" + Convert.ToDateTime(Bill_date).ToString("yyyy/MM/dd") + "','" + SubTotal + "','" + Convert.ToDouble(Discount) + "','" + Convert.ToDouble(Tax5) + "','" + Convert.ToDouble(Tax14) + "','" + Convert.ToDouble(TotalAmount) + "','" + dCst + "','" + dExcise + "'," + PurchaseType + ",'" + POOrderNo + "','" + PayMode + "'," + BankId + ",'" + ChequeNo + "','" + Narration + "'," + DayBookID + ")";
                        isucess = dbObj.InlineExecuteNonQuery(sqry1);

                        string cdate1 = DateTime.Now.ToString("dd/MM/yyyy");
                        string shortDate1 = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                        DateTime cdate = DateTime.ParseExact(cdate1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime shortDate = DateTime.ParseExact(shortDate1, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                        if (BtnName == "Save")
                        {
                            sQry1 = "insert into " + tblAuditMaster + "( Type,Screen,BillNo,Amount,Bill_Date,Audit_Date,UserId,Ledgername,Description,Date) values ('Add','Purchase','" + DC_NO + "','" + TotalAmount + "','" + Convert.ToDateTime(DC_Date).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(shortDate).ToString("yyyy/MM/dd HH:mm:ss") + "','" + userid + "','" + vendorname + "','" + PurchaseTypename + "-" + POOrderNo + "-" + PayMode + "-" + Narration + "','" + Convert.ToDateTime(cdate).ToString("yyyy/MM/dd") + "')";

                        }
                        else
                        {
                            sQry1 = "insert into " + tblAuditMaster + "( Type,Screen,BillNo,Amount,Bill_Date,Audit_Date,UserId,Ledgername,Description,Date) values ('Edit','Purchase','" + DC_NO + "','" + TotalAmount + "','" + Convert.ToDateTime(DC_Date).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(shortDate).ToString("yyyy/MM/dd HH:mm:ss") + "','" + userid + "','" + vendorname + "','" + PurchaseTypename + "-" + POOrderNo + "-" + PayMode + "-" + Narration + "','" + Convert.ToDateTime(cdate).ToString("yyyy/MM/dd") + "')";
                        }
                        isucess = dbObj.InlineExecuteNonQuery(sQry1);

                    }
                }
                if (PurchaseType == 2)
                {
                    string strValue = POOrderNo;
                    string[] strArray = strValue.Split(',');

                    for (int i = 0; i < strArray.Count(); i++)
                    {
                        string cmd = "update  " + tblPO_ + " set Status='Y' where DC_NO=" + strArray[i] + "";
                        isucess = dbObj.InlineExecuteNonQuery(cmd);
                    }
                }

                if (ChequeNo == 0)
                {

                }
                else
                {
                    string cmd1 = "Update tblTransCheque set status='" + "Y" + "' where chequeno=" + ChequeNo + "";
                    isucess = dbObj.InlineExecuteNonQuery(cmd1);

                }
            }
            else
            {
                string sqry = "insert into " + tblDayBook + "(TransDate,DebtorId,CreditorId,Narration,RefNo,Type,Amount)values('" + Convert.ToDateTime(DC_Date).ToString("yyyy/MM/dd") + "'," + DebtorId + ",'" + CreditorID + "','" + Narration + "'," + DC_NO1 + ",'Purchase','" + Convert.ToDouble(TotalAmount) + "')";
                isucess = dbObj.InlineExecuteNonQuery(sqry);

                string sQry = "select Max(TransNo) as TransNo from " + tblDayBook + "";
                ds = dbObj.InlineExecuteDataSet(sQry);

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string DayBookID = ds.Tables[0].Rows[0]["TransNo"].ToString();

                        string sqry1 = "insert into " + tblPurchase + "(VendorID,DC_NO,DC_Date,Bill_NO,Bill_date,SubTotal,Discount,Tax5,Tax14,TotalAmount,CST,Excise,PurchaseType,PurchaseOrderNO,PaymentMode,BankId,ChequeNo,Narration,DayBookTransNo)values('" + VendorID + "'," + DC_NO1 + ",'" + Convert.ToDateTime(DC_Date).ToString("yyyy/MM/dd") + "','" + Bill_NO + "','" + Convert.ToDateTime(Bill_date).ToString("yyyy/MM/dd") + "','" + SubTotal + "','" + Convert.ToDouble(Discount) + "','" + Convert.ToDouble(Tax5) + "','" + Convert.ToDouble(Tax14) + "','" + Convert.ToDouble(TotalAmount) + "','" + dCst + "','" + dExcise + "'," + PurchaseType + "," + POOrderNo + ",'" + PayMode + "'," + BankId + ",'" + ChequeNo + "','" + Narration + "'," + DayBookID + ")";
                        isucess = dbObj.InlineExecuteNonQuery(sqry1);

                        string cdate1 = DateTime.Now.ToString("dd/MM/yyyy");
                        string shortDate1 = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                        DateTime cdate = DateTime.ParseExact(cdate1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime shortDate = DateTime.ParseExact(shortDate1, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                        if (BtnName == "Save")
                        {
                            sQry1 = "insert into " + tblAuditMaster + "( Type,Screen,BillNo,Amount,Bill_Date,Audit_Date,UserId,Ledgername,Description,Date) values ('Add','Purchase','" + DC_NO1 + "','" + TotalAmount + "','" + Convert.ToDateTime(DC_Date).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(shortDate).ToString("yyyy/MM/dd HH:mm:ss") + "','" + userid + "','" + vendorname + "','" + PurchaseTypename + "-" + POOrderNo + "-" + PayMode + "-" + Narration + "','" + Convert.ToDateTime(cdate).ToString("yyyy/MM/dd") + "')";

                        }
                        else
                        {
                            sQry1 = "insert into " + tblAuditMaster + "( Type,Screen,BillNo,Amount,Bill_Date,Audit_Date,UserId,Ledgername,Description,Date) values ('Edit','Purchase','" + DC_NO1 + "','" + TotalAmount + "','" + Convert.ToDateTime(DC_Date).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(shortDate).ToString("yyyy/MM/dd HH:mm:ss") + "','" + userid + "','" + vendorname + "','" + PurchaseTypename + "-" + POOrderNo + "-" + PayMode + "-" + Narration + "','" + Convert.ToDateTime(cdate).ToString("yyyy/MM/dd") + "')";
                        }
                        isucess = dbObj.InlineExecuteNonQuery(sQry1);

                    }
                }
                string cmd = "update  " + tblPO_ + " set Status='Y' where DC_NO=" + POOrderNo + "";
                isucess = dbObj.InlineExecuteNonQuery(cmd);

                if (ChequeNo == 0)
                {

                }
                else
                {
                    string cmd1 = "Update tblTransCheque set status='" + "Y" + "' where chequeno=" + ChequeNo + "";
                    isucess = dbObj.InlineExecuteNonQuery(cmd1);

                }
            }
            return isucess;
        }



        public DataSet GetLedgernames(int id, string type)
        {
            string sQry;
            DataSet ds = new DataSet();
            if (type == "New")
            {
                sQry = "select * from tblLedger where Groupid=" + id + " and IsActive='Yes'";
            }
            else
            {
                sQry = "select * from tblLedger where Groupid=" + id + "";
            }

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet GetJournalListLedgername()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblLedger";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet GetPartyname()
        {
            DataSet ds = new DataSet();
            string sQry = "select ledgerid,ledgername + ' - ' + companycode as Ledgername from tblLedger";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Ledgername(int types)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblLedger where Groupid=" + types + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }


        public DataSet Ledgername_Selected()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblLedger where status='N'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet searchExpense(string Name, int id)
        {
            string sqry = string.Empty;
            DataSet ds = new DataSet();

            if (id == 1)
                sqry = "SELECT tblGroups.GroupName as GName,* from tblLedger inner join tblGroups on tblLedger.GroupId = tblGroups.GroupId WHERE LedgerName LIKE '%" + Name + "%'  and tblLedger.GroupId =3 order by Ledgerid desc  ";
            else if (id == 2)
                sqry = "SELECT tblGroups.GroupName as GName,* from tblLedger inner join tblGroups on tblLedger.GroupId = tblGroups.GroupId WHERE MobileNo LIKE '%" + Name + "%' and tblLedger.GroupId =3  order by Ledgerid desc  ";

            ds = dbObj.InlineExecuteDataSet(sqry);

            if (ds.Tables[0].Rows.Count > 0)
                return ds;
            else
                return null;
        }

        public DataSet GetPurchaseAC(string sName)
        {
            DataSet ds = new DataSet();
            string sQry = "select LedgerID from tblLedger where GroupID='6' and LedgerName='" + sName + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        #region select PurchaseOrderDet
        public DataSet PurchaseOrderDet(int PONo, string TransPO, string tPO)
        {
            DataSet ds = new DataSet();
            string sQry = "select a.LedgerID,a.LedgerName as LedgerName ,a.City,a.Address,a.MobileNo,a.Pincode,a.Area ,c.*,d.category as category ,e.Definition as Definition from tblLedger a ," + TransPO + " b ," + tPO + " c ,tblcategory d,tblCategoryUser e where a.Ledgerid=b.VendorName  and d.categoryid=c.categoryId  and e.CategoryUserID=c.ItemName and c.PO_Id=" + PONo + " and b.pono=" + PONo + "";



            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet PurchasedcOrderDet(int PONo, string TransPO, string tPO)
        {
            DataSet ds = new DataSet();
            string sQry = "select a.LedgerID,a.LedgerName as LedgerName ,a.City,a.Address,a.MobileNo,a.Pincode,a.Area ,c.*,b.*,d.category as category ,e.Definition as Definition from tblLedger a ," + TransPO + " b ," + tPO + " c ,tblcategory d,tblCategoryUser e where a.Ledgerid=b.VendorID  and d.categoryid=c.categoryId  and e.CategoryUserID=c.DescriptionId and c.DC_Id=" + PONo + " and b.DC_NO=" + PONo + "";



            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet PurchasedcOrderDetnew(int PONo, string TransPO)
        {
            DataSet ds = new DataSet();
            string sQry = "select sum(b.totalamount) as totoal,sum(b.tax14) as tax,sum(b.Discount) as dis from " + TransPO + " b where b.DC_NO=" + PONo + "";



            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet PurchaseOrderDetl(int PONo, string TransPO, string tPO)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from " + TransPO + " where PO_Id=" + PONo + " ";



            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet PurchaseOrderDetStatusN(int PONo, string TransPO, string tPO)
        {
            DataSet ds = new DataSet();
            string sQry = "select " + TransPO + ".*, " + TransPO + ".Qty - " + TransPO + ".returnqty as Nqty from " + TransPO + " where PO_Id=" + PONo + " and Status = 'N'";



            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet PurchasedcOrderDetStatusN(int PONo, string TransPO, string tPO)
        {
            DataSet ds = new DataSet();
            string sQry = "select " + TransPO + ".*, " + TransPO + ".Qty - " + TransPO + ".returnqty as Nqty from " + TransPO + " where DC_Id=" + PONo + " and Status = 'N'";



            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }


        #endregion

        public int inserttranspurchase(string tblPurchase, string tblTransPurchase, string P_Id1, int CategoryId, int DescriptionId, int Qty, double Rate, int Units, double Dicount, double Tax, double Amount, int pono, string tblTransPO, string btnName)
        {
            int iSucess = 0;
            DataSet ds1 = new DataSet();
            string P_Id = string.Empty;

            if (btnName == "Save")
            {
                string sqry2 = "select MAX(DC_NO) as DC_NO from  " + tblPurchase + "";
                ds1 = dbObj.InlineExecuteDataSet(sqry2);

                P_Id = ds1.Tables[0].Rows[0]["DC_NO"].ToString();




                string sqry = "insert into " + tblTransPurchase + "(P_Id,CategoryId,DescriptionId,Qty,Rate,Units,Dicount,Tax,Amount)values('" + P_Id + "','" + CategoryId + "','" + DescriptionId + "','" + Qty + "','" + Rate + "','" + Units + "'," + Dicount + "," + Tax + ",'" + Amount + "')";
                iSucess = dbObj.InlineExecuteNonQuery(sqry);

                //string sQry = "select qty,returnqty from " + tblTransPO + " where ItemName = '" + DescriptionId + "' and po_id = " + pono + " ";
                //DataSet ds = dbObj.InlineExecuteDataSet(sQry);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    int sqty = Convert.ToInt32(ds.Tables[0].Rows[0]["qty"]);
                //    int returnqty = Convert.ToInt32(ds.Tables[0].Rows[0]["returnqty"]);
                //    if ((sqty - (Qty + returnqty)) > 0)
                //    {
                //        string sqryt = "update " + tblTransPO + " set returnqty = " + (Qty + returnqty) + ", status ='N' where ItemName = '" + DescriptionId + "' and po_id = " + pono + " ";
                //        iSucess = dbObj.InlineExecuteNonQuery(sqryt);
                //    }
                //    else
                //    {
                //        string sqryt = "update " + tblTransPO + " set returnqty = " + (Qty + returnqty) + ", status ='Y' where ItemName = '" + DescriptionId + "' and po_id = " + pono + " ";
                //        iSucess = dbObj.InlineExecuteNonQuery(sqryt);
                //    }
                //}
            }
            else
            {
                string sqry = "insert into " + tblTransPurchase + "(P_Id,CategoryId,DescriptionId,Qty,Rate,Units,Dicount,Tax,Amount)values('" + P_Id1 + "','" + CategoryId + "','" + DescriptionId + "','" + Qty + "','" + Rate + "','" + Units + "'," + Dicount + "," + Tax + ",'" + Amount + "')";
                iSucess = dbObj.InlineExecuteNonQuery(sqry);

                //string sQry = "select qty,returnqty from " + tblTransPO + " where ItemName = '" + DescriptionId + "' and po_id = " + pono + " ";
                //DataSet ds = dbObj.InlineExecuteDataSet(sQry);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    int sqty = Convert.ToInt32(ds.Tables[0].Rows[0]["qty"]);
                //    int returnqty = Convert.ToInt32(ds.Tables[0].Rows[0]["returnqty"]);
                //    if ((sqty - (Qty + returnqty)) > 0)
                //    {
                //        string sqryt = "update " + tblTransPO + " set returnqty = " + (Qty + returnqty) + ", status ='N' where ItemName = '" + DescriptionId + "' and po_id = " + pono + " ";
                //        iSucess = dbObj.InlineExecuteNonQuery(sqryt);
                //    }
                //    else
                //    {
                //        string sqryt = "update " + tblTransPO + " set returnqty = " + (Qty + returnqty) + ", status ='Y' where ItemName = '" + DescriptionId + "' and po_id = " + pono + " ";
                //        iSucess = dbObj.InlineExecuteNonQuery(sqryt);
                //    }
                //}
            }

            return iSucess;
        }

        public DataSet selectcategorydecriptionforDealer(int iCategory, int iCustomerID)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblcategoryuser where categoryid=" + iCategory + "  and customerID='" + iCustomerID + "' and isdelete=0 ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet selectcategorydecriptionforDealer(int iCategory, int iCustomerID, int iSubCategory)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblcategoryuser where categoryid=" + iCategory + " and categoryuserid=" + iSubCategory + "  and customerID='" + iCustomerID + "' and isdelete=0 ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet GetTax(int iSubCategory)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblcategoryuser where CategoryUserId=" + iSubCategory + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet GetTaxd(int iSubCategory)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblcategoryuser inner join tblBrand on tblbrand.brandid=tblcategoryuser.brandcode where CategoryUserId=" + iSubCategory + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet selectSerial(string iCategory)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblCategoryUser where Definition like'%" + iCategory + "%' ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        #endregion

        #region select category master Description
        public DataSet selectcategoryalldecription(string BtnName, string stablename, string companyid)
        {
            string sQry;
            DataSet ds = new DataSet();
            if (BtnName == "Save")
            {
                if (companyid == "0")
                {

                    sQry = "select * from tblcategoryuser as cu inner join tblstock_" + stablename + " as s on cu.categoryuserid=s.subcategoryid where IsActive='Yes' and s.Available_QTY > 0";
                }
                else
                {
                    sQry = "select * from tblcategoryuser as cu inner join tblstock_" + stablename + " as s on cu.categoryuserid=s.subcategoryid where IsActive='Yes' and companyid='" + companyid + "' and s.Available_QTY > 0";
                }
            }
            else
            {
                if (companyid == "0")
                {
                    sQry = "select * from tblcategoryuser";
                }
                else
                {
                    sQry = "select * from tblcategoryuser where companyid='" + companyid + "'";
                }
            }
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }



        public DataSet selectsize()
        {
            string sQry;
            DataSet ds = new DataSet();

            sQry = "select * from tblsize ";

            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        #endregion

        #region Login
        public DataSet Login(string username, string password)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbllogin where username ='" + username + "'and password='" + password + "' ";//@username and Password=@password";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Insert Category
        public int insertcategory(int categorydrp, string Definition, string sSno, string sSize, int iCheck, int iTax, int sBrandCode, string IsActive, string tblAuditMaster, string userid, string brandname, string categoryname, double Discount, int type, int UOM, double met, string mrp, string dp, string ws, string reoder, string minlead, string supp)
        {
            int iSuccess = 0;
            string sQry = "insert into tblCategoryUser( CategoryID,Definition,Serial_No,Size,isChecked,Tax,BrandCode,IsActive,Discount,type,uom,meter,Mrp,Dsp,Wsp,Reorderlevel,Minimumleadperiod,suppliers) values ('" + categorydrp + "','" + Definition + "','" + sSno + "','" + sSize + "','" + iCheck + "','" + iTax + "','" + sBrandCode + "','" + IsActive + "','" + Discount + "','" + type + "','" + UOM + "','" + met + "','" + mrp + "','" + dp + "','" + ws + "','" + reoder + "','" + minlead + "','" + supp + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            //string sUser = tblAuditMaster;

            //string[] branchid = sUser.Split('_');

            //string branchid1 = branchid[1].ToString();


            string cdate1 = DateTime.Now.ToString("dd/MM/yyyy");
            string shortDate1 = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            DateTime cdate = DateTime.ParseExact(cdate1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime shortDate = DateTime.ParseExact(shortDate1, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);


            string sQry1 = "insert into " + tblAuditMaster + "( Type,Screen,BillNo,Amount,Bill_Date,Audit_Date,UserId,Ledgername,Description,Date) values ('Add','Product',0,0,'" + Convert.ToDateTime(cdate).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(shortDate).ToString("yyyy/MM/dd HH:mm:ss") + "','" + userid + "','" + Definition + "','" + categoryname + "-" + brandname + "-" + IsActive + "-" + iTax + "','" + Convert.ToDateTime(cdate).ToString("yyyy/MM/dd") + "')";

            iSuccess = dbObj.InlineExecuteNonQuery(sQry1);

            return iSuccess;

        }
        #endregion

        #region Insert CategoryLabel
        public int InsertCategoryLabel(string Category, string isactive, string tblAuditMaster, string userid)
        {
            int iSuccess = 0;
            string sQry = "insert into tblCategory( Category,IsActive) values ('" + Category + "','" + isactive + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);

            //string sUser=  tblAuditMaster;

            //string[] branchid  = sUser.Split('_');

            //string branchid1 = branchid[1].ToString();

            string cdate = DateTime.Now.ToString("dd/MM/yyyy");
            string shortDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            DateTime cdate1 = DateTime.ParseExact(cdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime shortDate1 = DateTime.ParseExact(shortDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);



            string sQry1 = "insert into " + tblAuditMaster + "( Type,Screen,BillNo,Amount,Bill_Date,Audit_Date,UserId,Ledgername,Description,Date) values ('Add','Category',0,0,'" + Convert.ToDateTime(cdate1).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(shortDate1).ToString("yyyy/MM/dd HH:mm:ss") + "','" + userid + "','" + Category + "','" + Category + "','" + Convert.ToDateTime(cdate1).ToString("yyyy/MM/dd") + "')";

            iSuccess = dbObj.InlineExecuteNonQuery(sQry1);

            return iSuccess;


        }
        #endregion


        #region Fit
        public int InsertFit(string Fit, string isactive, string tblAuditMaster, string userid)
        {
            int iSuccess = 0;
            string sQry = "insert into tblFit(Fit,IsActive) values ('" + Fit + "','" + isactive + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);

            //string sUser=  tblAuditMaster;

            //string[] branchid  = sUser.Split('_');

            //string branchid1 = branchid[1].ToString();

            string cdate = DateTime.Now.ToString("dd/MM/yyyy");
            string shortDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            DateTime cdate1 = DateTime.ParseExact(cdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime shortDate1 = DateTime.ParseExact(shortDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);



            string sQry1 = "insert into " + tblAuditMaster + "( Type,Screen,BillNo,Amount,Bill_Date,Audit_Date,UserId,Ledgername,Description,Date) values ('Add','Fit',0,0,'" + Convert.ToDateTime(cdate1).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(shortDate1).ToString("yyyy/MM/dd HH:mm:ss") + "','" + userid + "','" + Fit + "','" + Fit + "','" + Convert.ToDateTime(cdate1).ToString("yyyy/MM/dd") + "')";

            iSuccess = dbObj.InlineExecuteNonQuery(sQry1);

            return iSuccess;



        }

        public DataSet editFit(int FitID)
        {

            DataSet ds = new DataSet();
            string sQry = "select * from tblFit  where FitID='" + FitID + "' ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;

        }
        #endregion

        #region Width
        public int InsertWidth(string width, string isactive, string tblAuditMaster, string userid)
        {
            int iSuccess = 0;


            string check = "SELECT isnull(COLUMN_NAME,0) as column_name FROM   INFORMATION_SCHEMA.COLUMNS WHERE   TABLE_NAME = 'tblsizesetting' and column_name='" + width + "Width'";
            DataSet ds = dbObj.InlineExecuteDataSet(check);

            if (ds.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                string sQry = "insert into tblWidth( Width,IsActive) values ('" + width + "','" + isactive + "')";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);

                //string sUser=  tblAuditMaster;

                //string[] branchid  = sUser.Split('_');

                //string branchid1 = branchid[1].ToString();




                string sq = "alter table tblsizesetting add [" + width + "Width] nvarchar(100)  default (0)";
                iSuccess = dbObj.InlineExecuteNonQuery(sq);

                string s = "Update tblsizesetting set [" + width + "Width]='0'";
                iSuccess = dbObj.InlineExecuteNonQuery(s);


                string cdate = DateTime.Now.ToString("dd/MM/yyyy");
                string shortDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                DateTime cdate1 = DateTime.ParseExact(cdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime shortDate1 = DateTime.ParseExact(shortDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);



                string sQry1 = "insert into " + tblAuditMaster + "( Type,Screen,BillNo,Amount,Bill_Date,Audit_Date,UserId,Ledgername,Description,Date) values ('Add','Width',0,0,'" + Convert.ToDateTime(cdate1).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(shortDate1).ToString("yyyy/MM/dd HH:mm:ss") + "','" + userid + "','" + width + "','" + width + "','" + Convert.ToDateTime(cdate1).ToString("yyyy/MM/dd") + "')";

                iSuccess = dbObj.InlineExecuteNonQuery(sQry1);

            }
            return iSuccess;



        }

        public DataSet editwidth(int WidthID)
        {

            DataSet ds = new DataSet();
            string sQry = "select * from tblWidth  where Widthid='" + WidthID + "' ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;

        }
        #endregion

        #region Unit Master
        public int InsertUnit(string UnitName, string isactive, string tblAuditMaster, string userid)
        {
            int iSuccess = 0;
            string sQry = "insert into tblUnit(UnitName,IsActive) values ('" + UnitName + "','" + isactive + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);

            //string sUser=  tblAuditMaster;

            //string[] branchid  = sUser.Split('_');

            //string branchid1 = branchid[1].ToString();

            string cdate = DateTime.Now.ToString("dd/MM/yyyy");
            string shortDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            DateTime cdate1 = DateTime.ParseExact(cdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime shortDate1 = DateTime.ParseExact(shortDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);



            string sQry1 = "insert into " + tblAuditMaster + "( Type,Screen,BillNo,Amount,Bill_Date,Audit_Date,UserId,Ledgername,Description,Date) values ('Add','Width',0,0,'" + Convert.ToDateTime(cdate1).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(shortDate1).ToString("yyyy/MM/dd HH:mm:ss") + "','" + userid + "','" + UnitName + "','" + UnitName + "','" + Convert.ToDateTime(cdate1).ToString("yyyy/MM/dd") + "')";

            iSuccess = dbObj.InlineExecuteNonQuery(sQry1);

            return iSuccess;



        }

        public DataSet editUnit(int UnitID)
        {

            DataSet ds = new DataSet();
            string sQry = "select * from tblUnit  where UnitID='" + UnitID + "' ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;

        }
        #endregion

        #region Product
        public DataSet Select_Product()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblProduct where IsDel=0 Order By ProductID desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_ExpiryThisyear(string year1, string year2)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblProduct where Validtill between '" + year1 + "' and '" + year2 + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        //public DataSet Select_ExpiryNextyear()
        //{
        //    DataSet ds = new DataSet();
        //    string sQry = "select * from tblProduct where Validtill between '2024-01-01' and '2024-12-12'";
        //    ds = dbObj.InlineExecuteDataSet(sQry);
        //    return ds;
        //}
        //public int InsertProduct(DateTime Initialadditiondate, string sProductname, string sLicenseno, DateTime Validtill, string sDosageform, string sPacktype, string sPacksize, string sPriceperpack, string sStrength, string sCurrency, string sProductmanufacture, string sProductmanufacturecountry, string sProductcode, string sProductGTINbarcode, string sProductaprovalauthority, string sProductaprovalstatus, string sTax, string sTaxationtype, string sProductphoto, string sSelectaproval, int iApproverId, string sStatus)
        //{
        //    int iSuccess = 0;
        //    string sQry = "insert into tblProduct(Initialadditiondate,Productname,Licenseno,validtill,Dosageform,Packtype,Packsize,Priceperpack,Strength,Currency,Productmanufacture,Productmanufacturecountry,Productcode,ProductGTINbarcode,Productaprovalauthority,Productaprovalstatus,Tax,Taxationtype,Productphoto,Selectaproval,Approvarid,Status) values ('" + Initialadditiondate.ToString("yyyy/MM/dd") + "','" + sProductname + "','" + sLicenseno + "','" + Validtill.ToString("yyyy/MM/dd") + "','" + sDosageform + "','" + sPacktype + "','" + sPacksize + "','" + sPriceperpack + "','" + sStrength + "','" + sCurrency + "','" + sProductmanufacture + "','" + sProductmanufacturecountry + "','" + sProductcode + "','" + sProductGTINbarcode + "','" + sProductaprovalauthority + "','" + sProductaprovalstatus + "','" + sTax + "','" + sTaxationtype + "','" + sProductphoto + "','" + sSelectaproval + "'," + iApproverId + ",'" + sStatus + "')";
        //    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
        //    return iSuccess;

        //}
        public int InsertProduct(DateTime Initialadditiondate, string sProductname, string sLicenseno, string sDosageform, string sPacksize, string sStrength, string sProductmanufacture, string sProductcatogory, string sProductcode, string sProductGTINbarcode, string sTaxationtype, int iApproverId, string sStatus, string sProductqty, string PIPcode,string productstatus)
        {
            int iSuccess = 0;
            string sQry = "insert into tblProduct(Initialadditiondate,Productname,Licenseno,Dosageform,Packsize,Strength,Productmanufacture,Productcatogory,Productcode,ProductGTINbarcode,Taxationtype,Approvarid,Status,ProductQty,PIPcode,IsDel,Productstatus) values ('" + Initialadditiondate.ToString("yyyy/MM/dd") + "','" + sProductname + "','" + sLicenseno + "','" + sDosageform + "','" + sPacksize + "','" + sStrength + "','" + sProductmanufacture + "','" + sProductcatogory + "','" + sProductcode + "','" + sProductGTINbarcode + "','" + sTaxationtype + "'," + iApproverId + ",'" + sStatus + "','" + sProductqty + "','" + PIPcode + "',0,'"+productstatus+"')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public DataSet selectproduct_byProdID(string sProductId)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblProduct where ProductID=" + sProductId + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet selectProduct_byProductId(int iProductId)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblProduct where ProductID=" + iProductId + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        //public DataSet selectPO_byEditPoid(int iPoid)
        //{
        //    DataSet ds = new DataSet();
        //    string sQry = "select * from tblProduct where ProductID=" + iProductId + "";
        //    ds = dbObj.InlineExecuteDataSet(sQry);
        //    return ds;
        //}
        public DataSet selectProduct_qty(int iProductId)
        {
            DataSet ds = new DataSet();
            string sQry = "select sum(FinalbatchQty) as productqty from tblGoodReceipts gr,tblTransGoodReceipts tgr  where gr.GRId=tgr.GRId and gr.ProductId='" + iProductId + "' and tgr.BatchStatus='Release'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        //public int UpdateProduct(int sProductID, DateTime Initialadditiondate, string sProductname, string sLicenseno, DateTime Validtill, string sDosageform, string sPacktype, string sPacksize, string sPriceperpack, string sStrength, string sCurrency, string sProductmanufacture, string sProductmanufacturecountry, string sProductcode, string sProductGTINBarcode, string sProductaprovalauthority, string sProductaprovalstatus, string sTax, string sTaxationtype, string sProductphoto, string sSelectaproval, int iApproverId, string sStatus)
        //{
        //    int iSuccess = 0;
        //    string sQry = "update  tblProduct set Initialadditiondate='" + Initialadditiondate.ToString("yyyy/MM/dd") + "', Productname ='" + sProductname + "',Licenseno='" + sLicenseno + "',validtill='" + Validtill + "',Dosageform='" + sDosageform + "',Packtype='" + sPacktype + "',Packsize='" + sPacksize + "',Priceperpack='" + sPriceperpack + "',Strength='" + sStrength + "', Currency ='" + sCurrency + "', Productmanufacture ='" + sProductmanufacture + "', Productmanufacturecountry ='" + sProductmanufacturecountry + "',Productcode='" + sProductcode + "',ProductGTINbarcode='" + sProductGTINBarcode + "', Productaprovalauthority ='" + sProductaprovalauthority + "', Productaprovalstatus ='" + sProductaprovalstatus + "', Tax ='" + sTax + "', Taxationtype ='" + sTaxationtype + "', Productphoto ='" + sProductphoto + "',Selectaproval='" + sSelectaproval + "',Approvarid=" + iApproverId + ", Status='" + sStatus + "' where ProductID=" + sProductID + "";
        //    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
        //    return iSuccess;
        //}
        public int UpdateProduct(int sProductID, DateTime Initialadditiondate, string sProductname, string sLicenseno, string sDosageform, string sPacksize, string sStrength, string sProductmanufacture, string sProductcatogory, string sProductcode, string sProductGTINBarcode, string sTaxationtype, string sProdutqty, string PIPcode,string productstatus)
        {
            int iSuccess = 0;
            string sQry = "update  tblProduct set Initialadditiondate='" + Initialadditiondate.ToString("yyyy/MM/dd") + "', Productname ='" + sProductname + "',Licenseno='" + sLicenseno + "',Dosageform='" + sDosageform + "',Packsize='" + sPacksize + "',Strength='" + sStrength + "', Productmanufacture ='" + sProductmanufacture + "',Productcatogory='" + sProductcatogory + "',Productcode='" + sProductcode + "',ProductGTINbarcode='" + sProductGTINBarcode + "', Taxationtype ='" + sTaxationtype + "',Approvarid=0, Status='0',ProductQty='" + sProdutqty + "',PIPcode='" + PIPcode + "',Productstatus='"+productstatus+"' where ProductID=" + sProductID + "";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        public int deleteProduct(int iProductID)
        {
            int iSucess = 0;
            string sQry = "update tblProduct set IsDel=1  WHERE ProductID ='" + iProductID + "' ";
            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        #endregion

        #region Suplier

        public DataSet Select_Suplier()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from Suplier s, tblcountry c where s.Country=c.CountryID and IsDel=0  ORDER BY SupplierID DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Supliername(string Companyname)
        {
            DataSet ds = new DataSet();
            string sQry = "select CompanyName from Suplier where CompanyName='"+ Companyname + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int InsertSuplier(DateTime Initialadditionaldate, string sCompanyName, string sContactName, string sContactName1, string sContactName2, string sContactName3, string sContactName4, string sContactEmail, string sContactNumber, DateTime ValidTill, string sSupplierStatus, string sSupplierQualification, string sAddressLine1, string sAddressLine2, string sAddressLine3, string sAddressLine4, string sAddressLine5, string sCountry, string sPostCode)
        {
            int iSuccess = 0;
            string sQry = "insert into Suplier(Initialadditionaldate,CompanyName,ContactName,ContactName1,ContactName2,ContactName3,ContactName4,ContactEmail,ContactNumber,ValidTill,SupplierStatus,SupplierQualification,AddressLine1,AddressLine2,AddressLine3,AddressLine4,AddressLine5,Country,PostCode,SelectApproverid,IsDel) values ('" + Initialadditionaldate.ToString("yyyy/MM/dd") + "','" + sCompanyName + "','" + sContactName + "','" + sContactName1 + "','" + sContactName2 + "','" + sContactName3 + "','" + sContactName4 + "','" + sContactEmail + "','" + sContactNumber + "','" + ValidTill.ToString("yyyy/MM/dd") + "','" + sSupplierStatus + "','" + sSupplierQualification + "','" + sAddressLine1 + "','" + sAddressLine2 + "','" + sAddressLine3 + "','" + sAddressLine4 + "','" + sAddressLine5 + "','" + sCountry + "','" + sPostCode + "',0,0)";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;




        }
        public int InsertTransSuplier(int iSupplierID, string PersonName, string sContactEmail, string sContactNumber, string sAddressLine, int sCountry, string sPostCode, string sCountryCode)
        {
            int iSuccess = 0;
            string sQry = "insert into tblTransSupplier(SupplierID,PersonName,Address,Country,Postcode,Phone,CountryCode,EmailId) values ('" + iSupplierID + "','" + PersonName + "','" + sAddressLine + "'," + sCountry + ",'" + sPostCode + "','" + sContactNumber + "','" + sCountryCode + "','" + sContactEmail + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;




        }
        public DataSet selectsuplier_bysuplierid(int iSuplierID)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from Suplier where SupplierID=" + iSuplierID + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet selectTranssuplier_bysuplierid(int iSuplierID)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransSupplier where SupplierID=" + iSuplierID + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_MaxSupplier()
        {
            DataSet ds = new DataSet();

            string sQry = "SELECT ISNULL(MAX(SupplierID), 0) +1 AS Id FROM Suplier";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int UpdateSuplier(int iSupplierID, DateTime Initialadditionaldate, string sCompanyName, string sContactName, string sContactName1, string sContactName2, string sContactName3, string sContactName4, string sContactEmail, string sContactNumber, DateTime ValidTill, string sSupplierStatus, string sSupplierQualification, string sAddressLine1, string sAddressLine2, string sAddressLine3, string sAddressLine4, string sAddressLine5, string sCountry, string sPostCode)
        {
            int iSuccess = 0;
            string sQry = "update Suplier set Initialadditionaldate='" + Initialadditionaldate.ToString("yyyy/MM/dd") + "', CompanyName ='" + sCompanyName + "',ContactName='" + sContactName + "',ContactName1='" + sContactName1 + "',ContactName2='" + sContactName2 + "',ContactName3='" + sContactName3 + "',ContactName4='" + sContactName4 + "',ContactEmail='" + sContactEmail + "',ContactNumber='" + sContactNumber + "',ValidTill='" + ValidTill.ToString("yyyy/MM/dd") + "',SupplierStatus='" + sSupplierStatus + "',SupplierQualification ='" + sSupplierQualification + "',AddressLine1='" + sAddressLine1 + "',AddressLine2='" + sAddressLine2 + "',AddressLine3='" + sAddressLine3 + "',AddressLine4='" + sAddressLine4 + "',AddressLine5='" + sAddressLine5 + "',Country='" + sCountry + "',PostCode='" + sPostCode + "' where SupplierID=" + iSupplierID + "";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;




        }
        public int deleteSuplier(int iSuplierId)
        {
            int iSucess = 0;
            string sQry = "update Suplier set SupplierStatus='Not Active',IsDel='1'  WHERE SupplierID ='" + iSuplierId + "' ";
            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        public int deleteTransSuplier(int iSuplierId)
        {
            int iSucess = 0;
            string sQry = "delete tblTransSupplier  WHERE SupplierID ='" + iSuplierId + "' ";
            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }

        public DataSet selectsuplier_Contactnumsupid(int Supid,string connum)
        {
            DataSet ds = new DataSet();
            string sQry = "select ContactNumber from Suplier where Supplierid<>'"+ Supid + "'and ContactNumber='"+ connum + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet selectsuplier_Contactnum(string Connum)
        {
            DataSet ds = new DataSet();
            string sQry = "select ContactNumber from Suplier where ContactNumber='" + Connum + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet selectsuplier_Contactnumtranssupid(int Supid, string connum)
        {
            DataSet ds = new DataSet();
            string sQry = "select Phone from tblTransSupplier where Supplierid<>'"+ Supid + "' and Phone='" + connum + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet selectsuplier_Contactnumtrans(string Connum)
        {
            DataSet ds = new DataSet();
            string sQry = "select Phone from tblTransSupplier where Phone='"+ Connum + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region
        public DataSet SelectLogin(string sUsername, string sPassword)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblLogin l inner join tblEmployee e on l.EmployeeID=e.EmployeeID   where Username='"+sUsername+"' and Password ='"+sPassword+"'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Transpot
        public DataSet SelectTranspot()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTranspotMaster  order by id desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Check_Transnumberupdate(string PhnNo, int transid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTranspotMaster where ContactNum='" + PhnNo + "' and id<>'" + transid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Check_Transnumber(string PhnNo)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTranspotMaster where ContactNum='" + PhnNo + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet CheckTranspotname(string transpot)
        {
            DataSet ds = new DataSet();
            string sQry = "select transpot from tblTranspotMaster where transpot='"+ transpot + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int InsertTranspot(string stranspot,DateTime DOJ,DateTime ExpiryDate,string Contnum,string Address)
        {
            int iSuccess = 0;
            string sQry = "insert into tblTranspotMaster(transpot,DOJ,ExpiryDate,ContactNum,Address) values ('" + stranspot + "','"+ DOJ.ToString("yyyy/MM/dd") + "','"+ ExpiryDate.ToString("yyyy/MM/dd") + "','"+Contnum+"','"+Address+"')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        public DataSet DeleteTranspot(int iid)
        {
            DataSet ds = new DataSet();
            string sQry = "delete from tblTranspotMaster where id=" + iid + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet SelectTranspot_byId(int iid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTranspotMaster where id=" + iid + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int UpdateTranspot(int iid, string sTranspot,string DOJ,string ExpiryDate, string Contnum, string Address)
        {
            int iSuccess = 0;
            string sQry = "update tblTranspotMaster set transpot='" + sTranspot + "',DOJ='"+ Convert.ToDateTime(DOJ).ToString("yyyy/MM/dd") + "',ExpiryDate='"+ Convert.ToDateTime(ExpiryDate).ToString("yyyy/MM/dd") + "',ContactNum='"+ Contnum + "',Address='"+ Address + "' where id=" + iid + "";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        public DataSet Select_Transpotname()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTranspotMaster order by id";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Designation
        public DataSet SelectDesignation()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from Designation where IsDel=0  order by DesignationID desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet CheckDesignation(string Designation)
        {
            DataSet ds = new DataSet();
            string sQry = "select Designation,IsDel from Designation where Designation='" + Designation + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet SelectDesignation_byId(int iDesgId)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from Designation where DesignationId=" + iDesgId + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int InsertDesignation(string sDesignation)
        {
            int iSuccess = 0;
            string sQry = "insert into Designation(Designation,IsDel) values ('" + sDesignation + "',0)";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;




        }
        public int UpdateDesignation(int iDesgId, string sDesignation)
        {
            int iSuccess = 0;
            string sQry = "update Designation set Designation='" + sDesignation + "' where DesignationID=" + iDesgId + "";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public int UpdateDesignationinsert(string sDesignation)
        {
            int iSuccess = 0;
            string sQry = "update Designation set IsDel=0 where Designation='" + sDesignation + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
            public DataSet DeleteDesignation(int iDesignationId)
        {
            DataSet ds = new DataSet();
            string sQry = "Update  Designation set IsDel=1 where DesignationID=" + iDesignationId + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Warehouse
        public int Insert_Warehouse(string sWarehouseName, string sWarehouseCode, string sFloorNo, string sUnitName, string sNumberofUnity, string sSelectapproval)
        {
            int iSuccess = 0;
            string sQry = "insert into tblWarehouse(WarehouseName,WarehouseCode,FloorNo,UnitName,NumberofUnity,Selectapproval) values ('" + sWarehouseName + "','" + sWarehouseCode + "','" + sFloorNo + "','" + sUnitName + "','" + sNumberofUnity + "','" + sSelectapproval + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        public DataSet Select_Warehouse()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblWarehouse;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_byWarehouseId(int iWarehouseId)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblWarehouse where WarehouseID=" + iWarehouseId + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Login
        public int Insert_Login(string sUsername, string sPassword)
        {
            int iSuccess = 0;
            string sQry = "insert into tblLogin(Username,Password,IsDel) values ('" + sUsername + "','" + sPassword + "',0)";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;


        }
        public int Update_Login(string sUsername, string sPassword, int iEmployeeID)
        {
            int iSuccess = 0;
            string sQry = "update tblLogin set Username='" + sUsername + "',Password='" + sPassword + "' where EmployeeID='" + iEmployeeID + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;


        }
        #endregion

        #region Employee

        public DataSet Select_Employee()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT *, d.Designation AS DesignationName  FROM tblEmployee e JOIN Designation d ON e.Designation = d.DesignationID  JOIN tblLogin l ON e.EmployeeID = l.EmployeeID where e.IsDel=0 ORDER BY e.EmployeeID DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Employeename()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblEmployee where IsDel=0 order by EmployeeID";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Check_Employeename(string EmployeeName)
        {
            DataSet ds = new DataSet();
            string sQry = "select EmployeeName from tblEmployee where EmployeeName='"+ EmployeeName + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Check_Phonno(string PhnNo)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblEmployee where PhoneNumber='"+ PhnNo + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Check_Phonnoupdate(string PhnNo,int Empid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblEmployee where PhoneNumber='"+PhnNo+"' and EmployeeID<>'"+Empid+"'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Check_Username(string UserName)
        {
            DataSet ds = new DataSet();
            string sQry = "select Username from tblLogin where Username='" + UserName + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Check_UsernameandEmpname(string Empname,int Employeeid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblLogin l inner join tblEmployee e on e.EmployeeID=l.EmployeeID where e.EmployeeID='"+ Employeeid + "' and e.EmployeeName='"+ Empname + "' ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Employeeedid(int iEmployeeid)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT * FROM tblEmployee s INNER JOIN tblLogin l ON s.EmployeeID = l.EmployeeID WHERE s.EmployeeID = '" + iEmployeeid + "';";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public int Insert_Employee(string sEmployeeName, DateTime DateofBirth, DateTime DateofJoining, string sGender, string sDesignation, string sEmail, string sPhoneNumber, string sAddress)
        {
            int iSuccess = 0;
            string sQry = "insert into tblEmployee(EmployeeName,DateofBirth,DateofJoining,Gender,Designation,Email,PhoneNumber,Address,IsDel) values ('" + sEmployeeName + "','" + DateofBirth.ToString("yyyy/MM/dd") + "','" + DateofJoining.ToString("yyyy/MM/dd") + "','" + sGender + "','" + sDesignation + "','" + sEmail + "','" + sPhoneNumber + "','" + sAddress + "',0)";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;


        }
        public DataSet selectEmployee_byEmployeeId(int iEmployeeId)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblEmployee where EmployeeID=" + iEmployeeId + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet DeleteEmployee(int iEmployeeId)
        {
            DataSet ds = new DataSet();
            string sQry = "update  tblEmployee set IsDel=1 where EmployeeID=" + iEmployeeId + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            DataSet ds1 = new DataSet();
            string sQry1 = "update  tblLogin set IsDel=1 where EmployeeID=" + iEmployeeId + "";
            ds1 = dbObj.InlineExecuteDataSet(sQry1);
            return ds;
        }


        public int UpdateEmployee(int iEmployeeID, string sEmployeeName, DateTime DateofBirth, DateTime DateofJoining, string sGender, string sDesignation, string sEmail, string sPhoneNumber, string sAddress)
        {
            int iSuccess = 0;
            string sQry = "update  tblEmployee set EmployeeName='" + sEmployeeName + "', DateofBirth ='" + DateofBirth.ToString("yyyy/MM/dd") + "',DateofJoining='" + DateofJoining.ToString("yyyy/MM/dd") + "',Gender='" + sGender + "',Designation='" + sDesignation + "',Email='" + sEmail + "',PhoneNumber='" + sPhoneNumber + "',Address='" + sAddress + "' where EmployeeID=" + iEmployeeID + "";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;




        }


        #endregion

        public int InsertAddCustomer(DateTime Initialadditiondate, string sCustomerName, string sContactName, string sContactEmail, string sContactNumber, DateTime Validtill, string sDefaultcurrency, string sCustomerStatus, string sCustomerQualification, string sAddressLine1, string sAddressLine2, string sAddressLine3, string sTown, string sCountry, string sPostcode, string sSelectApprover)
        {
            int iSuccess = 0;
            string sQry = "insert into AddCustomer(Initialadditiondate,CustomerName,ContactName,ContactEmail,ContactNumber,Validtill,Defaultcurrency,CustomerStatus,CustomerQualification,AddressLine1,AddressLine2,AddressLine3,Town,Country,Postcode,SelectApprover) values ('" + Initialadditiondate.ToString("yyyy/MM/dd") + "','" + sCustomerName + "','" + sContactName + "','" + sContactEmail + "','" + sContactNumber + "','" + Validtill.ToString("yyyy/MM/dd") + "','" + sDefaultcurrency + "','" + sCustomerStatus + "','" + sCustomerQualification + "','" + sAddressLine1 + "','" + sAddressLine2 + "','" + sAddressLine3 + "','" + sTown + "','" + sCountry + "','" + sPostcode + "','" + sSelectApprover + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        #region Country
        public DataSet Select_Country()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblCountry";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion


        //#region createPo
        //public int InsertProducts(int Productid, string sLicenseno, string sProductname, string sDosageform, string sStrength, string sPacktype, string sPacksize, string sPoQty, string sPriceperpack, string sTotalproductamt)
        //{
        //    int iSuccess = 0;
        //    string sQry = "insert into TempPo(Productid,Licenseno,Productname,Dosageform,Strength,Packtype,Packsize,PoQty,Priceperpack,Totalproductamt) values ('" + Productid + "','" + sLicenseno + "','" + sProductname + "','" + sDosageform + "','" + sStrength + "','" + sPacktype + "','" + sPacksize + "','" + sPoQty + "','" + sPriceperpack + "','" + sTotalproductamt + "')";
        //    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
        //    return iSuccess;

        //}
        //public DataSet Select_CreatePO()
        //{
        //    DataSet ds = new DataSet();
        //    string sQry = "select * from TempPo order by Poid";
        //    ds = dbObj.InlineExecuteDataSet(sQry);
        //    return ds;
        //}
        //public DataSet getSuppliername()
        //{
        //    DataSet ds = new DataSet();
        //    string sQry = "select * from Suplier order by SupplierID";
        //    ds = dbObj.InlineExecuteDataSet(sQry);
        //    return ds;
        //}
        //public DataSet getProductname()
        //{
        //    DataSet ds = new DataSet();
        //    string sQry = "select * from tblProduct order by ProductID";
        //    ds = dbObj.InlineExecuteDataSet(sQry);
        //    return ds;
        //}
        //#endregion

        #region Insert UOM
        //public DataSet editumo(int UMOID)
        //{

        //    DataSet ds = new DataSet();
        //    string sQry = "select * from tbluom  where uomid='" + UMOID + "' ";
        //    ds = dbObj.InlineExecuteDataSet(sQry);
        //    return ds;

        //}




        #endregion


        #region SO Master
        public int InsertSoProducts(int Productid,  string sProductname, string sDosageform, string sStrength, string sSoQty, string sPriceperpack, string sVat, string sTotaltamt)
        {
            int iSuccess = 0;
            string sQry = "insert into TempSo(Productid,Productname,Dosageform,Strength,SoQty,Priceperpack,VAT,Totalamount) values ('" + Productid + "','" + sProductname + "','" + sDosageform + "','" + sStrength + "','" + sSoQty + "','" + sPriceperpack + "','" + sVat + "','" + sTotaltamt + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public DataSet selectSO_bySOid(int iSoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TempSo where Soid=" + iSoid + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet SOdatesearch(DateTime fromdate, DateTime todate)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT s.Soid, s.SOdatetime, sp.CompanyName,ts.PersonName,ts.Phone,ts.EmailId, s.Amount, s.Status,s.SOPrintno,s.Deliverydate FROM TblSO s inner join  tblTransSupplier ts on ts.transSupplierid=s.Supplierid inner join  Suplier sp ON sp.SupplierID = ts.SupplierID WHERE s.SOdatetime BETWEEN '" + fromdate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' ORDER BY s.Soid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet SOMonthsearch(int Month,int Year)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT s.Soid,s.SOdatetime,sp.CompanyName,ts.PersonName,ts.Phone,ts.EmailId,s.Amount,s.Status,s.SOPrintno,s.Deliverydate FROM TblSO s INNER JOIN   tblTransSupplier ts on ts.transSupplierid=s.Supplierid inner join  Suplier sp ON sp.SupplierID = ts.SupplierID WHERE  YEAR(s.Deliverydate) = '" + Year+"' AND MONTH(s.Deliverydate) = '"+Month+"' ORDER BY  s.Soid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_CreateSO()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TempSo order by Soid";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int deleteSO(int Productid)
        {
            int iSucess = 0;
            string sQry = "delete TempSo  WHERE Productid ='" + Productid + "' ";
            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        public int InsertSoDetails(string sSuppliername, DateTime Podatetime, int iSelectapprover, string sStatus, string sAmount, string iSOprintMax,string deladdress,string Refno,DateTime Deliverydate)
        {
            int iSuccess = 0;
            string sQry = "insert into TblSO(SupplierId,SOdatetime,ApproverId,Status,Amount,SOPrintno,IsReturn,DelAddress,Refno,Deliverydate,Dispatch) values ('" + sSuppliername + "','" + Podatetime.ToString("yyyy/MM/dd") + "','" + iSelectapprover + "','" + sStatus + "','" + sAmount + "','" + iSOprintMax + "',0,'"+deladdress+"','"+Refno+"','"+ Deliverydate.ToString("yyyy/MM/dd")+ "','Pending')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        public int InsertTransSo(int Soid, int Productid, string sLicenseno, string sProductname, string sDosageform, string sStrength, string sPacktype, string sPacksize, string sSoQty, string sPriceperpack, string sVAT, string sTotalamount)
        {
            int iSuccess = 0;
            string sQry = "insert into tblTransSo(Soid,Productid,Licenseno,Productname,Dosageform,Strength,Packtype,Packsize,SoQty,Priceperpack,VAT,Totalamount,IsReturn,Dispatch) values (" + Soid + ",'" + Productid + "','" + sLicenseno + "','" + sProductname + "','" + sDosageform + "','" + sStrength + "','" + sPacktype + "','" + sPacksize + "','" + sSoQty + "','" + sPriceperpack + "','" + sVAT + "','" + sTotalamount + "',0,'Pending')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public DataSet GetMaxSO()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT ISNULL(MAX(Soid), 0) +1 AS Soid FROM TblSO";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet GetMaxSO_only()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT Isnull(MAX(Soid),1) AS Soid FROM TblSO";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_SoGrid()
        {
            DataSet ds = new DataSet();
            string sQry = "select s.Soid,s.SOPrintno, s.SOdatetime, s.Deliverydate,s.Status,ts.PersonName, ts.Phone, ts.EmailId,s.Amount,sup.CompanyName from tblso s inner join tblTransSupplier ts on s.supplierid=ts.TransSupplierID inner join Suplier sup  on sup.SupplierID=ts.SupplierID  WHERE ts.TransSupplierID = s.SupplierID ORDER BY s.Soid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_SOProduct(int iSoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransSo Productid  where Soid ='" + iSoid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int ClearTempSO()
        {
            int iSucess = 0;
            string sQry = "truncate table TempSo";
            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        public DataSet selectSO_bySoid(int iSoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblSO where Soid=" + iSoid + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_CreateSo(int iSoid)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT * FROM tblSO  WHERE Soid = '" + iSoid + "';";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_UpdateSo(int iSoid)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT * FROM tblTransSo  WHERE Soid = '" + iSoid + "';";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int UpdateCreateSo(int iSoid, string sSuppliername, DateTime Sodatetime, int iSelectapproverid, string sStatus, string sAmount,string DelAddress,string Refno,DateTime Deliverydate)
        {
            int iSuccess = 0;
            string sQry = "Update tblSO set SupplierId='" + sSuppliername + "',SOdatetime='" + Sodatetime.ToString("yyyy/MM/dd") + "',ApproverId='" + iSelectapproverid + "',Amount='" + sAmount + "',Status='" + sStatus +"',DelAddress='"+ DelAddress + "',Refno='"+Refno+ "',Deliverydate='" + Deliverydate.ToString("yyyy/MM/dd") + "' where Soid='" + iSoid + "';";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        #endregion

        #region Pomaster
        public DataSet getSuppliername(string todaydate)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from Suplier where  ValidTill>='"+ todaydate + "' and SupplierStatus='Active' order by SupplierID  ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getsupplierforreturn(string todaydate,int supid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransSupplier ts inner join suplier s on s.supplierid=ts.supplierid  where ts.SupplierID='"+ supid + "'  and ValidTill>='" + todaydate + "' and SupplierStatus='Active' order by ts.SupplierID";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getCompanySuppliername(int supid,string todaydate)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from Suplier s inner join tblTransSupplier ts on s.SupplierID=ts.SupplierID  where s.SupplierID='"+ supid + "' and  ValidTill>='" + todaydate + "' order by ts.TransSupplierID";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getSupplierAddress(string supid)
        {
            DataSet ds = new DataSet();
            string sQry = "select Address from tblTransSupplier where TransSupplierID='" + supid+"'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getCompanyname(string todaydate)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from Suplier where ValidTill>='"+ todaydate + "' and SupplierStatus='Active'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getSuppliernameaddress()
        {
            DataSet ds = new DataSet();
            string sQry = "select ContactName,AddressLine1 from Suplier order by SupplierID";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getProductname()
        {
            DataSet ds = new DataSet();
            string sQry = "select ProductId,Productname from tblProduct where IsDel=0 and Productstatus='Active'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getProductnamepo()
        {
            DataSet ds = new DataSet();
            string sQry = "select ProductId,Productname from tblProduct where IsDel=0 and Productstatus='Active'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int InsertProducts(int Productid, string sProductname, string sDosageform, string sStrength, string sPoQty, string sPriceperpack,string VAT, string sTotalproductamt)
        {
            int iSuccess = 0;
            string sQry = "insert into TempPo(Productid,Productname,Dosageform,Strength,PoQty,Priceperpack,VAT,Productamt) values ('" + Productid + "','" + sProductname + "','" + sDosageform + "','" + sStrength + "','" + sPoQty + "','" + sPriceperpack + "','"+ VAT + "','" + sTotalproductamt + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }

        public DataSet Select_CreatePO()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TempPo order by Poid";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet selectPO_byPOid(int iPoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TempPo where Poid=" + iPoid + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet GetMaxPO()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT ISNULL(MAX(Poid), 0) +1 AS Poid FROM TblPO";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet GetMaxPO_only()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT ISnull(MAX(Poid),1) AS Poid FROM TblPO";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int InsertDetails(string sSuppliername, DateTime Podatetime, int iSelectapproverid, string sStatus, string sAmount, string iPOprintMax)
        {
            int iSuccess = 0;
            string sQry = "insert into TblPO(SupplierId,Podatetime,ApproverId,Status,Amount,IsGoodReceived,POprintno) values ('" + sSuppliername + "','" + Podatetime.ToString("yyyy/MM/dd") + "','" + iSelectapproverid + "','" + sStatus + "','" + sAmount + "',0,'" + iPOprintMax + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        public int InsertTransPOProducts(int POId, int Productid, string sLicenseno, string sProductname, string sDosageform, string sStrength, string sPoQty, string sPriceperpack,string VAT, string sTotalproductamt)
        {
            int iSuccess = 0;
            string sQry = "insert into tblTransPo(POid,Productid,Licenseno,Productname,Dosageform,Strength,PoQty,Priceperpack,VAT,Productamt,IsGoodReceived) values (" + POId + ",'" + Productid + "','" + sLicenseno + "','" + sProductname + "','" + sDosageform + "','" + sStrength + "','" + sPoQty + "','" + sPriceperpack + "','"+VAT+"','" + sTotalproductamt + "',0)";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public DataSet Selecttranspo()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TbltransPo";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet selectPO_byPoid(int iPoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblPO where Poid=" + iPoid + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public int deletePomaster(int iProductid)
        {
            int iSucess = 0;
            string sQry = "delete TempPo  WHERE Productid ='" + iProductid + "' ";
            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        public int ClearTempPO()
        {
            int iSucess = 0;
            string sQry = "truncate table TempPo";
            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        public DataSet Select_CreatePo(int iPoid)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT * FROM tblPO  WHERE Poid = '" + iPoid + "';";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_UpdatePo(int iPoid)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT * FROM tblTransPo  WHERE Poid = '" + iPoid + "';";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int UpdateCreatePo(int iPoid, string sSuppliername, DateTime Podatetime, int iSelectapproverid, string sStatus, string sAmount)
        {
            int iSuccess = 0;
            string sQry = "Update tblPO set SupplierId='" + sSuppliername + "',Podatetime='" + Podatetime.ToString("yyyy/MM/dd") + "',ApproverId='" + iSelectapproverid + "',Amount='" + sAmount + "',Status='" + sStatus + "' where Poid='" + iPoid + "';";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }
        public int UpdatePO_GoodReceipt(int iTransPoid, int ProdId,string status,int Returnid)
        {
            int iSuccess = 0;
            if (Returnid == 0)
            {
                if (status == "Approved")
                {

                    string sQry1 = "Update tblTransPo set IsGoodReceived=1 where poid=" + iTransPoid + " and Productid=" + ProdId + "";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry1);

                }
                else
                {

                    string sQry = "Update tblTransPo set IsGoodReceived=0 where poid=" + iTransPoid + " and Productid=" + ProdId + "";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);

                }
            }
            else
            {
                if (status == "Approved")
                {

                    string sQry1 = "Update tblTransReturn set IsGoodReceived=1 where Returnid=" + Returnid + " and Productid=" + ProdId + "";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry1);

                }
                else
                {

                    string sQry = "Update tblTransReturn set IsGoodReceived=0 where Returnid=" + Returnid + " and Productid=" + ProdId + "";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);

                }
            }
           
            return iSuccess;
        }
        public int UpdatePO_GoodReceiptforreject(int iTransPoid, int ProdId, int Returnid)
        {
            int iSuccess = 0;
            if (Returnid == 0)
            {
                    string sQry1 = "Update tblTransPo set IsGoodReceived=0 where poid=" + iTransPoid + " and Productid=" + ProdId + "";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry1);
            }
            else
            {

                    string sQry1 = "Update tblTransReturn set IsGoodReceived=0 where Returnid=" + Returnid + " and Productid=" + ProdId + "";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry1);

            }

            return iSuccess;
        }
        //public DataSet select_Transpo()
        //{
        //    DataSet ds = new DataSet();
        //    string sQry = "select * from tblTransPo order by Poid;
        //    ds = dbObj.InlineExecuteDataSet(sQry);
        //    return ds;
        //}
        public DataSet select_Transpo()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransPo order by Poid";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_Po()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblPo order by Poid";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_Po1()
        {
            DataSet ds = new DataSet();
            string sQry = "select distinct po.Poid,po.POPrintno from tblPO po, tblTransPo tpo where po.Poid=tpo.Poid and tpo.isgoodreceived<>1 and po.Status='Approved' order by Poid desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_Return()
        {
            DataSet ds = new DataSet();
            string sQry = "select distinct r.Returnid,r.ReturnPrintno from TblReturn r, tblTransReturn tr where r.Returnid=tr.Returnid and tr.IsGoodReceived<>1  and r.Status='Approved' and tr.ReturnAmount<>'0'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_poid(int ipoid, int iproductid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbltransPo where Poid='" + ipoid + "' and Productid='" + iproductid + "' ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }


        #region goods picking
        public DataSet Select_Goodspicking()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransSo ts inner join Suplier s on ts.SupplierID=s.SupplierID;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        #region Sampling report
        public DataSet Samplingreport(string sBatchNo)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblGoodReceipts gr inner join  tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on gr.ProductId=p.ProductID inner join tblUnit u on u.TransGRId=gr.GRId Where gr.Batchnumber='" + sBatchNo + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #endregion sampling
        public int InsertSamplingProducts(string sBatchno, string GRId, string ProductID, string sProductname, string sStrength, string sBatchQty, string sUnits, string sPalletsrefno, string sSampleQty, string sFinalbatchQty, string sBatchstatus)
        {
            int iSuccess = 0;
            string sQry = "insert into tblSamproduct(BatchNo,GRId,ProductID,ProductName,Strength,BatchQty,Units,PalletsRefNo,SampleQty,FinalBatchQty,BatchStatus) values ('" + sBatchno + "','" + GRId + "','" + ProductID + "','" + sProductname + "','" + sStrength + "','" + sBatchQty + "','" + sUnits + "','" + sPalletsrefno + "','" + sSampleQty + "','" + sFinalbatchQty + "','" + sBatchstatus + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public int UpdateTransGRsam(string iunitname, string sSampleQty, string sFinalbatchQty)
        {
            int iSuccess = 0;
            string sQry = "update tblTransGoodReceipts set SampleQty='" + sSampleQty + "', FinalbatchQty='" + sFinalbatchQty + "' where Unitname='" + iunitname + "';";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public int UpdateUnitQty(int iGRId, string Unitname, int iProductId, string sBatchNo, String Expirydate, int iTotalqty, string sStatus, string Spalletsrefno,int Returnid)
        {
            int iSuccess = 0;
            if (iTotalqty == 0)
            {
                string sQry = "update  tblUnit set TransGRId=0,ProductId=0,Batchnumber=0,Expirydate='1900-01-01',Totalqty=0,Status='',Palletsrefno='',Isempty=1,Returnid=0 where TransGrid='" + iGRId + "' ";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);

                string sqry1 = "delete tblTransGoodReceipts where TransGRId='" + iGRId + "' ";
                int succes1 = dbObj.InlineExecuteNonQuery(sqry1);

            }
            else
            {
                if (Returnid == 0)
                {
                    string sQry = "update  tblUnit set TransGRId=" + iGRId + ",ProductId='" + iProductId + "',Batchnumber='" + sBatchNo + "',Expirydate='" + Expirydate + "',Totalqty='" + iTotalqty + "',Status='" + sStatus + "',Palletsrefno='" + Spalletsrefno + "',Isempty=0,Returnid=0 where Unitname='" + Unitname + "'";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }
                else
                {
                    string sQry = "update  tblUnit set TransGRId='"+ iGRId + "',ProductId='" + iProductId + "',Batchnumber='" + sBatchNo + "',Expirydate='" + Expirydate + "',Totalqty='" + iTotalqty + "',Status='" + sStatus + "',Palletsrefno='" + Spalletsrefno + "',Isempty=0,Returnid='" + Returnid + "' where Unitname='" + Unitname + "'";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }
            }
            return iSuccess;

        }
        public int UpdateUnitQtyupdate1(int iGRId,string status)
        {
            int iSuccess = 0;
            if (status == "Rejected")
            {
                DataSet ds = new DataSet();
                string sqry = "select * from tblTransGoodReceipts  where GRId='" + iGRId + "'";
                ds = dbObj.InlineExecuteDataSet(sqry);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        int grid1 =Convert.ToInt32(ds.Tables[0].Rows[i]["TransGRId"].ToString());

                        string sQry = "update  tblUnit set TransGRId=0,ProductId=0,Batchnumber=0,Expirydate='1900-01-01',Totalqty=0,Status='',Palletsrefno='',Isempty=1,Returnid=0 where TransGrid='" + grid1 + "' ";
                        iSuccess = dbObj.InlineExecuteNonQuery(sQry);

                        string sqry1 = "delete tblTransGoodReceipts where TransGRId='" + grid1 + "' ";
                        int succes1 = dbObj.InlineExecuteNonQuery(sqry1);
                    }

                }

            }
            return iSuccess;

        }
            public int Updatetrancegrforgp(string sUnitname, string sFinalbatchqty)
        {
            int iSuccess = 0;
            string sQry = "update tblTransGoodReceipts set  FinalbatchQty='" + sFinalbatchqty + "' where Unitname='" + sUnitname + "';";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public int UpdateUnitvalue(string sUnitname, string sFinalbatchqty, int status)
        {
            int iSuccess = 0;
            string sQry = "UPDATE tblUnit SET TotalQty = " + sFinalbatchqty + " , isempty=" + status + "  WHERE Unitname = '" + sUnitname + "'";// IF EXISTS (SELECT 1 FROM tblUnit WHERE Unitname =  '" + sUnitname + "' AND TotalQty = " + sFinalbatchqty + ") BEGIN UPDATE tblUnit SET Isempty = 1 WHERE Unitname = '" + sUnitname + "'; SELECT * FROM tblUnit WHERE Unitname = '" + sUnitname + "'; END ELSE BEGIN UPDATE tblUnit SET Isempty = 0 WHERE Unitname = '" + sUnitname + "'; SELECT * FROM tblUnit WHERE Unitname = '" + sUnitname + "'; END";
            // string sQry = "UPDATE tblUnit SET TotalQty = "+sFinalbatchqty+ " WHERE Unitname = '" + sUnitname + "'; IF EXISTS (SELECT 1 FROM tblUnit WHERE Unitname =  '" + sUnitname + "' AND TotalQty = " + sFinalbatchqty+ ") BEGIN UPDATE tblUnit SET Isempty = 1 WHERE Unitname = '" + sUnitname + "'; SELECT * FROM tblUnit WHERE Unitname = '" + sUnitname + "'; END ELSE BEGIN UPDATE tblUnit SET Isempty = 0 WHERE Unitname = '" + sUnitname + "'; SELECT * FROM tblUnit WHERE Unitname = '" + sUnitname + "'; END";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public int UpdateUnitvalue1(string sUnitname, string sFinalbatchqty, int status)
        {
            int iSuccess = 0;
            string sQry = "UPDATE tblUnit SET TotalQty = " + sFinalbatchqty + " , isempty=" + status + ", TransGRId='',Batchnumber='', ProductId='',Status='', Palletsrefno='', Expirydate='1900-01-01' WHERE Unitname = '" + sUnitname + "'";// IF EXISTS (SELECT 1 FROM tblUnit WHERE Unitname =  '" + sUnitname + "' AND TotalQty = " + sFinalbatchqty + ") BEGIN UPDATE tblUnit SET Isempty = 1 WHERE Unitname = '" + sUnitname + "'; SELECT * FROM tblUnit WHERE Unitname = '" + sUnitname + "'; END ELSE BEGIN UPDATE tblUnit SET Isempty = 0 WHERE Unitname = '" + sUnitname + "'; SELECT * FROM tblUnit WHERE Unitname = '" + sUnitname + "'; END";
            // string sQry = "UPDATE tblUnit SET TotalQty = "+sFinalbatchqty+ " WHERE Unitname = '" + sUnitname + "'; IF EXISTS (SELECT 1 FROM tblUnit WHERE Unitname =  '" + sUnitname + "' AND TotalQty = " + sFinalbatchqty+ ") BEGIN UPDATE tblUnit SET Isempty = 1 WHERE Unitname = '" + sUnitname + "'; SELECT * FROM tblUnit WHERE Unitname = '" + sUnitname + "'; END ELSE BEGIN UPDATE tblUnit SET Isempty = 0 WHERE Unitname = '" + sUnitname + "'; SELECT * FROM tblUnit WHERE Unitname = '" + sUnitname + "'; END";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public int Updatetracevalue(string sUnitname, string sFinalbatchqty)
        {
            int iSuccess = 0;
            string sQry = "update tblTrancetraceablity set Qty='" + sFinalbatchqty + "' where Unitname='" + sUnitname + "';";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public DataSet Selectsampling()
        {
            DataSet ds = new DataSet();
            //string sQry = "SELECT s.CreatedDate,s.SampleNo,s.BatchNo,sp.ProductName,SUM(CAST(sp.SampleQty AS INT)) AS qty,sp.BatchStatus,s.Selectapproverid,emp.EmployeeName FROM tblSampling s JOIN tblSamproduct sp ON s.BatchNo = sp.BatchNo JOIN tblEmployee emp ON emp.EmployeeID = s.Selectapproverid GROUP BY s.CreatedDate,s.SampleNo,s.BatchNo,sp.ProductName,sp.BatchStatus,s.Selectapproverid,emp.EmployeeName ORDER BY s.BatchNo DESC;";
            string sQry = "SELECT s.CreatedDate,s.SampleNo,s.BatchNo,sp.ProductName,SUM(CAST(sp.SampleQty AS INT)) AS qty,sp.BatchStatus FROM tblSampling s JOIN tblSamproduct sp ON s.BatchNo = sp.BatchNo  GROUP BY s.CreatedDate,s.SampleNo,s.BatchNo,sp.ProductName,sp.BatchStatus ORDER BY s.CreatedDate DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet LoadBatchsampling(string sBatchNo)
        {
            DataSet ds = new DataSet();
            // string sQry = "select * from tblGoodReceipts gr inner join  tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on gr.ProductId=p.ProductID inner join tblUnit u on u.TransGRId=gr.GRId Where gr.Batchnumber='" + sBatchNo + "'";
            string sQry = "select gr.Batchnumber,gr.PalletsQty,p.Productname,sum(Qty) as totalqty,gr.BatchStatus from tblGoodReceipts gr, tblTransGoodReceipts tgr, tblProduct p where gr.GRId=tgr.GRId and gr.ProductId=p.ProductID and Batchnumber='" + sBatchNo + "' group by gr.Batchnumber,gr.PalletsQty,p.Productname,gr.BatchStatus";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        #region Batch Management 
        public int UpdateTranceGRstatus(string sunitname, string sBatchStatus)
        {
            int iSuccess = 0;
            string sQry = "update tblTransGoodReceipts set BatchStatus='" + sBatchStatus + "' where Unitname='" + sunitname + "';";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public int UpdateUnitstatus(string sunitname, string sStatus)
        {
            int iSuccess = 0;
            string sQry = "update tblUnit set Status='" + sStatus + "' where Unitname='" + sunitname + "';";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public int UpdateGrstatus(string sbatchname, string sStatus)
        {
            int iSuccess = 0;
            string sQry = "update tblGoodReceipts set BatchStatus='" + sStatus + "' where Batchnumber='" + sbatchname + "';";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public DataSet LoadBatchmanagement(string sBatchNo)
        {
            DataSet ds = new DataSet();
            // string sQry = "select * from tblGoodReceipts gr inner join  tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on gr.ProductId=p.ProductID inner join tblUnit u on u.TransGRId=gr.GRId Where gr.Batchnumber='" + sBatchNo + "'";
            string sQry = "select gr.Batchnumber,gr.ProductId,gr.Strength,tgr.FinalbatchQty,tgr.Unitname,tgr.BatchStatus,p.Productname from tblGoodReceipts gr, tblTransGoodReceipts tgr, tblProduct p where gr.GRId=tgr.GRId and gr.ProductId=p.ProductID and Batchnumber='" + sBatchNo + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        #endregion

        public DataSet LoadTraceablity(string sBatchNo)
        {
            DataSet ds = new DataSet();
            // string sQry = "select * from tblGoodReceipts gr inner join  tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on gr.ProductId=p.ProductID inner join tblUnit u on u.TransGRId=gr.GRId Where gr.Batchnumber='" + sBatchNo + "'";
            string sQry = "select * from tblTraceablity t inner join tblTrancetraceablity tt on  t.TraceId=tt.TraceId   inner join tblProduct p on p.ProductID=t.ProductId inner join tblGoodReceipts tg on tg.GRId=t.GRId  and t.Batchnumber='" + sBatchNo + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int Insertsampling(string sBatchNo, string sSampleNo, int iSelectapproverid, string sStatus, DateTime CreatedDate)
        {
            int iSuccess = 0;
            string sQry = "insert into TblSampling(BatchNo,SampleNo,Selectapproverid,Status,CreatedDate) values ('" + sBatchNo + "','" + sSampleNo + "','" + iSelectapproverid + "','" + sStatus + "','" + CreatedDate.ToString("yyyy/MM/dd") + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }


        #region Dashbord

        public DataSet TotalSupplier()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT COUNT(ContactName) AS TotalSuppliers FROM Suplier where IsDel=0;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet QualifiedSupplier(string sdate)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT COUNT(ContactName) AS TotalSuppliers FROM Suplier where ValidTill>='" + sdate + "' and SupplierStatus='Active';";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet NonQualifiedSupplier(string sdate1)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT COUNT(ContactName) AS TotalSuppliers FROM Suplier where ValidTill<='" + sdate1 + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet NotActiveSupplier()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT COUNT(ContactName) AS TotalSuppliers FROM Suplier where SupplierStatus='Not Active' and IsDel=0";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Occupiedunits()
        {
            DataSet ds = new DataSet();
            string sQry = "select count(UnitId) as unitqty from tblUnit where Isempty='0'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Availableunit()
        {
            DataSet ds = new DataSet();
            string sQry = "select count(UnitId) as unitqty from tblUnit where Isempty='1'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Totalunitqty()
        {
            DataSet ds = new DataSet();
            string sQry = "select sum(totalQty) as totalunitqty from tblUnit";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet SampleQty()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT SUM(CAST(SampleQty AS INT)) AS SamQty FROM tblSamproduct;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Quarntine()
        {
            DataSet ds = new DataSet();
            string sQry = "select count(Status) Batchstatus from tblUnit where Status='Quarantine'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Rejected()
        {
            DataSet ds = new DataSet();
            string sQry = "select count(Status) Batchstatus from tblUnit where Status='Rejected'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Released()
        {
            DataSet ds = new DataSet();
            string sQry = "select count(Status) Batchstatus from tblUnit where Status='Release'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet TotalPO()
        {
            DataSet ds = new DataSet();
            string sQry = "select COUNT(PoId) as totalpo  from TblPO";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet ClosedPO()
        {
            DataSet ds = new DataSet();
            string sQry = "select count(Status) as closedgr from tblGoodReceipts where Status='Approved'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Salesorder(DateTime Fromdate, DateTime Todate)
        {
            DataSet ds = new DataSet();
            string sQry = "select COUNT(Soid) as totalso,sum(cast(Amount as decimal)) as totalamount from TblSO where SOdatetime between'" + Fromdate.ToString("yyyy/MM/dd") + "' and '" + Todate.ToString("yyyy/MM/dd") + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet TodaySO(DateTime sdate)
        {
            DataSet ds = new DataSet();
            string sQry = "select count(Soid) as totalso,SUM(CAST(Amount AS decimal)) as totalamount from TblSO where SOdatetime ='" + sdate.ToString("yyyy/MM/dd") + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet TotalSO()
        {
            DataSet ds = new DataSet();
            string sQry = "select COUNT(Soid) as totalso,sum(cast(Amount as decimal)) as totalamount  from TblSO";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Batch Sampling
        public DataSet LoadBatchsampling1(string sBatchNo)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblGoodReceipts gr inner join tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on p.ProductID=gr.ProductId  where gr.Batchnumber='" + sBatchNo + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet checkSampleAvailable(string sSample)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblSampling where Sampleno='" + sSample + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet LoadBatchsampling2(string sBatchNo)
        {
            DataSet ds = new DataSet();
            string sQry = "select gr.Batchnumber,tgr.Unitname,tgr.Qty,tgr.SampleQty,tgr.FinalbatchQty,p.Productname,gr.PalletsQty,gr.BatchStatus  from tblGoodReceipts gr inner join  tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on gr.ProductId=p.ProductID Where gr.Batchnumber='" + sBatchNo + "'";
            //string sQry = "select * from tblGoodReceipts gr inner join  tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on gr.ProductId=p.ProductID Where  gr.BatchStatus='Quarantine'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet LoadBatchsampling3()
        {
            DataSet ds = new DataSet();
            //string sQry = "select * from tblGoodReceipts gr inner join  tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on gr.ProductId=p.ProductID Where gr.Batchnumber='" + sBatchNo + "'";
            string sQry = "select * from tblGoodReceipts gr inner join  tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on gr.ProductId=p.ProductID Where  gr.BatchStatus='Quarantine'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        #endregion

        #region order processing

        public DataSet Selectgoodrecieporder()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblGoodReceipts gr inner join tblProduct p on gr.ProductId=p.ProductID";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region GoodReceipt
        public DataSet select_CheckUnitname(string unitname)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblunit where Unitname='"+unitname+ "' and Isempty=0 and TotalQty<>0";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_CheckBatchnumber(string Batchno)
        {
            DataSet ds = new DataSet();
            string sQry = "select Batchnumber from tblunit where Batchnumber='"+ Batchno + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int deleteGRGird(int GRId)
        {
            int iSucess = 0;
            string sQry = "delete tblGoodReceipts  WHERE GRId ='" + GRId + "'; ";

            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }

        public DataSet LoadGoodReceipt()
        {
            DataSet ds = new DataSet();
            string sQry = "select gr.GRId,po.POPrintno,po.Poid,p.ProductID,p.Productname,gr.OrderQty,sum(tgr.Qty) as ReceivedQty,gr.OrderAmt,gr.Batchnumber,gr.PalletsQty,"+
                "gr.ExpiryDate,gr.Status from tblGoodReceipts gr INNER JOIN tblProduct p on gr.ProductId=p.ProductID inner join TblPO po on po.Poid=gr.Poid inner join "+
                "tblTransGoodReceipts tgr  on tgr.GRId=gr.GRId group by gr.GRId,po.POPrintno,po.Poid,p.ProductID,p.Productname,gr.OrderQty,gr.OrderAmt,gr.Batchnumber,"+
                "gr.PalletsQty,gr.ExpiryDate,gr.Status,tgr.GRId  order by GRId DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet LoadGoodReceiptret()
        {
            DataSet ds = new DataSet();
            string sQry = "select gr.GRId,ret.ReturnPrintno as POPrintno,ret.Soid as Poid,p.ProductID,p.Productname,gr.OrderQty,sum(tgr.Qty) as ReceivedQty,gr.OrderAmt,gr.Batchnumber,gr.PalletsQty,gr.ExpiryDate,gr.Status from tblGoodReceipts gr INNER JOIN tblProduct p on gr.ProductId=p.ProductID inner join tblreturn ret on ret.Returnid=gr.Returnid inner join tblTransGoodReceipts tgr  on tgr.GRId=gr.GRId group by gr.GRId,ret.ReturnPrintno,ret.Soid,p.ProductID,p.Productname,gr.OrderQty,gr.OrderAmt,gr.Batchnumber,gr.PalletsQty,gr.ExpiryDate,gr.Status,tgr.GRId  order by GRId DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet LoadGoodReceiptbyID(int Id)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblGoodReceipts g, tblProduct p where g.productid=p.ProductID and g.GRId=" + Id + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_UnitsQty(int iGRId)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransGoodReceipts  where GRId ='" + iGRId + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_UnitsQty_byname(string Unitname)
        {
            DataSet ds = new DataSet();
            string sQry = "select top 1 * from tblTransGoodReceipts tg, tblUnit u  where tg.Unitname=u.Unitname and tg.Unitname ='" + Unitname + "' and u.TransGrid=tg.TransGRId order by GRId desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_UnitsQty_byname1(string Unitname)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from  tblUnit  where  Unitname ='" + Unitname + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet GetMax_GR()
        {
            DataSet ds = new DataSet();
            string sQry = "select Isnull(Max(GRId),1) as Id from tblGoodReceipts";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int InsertTransGR(int iGRId, string sUnitName, int iQty, string sPalletsrefno, string sBatchstatus,int returnid)
        {
            int iSuccess = 0;
                if (returnid == 0)
                {
                    string sQry = "insert into tblTransGoodReceipts(GRId,Unitname,Qty,Palletsrefno,FinalbatchQty,BatchStatus,Returnid,Isreturn) values (" + iGRId + ",'" + sUnitName + "'," + iQty + ",'" + sPalletsrefno + "'," + iQty + ",'" + sBatchstatus + "','0','0')";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }
                else
                {
                    string sQry = "insert into tblTransGoodReceipts(GRId,Unitname,Qty,Palletsrefno,FinalbatchQty,BatchStatus,Returnid,Isreturn) values (" + iGRId + ",'" + sUnitName + "'," + iQty + ",'" + sPalletsrefno + "'," + iQty + ",'" + sBatchstatus + "','" + returnid + "','1')";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }
            return iSuccess;

        }
        public int InsertTransGRedit(int iGRId, string sUnitName, int iQty, string sPalletsrefno, string sBatchstatus, int returnid)
        {
            int iSuccess = 0;
            DataSet dscheckgrid = new DataSet();
            string gridcheck = "SELECT  * FROM tblTransGoodReceipts WHERE GRId = '" + iGRId + "'";
            dscheckgrid = dbObj.InlineExecuteDataSet(gridcheck);
            if (dscheckgrid.Tables[0].Rows.Count > 0)
            {
                string sQry1 = "insert into tblTransHistoryGoodReceipts(TransGRId,GRId,Unitname,Qty,SampleQty,FinalbatchQty,Palletsrefno,BatchStatus,Returnid,Isreturn,Entrydate) select  TransGRId,GRId,Unitname,Qty,SampleQty,FinalbatchQty,Palletsrefno,BatchStatus,Returnid,Isreturn,GetDate() from tblTransGoodReceipts WHERE GRId='" + iGRId + "'";
                int iSuccess3 = dbObj.InlineExecuteNonQuery(sQry1);
                string sqry2 = "delete tblTransGoodReceipts  WHERE GRId = '" + iGRId + "'";
                int iSuccess4 = dbObj.InlineExecuteNonQuery(sqry2);
                if (returnid == 0)
                {
                    string sqry3 = "insert into tblTransGoodReceipts(GRId,Unitname,Qty,Palletsrefno,FinalbatchQty,BatchStatus,Returnid,Isreturn) values (" + iGRId + ",'" + sUnitName + "'," + iQty + ",'" + sPalletsrefno + "'," + iQty + ",'" + sBatchstatus + "','0','0')";
                    int iSuccess5 = dbObj.InlineExecuteNonQuery(sqry3);
                }
                else
                {
                    string sqry3 = "insert into tblTransGoodReceipts(GRId,Unitname,Qty,Palletsrefno,FinalbatchQty,BatchStatus,Returnid,Isreturn) values (" + iGRId + ",'" + sUnitName + "'," + iQty + ",'" + sPalletsrefno + "'," + iQty + ",'" + sBatchstatus + "','"+returnid+"','1')";
                    int iSuccess5 = dbObj.InlineExecuteNonQuery(sqry3);
                }
            }
            else
            {
                if (returnid == 0)
                {
                    string sQry = "insert into tblTransGoodReceipts(GRId,Unitname,Qty,Palletsrefno,FinalbatchQty,BatchStatus,Returnid,Isreturn) values (" + iGRId + ",'" + sUnitName + "'," + iQty + ",'" + sPalletsrefno + "'," + iQty + ",'" + sBatchstatus + "','0','0')";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }
                else
                {
                    string sQry = "insert into tblTransGoodReceipts(GRId,Unitname,Qty,Palletsrefno,FinalbatchQty,BatchStatus,Returnid,Isreturn) values (" + iGRId + ",'" + sUnitName + "'," + iQty + ",'" + sPalletsrefno + "'," + iQty + ",'" + sBatchstatus + "','" + returnid + "','1')";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }

            }
            return iSuccess;

        }
        public int InsertTransetraceablity(int iPoid, string sUnitName, int iQty, string sStatus, int iGRId, int iTraceId, string sPalletsrefno,int returnid)
        {
            int iSuccess = 0;
                if (returnid == 0)
                {
                    string sQry = "insert into tblTrancetraceablity(Poid,Unitname,Qty,Status,GRId,TraceId,Palletsrefno,Returnid,Isreturn) values ('" + iPoid + "','" + sUnitName + "','" + iQty + "','" + sStatus + "','" + iGRId + "','" + iTraceId + "','" + sPalletsrefno + "','0','0')";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }
                else
                {
                    string sQry = "insert into tblTrancetraceablity(Poid,Unitname,Qty,Status,GRId,TraceId,Palletsrefno,Returnid,Isreturn) values ('0','" + sUnitName + "','" + iQty + "','" + sStatus + "','" + iGRId + "','" + iTraceId + "','" + sPalletsrefno + "','" + returnid + "','1')";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }
            return iSuccess;

        }
        public int InsertTransetraceablityedit(int iPoid, string sUnitName, int iQty, string sStatus, int iGRId, int iTraceId, string sPalletsrefno, int returnid)
        {
            int iSuccess = 0;
            DataSet dscheckgrid = new DataSet();
            string gridcheck = "SELECT  * FROM tblTrancetraceablity WHERE GRId = '" + iGRId + "'";
            dscheckgrid = dbObj.InlineExecuteDataSet(gridcheck);
            if (dscheckgrid.Tables[0].Rows.Count > 0)
            {
                string sqry2 = "delete tblTrancetraceablity WHERE GRId = '" + iGRId + "'";
                int iSuccess4 = dbObj.InlineExecuteNonQuery(sqry2);
                if (returnid == 0)
                {
                    string sQry1 = "insert into tblTrancetraceablity(Poid,Unitname,Qty,Status,GRId,TraceId,Palletsrefno,Returnid,Isreturn) values ('" + iPoid + "','" + sUnitName + "','" + iQty + "','" + sStatus + "','" + iGRId + "','" + iTraceId + "','" + sPalletsrefno + "','0','0')";
                    int iSuccess3 = dbObj.InlineExecuteNonQuery(sQry1);
                }
                else
                {
                    string sQry1 = "insert into tblTrancetraceablity(Poid,Unitname,Qty,Status,GRId,TraceId,Palletsrefno,Returnid,Isreturn) values ('" + iPoid + "','" + sUnitName + "','" + iQty + "','" + sStatus + "','" + iGRId + "','" + iTraceId + "','" + sPalletsrefno + "','"+returnid+"','1')";
                    int iSuccess3 = dbObj.InlineExecuteNonQuery(sQry1);
                }
            }
            else
            {
                if (returnid == 0)
                {
                    string sQry = "insert into tblTrancetraceablity(Poid,Unitname,Qty,Status,GRId,TraceId,Palletsrefno,Returnid,Isreturn) values ('" + iPoid + "','" + sUnitName + "','" + iQty + "','" + sStatus + "','" + iGRId + "','" + iTraceId + "','" + sPalletsrefno + "','0','0')";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }
                else
                {
                    string sQry = "insert into tblTrancetraceablity(Poid,Unitname,Qty,Status,GRId,TraceId,Palletsrefno,Returnid,Isreturn) values ('0','" + sUnitName + "','" + iQty + "','" + sStatus + "','" + iGRId + "','" + iTraceId + "','" + sPalletsrefno + "','" + returnid + "','1')";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }
            }

            return iSuccess;

        }
        public DataSet GetMax_TransGR()
        {
            DataSet ds = new DataSet();
            string sQry = "select Max(TransGRId) as Id from tblTransGoodReceipts";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int UpdateUnitQty(int iGRId, string Unitname, int iProductId, string sBatchNo, String Expirydate, int iTotalqty)
        {
            int iSuccess = 0;
            string sQry = "update  tblUnit set TransGRId=" + iGRId + ",ProductId='" + iProductId + "',Batchnumber='" + sBatchNo + "',Expirydate='" + Expirydate + "',Totalqty='" + iTotalqty + "',Isempty=0 where Unitname='" + Unitname + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public DataSet selectGR_byGRId(int iGRid)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT gr.*, r.ReturnPrintno,p.POPrintno,(select Sum(Qty) as qty from tblTransGoodReceipts where GRId='"+iGRid+"') as Qty FROM tblGoodReceipts gr LEFT JOIN tblReturn r ON r.Returnid = gr.Returnid left join TblPO p on p.Poid=gr.Poid WHERE gr.GRId ='" + iGRid+"'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet selecttranspoby_poid(int ipoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransPo where Poid=" + ipoid + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_TranspoProductid()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransPo";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int InsertGR(int Poid, int ProductId, string Dosage, string Strength, int OrderQty, double OrderAmt, string Batchnumber, int ReceivedQty, string ExpiryDate, int PalletsQty, string BatchStatus, int iSelectapproverid, string sStatus, DateTime date,int Returnid)
        {
            int iSuccess = 0;
            if (Returnid == 0)
            {
                string sQry = "insert into tblGoodReceipts(Poid,ProductId,Dosage,Strength,OrderQty,OrderAmt,Batchnumber,ReceivedQty,ExpiryDate,PalletsQty,BatchStatus,Approverid,Status,GoodsReceiveddate,Returnid) values (" + Poid + "," + ProductId + ",'" + Dosage + "','" + Strength + "','" + OrderQty + "'," + OrderAmt + ",'" + Batchnumber + "'," + ReceivedQty + ",'" + ExpiryDate + "'," + PalletsQty + ",'" + BatchStatus + "','" + iSelectapproverid + "','" + sStatus + "','" + date.ToString("yyyy/MM/dd") + "','0')";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            }
            else
            {
                string sQry = "insert into tblGoodReceipts(Poid,ProductId,Dosage,Strength,OrderQty,OrderAmt,Batchnumber,ReceivedQty,ExpiryDate,PalletsQty,BatchStatus,Approverid,Status,GoodsReceiveddate,Returnid) values (0," + ProductId + ",'" + Dosage + "','" + Strength + "','" + OrderQty + "'," + OrderAmt + ",'" + Batchnumber + "'," + ReceivedQty + ",'" + ExpiryDate + "'," + PalletsQty + ",'" + BatchStatus + "','" + iSelectapproverid + "','" + sStatus + "','" + date.ToString("yyyy/MM/dd") + "','"+Returnid+"')";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            }
            return iSuccess;

        }
        #region traceablity
        public DataSet GetMax_Traceid()
        {
            DataSet ds = new DataSet();
            string sQry = "select Max(TraceId) as TraceId from tblTraceablity";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public int InsertTraceablity(int iPoid, int ProductId, int iGRId, string Batchnumber, int ApproverId,int Returnid)
        {
            int iSuccess = 0;
            if (Returnid==0)
            {
                string sQry = "insert into tblTraceablity(Poid,ProductId,GRId,Batchnumber,ApproverId,Returnid) values ('" + iPoid + "'," + ProductId + ",'" + iGRId + "','" + Batchnumber + "','" + ApproverId + "','0')";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            }
            else
            {
                string sQry = "insert into tblTraceablity(Poid,ProductId,GRId,Batchnumber,ApproverId,Returnid) values ('0'," + ProductId + ",'" + iGRId + "','" + Batchnumber + "','" + ApproverId + "','"+Returnid+"')";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            }
            return iSuccess;

        }
        public int UpdateTraceablity(int iPoid, int ProductId, int iGRId, string Batchnumber, int ApproverId, int Returnid)
        {
            int iSuccess = 0;
            if (Returnid == 0)
            {
                string sQry = "update tblTraceablity set Returnid='0',ProductId=" + ProductId + ",Batchnumber='" + Batchnumber + "',ApproverId='" + ApproverId + "',Poid='" + iPoid + "' where GRId='" + iGRId + "'";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            }
            else
            {
                string sQry = "update tblTraceablity set Poid='0',ProductId=" + ProductId + ",Batchnumber='" + Batchnumber + "',ApproverId='" + ApproverId + "',Returnid='" + Returnid + "' where GRId='" + iGRId + "'";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            }
            return iSuccess;

        }
        public int UpdatetblTrancetraceablity(int iGRId, string sStatus,int Returnid)
        {
            int iSuccess = 0;
            if (Returnid == 0)
            {
                if (sStatus == "Rejected")
                {
                    //string sqry1 = "Delete tblTrancetraceablity  where GRId='" + iGRId + "'";
                }
                else
                {
                    string sQry = "update   tblTrancetraceablity set Status='" + sStatus + "' where GRId='" + iGRId + "'";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }
            }
            else
            {
                if (sStatus == "Rejected")
                {
                    //string sqry1 = "Delete tblTrancetraceablity  where GRId='" + iGRId + "'";
                }
                else
                {
                    string sQry = "update   tblTrancetraceablity set Status='" + sStatus + "' where GRId='" + iGRId + "'";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                }
            }
            
            return iSuccess;

        }
        public int UpdatetblTrancetraceablityforrej(int iGRId, string sStatus)
        {
            int iSuccess = 0;

                    string sQry = "delete   tblTrancetraceablity  where GRId='" + iGRId + "'";
                    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        #endregion
        //public int InsertGRandUnits( int iProductId, string sBatchNo,String Expirydate, int iTotalqty)
        //{
        //    int iSuccess = 0;
        //    string sQry = "insert into tblUnit (ProductId,Batchnumber,Expirydate,TotalQty) values('"+iProductId+"','"+sBatchNo+"','"+Expirydate+"','"+iTotalqty+"')";
        //    iSuccess = dbObj.InlineExecuteNonQuery(sQry);
        //    return iSuccess;

        //}
        public int UpdateGR(int iGrid, int Poid, int ProductId, string Dosage, string Strength, int OrderQty, double OrderAmt, string Batchnumber, int ReceivedQty, string ExpiryDate, int PalletsQty, string BatchStatus, int iSelectapproverid, string sStatus,int Returnid)
        {
            int iSuccess = 0;
            if (Returnid == 0)
            {
                string sQry = "update tblGoodReceipts set Poid='" + Poid + "', ProductId='" + ProductId + "',Dosage='" + Dosage + "',Strength='" + Strength + "',OrderQty='" + OrderQty + "',OrderAmt='" + OrderAmt + "',Batchnumber='" + Batchnumber + "',ReceivedQty='" + ReceivedQty + "',ExpiryDate='" + ExpiryDate + "',PalletsQty='" + PalletsQty + "',BatchStatus='" + BatchStatus + "',ApproverId='" + iSelectapproverid + "',Status='" + sStatus + "',Returnid='0' where GRId='" + iGrid + "';";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            }
            else
            {
                string sQry = "update tblGoodReceipts set Poid='0', ProductId='" + ProductId + "',Dosage='" + Dosage + "',Strength='" + Strength + "',OrderQty='" + OrderQty + "',OrderAmt='" + OrderAmt + "',Batchnumber='" + Batchnumber + "',ReceivedQty='" + ReceivedQty + "',ExpiryDate='" + ExpiryDate + "',PalletsQty='" + PalletsQty + "',BatchStatus='" + BatchStatus + "',ApproverId='" + iSelectapproverid + "',Status='" + sStatus + "',Returnid='"+Returnid+"' where GRId='" + iGrid + "';";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            }    

            return iSuccess;

        }
        public int UpdateGRforreject(int iGrid,int prodid)
        {
            int iSuccess = 0;
                string sQry = "delete tblGoodReceipts  where GRId='" + iGrid + "' and ProductId='"+prodid+"'";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                string sQry1 = "delete tblTransGoodReceipts  where GRId='" + iGrid + "'";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry1);
            return iSuccess;

        }

        #endregion
        public DataSet select_TranspoProduct(int iPoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransPo where Poid='" + iPoid + "' and isgoodreceived=0";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_TransReturnProduct(int iReturnid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransReturn where Returnid='"+iReturnid+"' and isgoodreceived=0 and ReturnQty<>0";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_TranspoProductvalues(int iProductid, int POid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransPo where Productid='" + iProductid + "' and Poid=" + POid + " ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_Goodsreceiptpoidcheck(string poid, string productid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblgoodreceipts where Poid='"+poid+"' and ProductId='"+productid+"'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_Goodsreceiptreturnidcheck(string Returnid, string productid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblgoodreceipts where Returnid='" + Returnid + "' and ProductId='" + productid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet select_TransReturnProductvalues(int iProductid, int ReturnId)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransReturn where Productid='" + iProductid + "' and Returnid=" + ReturnId + " ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int deleteSoGrid(int iSoid)
        {
            int iSucess = 0;
            string sQry = "delete tblSO  WHERE Soid ='" + iSoid + "'   delete tblTransSo  WHERE Soid ='" + iSoid + "' ";

            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        #endregion


        #region Reports
        public DataSet Select_Reports(DateTime fromdate, DateTime todate)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT p.Poid, p.POdatetime, s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount, p.Status FROM TblPO p inner join Suplier s ON p.SupplierID = s.SupplierID WHERE p.POdatetime BETWEEN '" + fromdate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' ORDER BY p.Poid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #region WareHouseStock

        public DataSet WareHouseStockGrid()
        {
            DataSet ds = new DataSet();
            string sQry = "select p.productcode,p.productname,gr.packtype,gr.orderqty,gr.batchnumber,gr.expirydate,tgr.unitname, gr.batchstatus,tgr.qty,tgr.sampleqty,tgr.finalbatchqty\r\n   from tblproduct p,tblGoodReceipts gr, tblTransGoodReceipts tgr where p.productid=gr.productid and gr.grid=tgr.grid";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }


        #endregion

        #region ProductStockGrid
        public DataSet ProductStockGrid()
        {
            DataSet ds = new DataSet();
            string sQry = "select p.productcode,p.productname,gr.packtype,gr.batchnumber,gr.expirydate,tgr.unitname,tgr.qty,tgr.sampleqty,tgr.finalbatchqty\r\n   from tblproduct p,tblGoodReceipts gr, tblTransGoodReceipts tgr where p.productid=gr.productid and gr.grid=tgr.grid";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        #endregion

        #region ProductStockGridSpecific
        public DataSet ProductStockSpecific()
        {
            DataSet ds = new DataSet();
            string sQry = "select p.productcode,p.productname,gr.packtype,gr.batchnumber,gr.expirydate,tgr.unitname,tgr.qty,tgr.sampleqty,tgr.finalbatchqty\r\n   from tblproduct p,tblGoodReceipts gr, tblTransGoodReceipts tgr where p.productid=gr.productid and gr.grid=tgr.grid and p.productcode='1001'\r\n";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        #endregion
        #endregion

        #region PoGrid
        public DataSet Select_POProduct(int iPoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransPo Productid  where Poid ='" + iPoid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Select_PObyproductid()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransPo order by  Productid";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_TransPObyproductid_Print(int Id)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransPo where Poid=" + Id + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_PObyproductid_Print(int Id)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransPo tpo inner join TblPO p on p.Poid=tpo.Poid where p.Poid=" + Id + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_POTotalqty(int Id)
        {
            DataSet ds = new DataSet();
            string sQry = "select sum(cast(tpo.PoQty as decimal)) as TottalQty from tblTransPo tpo inner join TblPO p on p.Poid=tpo.Poid where p.Poid='"+Id+"'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_SOTotalqty(int Id)
        {
            DataSet ds = new DataSet();
            string sQry = "select sum(cast(tso.SoQty as decimal)) as TottalQty from tblTransSo tso inner join TblSO s on s.Soid=tso.Soid where s.Soid='"+ Id + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_TransSObyproductid_Print(int Id)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TblSO s inner join tblTransSo ts on s.Soid=ts.Soid where s.Soid='" + Id + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_SObyproductid_Print(int Id)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblSo where Soid=" + Id + "";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_PoGrid()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT p.Poid,p.POPrintno, p.POdatetime, s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount,p.Status,p.POPrintno FROM Suplier s, TblPO p WHERE s.SupplierID = p.SupplierID ORDER BY p.Poid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int deletePoGrid(int iPoid)
        {
            int iSucess = 0;
            string sQry = "delete tblPO  WHERE Poid ='" + iPoid + "'   delete tblTransPo  WHERE Poid ='" + iPoid + "' ";

            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        public DataSet GRview(int iPoid)
        {
            DataSet ds = new DataSet();
            string sQry = "Select * from tblTransPo where Poid='" + iPoid + "' order by Productid;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int deletePO(int Productid)
        {
            int iSucess = 0;
            string sQry = "delete TempPo  WHERE Productid ='" + Productid + "' ";
            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }


        #endregion


        #region SO_GoodsPick
        public DataSet SoList()
        {
            DataSet ds = new DataSet();
            string sQry = "select distinct po.Soid from TblSO po, tblTransSO tpo where po.SOid=tpo.SOid and Status='Approved'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet SoList_new()
        {
            DataSet ds = new DataSet();
            //  string sQry = "SELECT ts.SoId FROM tblso ts LEFT JOIN tblGoodsPicking gp ON ts.SoId = gp.SoId LEFT JOIN tbltransso tso ON ts.SoId = tso.Soid LEFT JOIN tblTransGoodPicking tgp ON tso.Productid = tgp.Prodid AND gp.id = tgp.GoodPickid WHERE ts.Status='Approved' and gp.SoId IS NULL OR tgp.GoodPickid IS NULL GROUP BY ts.SoId";
            // string sQry = "SELECT DISTINCT s.soid FROM tblso s INNER JOIN tbltransso ts ON s.SoId = ts.SoId INNER JOIN tblgoodspicking gp ON s.SoId = gp.SoId INNER JOIN tbltransgoodpicking tgp ON gp.id = tgp.goodpickid WHERE s.SoId = ts.SoId GROUP BY s.soid, gp.suppid, ts.Productid, ts.Productname, ts.SoQty, tgp.prodid HAVING SUM(ts.soqty) >= SUM(tgp.qty) AND ts.Productid = tgp.prodid\r\n";

            string sQry = "SELECT s.soid,s.SOPrintno FROM tblso s where Status<>'Draft' order by soid desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet SoList1()
        {
            DataSet ds = new DataSet();
            //  string sQry = "SELECT ts.SoId FROM tblso ts LEFT JOIN tblGoodsPicking gp ON ts.SoId = gp.SoId LEFT JOIN tbltransso tso ON ts.SoId = tso.Soid LEFT JOIN tblTransGoodPicking tgp ON tso.Productid = tgp.Prodid AND gp.id = tgp.GoodPickid WHERE ts.Status='Approved' and gp.SoId IS NULL OR tgp.GoodPickid IS NULL GROUP BY ts.SoId";
            // string sQry = "SELECT DISTINCT s.soid FROM tblso s INNER JOIN tbltransso ts ON s.SoId = ts.SoId INNER JOIN tblgoodspicking gp ON s.SoId = gp.SoId INNER JOIN tbltransgoodpicking tgp ON gp.id = tgp.goodpickid WHERE s.SoId = ts.SoId GROUP BY s.soid, gp.suppid, ts.Productid, ts.Productname, ts.SoQty, tgp.prodid HAVING SUM(ts.soqty) >= SUM(tgp.qty) AND ts.Productid = tgp.prodid\r\n";

            string sQry = "SELECT DISTINCT s.soid,s.SOPrintno FROM tblso s INNER JOIN tbltransso ts ON s.SoId = ts.SoId INNER JOIN tblgoodspicking gp ON s.SoId = gp.SoId INNER JOIN tbltransgoodpicking tgp ON gp.id = tgp.goodpickid WHERE s.SoId = ts.SoId GROUP BY s.soid,s.SOPrintno,gp.suppid, ts.Productid, ts.Productname, ts.SoQty, tgp.prodid HAVING SUM(ts.soqty) >= SUM(tgp.qty) AND ts.Productid = tgp.prodid UNION SELECT s.soid,s.SOPrintno FROM tblso s WHERE s.soid NOT IN (SELECT SoId FROM tblgoodspicking)";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet SoGrid(int Id)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT  s.SOPrintno,s.soid,s.supplierid,ts.Productid, ts.Productname, ts.SoQty, SUM(tgp.qty) AS sentqty FROM tblso s INNER JOIN tbltransso ts ON s.SoId = ts.SoId INNER JOIN tblgoodspicking gp ON s.SoId = gp.SoId INNER JOIN tbltransgoodpicking tgp ON gp.id = tgp.goodpickid WHERE s.SoId = " + Id + " GROUP BY s.supplierid,ts.Productid, ts.Productname, ts.SoQty, tgp.prodid,s.soid,s.SOPrintno HAVING SUM(ts.soqty) >= SUM(tgp.qty) AND ts.Productid = tgp.prodid " +
                "UNION SELECT s.SOPrintno,s.soid,s.supplierid,ts.Productid, ts.Productname, ts.SoQty, 0 AS sentqty FROM tblso s INNER JOIN tbltransso ts ON s.SoId = ts.SoId INNER JOIN tblgoodspicking gp ON s.SoId = gp.SoId INNER JOIN tbltransgoodpicking tgp ON gp.id = tgp.goodpickid WHERE s.SoId = " + Id + " and ts.productid NOT IN (SELECT prodid FROM tbltransgoodpicking a, tblgoodspicking b where a.goodpickid=b.id and b.soid=" + Id + ") GROUP BY s.supplierid,ts.Productid, ts.Productname, ts.SoQty, tgp.prodid,s.soid,s.SOPrintno " +
                "UNION SELECT s.SOPrintno,s.soid,s.supplierid,ts.Productid, ts.Productname, ts.SoQty, 0 AS sentqty FROM tblso s INNER JOIN tbltransso ts ON s.SoId = ts.SoId WHERE s.SoId = " + Id + " and s.soid NOT IN (SELECT SoId FROM tblgoodspicking) GROUP BY s.supplierid,ts.Productid, ts.Productname, ts.SoQty,s.soid,s.SOPrintno";
            //string sQry = "SELECT s.supplierid,ts.Productid, ts.Productname, ts.SoQty, SUM(tgp.qty) AS sentqty FROM tblso s INNER JOIN tbltransso ts ON s.SoId = ts.SoId INNER JOIN tblgoodspicking gp ON s.SoId = gp.SoId INNER JOIN tbltransgoodpicking tgp ON gp.id = tgp.goodpickid WHERE s.SoId = "+Id+ " GROUP BY s.supplierid,ts.Productid, ts.Productname, ts.SoQty, tgp.prodid HAVING SUM(ts.soqty) >= SUM(tgp.qty) AND ts.Productid = tgp.prodid";
            // string sQry = "select * from  TblSO po, tblTransSO tpo, Suplier s where po.SOid=tpo.SOid and po.SOid='" + Id + "' and po.SupplierId=s.SupplierID";
            //string sQry = "  select * from  TblSO po, tblTransSO tpo inner join Suplier s on tpo.SupplierID=s.SupplierID where po.SOid=tpo.SOid  and po.SOid='" + Id + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);

            if (ds.Tables[0].Rows.Count == 0 || ds.Tables[0].Rows == null)
            {

                string sQry1 = "select *, '0' AS SentQty from  TblSO po, tblTransSO tpo, Suplier s where po.SOid=tpo.SOid and po.SOid='" + Id + "' and po.SupplierId=s.SupplierID";
                ds = dbObj.InlineExecuteDataSet(sQry1);
            }
            return ds;
        }
        //public DataSet SelectProducts_UnitsAvailable(int iSoId)
        //{
        //    DataSet ds = new DataSet();
        //    string sQry = "select * from tblTransSo ts, tblUnit u where ts.Soid="+ iSoId + " and ts.productid=u.productid  order by Expirydate";
        //    ds = dbObj.InlineExecuteDataSet(sQry);
        //    return ds;
        //}
        public DataSet SelectProducts_UnitsAvailable(int iSoId, int iProdid, int Sent)
        {
            DataSet ds = new DataSet();
            string sQry = "select ts.soqty-" + Sent + " as remaining,'0' as Qty, *from tblTransSo ts, tblUnit u where ts.Soid = " + iSoId + " and ts.productid = u.productid and ts.productid = " + iProdid + " and u.TotalQty > 0 and Status='Release' order by Expirydate";
            // string sQry = "select '0' as Qty, * from tblTransSo ts, tblUnit u where ts.Soid=" + iSoId + " and ts.productid=u.productid  order by Expirydate";
            //string sQry = "select '0' as Qty, * from tblTransSo ts, tblUnit u where ts.Soid=" + iSoId + " and ts.productid=u.productid  order by ts.Productid";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int InsertGPN(DateTime PickDate, int SOId, int SuppId, int TotalQty)
        {
            int iSuccess = 0;
            string sQry = "insert into tblGoodsPicking(PickupDate,SoId,SuppId,TotalQty) values ('" + PickDate.ToString("yyyy/MM/dd") + "'," + SOId + "," + SuppId + "," + TotalQty + ")";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public DataSet MaxGPN()
        {
            DataSet ds = new DataSet();
            string sQry = "Select Isnull(max(Id),1) as ID from tblGoodsPicking";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int InsertTransGPN(int GoodPickid, int ProdId, int PackSize, int Qty, double PricePerPack, decimal VATPerc, double AmtTotal, string Batchnumber, string Unitname, string sPalletsrefno,string Expirydate)
        {
            int iSuccess = 0;
            string sQry = "insert into tblTransGoodPicking(GoodPickid,ProdId,PackSize,Qty,PricePerPack,VATPerc,AmtTotal,Batchnumber,Unitname,Palletsrefno,Expirydate) values (" + GoodPickid + "," + ProdId + "," + PackSize + "," + Qty + "," + PricePerPack + "," + VATPerc + "," + AmtTotal + ",'" + Batchnumber + "','" + Unitname + "','" + sPalletsrefno + "','"+ Convert.ToDateTime(Expirydate).ToString("yyyy-MM-dd") + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        #endregion
        #region  inventory

        public DataSet Select_Inventory()
        {
            DataSet ds = new DataSet();
            string sQry = "select p.productname,sum(tgr.FinalbatchQty) as Availableqty,p.ProductQty from tblGoodReceipts gr,tblTransGoodReceipts tgr,tblProduct p where gr.GRId=tgr.GRId and p.ProductID=gr.ProductId group by p.Productname,p.ProductQty";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        #endregion
        #region Traceablity
        public DataSet Select_Traceablity()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTraceablity t inner join tblTrancetraceablity tt on  t.TraceId=tt.TraceId   inner join tblProduct p on p.ProductID=t.ProductId  order by tt.TransetraceId desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int Updatetraceablity(int iGPNId, int iSoid, int icustomerid, string sBatchnumber)
        {
            int iSuccess = 0;
            string sQry = "update tblTraceablity set Soid='" + iSoid + "',Cutomerid='" + icustomerid + "',GPNId='" + iGPNId + "' where Batchnumber='" + sBatchnumber + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public int UpdateTrancetraceablity(int iQty, string sUnitname)
        {
            int iSuccess = 0;
            string sQry = "update tblTrancetraceablity set Qty='" + iQty + "' where Unitname='" + sUnitname + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public int UpdateDipatchinsales(string Soid, string prodid)
        {
            int iSuccess = 0;
            string sQry = "update tblTransSo set Dispatch='Picked' where Soid='"+ Soid + "' and Productid='"+prodid+"'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);

            int iSuccess1 = 0;
            string sqry1 = "update tblso set Dispatch='Picked' where Soid='"+ Soid + "'";
            iSuccess1 = dbObj.InlineExecuteNonQuery(sqry1);

            return iSuccess;

        }
        #endregion



        #region Batch treacing report
        public DataSet Batchtracingreport(string sBatchNo)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblGoodReceipts gr inner join  tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on gr.ProductId=p.ProductID inner join tblUnit u on u.TransGRId=gr.GRId Where gr.Batchnumber='" + sBatchNo + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion


        #region Batch  report
        //public DataSet Batchtracingreport(string sBatchNo)
        //{
        //    DataSet ds = new DataSet();
        //    string sQry = "select * from tblGoodReceipts gr inner join  tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on gr.ProductId=p.ProductID inner join tblUnit u on u.TransGRId=gr.GRId Where gr.Batchnumber='" + sBatchNo + "'";
        //    ds = dbObj.InlineExecuteDataSet(sQry);
        //    return ds;
        //}
        #endregion

        #region  Po Report
        public DataSet POReport()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT p.Poid, p.POdatetime, s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount,p.Status,p.POPrintno FROM Suplier s, TblPO p WHERE s.SupplierID = p.SupplierID ORDER BY p.Poid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Podate search
        public DataSet Podatesearch(DateTime fromdate, DateTime todate)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT p.Poid, p.POdatetime, s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount, p.Status,p.POPrintno FROM TblPO p inner join Suplier s ON p.SupplierID = s.SupplierID WHERE p.POdatetime BETWEEN '" + fromdate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' ORDER BY p.Poid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion


        #region GRN Report

        public DataSet GRNreport()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblGoodReceipts gr inner join tblProduct p on gr.ProductId=p.ProductID";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        #endregion

        #region GRNdate search
        public DataSet GRNdatesearch(DateTime fromdate, DateTime todate)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT * from tblGoodReceipts gr inner join tblProduct p on gr.ProductId=p.ProductID WHERE gr.GoodsReceiveddate BETWEEN '" + fromdate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' ORDER BY gr.GRId DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Traceablity
        public DataSet checkProdid(string sBatchNo)
        {
            DataSet ds = new DataSet();
            string sQry = "select productid from tblGoodReceipts where Batchnumber='" + sBatchNo + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int prodId = Convert.ToInt32(ds.Tables[0].Rows[0]["productid"].ToString());
                sQry = "select* from tbltransgoodpicking where batchnumber = '" + sBatchNo + "' and ProdId = " + prodId + "";
                ds = dbObj.InlineExecuteDataSet(sQry);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string unitname = ds.Tables[0].Rows[0]["unitname"].ToString();
                    sQry = " select sum(gp.Qty) as PickQty,su.CompanyName,su.ContactNumber,so.SOPrintno,so.SOdatetime,g.id,g.PickupDate from tblgoodspicking g, tbltransGoodpicking gp,tblSO so, tblTransSupplier s inner join Suplier su on s.supplierid=su.supplierid " +
                            "where gp.Batchnumber = '"+sBatchNo+"'  and gp.prodid = '"+prodId+"' and g.id = gp.goodpickid and g.suppid = s.TransSupplierID and "+
                            "so.Soid = g.SoId and gp.Qty<>0 group by su.CompanyName,su.ContactNumber,so.SOPrintno,so.SOdatetime,g.id,g.PickupDate";
                    ds = dbObj.InlineExecuteDataSet(sQry);
                }


            }
            return ds;
        }
        public DataSet LoadTraceablity1(string sBatchNo)
        {
            DataSet ds = new DataSet();
            // string sQry = "select * from tblGoodReceipts gr inner join  tblTransGoodReceipts tgr on gr.GRId=tgr.GRId inner join tblProduct p on gr.ProductId=p.ProductID inner join tblUnit u on u.TransGRId=gr.GRId Where gr.Batchnumber='" + sBatchNo + "'";
            string sQry = "SELECT  tgr.GRId, sum(tgr.FinalbatchQty) as finalqty,sum(tgr.SampleQty) as sampleqty,sum(tgr.Qty) as totalqty, gr.Batchnumber,tt.Soid,s.CompanyName,s.ContactName,p.Productname,gr.GoodsReceiveddate FROM tblTransGoodReceipts tgr INNER JOIN tblTraceablity tt ON tgr.GRId = tt.GRId INNER JOIN tblGoodReceipts gr ON gr.GRId = tt.GRId inner join TblPO po on po.Poid=gr.Poid  INNER JOIN Suplier s ON po.SupplierId = s.SupplierID INNER JOIN tblProduct p ON gr.ProductId = p.ProductID WHERE gr.Batchnumber = '" + sBatchNo + "' group by  tgr.GRId, gr.Batchnumber,tt.Soid,s.CompanyName,s.ContactName,p.Productname,gr.GoodsReceiveddate; ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Loadgrunits(string sBatchNo) 
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblGoodReceipts gr,tblTransGoodReceipts tgr where gr.GRId=tgr.GRId and gr.Batchnumber='" + sBatchNo + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Loadsodetails(string iSoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTraceablity t inner join TblSO s on t.Soid=s.Soid inner join tblGoodsPicking gp on gp.SoId=s.Soid inner join tblTransGoodPicking tgp on gp.id=tgp.GoodPickid inner join Suplier sup on sup.SupplierID=s.SupplierId where t.Soid='" + iSoid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Pickiing Details
        public DataSet Select_Pickingdetails(DateTime date)
        {
            DataSet ds = new DataSet();
            string sQry = " select sum(tgp.Qty) as TotalQty,s.Soid,gp.PickupDate, sup.CompanyName,s.SoPrintno from tblgoodspicking gp inner join tblso s  on s.Soid=gp.SoId inner join tblTransSupplier ss on ss.TransSupplierID=gp.SuppId inner join Suplier sup on ss.SupplierID=sup.SupplierID  inner join tblTransGoodPicking tgp on tgp.GoodPickid=gp.id where gp.PickupDate='" + date.ToString("yyyy/MM/dd") + "'  group by s.soid,gp.PickupDate,gp.SuppId,sup.CompanyName,s.SoPrintno order by s.Soid desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Pickingdetailsnew()
        {
            DataSet ds = new DataSet();
            string sQry = " select sum(tgp.Qty) as TotalQty,s.Soid,gp.PickupDate, sup.CompanyName,s.SoPrintno from tblgoodspicking gp inner join tblso s  on s.Soid=gp.SoId inner join tblTransSupplier ss on ss.TransSupplierID=gp.SuppId inner join Suplier sup on ss.SupplierID=sup.SupplierID  inner join tblTransGoodPicking tgp on tgp.GoodPickid=gp.id  group by s.soid,gp.PickupDate,gp.SuppId,sup.CompanyName,s.SoPrintno order by s.Soid desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Sodetails(int iSoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select c.Productname,sum(b.Qty) as Qty,a.Soid from tblGoodsPicking as a inner join tblTransGoodPicking as b on b.GoodPickid=a.id inner join tblproduct as c on c.ProductID = b.ProdId where a.SoId = '" + iSoid+ "' group by c.Productname,a.Soid";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Select_Pickvalues(int pickid)
        {
            DataSet ds = new DataSet();
            string sQry = "select tgp.GoodPickid,so.SOPrintno,gp.PickupDate,su.CompanyName,s.PersonName,s.Address,p.Productname,sum(tgp.Qty) as Qty,gp.PickupDate,tgp.Unitname,tgp.ExpiryDate,tgp.Batchnumber,so.Deliverydate,so.Refno from tblTransGoodPicking tgp inner join tblGoodsPicking gp on tgp.GoodPickid = gp.id inner join tblTransSupplier s on gp.SuppId = s.TransSupplierID inner join Suplier su on s.SupplierID = su.SupplierID inner join tblProduct p  on p.productid = tgp.ProdId inner join TblSO so on gp.soid = so.soid inner join tblunit u on u.Unitname = tgp.Unitname   where gp.SoId = '" + pickid+ "' and tgp.Qty <> 0 group by gp.PickupDate,su.CompanyName,s.PersonName,p.Productname,gp.PickupDate,tgp.GoodPickid,so.SOPrintno,s.Address,tgp.Unitname,tgp.ExpiryDate,tgp.Batchnumber,so.Deliverydate,so.Refno";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_PickvaluesExpirydate(int pickid)
        {
            DataSet ds = new DataSet();
            string sQry = "select tgp.GoodPickid,so.SOPrintno,gp.PickupDate,su.CompanyName,s.PersonName,s.Address,p.Productname,sum(tgp.Qty) as Qty,gp.PickupDate,p.Validtill,tr.Expirydate from tblTransGoodPicking tgp inner join tblGoodsPicking gp on tgp.GoodPickid=gp.id inner join tblTransSupplier s on gp.SuppId=s.TransSupplierID inner join Suplier su on s.SupplierID=su.SupplierID inner join tblProduct p  on p.productid=tgp.ProdId inner join TblSO so on gp.soid=so.soid inner join tblunit u on u.Unitname=tgp.Unitname inner join tblGoodReceipts tr  on tr.Batchnumber=u.Batchnumber  where tgp.GoodPickid='"+pickid+"' group by gp.PickupDate,su.CompanyName,s.PersonName,p.Productname,gp.PickupDate,p.Validtill,tgp.GoodPickid,so.SOPrintno,tr.ExpiryDate,s.Address";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region poprintno
        public DataSet GetMaxPOPrintno_only()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT Isnull(MAX(POPrintno+1),5000) AS Printno FROM TblPO";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region soprintno
        public DataSet GetMaxSOPrintno_only()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT Isnull(MAX(SOPrintno+1),15000) AS Printno FROM TblSO";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion


        #region update po values
        public DataSet Select_Prodpoid(int prodid)
        {
            DataSet ds = new DataSet();
            string sQry = "select Productid from TempPo where Productid='"+ prodid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Prodtemp()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TempPo";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int UpdateTempProducts(int Productid, string sProductname, string sDosageform, string sStrength, string sPoQty, string sPriceperpack,string VAT, string sTotalproductamt)
        {
            int iSuccess = 0;
            //string sQry = "insert into TempPo(Productid,Productname,Dosageform,Strength,PoQty,Priceperpack,Productamt) values ('" + Productid + "','" + sProductname + "','" + sDosageform + "','" + sStrength + "','" + sPoQty + "','" + sPriceperpack + "','" + sTotalproductamt + "')";
            string sQry = "update  TempPo set Productname='" + sProductname + "',Dosageform='" + sDosageform + "',Strength='" + sStrength + "',PoQty='" + sPoQty + "',Priceperpack='" + sPriceperpack + "',VAT='"+ VAT + "',Productamt='" + sTotalproductamt + "' where Productid='" + Productid + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }
        public DataSet Select_updatepO(int poid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbltranspo tp inner join tblpo s on tp.poid=s.poid inner join tblproduct p on p.productid=tp.productid inner join suplier su on su.supplierid=s.supplierid inner join tblemployee e on e.employeeid=approverid  where s.Poid='"+poid+"'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_updatepO1(int poid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbltranspo tp inner join tblpo s on tp.poid=s.poid inner join tblproduct p on p.productid=tp.productid inner join suplier su on su.supplierid=s.supplierid inner join tblemployee e on e.employeeid=approverid  where tp.TransPo='" + poid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public int updatetranspoProducts(int poid,int Productid, string sProductname, string sDosageform, string sStrength, string sPoQty, string sPriceperpack,string VAT, string sTotalproductamt)
        {
            int iSuccess = 0;
            string sQry = "insert into tblTransPo(POid,Productid,Productname,Dosageform,Strength,PoQty,Priceperpack,VAT,Productamt,IsGoodReceived) values (" + poid + ",'" + Productid + "','" + sProductname + "','" + sDosageform + "','" + sStrength + "','" + sPoQty + "','" + sPriceperpack + "','"+VAT+"','" + sTotalproductamt + "',0)";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }

        public int deletetranspoold(int transid)
        {
            int iSucess = 0;
            string sQry = "delete tbltranspo  WHERE Poid ='" + transid + "'";

            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }
        public DataSet Select_transPOupdate(int poid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbltranspo where poid='"+ poid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getProductnameforupdatepo(int ProductId, int Poid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransPo tp  where tp.Productid = '" + ProductId + "' and tp.Poid = '" + Poid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Select_tempo()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TempPo";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region SoUpdate 
        public DataSet Select_UpdateSo1(int iSoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbltransso ts inner join tblso s on ts.soid=s.soid inner join tblproduct p on p.productid=ts.productid inner join tblTransSupplier su on su.TransSupplierID=s.supplierid inner join suplier sup on sup.SupplierID=su.SupplierID inner join tblemployee e on e.employeeid=approverid  where s.soid='"+iSoid+"'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_transSOupdate(int Soid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbltransSo where Soid='" + Soid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int deletetranssoold(int transid)
        {
            int iSucess = 0;
            string sQry = "delete tbltransso  WHERE Soid ='" + transid + "'";

            iSucess = dbObj.InlineExecuteNonQuery(sQry);
            return iSucess;
        }

        public int updatetranssoProducts(int soid, int Productid, string sProductname, string sDosageform, string sStrength, string sSoQty, string sPriceperpack,string VAT,string sTotalproductamt)
        {
            int iSuccess = 0;
            string sQry = "insert into tblTransSo(SOid,Productid,Productname,Dosageform,Strength,SoQty,Priceperpack,VAT,Totalamount) values (" + soid + ",'" + Productid + "','" + sProductname + "','" + sDosageform + "','" + sStrength + "','" + sSoQty + "','" + sPriceperpack + "','"+VAT+"','" + sTotalproductamt + "')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }

        public DataSet Select_updateSO(int poid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tbltranspo tp inner join tblpo s on tp.poid=s.poid inner join tblproduct p on p.productid=tp.productid inner join suplier su on su.supplierid=s.supplierid inner join tblemployee e on e.employeeid=approverid  where s.Poid='" + poid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Select_ProdSoid(int prodid)
        {
            DataSet ds = new DataSet();
            string sQry = "select Productid from TempSo where Productid='"+ prodid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public int UpdateTempProductsso(int Productid, string sProductname, string sDosageform, string sStrength, string sPoQty, string sPriceperpack,string VAT, string sTotalproductamt)
        {
            int iSuccess = 0;
            //string sQry = "insert into TempPo(Productid,Productname,Dosageform,Strength,PoQty,Priceperpack,Productamt) values ('" + Productid + "','" + sProductname + "','" + sDosageform + "','" + sStrength + "','" + sPoQty + "','" + sPriceperpack + "','" + sTotalproductamt + "')";
            string sQry = "update  TempSo set Productname='" + sProductname + "',Dosageform='" + sDosageform + "',Strength='" + sStrength + "',SoQty='" + sPoQty + "',Priceperpack='" + sPriceperpack + "',VAT='"+ VAT + "',Totalamount='" + sTotalproductamt + "' where Productid='" + Productid + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }

        public DataSet getProductnameforupdate()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblproduct";
            //string sQry = "select * from tblTransSo ts  where ts.Productid = '"+ ProductId + "' and ts.Soid = '"+ soid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getProductnameforupdate1(int ProductId, int Soid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransSo ts  where ts.Productid = '" + ProductId + "' and ts.Soid = '" + Soid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Update Goods Receipts
        public int UpdateUnitQtyupdate( string Unitname)
        {
            int iSuccess = 0;
            string sQry = "update  tblUnit set TransGRId='0',ProductId='0',Batchnumber='null',Expirydate='1900-01-01',Totalqty='1900-01-01',Status='null',Palletsrefno='null',Isempty=1 where Unitname='" + Unitname + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;

        }

        public DataSet Gettemptbl()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TempPo";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet getProductnametemppo(int ProductId)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TempPo tp  where tp.Productid = '" + ProductId + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Sales Update
        public DataSet Gettemptblso()
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TempSo";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getProductnametempSo(int ProductId)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from TempSo ts  where ts.Productid = '" + ProductId + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet getProductnameforupdateso(int ProductId, int soid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransSo ts  where ts.Productid = '" + ProductId + "' and ts.Soid = '" + soid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Return Sales
        public DataSet GetSonumber(int Suppid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblSO where SupplierId='"+ Suppid + "' and IsReturn=0";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet GetSoDetailsforReturn(int Soid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblSO s inner join tblTransSo ts on s.soid=ts.soid where s.soid='"+Soid+"' and s.IsReturn=0";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Returndatesearch(DateTime fromdate, DateTime todate)
        {
            DataSet ds = new DataSet();
            string sQry = "select r.Returnid,r.ReturnPrintno,r.Returndatetime,r.Status,ts.PersonName, ts.Phone, ts.EmailId,r.ReturnAmount,sup.CompanyName from tblReturn r inner join tblTransSupplier ts on r.supplierid=ts.TransSupplierID inner join Suplier sup  on sup.SupplierID=ts.SupplierID  WHERE r.Returndatetime between '"+ fromdate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' ORDER BY r.Returnid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public int InsertReturnvalues(int Returnid,int iSalesid,int productid,string Licenseno, string Productname, string Dosageform, string Strength, string Packtype, string Packsize, string SoQty, string Priceperpack, string VAT, string Totalamount, string ReturnQty, string ReturnAmnt)
        {
            int iSuccess = 0;
            string sQry = "Insert into tblTransReturn(Returnid,Soid,Productid,LicenseNo,Productname,Dosageform,Strength,Packtype,Packsize,SoQty,Priceperpack,VAT,Totalamount,ReturnQty,ReturnAmount,IsGoodReceived)values('" + Returnid+"','"+ iSalesid + "'" +
                ",'"+ productid + "','"+ Licenseno + "','"+ Productname + "','"+ Dosageform + "','"+ Strength + "','"+ Packtype + "','"+ Packsize + "','"+ SoQty + "','"+ Priceperpack + "','"+ VAT + "','"+ Totalamount + "','"+ ReturnQty + "','"+ ReturnAmnt + "','0')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);


            string sQry1 = "update tblTransso set ReturnQty='"+ ReturnQty + "',IsReturn=1 where Soid='"+ iSalesid + "' and Productid='"+ productid + "'";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry1);

            return iSuccess;

        }

        public DataSet SelectSoDetailsFroReturn(string Soid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblSO s inner join tblTransSo ts on s.soid=ts.soid where s.soid='" + Soid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public int InsertReturn(string SupplierId, DateTime Returndatetime, string ApproverId, string ReturnAmount, string Status, string ReturnPrintno,string Soid)
        {
            int iSuccess = 0;
            string sQry = "insert into TblReturn(SupplierId,Returndatetime,ApproverId,ReturnAmount,Status,ReturnPrintno,Soid) values ('" + SupplierId + "','" + Returndatetime.ToString("yyyy/MM/dd") + "','" + ApproverId + "','" + ReturnAmount + "','" + Status + "','" + ReturnPrintno + "','"+Soid+"')";
            iSuccess = dbObj.InlineExecuteNonQuery(sQry);
            return iSuccess;
        }

        public DataSet GetMaxReturnPrintno_only()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT Isnull(MAX(ReturnPrintno+1),5000) AS Printno FROM TblReturn";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet GetMaxReturnID_only()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT Isnull(MAX(Returnid),1) AS Returnid FROM TblReturn";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Select_Returngrid()
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT r.Returnid,r.ReturnPrintno, r.Returndatetime, su.CompanyName, s.PersonName, s.Phone, s.EmailId, r.ReturnAmount,r.Status  FROM tblTransSupplier s inner join Suplier su on s.SupplierID=su.SupplierID, TblReturn r   WHERE s.TransSupplierID = r.SupplierID ORDER BY r.Returnid DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_ReturnProduct(int iReturnid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblTransReturn Productid  where Returnid ='" + iReturnid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_ReturnGrid()
        {
            DataSet ds = new DataSet();
            string sQry = "select r.Returnid,r.ReturnPrintno,r.Returndatetime,r.Status,ts.PersonName, ts.Phone, ts.EmailId,r.ReturnAmount,sup.CompanyName from tblReturn r inner join tblTransSupplier ts on r.supplierid=ts.TransSupplierID inner join Suplier sup  on sup.SupplierID=ts.SupplierID  WHERE ts.TransSupplierID = r.SupplierID ORDER BY r.Returnid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet EditReturn(int Returnid)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT * FROM  TblReturn r inner join tblTransSupplier s on s.TransSupplierID = r.SupplierID inner join tblEmployee e on r.ApproverId=e.EmployeeId inner join tblTransReturn tr on r.Returnid=tr.Returnid inner join suplier su on su.supplierid=s.SupplierID  where r.Returnid='" + Returnid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public int UpdateReturn(string SupplierId, DateTime Returndatetime, string ApproverId, string ReturnAmount, string Status, string ReturnPrintno,int Returnid,int isoid)
        {
            int iSuccess = 0;
            if (Status== "Approved")
            {
                iSuccess = 1;
                string sQry1 = "Update TblSo Set IsReturn=1 where Soid='"+isoid+"' ";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry1);
                string sQry = "Update TblReturn set SupplierId='" + SupplierId + "',ApproverId='" + ApproverId + "',ReturnAmount='" + ReturnAmount + "',Status='" + Status + "' where Returnid='" + Returnid + "'";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                return iSuccess;
            }
            else
            {
                string sQry1 = "Update TblSo Set IsReturn=1 where Soid='" + isoid + "' ";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry1);
                string sQry = "Update TblReturn set SupplierId='" + SupplierId + "',ApproverId='" + ApproverId + "',ReturnAmount='" + ReturnAmount + "',Status='" + Status + "' where Returnid='" + Returnid + "'";
                iSuccess = dbObj.InlineExecuteNonQuery(sQry);
                return iSuccess;
            }
           
        }

        public DataSet GetSoQtyDetailsforReturn(int Soid,int Productid)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblSO s inner join tblTransSo ts on s.soid=ts.soid where s.soid='" + Soid + "' and Productid='"+ Productid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        //#region Poprint Number

        //public DataSet Select_POPrintNumberchech(string )
        //{
        //    DataSet ds = new DataSet();
        //    string sQry = "select * from tblPO where ";
        //    ds = dbObj.InlineExecuteDataSet(sQry);
        //    return ds;
        //}
        //#endregion

        #region New reports

        public DataSet select_DDLSts(string status,DateTime fromdate,DateTime todate)
        {
            DataSet ds = new DataSet();
            if(status=="Pending")
            {
                string sqry1 = "SELECT distinct tpo.*, p.Poid, p.POdatetime,s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount, CASE WHEN tpo.IsGoodReceived = 0 THEN 'Pending' END AS Status ,p.POPrintno,tpo.IsGoodReceived FROM Suplier s, TblPO p INNER JOIN tblTransPo tpo ON tpo.Poid = p.poid WHERE s.SupplierID = p.SupplierID and tpo.IsGoodReceived=0 and p.POdatetime BETWEEN '"+Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd")+ "' AND '"+Convert.ToDateTime(todate).ToString("yyyy-MM-dd")+"'  ORDER BY p.Poid DESC";
                ds = dbObj.InlineExecuteDataSet(sqry1);
            }
            else if(status=="Completed")
            {
                string sqry2 = "SELECT distinct tpo.*, p.Poid, p.POdatetime,s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount, CASE WHEN tpo.IsGoodReceived = 1 THEN 'Completed' END AS Status ,p.POPrintno,tpo.IsGoodReceived FROM Suplier s, TblPO p INNER JOIN tblTransPo tpo ON tpo.Poid = p.poid WHERE s.SupplierID = p.SupplierID and tpo.IsGoodReceived=1 and p.POdatetime BETWEEN '"+Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd")+ "' AND '"+Convert.ToDateTime(todate).ToString("yyyy-MM-dd")+"'  ORDER BY p.Poid DESC ";
                ds = dbObj.InlineExecuteDataSet(sqry2);
            }
            else
            {
                string sQry = "SELECT distinct tpo.*, p.Poid, p.POdatetime,s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount,p.Status,p.POPrintno FROM Suplier s, TblPO p INNER JOIN tblTransPo tpo ON tpo.Poid = p.poid WHERE s.SupplierID = p.SupplierID And p.Status = '" + status + "' and p.POdatetime BETWEEN '"+Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd")+ "' AND '"+Convert.ToDateTime(todate).ToString("yyyy-MM-dd")+"' ORDER BY p.Poid DESC ";
                ds = dbObj.InlineExecuteDataSet(sQry);
            }
            
            return ds;
        }

        public DataSet Podatesearchnew(DateTime fromdate, DateTime todate)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT tpo.*, p.Poid, p.POdatetime, s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount, p.Status,p.POPrintno FROM TblPO p INNER JOIN tblTransPo tpo ON tpo.Poid = p.poid inner join Suplier s ON p.SupplierID = s.SupplierID  WHERE p.POdatetime BETWEEN '" + fromdate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' ORDER BY p.Poid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Podatesearchby_sts(DateTime fromdate, DateTime todate, string sts)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT tpo.*, p.Poid, p.POdatetime, s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount, p.Status,p.POPrintno FROM TblPO p INNER JOIN tblTransPo tpo ON tpo.Poid = p.poid inner join Suplier s ON p.SupplierID = s.SupplierID WHERE p.Status ='" + sts + "' And p.POdatetime BETWEEN '" + fromdate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' ORDER BY p.Poid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet POReportby_Poid(int poid)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT tpo.*, p.Poid, p.POdatetime, s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount,p.Status,p.POPrintno FROM Suplier s, TblPO p INNER JOIN tblTransPo tpo ON tpo.Poid = p.poid WHERE s.SupplierID = p.SupplierID And p.POPrintno = '" + poid + "' ORDER BY p.Poid DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet PoReportby_SuplierName(string supname)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT tpo.*, p.Poid, p.POdatetime, s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount,p.Status,p.POPrintno FROM Suplier s, TblPO p INNER JOIN tblTransPo tpo ON tpo.Poid = p.poid WHERE s.SupplierID = p.SupplierID And s.ContactName = '" + supname + "' ORDER BY p.Poid DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet PoReportby_Receivedqtycheck(int poid,int prodid)
        {
            DataSet ds = new DataSet();
            string sQry = "select  sum(ReceivedQty) as receivedqty,Poid,ProductId from tblgoodreceipts where Poid='" + poid+"' and ProductId='"+prodid+ "' group by Poid,ProductId";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet SOdatesearchby_DateinSts(DateTime fromdate, DateTime todate, string sts)
        {
            DataSet ds = new DataSet();
            string sQry = "select tas.*, s.Soid,s.SOPrintno, s.SOdatetime, s.Deliverydate,s.Status,ts.PersonName, ts.Phone, ts.EmailId,s.Amount,sup.CompanyName from tblso s INNER JOIN tblTransSo tas ON tas.Soid = s.soid inner join tblTransSupplier ts on s.supplierid=ts.TransSupplierID inner join Suplier sup  on sup.SupplierID=ts.SupplierID WHERE ts.TransSupplierID = s.SupplierID AND s.status = '" + sts + "' And s.SOdatetime BETWEEN '" + fromdate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' ORDER BY s.Soid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Selectbysts_SoGrid(string sts)
        {
            DataSet ds = new DataSet();
            if (sts == "Pending")
            {
                string sQry = "select tas.*, s.Soid,s.SOPrintno, s.SOdatetime, s.Deliverydate,s.Status,ts.PersonName, ts.Phone, ts.EmailId,s.Amount,sup.CompanyName from tblso s INNER JOIN tblTransSo tas ON tas.Soid = s.soid inner join tblTransSupplier ts on s.supplierid=ts.TransSupplierID inner join Suplier sup  on sup.SupplierID=ts.SupplierID WHERE ts.TransSupplierID = s.SupplierID AND s.Status = '" + sts + "' ORDER BY s.Soid DESC";
                ds = dbObj.InlineExecuteDataSet(sQry);
            }
            else if(sts == "Completed")
            {
                string sQry = "SELECT  tas.TransSo,tas.Soid,tas.Productname,tas.SoQty,tas.Priceperpack,tas.Totalamount,s.Soid,s.SOPrintno,s.SOdatetime,"+
                 "s.Deliverydate,ts.PersonName,ts.Phone,ts.EmailId,s.Amount,sup.CompanyName,sum(gp.TotalQty) as ttsqty,"+
                 "case when tas.SoQty=(SELECT SUM(gp2.TotalQty) FROM tblGoodsPicking gp2 WHERE gp2.SoId = s.soid)THEN 'Completed' END AS Status "+
                 "FROM   tblso s INNER JOIN  tblTransSo tas ON tas.Soid = s.soid INNER JOIN  tblTransSupplier ts ON s.supplierid = ts.TransSupplierID "+
                 "INNER JOIN    Suplier sup ON sup.SupplierID = ts.SupplierID INNER JOIN     tblGoodsPicking gp ON gp.SoId = s.soid INNER JOIN "+
                 "tbltransGoodPicking tgp ON tgp.GoodPickid = gp.id  WHERE     ts.TransSupplierID = s.SupplierID    AND tas.SoQty = (SELECT SUM(gp2.TotalQty) FROM tblGoodsPicking gp2 WHERE gp2.SoId = s.soid)"+
                 "GROUP BY tas.TransSo, tas.Soid, tas.Productname, tas.SoQty, tas.Priceperpack, tas.Totalamount, s.Soid, s.SOPrintno, s.SOdatetime, s.Deliverydate, ts.PersonName, ts.Phone, ts.EmailId, s.Amount, sup.CompanyName, gp.TotalQty ORDER BY     s.Soid DESC;";
                ds = dbObj.InlineExecuteDataSet(sQry);
            }
            else
            {
                string sQry = "select tas.*, s.Soid,s.SOPrintno, s.SOdatetime, s.Deliverydate,s.Status,ts.PersonName, ts.Phone, ts.EmailId,s.Amount,sup.CompanyName from tblso s INNER JOIN tblTransSo tas ON tas.Soid = s.soid inner join tblTransSupplier ts on s.supplierid=ts.TransSupplierID inner join Suplier sup  on sup.SupplierID=ts.SupplierID WHERE ts.TransSupplierID = s.SupplierID AND s.Status = '" + sts + "' ORDER BY s.Soid DESC";
                ds = dbObj.InlineExecuteDataSet(sQry);
            }
           
            return ds;
        }

        public DataSet Selectby_SOPrintno(int iSoid)
        {
            DataSet ds = new DataSet();
            string sQry = "select tas.*, s.Soid,s.SOPrintno, s.SOdatetime, s.Deliverydate,s.Status,ts.PersonName, ts.Phone, ts.EmailId,s.Amount,sup.CompanyName from tblso s INNER JOIN tblTransSo tas ON tas.Soid = s.soid inner join tblTransSupplier ts on s.supplierid=ts.TransSupplierID inner join Suplier sup  on sup.SupplierID=ts.SupplierID WHERE ts.TransSupplierID = s.SupplierID And s.SOPrintno =" + iSoid + " ORDER BY s.Soid DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Selectby_SoPersonname(string name)
        {
            DataSet ds = new DataSet();
            string sQry = "select tas.*, s.Soid,s.SOPrintno, s.SOdatetime, s.Deliverydate,s.Status,ts.PersonName, ts.Phone, ts.EmailId,s.Amount,sup.CompanyName from tblso s INNER JOIN tblTransSo tas ON tas.Soid = s.soid inner join tblTransSupplier ts on s.supplierid=ts.TransSupplierID inner join Suplier sup  on sup.SupplierID=ts.SupplierID WHERE ts.TransSupplierID = s.SupplierID And ts.PersonName ='" + name + "' ORDER BY s.Soid DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Select_SoGridnew()
        {
            DataSet ds = new DataSet();
            string sQry = "select tas.*, s.Soid,s.SOPrintno, s.SOdatetime, s.Deliverydate,s.Status,ts.PersonName, ts.Phone, ts.EmailId,s.Amount,sup.CompanyName from tblso s INNER JOIN tblTransSo tas ON tas.Soid = s.soid inner join tblTransSupplier ts on s.supplierid=ts.TransSupplierID inner join Suplier sup  on sup.SupplierID=ts.SupplierID WHERE ts.TransSupplierID = s.SupplierID ORDER BY s.Soid DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet POReportnew(DateTime fromdate,DateTime todate)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT tpo.*, p.Poid, p.POdatetime, s.CompanyName, s.ContactName, s.ContactNumber, s.ContactEmail, p.Amount,p.Status,p.POPrintno FROM Suplier s, TblPO p INNER JOIN tblTransPo tpo ON tpo.Poid = p.poid WHERE s.SupplierID = p.SupplierID and p.POdatetime  BETWEEN '"+Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd")+ "' AND '"+Convert.ToDateTime(todate).ToString("yyyy-MM-dd")+"' ORDER BY p.Poid DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet Select_Unitdetailnew(int Prodid)
        {
            DataSet ds = new DataSet();
            string sQry = "select p.productname, u.unitname,u.Batchnumber,u.Expirydate,u.TotalQty,u.Status from tblunit u inner join tblProduct p on u.ProductId=p.ProductID where u.ProductId='" + Prodid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_Unitdetailforall()
        {
            DataSet ds = new DataSet();
            string sQry = "select p.Productname, u.unitname,u.Batchnumber,u.Expirydate,u.TotalQty,u.Status from tblunit u inner join tblProduct p on u.ProductId=p.ProductID ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Select_UnitBatchdetailnew(int Prodid, string Batchno)
        {
            DataSet ds = new DataSet();
            string sQry = "select p.productname, u.unitname,u.Batchnumber,u.Expirydate,u.TotalQty,u.Status from tblunit u inner join tblProduct p on u.ProductId=p.ProductID where u.ProductId='" + Prodid + "' and u.Batchnumber='" + Batchno + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet SOdatesearchnew(DateTime fromdate, DateTime todate)
        {
            DataSet ds = new DataSet();
            string sQry = "select tas.*, s.Soid,s.SOPrintno, s.SOdatetime, s.Deliverydate,s.Status,ts.PersonName, ts.Phone, ts.EmailId,s.Amount,sup.CompanyName from tblso s INNER JOIN tblTransSo tas ON tas.Soid = s.soid inner join tblTransSupplier ts on s.supplierid=ts.TransSupplierID inner join Suplier sup  on sup.SupplierID=ts.SupplierID WHERE ts.TransSupplierID = s.SupplierID And s.SOdatetime BETWEEN '" + fromdate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' ORDER BY s.Soid DESC;";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet SoReport_grid1(string sts,DateTime fromdate, DateTime todate)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT *FROM (  SELECT s.SOPrintno, ts.Soid, ts.Productname, SUM(tgp.Qty) as qty, tgp.ProdId, ts.SoQty, ts.Totalamount,s.SOdatetime,CASE WHEN SUM(tgp.Qty) = ts.SoQty THEN 'Completed' ELSE 'Pending' END as Status FROM tblGoodsPicking gp INNER JOIN tbltransGoodPicking tgp ON gp.id = tgp.GoodPickid INNER JOIN tblTransSo ts ON ts.Soid = gp.Soid AND ts.productid = tgp.ProdId INNER JOIN tblso s ON s.Soid = ts.Soid AND ts.productid = tgp.ProdId GROUP BY tgp.ProdId, ts.SoQty, ts.Soid, ts.Productname,ts.Totalamount,s.SOPrintno,s.SOdatetime) AS subquery WHERE Status = '" + sts+ "' and SOdatetime BETWEEN '"+fromdate.ToString("yyyy/MM/dd") + "' AND '"+todate.ToString("yyyy/MM/dd") + "' ORDER BY Soid DESC";
            //string sQry = "select * from TblSO s inner join tbltransso ts on s.Soid=ts.Soid where s.Dispatch='Pending' order by s.Soid desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet SoReport_grid2compl(string sts, DateTime fromdate, DateTime todate)
        {
            DataSet ds = new DataSet();
            //string sQry = " SELECT *FROM (  SELECT s.SOPrintno, ts.Soid, ts.Productname, SUM(tgp.Qty) as qty, tgp.ProdId, ts.SoQty, ts.Totalamount,    CASE            WHEN SUM(tgp.Qty) = ts.SoQty THEN 'Completed' \r\n            ELSE 'Pending' \r\n        END as Status  \r\n    FROM tblGoodsPicking gp \r\n    INNER JOIN tbltransGoodPicking tgp ON gp.id = tgp.GoodPickid  \r\n    INNER JOIN tblTransSo ts ON ts.Soid = gp.Soid AND ts.productid = tgp.ProdId \r\n\tINNER JOIN tblso s ON s.Soid = ts.Soid AND ts.productid = tgp.ProdId \r\n    GROUP BY tgp.ProdId, ts.SoQty, ts.Soid, ts.Productname, ts.Totalamount,s.SOPrintno \r\n) AS subquery WHERE Status = '" + sts +"'ORDER BY Soid DESC";
            //string sQry = "select * from TblSO s inner join tbltransso ts on s.Soid=ts.Soid where s.Dispatch='Pending' order by s.Soid desc";
            string sQry = " SELECT *FROM (SELECT s.SOPrintno, ts.Soid, ts.Productname, SUM(tgp.Qty) as qty, tgp.ProdId, ts.SoQty, ts.Totalamount,s.SOdatetime, CASE  WHEN SUM(tgp.Qty) = ts.SoQty THEN 'Completed' ELSE 'Pending' END as Status  FROM tblGoodsPicking gp INNER JOIN  tbltransGoodPicking tgp ON gp.id = tgp.GoodPickid  INNER JOIN tblTransSo ts ON ts.Soid = gp.Soid AND ts.productid = tgp.ProdId INNER JOIN tblso s ON s.Soid = ts.Soid AND ts.productid = tgp.ProdId and s.SOdatetime BETWEEN '" + Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd") + "' GROUP BY tgp.ProdId, ts.SoQty, ts.Soid, ts.Productname,s.SOdatetime, ts.Totalamount,s.SOPrintno) AS subquery WHERE Status = '" + sts + "' ORDER BY Soid DESC";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet SoDispatch_grid()
        {
            DataSet ds = new DataSet();
            string sQry = "select s.SOPrintno, ts.Soid,ts.Productname,tgp.ProdId,ts.SoQty,SUM(tgp.Qty) as PickeQty, (ts.SoQty - SUM(tgp.Qty)) as RemainingQty,"+
                "ts.Totalamount,case when SUM(tgp.Qty)=ts.SoQty then 'Completed' else 'Pending' end as Status,ts.Dispatch from tblGoodsPicking gp inner join "+
                "tbltransGoodPicking tgp on gp.id = tgp.GoodPickid    inner join tblTransSo ts on ts.Soid = gp.Soid and ts.productid = tgp.ProdId inner join tblso s on s.Soid = ts.soid "+
                "group by s.SOPrintno,tgp.ProdId,ts.SoQty,ts.Soid,ts.Productname,ts.Totalamount,ts.Dispatch order by ts.Soid desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }

        public DataSet checkDispatchdtails(string ISoid,string ProdId)
        {
            DataSet ds = new DataSet();
            //string sQry = "SELECT s.CreatedDate,s.SampleNo,s.BatchNo,sp.ProductName,SUM(CAST(sp.SampleQty AS INT)) AS qty,sp.BatchStatus,s.Selectapproverid,emp.EmployeeName FROM tblSampling s JOIN tblSamproduct sp ON s.BatchNo = sp.BatchNo JOIN tblEmployee emp ON emp.EmployeeID = s.Selectapproverid GROUP BY s.CreatedDate,s.SampleNo,s.BatchNo,sp.ProductName,sp.BatchStatus,s.Selectapproverid,emp.EmployeeName ORDER BY s.BatchNo DESC;";
            string sQry = " select s.SOPrintno, ts.Soid,ts.Productname,tgp.ProdId,ts.SoQty,SUM(tgp.Qty) as PickeQty from tblGoodsPicking gp inner join  tbltransGoodPicking tgp on gp.id = tgp.GoodPickid  inner join tblTransSo ts on ts.Soid = gp.Soid and ts.productid = tgp.ProdId inner join  tblso s on s.Soid = ts.soid where ts.Soid='"+ISoid+"' and ts.Productid='"+ProdId+"'  group by s.SOPrintno,tgp.ProdId,ts.SoQty,ts.Soid,ts.Productname,ts.Totalamount order by ts.Soid desc";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region Unitvalue

        public DataSet select_Editunitvalue(int grid,int prodid)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT  (SELECT COUNT(TransGRId) FROM tblTransGoodReceipts WHERE GRId ='"+ grid + "' ) as rows, * FROM tblTransGoodReceipts WHERE GRId ='"+ grid + "' ";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion


        #region Qty check
        public DataSet Getrecqty(string grid)
        {
            DataSet ds = new DataSet();
            string sQry = "SELECT  sum(Qty) as Qty FROM tblTransGoodReceipts tgr inner join tblGoodReceipts gp on gp.GRId=tgr.GRId WHERE tgr.GRId = '" + grid + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Getremcqty(int poid,int prodid)
        {
            DataSet ds = new DataSet();
            string sQry = "select sum(ReceivedQty) as Qty,ProductId from tblGoodReceipts WHERE Poid='" + poid+ "' and ProductId='"+prodid+ "' and Status='Approved' group by ProductId";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet Getremcqtyret(int Retid, int prodid)
        {
            DataSet ds = new DataSet();
            string sQry = "select sum(ReceivedQty) as Qty,ProductId from tblGoodReceipts WHERE Returnid='" + Retid + "' and ProductId='" + prodid + "' and Status='Approved' group by ProductId";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion

        #region clear unitname
        public DataSet Checkunitname(string unitname)
        {
            DataSet ds = new DataSet();
            string sqry = "select unitname from tblunit";
            ds = dbObj.InlineExecuteDataSet(sqry);
                return ds;
        }


        public int ClearUnitvalue(string Unitname)
        {
            int isuccess = 0;
            string sqry = "update tblUnit set Isempty=1,TransGRId=0,ProductId=0,Batchnumber=0,Expirydate='1900-01-01',TotalQty=0,Status='',Palletsrefno='',Returnid=0 where Unitname='"+ Unitname + "'";
            isuccess = dbObj.InlineExecuteNonQuery(sqry);
            return isuccess;

        }
        #endregion

        #region Unit change
        public DataSet CheckPreviousunit(string unitname)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblunit u inner join tblProduct p on p.ProductID=u.ProductId  where unitname='" + unitname+"'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        public DataSet CheckChangeunit(string unitname)
        {
            DataSet ds = new DataSet();
            string sQry = "select * from tblunit where unitname='" + unitname + "'";
            ds = dbObj.InlineExecuteDataSet(sQry);
            return ds;
        }
        #endregion
    }
}