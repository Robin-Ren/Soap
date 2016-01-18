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
        private int m_sid;

        public int ID
        {
            get { return m_sid; }
            set { m_sid = value; }
        }
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

        private string m_CreatedDate;

        public string CreatedDate
        {
            get { return m_CreatedDate; }
            set { m_CreatedDate = value; }
        }

        private string m_DateModified;

        public string DateModified
        {
            get { return m_DateModified; }
            set { m_DateModified = value; }
        }

        private bool m_IsDeleted;

        public bool IsDeleted
        {
            get { return m_IsDeleted; }
            set { m_IsDeleted = value; }
        }
    }

    public enum BrowseType
    {
        Normal = 0,
        Search = 1,
    }
}