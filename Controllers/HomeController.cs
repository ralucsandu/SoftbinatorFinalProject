using FinalProject.Models;
using FinalProject.Repositories;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConcertsRepository _concertRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IConcertsRepository concertRepository,
                              IHostingEnvironment hostingEnvironment)
        {
            _concertRepository = concertRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ConcertCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (model.Photo != null)
                {

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
  
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                ConcertModel2 newConcert = new ConcertModel2
                {
                    ConcertName = model.ConcertName,
                    Date = model.Date,
                    Location = model.Location,
                    PhotoPath = uniqueFileName
                };

                // _concertRepository.CreateConcert(newConcert);
                return RedirectToAction("details", new { id = newConcert.Id });
            }

            return View();
        }
    }
}