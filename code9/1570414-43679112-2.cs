    public class Bootstrapper
    {
        private readonly UnityContainer _container;
        private Bootstrapper()
        {
            _container = new UnityContainer();
        }
        public Program Intialize()
        {
            this.ConfigureDependencies(UnityContainer container);
            return this.GetCompositionRoot();
        }
        private void ConfigureDependencies()
        {
            _container.RegisterType<IUserProvider, UserProviderSimple>();
            _container.RegisterType<IUserService, UserServiceSimple>();
            _container.RegisterType<Program, Program>();
        }
        private Program GetCompositionRoot()
        {
            return _container.Resolve<Program>();
        }
    }
    public class Program
    {
        public Program(IUserService userService)
        {
            _userService = userService ?? throw AgrumentNullExcpetion(nameof(userService));
        }
        static void Main(string[] args)
        {
            var program = new Bootstrapper().Initialize();
            program.Run();
        }
        public void Run()
        {
            // Do your work using the injected dependency _userService
            // and return (exit) when done.
        }
    }
