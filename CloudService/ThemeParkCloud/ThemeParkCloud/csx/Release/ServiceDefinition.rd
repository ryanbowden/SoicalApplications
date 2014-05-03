<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="ThemeParkCloud" generation="1" functional="0" release="0" Id="e0b00072-9f57-4bc8-9a09-144a5cf6eec5" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="ThemeParkCloudGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WCFServiceWebRole1:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/LB:WCFServiceWebRole1:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WCFServiceWebRole1:AzureStorage" defaultValue="">
          <maps>
            <mapMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/MapWCFServiceWebRole1:AzureStorage" />
          </maps>
        </aCS>
        <aCS name="WCFServiceWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/MapWCFServiceWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WCFServiceWebRole1Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/MapWCFServiceWebRole1Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WCFServiceWebRole1:Endpoint1">
          <toPorts>
            <inPortMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/WCFServiceWebRole1/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWCFServiceWebRole1:AzureStorage" kind="Identity">
          <setting>
            <aCSMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/WCFServiceWebRole1/AzureStorage" />
          </setting>
        </map>
        <map name="MapWCFServiceWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/WCFServiceWebRole1/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWCFServiceWebRole1Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/WCFServiceWebRole1Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WCFServiceWebRole1" generation="1" functional="0" release="0" software="C:\Users\Ryan\Documents\GitHub\SoicalApplications\CloudService\ThemeParkCloud\ThemeParkCloud\csx\Release\roles\WCFServiceWebRole1" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="AzureStorage" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WCFServiceWebRole1&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WCFServiceWebRole1&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="WCFServiceWebRole1.svclog" defaultAmount="[1000,1000,1000]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/WCFServiceWebRole1Instances" />
            <sCSPolicyUpdateDomainMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/WCFServiceWebRole1UpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/WCFServiceWebRole1FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WCFServiceWebRole1UpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WCFServiceWebRole1FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WCFServiceWebRole1Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="7e301f7e-638a-4091-b27b-17836a1d267e" ref="Microsoft.RedDog.Contract\ServiceContract\ThemeParkCloudContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="477cd07c-c0d9-483a-b5a3-d4f2e7c230d5" ref="Microsoft.RedDog.Contract\Interface\WCFServiceWebRole1:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/ThemeParkCloud/ThemeParkCloudGroup/WCFServiceWebRole1:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>