using Exam_Practicing_Vol1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_Practicing_Vol1.Controllers
{
    public class ManagerController : Controller
    {
        List<ManagerModel> managersList = new List<ManagerModel>();
        ManagerModel[] managersArray = new ManagerModel[5]
        {
            new ManagerModel(1, "John Wick", 35, "JohnBlazing@Gmail.com", 5000),
            new ManagerModel(2, "John Rambo", 32, "Kaboom@gmail.com", 100000),
            new ManagerModel(3, "Tony Montana", 38, "WorldIsMine@gmail.com", 5000000),
            new ManagerModel(4, "Tupac Shakur", 30, "Alleyezonme@gmail.com", 1000000),
            new ManagerModel(5, "Bibi Netanyahu", 60, "BombinIran@gmail.com", 200000000)
        };
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetManagerName()
        {
            managersList.AddRange(managersArray);
            ViewBag.manager = managersList[managersList.Count - 1];
            return View();
        }

        public ActionResult GetManager(int id)
        {
            managersList.AddRange(managersArray);

            foreach(ManagerModel manager in managersList)
            {
                if (manager.Id == id) ViewBag.manager = manager;
            }
            return View();
        }
    }
}