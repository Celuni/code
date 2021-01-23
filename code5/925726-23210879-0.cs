    <system.web>
        <httpModules>
            <add name="Glimpse" type="Glimpse.AspNet.HttpModule, Glimpse.AspNet"/>
        </httpModules>
        <httpHandlers>
            <add path="glimpse.axd" verb="GET" type="Glimpse.AspNet.HttpHandler, Glimpse.AspNet"/>
        </httpHandlers>
    </system.web>
    <system.webServer>
        <validation validateIntegratedModeConfiguration="false"/>
        <modules>
            <add name="Glimpse" type="Glimpse.AspNet.HttpModule, Glimpse.AspNet" preCondition="integratedMode"/>
        </modules>
        <handlers>
            <add name="Glimpse" path="glimpse.axd" verb="GET" type="Glimpse.AspNet.HttpHandler, Glimpse.AspNet"  preCondition="integratedMode" />
        </handlers>
    </system.webServer>
