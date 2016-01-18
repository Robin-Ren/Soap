using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sopon.Library
{
    public class OutcomeCallResult
    {
        public List<OutCome> OutcomeDetails;
    }

    public class OutCome
    {
        private double m_Amout;

        public double Amout
        {
            get { return m_Amout; }
            set { m_Amout = value; }
        }
        private string m_OutcomeName;

        public string OutcomeName
        {
            get { return m_OutcomeName; }
            set { m_OutcomeName = value; }
        }
        private string m_OutcomeDesc;

        public string OutcomeDesc
        {
            get { return m_OutcomeDesc; }
            set { m_OutcomeDesc = value; }
        }
        private double m_GoodsUnitPrice;

        public double GoodsUnitPrice
        {
            get { return m_GoodsUnitPrice; }
            set { m_GoodsUnitPrice = value; }
        }
        private int m_GoodsCount;

        public int GoodsCount
        {
            get { return m_GoodsCount; }
            set { m_GoodsCount = value; }
        }

        private DateTime m_CreatedDate;

        public DateTime CreatedDate
        {
            get { return m_CreatedDate; }
            set { m_CreatedDate = value; }
        }
    }
}