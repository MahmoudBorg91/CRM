using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GSI_Internal.Repositry.ApiRepositry.Services
{
    public static class SmsService
    {
        private static string _username = "YHf72WYP";
        private static string _password = "XCcgjVJ4y2";
        private static string _sender = "GMG Dewan";
        private static string _apiUrl = "https://smsmisr.com/api/webapi/?";

        public static async Task<string> SendMessage(string phoneCountryCode, string phoneNumber, string message)
        {
            if (phoneNumber.StartsWith("+"))
            {
                phoneNumber = phoneNumber.Remove(0, 1);
            }
            if (!phoneNumber.StartsWith("2"))
            {
                phoneNumber = "2" + phoneNumber;
            }

            if (!string.IsNullOrEmpty(phoneCountryCode) && !string.IsNullOrEmpty(phoneNumber) && !string.IsNullOrEmpty(message))
            {
                try
                {
                    var endPoint = _apiUrl + "username=" + _username + "&password=" + _password + "&language=2" + "&message=" + message + "&sender=" + _sender + "&mobile=" + phoneNumber;
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        // var bodyJS = JsonConvert.SerializeObject(new PaymentStatusDto());
                        var body = new StringContent("aaaaa", Encoding.UTF8, "application/json");
                        var response = client.PostAsync(endPoint, body).GetAwaiter().GetResult();
                        var x = await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode == true)
                        {
                            return "تم ارسال الرسالة بنجاح";
                        }
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                    //  return "برجاء المحاوله مره اخرى";
                }
            }
            return null;
        }

        public static async Task<string> SendMessageToMultipleUsers(string phoneCountryCode, List<string> phoneNumbers, string message)
        {
            for (int i = 0; i < phoneNumbers.Count; ++i)
            {
                if (phoneNumbers[i].StartsWith("+"))
                {
                    phoneNumbers[i] = phoneNumbers[i].Remove(0, 1);
                }
                if (!phoneNumbers[i].StartsWith("2"))
                {
                    phoneNumbers[i] = "2" + phoneNumbers[i];
                }
            }
            if (!string.IsNullOrEmpty(phoneCountryCode) && phoneNumbers != null && phoneNumbers.Count() > 0 && !string.IsNullOrEmpty(message))
            {
                var mobiles = string.Join(",", phoneNumbers);
                var endPoint = _apiUrl + "username=" + _username + "&password=" + _password + "&language=2" + "&message=" + message + "&sender=" + _sender + "&mobile=" + mobiles;

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        // var bodyJS = JsonConvert.SerializeObject(new PaymentStatusDto());
                        var body = new StringContent("aaaa", Encoding.UTF8, "application/json");
                        var response = client.PostAsync(endPoint, body).GetAwaiter().GetResult();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            return "تم ارسال الرسالة بنجاح";
                        }
                        else
                        {
                            return "عفواً ، برجاء المحاوله لاحقاً ، فى حاله تكرر المشكلة برجاء التواصل مع التقنى.";
                        }
                    }
                    catch
                    {
                        return "عفواً ، برجاء المحاوله لاحقاً ، فى حاله تكرر المشكلة برجاء التواصل مع التقنى.";
                    }
                }
            }
            else
            {
                return "برجاء التأكد من صحة المدخلات";
            }
        }
    }
}
