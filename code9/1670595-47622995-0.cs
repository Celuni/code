    public async Task<ActionResult> Add(Dog dog, string type)
    {
        if (!ModelState.IsValid)
            return View(dog);
        var vm = new AddDogVM();
        vm.Add(dog, type);
            
        return RedirectToAction("Home");
    }
