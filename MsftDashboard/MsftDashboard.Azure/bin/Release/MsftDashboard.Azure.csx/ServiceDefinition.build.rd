<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="MsftDashboard.Azure" generation="1" functional="0" release="0" Id="c63292e6-d056-4ac8-bfb2-d59c8097f594" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="MsftDashboard.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="MsftDashboard.Web:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/LB:MsftDashboard.Web:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="MsftDashboard.Web:?IsSimulationEnvironment?" defaultValue="">
          <maps>
            <mapMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MapMsftDashboard.Web:?IsSimulationEnvironment?" />
          </maps>
        </aCS>
        <aCS name="MsftDashboard.Web:?RoleHostDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MapMsftDashboard.Web:?RoleHostDebugger?" />
          </maps>
        </aCS>
        <aCS name="MsftDashboard.Web:?StartupTaskDebugger?" defaultValue="">
          <maps>
            <mapMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MapMsftDashboard.Web:?StartupTaskDebugger?" />
          </maps>
        </aCS>
        <aCS name="MsftDashboard.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MapMsftDashboard.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="MsftDashboard.WebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MapMsftDashboard.WebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:MsftDashboard.Web:Endpoint1">
          <toPorts>
            <inPortMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MsftDashboard.Web/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapMsftDashboard.Web:?IsSimulationEnvironment?" kind="Identity">
          <setting>
            <aCSMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MsftDashboard.Web/?IsSimulationEnvironment?" />
          </setting>
        </map>
        <map name="MapMsftDashboard.Web:?RoleHostDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MsftDashboard.Web/?RoleHostDebugger?" />
          </setting>
        </map>
        <map name="MapMsftDashboard.Web:?StartupTaskDebugger?" kind="Identity">
          <setting>
            <aCSMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MsftDashboard.Web/?StartupTaskDebugger?" />
          </setting>
        </map>
        <map name="MapMsftDashboard.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MsftDashboard.Web/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapMsftDashboard.WebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MsftDashboard.WebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="MsftDashboard.Web" generation="1" functional="0" release="0" software="C:\Users\Administrator\Documents\MsftDashboard\MsftDashboard.Azure\bin\Release\MsftDashboard.Azure.csx\roles\MsftDashboard.Web" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="?IsSimulationEnvironment?" defaultValue="" />
              <aCS name="?RoleHostDebugger?" defaultValue="" />
              <aCS name="?StartupTaskDebugger?" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;MsftDashboard.Web&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;MsftDashboard.Web&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MsftDashboard.WebInstances" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyID name="MsftDashboard.WebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="db4f9e55-50f8-488a-9f70-4c75d2065fb6" ref="Microsoft.RedDog.Contract\ServiceContract\MsftDashboard.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="abaac2e9-016d-4fcd-b00d-5d3d59cc319b" ref="Microsoft.RedDog.Contract\Interface\MsftDashboard.Web:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/MsftDashboard.Azure/MsftDashboard.AzureGroup/MsftDashboard.Web:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>