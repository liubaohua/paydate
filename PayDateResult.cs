using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Reporting.WinForms;


namespace Print
{
    public class MyClass : IReportViewerMessages
    {
        string IReportViewerMessages.BackButtonToolTip
        {
            get { return "后退"; }
        }

        string IReportViewerMessages.BackMenuItemText
        {
            get { return ""; }
        }

        string IReportViewerMessages.ChangeCredentialsText
        {
            get { return ""; }
        }

        string IReportViewerMessages.CurrentPageTextBoxToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.DocumentMapButtonToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.DocumentMapMenuItemText
        {
            get { return ""; }
        }

        string IReportViewerMessages.ExportButtonToolTip
        {
            get { return "导出"; }
        }

        string IReportViewerMessages.ExportMenuItemText
        {
            get { return ""; }
        }

        string IReportViewerMessages.FalseValueText
        {
            get { return ""; }
        }

        string IReportViewerMessages.FindButtonText
        {
            get { return ""; }
        }

        string IReportViewerMessages.FindButtonToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.FindNextButtonText
        {
            get { return ""; }
        }

        string IReportViewerMessages.FindNextButtonToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.FirstPageButtonToolTip
        {
            get { return "首页"; }
        }

        string IReportViewerMessages.LastPageButtonToolTip
        {
            get { return "末页"; }
        }

        string IReportViewerMessages.NextPageButtonToolTip
        {
            get { return "下一页"; }
        }

        string IReportViewerMessages.NoMoreMatches
        {
            get { return "没有找到更多的匹配"; }
        }

        string IReportViewerMessages.NullCheckBoxText
        {
            get { return ""; }
        }

        string IReportViewerMessages.NullCheckBoxToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.NullValueText
        {
            get { return "空值"; }
        }

        string IReportViewerMessages.PageOf
        {
            get { return ""; }
        }

        string IReportViewerMessages.PageSetupButtonToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.PageSetupMenuItemText
        {
            get { return ""; }
        }

        string IReportViewerMessages.ParameterAreaButtonToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.PasswordPrompt
        {
            get { return ""; }
        }

        string IReportViewerMessages.PreviousPageButtonToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.PrintButtonToolTip
        {
            get { return "打印"; }
        }

        string IReportViewerMessages.PrintLayoutButtonToolTip
        {
            get { return "打印布局"; }
        }

        string IReportViewerMessages.PrintLayoutMenuItemText
        {
            get { return ""; }
        }

        string IReportViewerMessages.PrintMenuItemText
        {
            get { return ""; }
        }

        string IReportViewerMessages.ProgressText
        {
            get { return ""; }
        }

        string IReportViewerMessages.RefreshButtonToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.RefreshMenuItemText
        {
            get { return ""; }
        }

        string IReportViewerMessages.SearchTextBoxToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.SelectAValue
        {
            get { return ""; }
        }

        string IReportViewerMessages.SelectAll
        {
            get { return ""; }
        }

        string IReportViewerMessages.StopButtonToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.StopMenuItemText
        {
            get { return ""; }
        }

        string IReportViewerMessages.TextNotFound
        {
            get { return ""; }
        }

        string IReportViewerMessages.TotalPagesToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.TrueValueText
        {
            get { return ""; }
        }

        string IReportViewerMessages.UserNamePrompt
        {
            get { return ""; }
        }

        string IReportViewerMessages.ViewReportButtonText
        {
            get { return ""; }
        }

        string IReportViewerMessages.ViewReportButtonToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.ZoomControlToolTip
        {
            get { return ""; }
        }

        string IReportViewerMessages.ZoomMenuItemText
        {
            get { return ""; }
        }

        string IReportViewerMessages.ZoomToPageWidth
        {
            get { return ""; }
        }

        string IReportViewerMessages.ZoomToWholePage
        {
            get { return ""; }
        }
    }

    public class PayDateResult
    {
        public String 序号 { get; set; }
        public String cPOID { get; set; }
        public String cmaketime { get; set; }
        public String cVenName { get; set; }
        public String cexch_name { get; set; }
        public String cInvCode { get; set; }
        public String cInvName { get; set; }
        public String cInvStd { get; set; }
        public String cInvAddCode { get; set; }

        public String cComUnitName { get; set; }
        public Decimal iQuantity { get; set; }
        public Decimal iMoney { get; set; }
        public Decimal iSum { get; set; }
        public Decimal iNatMoney { get; set; }
        public Decimal iNatSum { get; set; }


        public Decimal iMoney_Total { get; set; }
        public Decimal iSum_Total { get; set; }
        public Decimal iNatMoney_Total { get; set; }
        public Decimal iNatSum_Total { get; set; }




        public Decimal iTaxPrice { get; set; }
        public Decimal iNatInvMoney { get; set; }
        public Decimal iOriTotal { get; set; }
        public Decimal iTotal { get; set; }


        public Decimal iTaxPrice_Total { get; set; }
        public Decimal iNatInvMoney_Total { get; set; }
        public Decimal iOriTotal_Total { get; set; }
        public Decimal iTotal_Total { get; set; }


        public DateTime dPBVDate { get; set; }
        public String PayTerm { get; set; }
        public DateTime PayDate { get; set; }
        public String cmaker { get; set; }
        


    }
}
