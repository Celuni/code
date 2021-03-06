    var model1 = new LuisModel("model1", "");
    var model2 = new LuisModel("model2", "");
    
    builder.RegisterType<LuisService>()
           .WithParameter("model", model1)
           .Keyed<ILuisService>(FiberModule.Key_DoNotSerialize)
           .AsImplementedInterfaces()
           .SingleInstance(); or // .InstancePerLifetimeScope()
    
    builder.RegisterType<LuisService>()
           .WithParameter("model", model2)
           .Keyed<ILuisService>(FiberModule.Key_DoNotSerialize)
           .AsImplementedInterfaces()
           .SingleInstance(); or // .InstancePerLifetimeScope()
