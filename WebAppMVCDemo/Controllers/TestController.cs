using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVCDemo.Controllers
{
    public class TestController: Controller
    {
        public ActionResult MyView()
        {
            return View(); 
        }

        public string Action2()
        {
            return "Hello world!"; 
        }

        public string Action3()
        {
            return
                "<html> <title> Tester un </title> " +
                "<body>" +
                " <h1> Text in H1 </h1> " +
                "<p> un paragraphe avec du <b> gras de <i> l'italique </i> et du <u> souligné </u> </p>"+
                "du <b style = 'color:red'; >  gras et rouge </b>"+
                "suite du paragraphe <span style = 'color:blue'; > en bleu ... </span>" +
                "</body> " +


                "</html>"; 

            
        }

        public JsonResult GetJson()
        {
            var data = new { nom = "LE", premon = "Van Anh" };
            return Json(data, JsonRequestBehavior.AllowGet); 
        }
    }
}