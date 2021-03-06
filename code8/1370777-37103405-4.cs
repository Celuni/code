    public class ProjectsController : Controller {
        private IUserManager userManager;
        private IDbContext db;
        public ProjectController(IDbContext db, IUserManager userManager) {
            this.userManager = userManager;
            this.db = db;
        }
        public async Task<ActionResult> Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null) {
                return HttpNotFound();
            }
            //construct model...                    
            var model = new ProjectDetailsViewModel {
                Project = project,
                Applications = await BuildApplicationModels(project.Applications)
            }
            return View(model);
        }
        private async Task<IEnumerable<ProjectDetailsApplicationModel>> BuildApplicationModels(IEnumerable<Application> applications) {
            List<ProjectDetailsApplicationModel> result = new List<ProjectDetailsApplicationModel>();
            foreach (var application in applications) {
                var model = new ProjectDetailsApplicationModel {
                    ApplicationId = application.ApplicationId,
                    ProjectId = application.ProjectId,
                    UserId = application.UserId,
                    CoverLetter = application.CoverLetter
                };
                var user = await userManager.FindByIdAsync(application.UserId);
                if (user != null) {
                    model.UserName = user.UserName;
                    model.Email = user.Email;
                }
                result.Add(model);
            }
            return result;
        }
    }
