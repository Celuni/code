    BusinessUnit unit = new BusinessUnit();
    unit.CompanyName = name;
    unitOfWork.ExternalPluginRepository.Attach(accountsModuleId);
    unitOfWork.ExternalPluginRepository.Attach(contactsModuleId);
    unit.AccountsDataSourceModule = accountsModuleId;
    unit.OptionalContactsDataSourceModule = contactsModuleId;
    unitOfWork.BusinessUnitRepository.Insert(unit);
