using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace TransServiceWebApp.Infrastucture
{
    public class SessionContext
    {
        public void SetAuthToken(string name, bool visPersistant, string userId)
        {
            string data = null;
            if (userId != null)
            {
                data = new JavaScriptSerializer().Serialize(userId);
            }

            var ticket
                = new FormsAuthenticationTicket
                (1, name, DateTime.Now, DateTime.Now.AddMinutes(5), visPersistant, userId);

            string cookieData = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData)
            {
                HttpOnly = true,
                Expires = ticket.Expiration
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public int GetLoginId()
        {
            //var session = HttpContext.Current.Session["LoginId"];
            //if(session != null)
            //{
            //    int.TryParse(session.ToString(), out int loginId);
            //    return loginId;
            //}
            //else
            //{
            //    //TODO opisac
            //    throw new Exception();
            //}
            string loginId = null;
            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                    loginId = new JavaScriptSerializer().Deserialize(ticket.UserData, typeof(string)) as string;
                    int.TryParse(loginId, out int idLoginI);
                    return idLoginI;
                }
                //TODO opisac blad 
                throw new Exception();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
