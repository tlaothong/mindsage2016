﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace MindSageWeb.Controllers
{
    public class HomeController : Controller
    {
        private CourseController _courseCtrl;

        public HomeController(CourseController courseCtrl)
        {
            _courseCtrl = courseCtrl;
        }

        public IActionResult Index()
        {
            var availableCourses = _courseCtrl.GetAvailableCourseGroups();
            return View(availableCourses);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Detail(string id)
        {
            var selectedCourse = _courseCtrl.GetCourseDetail(id);
            if (selectedCourse == null) return RedirectToAction("Error");

            return View(selectedCourse);
        }
    }
}
