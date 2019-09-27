using PMSWin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSWin.PurchasingOrder
{
    public class PurchasingOrderUtil
    {
        static string sessionKey = "PurchasingOrderDetailList";

        public static void InitPurchasingOrderDetail()
        {
            //存入Session
            List<PurchasingOrderDetail> podList = null;
            if (Util.GetSessionValue(sessionKey) == null)
            {
                podList = new List<PurchasingOrderDetail>();
                Util.SetSessionValue(sessionKey, podList);
            }
        }

        public static void SetPurchasingOrderDetail(PurchasingOrderDetail pod)
        {
            //存入Session
            List<PurchasingOrderDetail> podList = null;
            if (Util.GetSessionValue(sessionKey) == null)
            {
                podList = new List<PurchasingOrderDetail>();
                podList.Add(pod);
                Util.SetSessionValue(sessionKey, podList);
            }
            else
            {
                podList = (List<PurchasingOrderDetail>)Util.GetSessionValue(sessionKey);
                podList.Add(pod);
            }
        }

        public static List<PurchasingOrderDetail> GetPurchasingOrderDetail()
        {
            List<PurchasingOrderDetail> podList = null;
            if (Util.GetSessionValue(sessionKey) == null)
            {
                return null;
            }
            else
            {
                podList = (List<PurchasingOrderDetail>)Util.GetSessionValue(sessionKey);
                return podList;
            }
        }

        public static int GetPurchasingOrderDetailCount()
        {
            List<PurchasingOrderDetail> pods = GetPurchasingOrderDetail();
            if (pods == null)
            {
                return 0;
            }
            else
            {
                return pods.Count();
            }
        }

        public static string GetPurchasingOrderDetailStatus()
        {
            return $"已選取料件筆數 ({GetPurchasingOrderDetailCount()})";
        }

    }
}
