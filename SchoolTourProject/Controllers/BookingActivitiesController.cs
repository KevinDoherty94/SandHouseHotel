using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using SchoolTourProject.Models;

namespace SchoolTourProject.Controllers
{
    public class BookingActivitiesController : Controller
    {
        private SchoolTourEntities1 db = new SchoolTourEntities1();

        // GET: BookingActivities
        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.Booking);
            return View(activities.ToList());
        }
        [Route("ActivityDetails/{id:int?}")]
        // GET: BookingActivities/Details/5
        public ActionResult Details(int? id)
        {
            //Have to write code to send requests to the web api and retrieve info for our seeds

            if (id == null)
            {
                throw new HttpException(400, "The ID was a bad request - 400 Error");
            }
            Activity activity = db.Activities.Find(id);


            if (activity == null)
            {
                throw new HttpException(404, "The ID was not found - 404 Error");
            }

            //Get data from api


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58999/api/");

            var httpResponsMessage = client.GetAsync("GetWeatherDescription/" + activity.ActivityName);

            
                httpResponsMessage.Wait();

            var responseMessageFromApi = httpResponsMessage.Result;

            if (responseMessageFromApi.IsSuccessStatusCode)
            {
                var taskObjectRepresentingString = responseMessageFromApi.Content.ReadAsAsync<string>();
                taskObjectRepresentingString.Wait();

                //passes data from controller to view
                ViewBag.InfoFromApi = taskObjectRepresentingString.Result;
            }
            else
            {
                ViewBag.InfoFromApi = "Error";
                ModelState.AddModelError(string.Empty, "No API available");
            }

            return View(activity);
        }

        // GET: BookingActivities/Create
        public ActionResult Create()
        {
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "Name");
            return View();
        }

        // POST: BookingActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivitiesID,ActivityName,Image,BookingID")] Activity activity, HttpPostedFileBase ImageFileInput)
        {
            if (ModelState.IsValid)
            {
                if (ImageFileInput != null)
                {
                    //Adding an image manually
                    activity.Image = new byte[ImageFileInput.ContentLength];
                    ImageFileInput.InputStream.Read(activity.Image, 0, ImageFileInput.ContentLength);
                }
                db.Activities.Add(activity);
                db.SaveChanges();
                // return RedirectToAction("Index"); //Just in case wanted to create multiple bookings
            }

            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "Name", activity.BookingID);
            return View(activity);
        }

        // GET: BookingActivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "The ID was a bad request - 400 Error");
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                throw new HttpException(404, "The ID was not found - 404 Error");
            }
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "Name", activity.BookingID);
            return View(activity);
        }

        // POST: BookingActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivitiesID,ActivityName,Image,BookingID")] Activity activity, HttpPostedFileBase ImageFileInput)
        {
            if (ImageFileInput != null)
            {
                //Adding an image manually
                activity.Image = new byte[ImageFileInput.ContentLength];
                ImageFileInput.InputStream.Read(activity.Image, 0, ImageFileInput.ContentLength);
            }

            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingID = new SelectList(db.Bookings, "BookingID", "Name", activity.BookingID);
            return View(activity);
        }

        // GET: BookingActivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "The ID was a bad request - 400 Error");
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                throw new HttpException(404, "The ID was not found - 404 Error");
            }
            return View(activity);
        }

        // POST: BookingActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
