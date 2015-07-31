using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace Print
{
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
