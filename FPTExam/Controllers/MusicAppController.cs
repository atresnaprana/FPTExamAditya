using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FPTExam.Models;

namespace FPTExam.Controllers
{
    public class MusicAppController : Controller
    {
        ArtistDAL artistDal = new ArtistDAL();

        public IActionResult Index()
        {
            List<ArtistModel> artistList = new List<ArtistModel>();
            artistList = artistDal.GetArtist().ToList();
            return View(artistList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ArtistModel objFld)
        {
            if (ModelState.IsValid)
            {
                artistDal.addArtist(objFld);
                return RedirectToAction("Index");
            }
            return View(objFld);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ArtistModel fld = artistDal.GetArtistById(id);
            if (fld == null)
            {
                return NotFound();
            }
            return View(fld);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] ArtistModel fld)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                artistDal.updateArtist(fld);
                return RedirectToAction("Index");
            }
            return View(fld);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ArtistModel fld = artistDal.GetArtistById(id);
            if (fld == null)
            {
                return NotFound();
            }
            return View(fld);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteArtist(int? id)
        {
            artistDal.deleteArtist(id);
            return RedirectToAction("Index");
        }
    }
}