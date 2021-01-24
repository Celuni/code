    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    
    namespace MyProject.Controllers
    {
        public class HomeController : Controller
        {
            const string SessionKeyName = "_Name";
            const string SessionKeyFY = "_FY";
            const string SessionKeyDate = "_Date";
    
            public IActionResult Index()
            {
                HttpContext.Session.SetString(SessionKeyName, "Nam Wam");
                HttpContext.Session.SetInt32(SessionKeyFY , 2017);
                // Requires you add the Set extension method mentioned in the SessionExtensions static class.
                HttpContext.Session.Set<DateTime>(SessionKeyDate, DateTime.Now);
    
                return View();
            }
    
            public IActionResult About()
            {
                ViewBag.Name = HttpContext.Session.GetString(SessionKeyName);
                ViewBag.Age = HttpContext.Session.GetInt32(SessionKeyFY);
                ViewBag.Date = HttpContext.Session.Get<DateTime>(SessionKeyDate);
    
                ViewData["Message"] = "Session State In Asp.Net Core 1.1";
    
                return View();
            }
    
            public IActionResult Contact()
            {
                ViewData["Message"] = "Contact Details";
    
                return View();
            }
    
            public IActionResult Error()
            {
                return View();
            }
            
        }
    
        public static class SessionExtensions
        {
            public static void Set<T>(this ISession session, string key, T value)
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }
    
            public static T Get<T>(this ISession session, string key)
            {
                var value = session.GetString(key);
                return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
            }
        }
    }
