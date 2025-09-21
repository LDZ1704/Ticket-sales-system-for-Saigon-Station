using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace BUS_TicketSalesSystem
{
    public class VnpayLibrary
    {
        public const string VERSION = "2.1.0";

        private SortedList<string, string> _requestData = new SortedList<string, string>(new VnpayCompare());
        private SortedList<string, string> _responseData = new SortedList<string, string>(new VnpayCompare());

        #region Request

        // Thêm tham số cho request gửi đi VNPay
        public void AddRequestData(string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
                _requestData.Add(key, value);
        }

        // Tạo URL thanh toán - cách đơn giản nhất
        public string CreateRequestUrl(string baseUrl, string vnp_HashSecret)
        {
            StringBuilder data = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in _requestData)
            {
                if (!string.IsNullOrEmpty(kv.Value))
                {
                    data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                }
            }
            string queryString = data.ToString();

            string url = baseUrl + "?" + queryString;
            if (queryString.EndsWith("&"))
                queryString = queryString.Substring(0, queryString.Length - 1);
            
            string vnp_SecureHash = Utils.HmacSHA512(vnp_HashSecret, queryString);
            url += "vnp_SecureHash=" + vnp_SecureHash;

            return url;
        }

        #endregion

        #region Response

        // Thêm dữ liệu VNPay trả về
        public void AddResponseData(string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
                _responseData.Add(key, value);
        }

        // Lấy giá trị từ response
        public string GetResponseData(string key)
        {
            string retValue;
            if (_responseData.TryGetValue(key, out retValue))
            {
                return retValue;
            }
            else
            {
                return string.Empty;
            }
        }

        // Xác minh chữ ký VNPay - KHÔNG encode URL
        public bool ValidateSignature(string inputHash, string secretKey)
        {
            // Loại bỏ vnp_SecureHash và vnp_SecureHashType
            string rawData = GetResponseDataRaw();
            string myHash = Utils.HmacSHA512(secretKey, rawData);
            return myHash.Equals(inputHash, StringComparison.InvariantCultureIgnoreCase);
        }

        private string GetResponseDataRaw()
        {
            StringBuilder data = new StringBuilder();
            if (_responseData.ContainsKey("vnp_SecureHashType"))
            {
                _responseData.Remove("vnp_SecureHashType");
            }
            if (_responseData.ContainsKey("vnp_SecureHash"))
            {
                _responseData.Remove("vnp_SecureHash");
            }
            foreach (KeyValuePair<string, string> kv in _responseData)
            {
                if (!string.IsNullOrEmpty(kv.Value))
                {
                    data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                }
            }
            //remove last '&'
            if (data.Length > 0)
            {
                data.Remove(data.Length - 1, 1);
            }
            return data.ToString();
        }
        #endregion

        public SortedList<string, string> GetRequestData()
        {
            return _requestData;
        }
    }

    internal class Utils
    {
        // Tạo HMAC SHA512 - sửa lại theo chuẩn VNPay
        public static string HmacSHA512(string key, string inputData)
        {
            var hash = new StringBuilder();
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);

            using (var hmac = new HMACSHA512(keyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                foreach (var b in hashValue)
                {
                    hash.Append(b.ToString("x2"));
                }
            }
            return hash.ToString();
        }
    }

    // So sánh key theo chuẩn VNPay (alphabetical order)
    internal class VnpayCompare : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            var vnpCompare = CompareInfo.GetCompareInfo("en-US");
            return vnpCompare.Compare(x, y, CompareOptions.Ordinal);
        }
    }
}
