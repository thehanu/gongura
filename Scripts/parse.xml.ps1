
# Schema of XML
# <RnmDeployment xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
# <Regions>
#   <Region Id="USTest">
#     <Datacenters>
#       <Datacenter Id="CO1">
#         <FabricCluster Id="CO1CNFTest04">
#           <Tenant Id="RNM_CO1CNFTest04_01" State="Operational">
#             <Vip>168.62.72.165</Vip>
#             <WinFabricNodeGroup Id="NodeGroup01" SizePolicy="Large" NodeType="SVIPartition01">
#                <NodeAddressAssignments>
#                 <RoleInstance IsSeedNode="true" Name="RnmRoutingService_IN_0" CA="10.0.0.14"/>
#                 <RoleInstance IsSeedNode="true" Name="RnmRoutingService_IN_1" CA="10.0.0.15"/>
#                </NodeAddressAssignments>
#              </WinFabricNodeGroup>
#           </Tenant>

Param(
[Parameter(Mandatory = $false)]
[string] $rnmDeploymentXmlPath = "C:\temp\RnmDeployment.Public.xml")


[xml]$rnmDeployment = Get-Content -Path $rnmDeploymentXmlPath -Raw
Get-Date
Write-Output ("Provided File: {0}, regionName: {1}" -f $rnmDeploymentXmlPath, $regionName)
$rnmDeployment

$changedContent = $false

$regionCount = 0
foreach ($region in $rnmDeployment.RnmDeployment.Regions.Region)
{
    $otherNodeCount = 0
    $gen4NodeCount = 0
    $gen5NodeCount = 0

    Write-Output("For this region [{0}]: {1}" -f ++$regionCount, $region.Id)
    foreach ($tenant in $region.Datacenters.Datacenter.FabricCluster.Tenant)
    {
        $nodeCount = $tenant.WinFabricNodeGroup.NodeAddressAssignments.SelectNodes("RoleInstance").Count
        if($tenant.WinFabricNodeGroup.SizePolicy -eq "SSDVM10v2") {
            $gen4NodeCount += $nodeCount
        }
        elseif ($tenant.WinFabricNodeGroup.SizePolicy -eq "E64v3") {
            $gen5NodeCount += $nodeCount
        } else {
            $otherNodeCount += $nodeCount
        }
        Write-Output("Tenant name: {0}, NodeCount: {1} SizePolicy: {2}" -f $tenant.Id, $nodeCount, $tenant.WinFabricNodeGroup.SizePolicy)
    }
    Write-Output("Region: {0}, Total NodeCount: {1} Gen4 Node Count: {2}, Gen5 Node Count: {3}, Other Node Count: {4}" -f $region.Id, ($gen4NodeCount + $gen5NodeCount + $otherNodeCount), $gen4NodeCount, $gen5NodeCount, $otherNodeCount)
}