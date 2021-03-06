    public abstract class MembershipTestContext
        {
            var membershipService = new Mock<IMembershipService>();
            var formsService = new Mock<IFormsAuthenticationService>();
            var userService = new Mock<IUserService>();
            var dictService = new Mock<IDictionaryService>();
            var shoppingBasketService = new Mock<IShoppingBasketService>(); 
    
            [SetUp]
            //Create the service provider mock and pass in the IRepositoryFactory so that it isn't instantiating real repositories   
            var repoFactory = new Mock<IRepositoryFactory>();   
            var serviceProvider = new Mock<ServiceProvider>( (IRepositoryFactory)repoFactory.Object );   
       
            var context = new Mock<HttpContextBase> { DefaultValue = DefaultValue.Mock };   
            var sessionVars = new Mock<SessionVars>();   
       
            AccountController controller = new AccountController( serviceProvider.Object, sessionVars.Object )   
            {   
                FormsService = formsService.Object,   
                MembershipService = membershipService.Object,   
                UserService = userService.Object,   
                DictionaryService = dictService.Object,   
                ShoppingService = shoppingBasketService.Object   
            };   
            controller.ControllerContext = new ControllerContext()   
            {   
                Controller = controller,   
                RequestContext = new RequestContext( context.Object, new RouteData() )   
            }; 
        }
    [TestFixture]
    public class when_getting_sign_in : MembershipContext
    {
        [Test]
        public void Should_return_view()
        {
            // Act            
            ActionResult result = controller.SignIn();
            // Assert            
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
