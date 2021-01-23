        public async Task<IEnumerable<DeviceDefinition>> GetConnectedDeviceDefinitions(uint? vendorId, uint? productId)
        {
            var aqsFilter = "System.Devices.InterfaceClassGuid:=\"{DEE824EF-729B-4A0E-9C14-B7117D33A817}\" AND System.Devices.InterfaceEnabled:=System.StructuredQueryType.Boolean#True AND " + $" System.DeviceInterface.WinUsb.UsbVendorId:={vendorId.Value} AND System.DeviceInterface.WinUsb.UsbProductId:={productId.Value}";
            var deviceInformationCollection = await wde.DeviceInformation.FindAllAsync(aqsFilter).AsTask();
            //TODO: return the vid/pid if we can get it from the properties. Also read/write buffer size
            var deviceIds = deviceInformationCollection.Select(d => new DeviceDefinition { DeviceId = d.Id, DeviceType = DeviceType.Usb }).ToList();
            return deviceIds;
        }
