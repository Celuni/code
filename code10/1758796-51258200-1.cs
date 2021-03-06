    public ActionResult ReservasHoy()
        {
            DateTime today = DateTime.Today;
            var result = (from p in db.Reservas
                         where DbFunctions.TruncateTime(p.fecha) == today
                         select p)
                         .ToList()
                         .Select(x=>new Project.Models.Reserva 
                         { 
                          Reservas_Tipo=x.p.Reservas_Tipo, 
                          Cliente=x.p.Cliente, 
                          fecha=x.p.fecha 
                         }).ToList();
    
            var r = result.ToList();
            return View(r);
        }
