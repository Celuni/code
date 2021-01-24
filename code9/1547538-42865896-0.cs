    <Project Sdk="Microsoft.NET.Sdk">
    
      <PropertyGroup>
        <Description>An FTP and FTPS library for .NET, optimized for speed. Provides extensive FTP commands, file uploads/downloads, SSL/TLS connections and FTP proxies.</Description>
        <VersionPrefix>16.3.0</VersionPrefix>
        <Authors>J.P. Trosclair;Harsh Gupta</Authors>
        <TargetFramework>netstandard1.6</TargetFramework>
        <DefineConstants>$(DefineConstants);CORE</DefineConstants>
        <RootNamespace>FluentFTP</RootNamespace>
        <AssemblyName>FluentFTP</AssemblyName>
        <OutputType>Library</OutputType>
        <PackageId>FluentFTP</PackageId>
        <NetStandardImplicitPackageVersion>1.6.0</NetStandardImplicitPackageVersion>
        <GenerateAssemblyTitleAttribute>false</GenerateAssemblyTitleAttribute>
        <GenerateAssemblyDescriptionAttribute>false</GenerateAssemblyDescriptionAttribute>
        <GenerateAssemblyConfigurationAttribute>false</GenerateAssemblyConfigurationAttribute>
        <GenerateAssemblyCompanyAttribute>false</GenerateAssemblyCompanyAttribute>
        <GenerateAssemblyProductAttribute>false</GenerateAssemblyProductAttribute>
        <GenerateAssemblyCopyrightAttribute>false</GenerateAssemblyCopyrightAttribute>
        <GenerateAssemblyVersionAttribute>false</GenerateAssemblyVersionAttribute>
        <GenerateNeutralResourcesLanguageAttribute>false</GenerateNeutralResourcesLanguageAttribute>
      </PropertyGroup>
    
      <ItemGroup>
        <PackageReference Include="System.IO" Version="4.3.0.0" />
        <PackageReference Include="System.Net.NameResolution" Version="4.3.0.0" />
        <PackageReference Include="System.Net.Sockets" Version="4.3.0.0" />
        <PackageReference Include="System.Net.Security" Version="4.3.0.0" />
      </ItemGroup>
    
    </Project>
