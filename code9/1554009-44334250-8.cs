    public class ContentParameterBinding : FormatterParameterBinding
    {
        private struct AsyncVoid{}
        public ContentParameterBinding(HttpParameterDescriptor descriptor) : base(descriptor, descriptor.Configuration.Formatters,
                   descriptor.Configuration.Services.GetBodyModelValidator())
        {
        }
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
                                                    HttpActionContext actionContext,
                                                    CancellationToken cancellationToken)
        {
        }
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
                                                    HttpActionContext actionContext,
                                                    CancellationToken cancellationToken)
        {
            var binding = actionContext.ActionDescriptor.ActionBinding;
            if (binding.ParameterBindings.Length > 1 ||
                actionContext.Request.Method == HttpMethod.Get)
            {
                var taskSource = new TaskCompletionSource<AsyncVoid>();
                taskSource.SetResult(default(AsyncVoid));
                return taskSource.Task as Task;
            }
            var type = binding.ParameterBindings[0].Descriptor.ParameterType;
            if (type == typeof(HttpContent))
            {
                SetValue(actionContext, actionContext.Request.Content);
                var tcs = new TaskCompletionSource<object>();
                tcs.SetResult(actionContext.Request.Content);
                return tcs.Task;
            }
            if (type == typeof(Stream))
            {
                return actionContext.Request.Content
                .ReadAsStreamAsync()
                .ContinueWith((task) =>
                {
                    SetValue(actionContext, task.Result);
                });
            }
            throw new InvalidOperationException("Only HttpContent and Stream are supported for [FromContent] parameters");
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public sealed class FromContentAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            if (parameter == null)
                throw new ArgumentException("Invalid parameter");
            return new ContentParameterBinding(parameter);
        }
    }
