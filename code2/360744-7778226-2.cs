    // Handler interface
    interface IHandles<T> where T : ICommand {
    	void Handle(T command);
    }
    // Bus interface
    interface IBus {
    	void Publish<T>(T cmd) where T : ICommand;
    }
    
    // Bus implementation
    class BusImpl : IBus {
    	public void Publish<T>(T cmd) where T : ICommand {
    		var cmdType = cmd.GetType();
    		var handler = (IHandles<T>)IoC.Resolve(typeof(IHandles<>).MakeGenericType(cmdType));
    		handler.Handle(cmd);
    	}
    }
