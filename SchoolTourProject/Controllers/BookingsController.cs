using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolTourProject.Models;

namespace SchoolTourProject.Controllers
{
    public class BookingsController : Controller
    {
        private SchoolTourEntities1 db = new SchoolTourEntities1();

        

        // GET: Bookings
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }

        /*Need to go to web.config, to set this up*/

        /*[HandleError]*/ //Ive now made this global by going to Global.asax

        [Route("ShowBookingDetails/{id:int?}")]
        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            //Below is just for testing

            //if (id <= 0)
            //{
            //    //Throw an exception 
            //    throw new Exception("Kevins error happened");
            //}

            if (id == null)
            {
                //Below doesnt work anymore

                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                //Below does work

                throw new HttpException(400, "The ID was a bad request - 400 Error");
            }
            Booking booking = db.Bookings.Find(id);

            if (booking == null)
            {
                //Below doesnt work anymore

                //return HttpNotFound();

                //Below does work

                throw new HttpException(404, "The ID was not found - 404 Error");

            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,Name,PhoneNumber,Address,Email,SchoolName,ClassSize")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "The ID was a bad request - 400 Error");
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                throw new HttpException(404, "The ID was not found - 404 Error");
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,Name,PhoneNumber,Address,Email,SchoolName,ClassSize")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "The ID was a bad request - 400 Error");
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                throw new HttpException(404, "The ID was not found - 404 Error");
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
