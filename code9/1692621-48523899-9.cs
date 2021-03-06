    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "chimeTimeID,schedule,ChimeTimeStamp")] ChimeTime chimeTime)
    {
        ViewData["ScheduleID"] = new SelectList(db.Schedules, "scheduleID", "ScheduleName", "Select a Schedule");
        ViewBag.defaultModem = new SelectList(db.Schedules, "scheduleID", "ScheduleName", "Select a Schedule");
        if (ModelState.IsValid)
        {
            db.ChimeTimes.Add(chimeTime);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        buildChimeJob(chimeTime);
        return View(chimeTime);
    }
    
