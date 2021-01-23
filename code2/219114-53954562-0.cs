        public override Task InitializeAsync()
        {
            Dispose();
            int errorCode;
            if (string.IsNullOrEmpty(DeviceId))
            {
                throw new WindowsException($"{nameof(DeviceDefinition)} must be specified before {nameof(InitializeAsync)} can be called.");
            }
            _DeviceHandle = APICalls.CreateFile(DeviceId, (APICalls.GenericWrite | APICalls.GenericRead), APICalls.FileShareRead | APICalls.FileShareWrite, IntPtr.Zero, APICalls.OpenExisting, APICalls.FileAttributeNormal | APICalls.FileFlagOverlapped, IntPtr.Zero);
            if (_DeviceHandle.IsInvalid)
            {
                //TODO: is error code useful here?
                errorCode = Marshal.GetLastWin32Error();
                if (errorCode > 0) throw new Exception($"Device handle no good. Error code: {errorCode}");
            }
            var isSuccess = WinUsbApiCalls.WinUsb_Initialize(_DeviceHandle, out var defaultInterfaceHandle);
            HandleError(isSuccess, "Couldn't initialize device");
            var bufferLength = (uint)Marshal.SizeOf(typeof(USB_DEVICE_DESCRIPTOR));
            isSuccess = WinUsbApiCalls.WinUsb_GetDescriptor(defaultInterfaceHandle, WinUsbApiCalls.DEFAULT_DESCRIPTOR_TYPE, 0, 0, out _UsbDeviceDescriptor, bufferLength, out var lengthTransferred);
            HandleError(isSuccess, "Couldn't get device descriptor");
            byte i = 0;
            //Get the first (default) interface
            var defaultInterface = GetInterface(defaultInterfaceHandle);
            _UsbInterfaces.Add(defaultInterface);
            while (true)
            {
                isSuccess = WinUsbApiCalls.WinUsb_GetAssociatedInterface(defaultInterfaceHandle, i, out var interfacePointer);
                if (!isSuccess)
                {
                    errorCode = Marshal.GetLastWin32Error();
                    if (errorCode == APICalls.ERROR_NO_MORE_ITEMS) break;
                    throw new Exception($"Could not enumerate interfaces for device {DeviceId}. Error code: { errorCode}");
                }
                var associatedInterface = GetInterface(interfacePointer);
                _UsbInterfaces.Add(associatedInterface);
                i++;
            }
            IsInitialized = true;
            RaiseConnected();
            return Task.CompletedTask;
        }
        public override async Task<byte[]> ReadAsync()
        {
            return await Task.Run(() =>
            {
                var bytes = new byte[ReadBufferSize];
                //TODO: Allow for different interfaces and pipes...
                var isSuccess = WinUsbApiCalls.WinUsb_ReadPipe(_DefaultUsbInterface.Handle, _DefaultUsbInterface.ReadPipe.WINUSB_PIPE_INFORMATION.PipeId, bytes, ReadBufferSize, out var bytesRead, IntPtr.Zero);
                HandleError(isSuccess, "Couldn't read data");
                Tracer?.Trace(false, bytes);
                return bytes;
            });
        }
        public override async Task WriteAsync(byte[] data)
        {
            await Task.Run(() =>
            {
                if (data.Length > WriteBufferSize)
                {
                    throw new Exception($"Data is longer than {WriteBufferSize} bytes which is the device's max buffer size.");
                }
                //TODO: Allow for different interfaces and pipes...
                var isSuccess = WinUsbApiCalls.WinUsb_WritePipe(_DefaultUsbInterface.Handle, _DefaultUsbInterface.WritePipe.WINUSB_PIPE_INFORMATION.PipeId, data, (uint)data.Length, out var bytesWritten, IntPtr.Zero);
                HandleError(isSuccess, "Couldn't write data");
                Tracer?.Trace(true, data);
            });
        }
