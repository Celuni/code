    public async Task<IActionResult> LoadEmployee(string id)
    {
        var employee = await repository.GetById(id);
        if(employee == null) {
            return NotFound();
        }
        return StatusCode((int)HttpStatusCode.Ok, employee);
    }
