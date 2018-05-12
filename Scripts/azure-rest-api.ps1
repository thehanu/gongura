# Inspired by https://marckean.com/2016/09/08/using-the-azure-rest-api-in-powershell-asm-arm/

$global:subscriptionId = "6202c994-e3c0-4a6a-a1cf-b63047ca700f"
$global:autoPilot = $false

function Invoke-Prompt($message)
{
    Write-Output("`n`n`n`n {0}" -f $message)
    if($global:autoPilot) {
        $secondsToWait = 6
        Write-Output("-- Script execution paused. but I am in auto pilot mode will continue in {0} seconds..." -f $secondsToWait)
        Start-Sleep -s $secondsToWait
    }
    else {
        $userInput = Read-Host '-- Script execution paused. Press any key to continue... type "ap" to set to auto pilot'
        if($userInput.ToLower().Equals("ap")) { $global:autoPilot = $true }
    }
    
}

Function RESTAPI-Auth {
 
# Load ADAL Azure AD Authentication Library Assemblies
$Subscription = Get-AzureRmSubscription -SubscriptionId $global:subscriptionId
$adal = "${env:ProgramFiles(x86)}\Microsoft SDKs\Azure\PowerShell\ServiceManagement\Azure\Services\Microsoft.IdentityModel.Clients.ActiveDirectory.dll"
$adalforms = "${env:ProgramFiles(x86)}\Microsoft SDKs\Azure\PowerShell\ServiceManagement\Azure\Services\Microsoft.IdentityModel.Clients.ActiveDirectory.WindowsForms.dll"
$null = [System.Reflection.Assembly]::LoadFrom($adal)
$null = [System.Reflection.Assembly]::LoadFrom($adalforms)
 
$adTenant = $Subscription.TenantId
$global:SubscriptionID = $Subscription.SubscriptionId
 
# Client ID for Azure PowerShell
$clientId = "1950a258-227b-4e31-a9cf-717495945fc2"
# Set redirect URI for Azure PowerShell
$redirectUri = "urn:ietf:wg:oauth:2.0:oob"
# Set Resource URI to Azure Service Management API | @marckean
$resourceAppIdURIASM = "https://management.core.windows.net/"
$resourceAppIdURIARM = "https://management.azure.com/"
 
# Authenticate and Acquire Token
 
# Set Authority to Azure AD Tenant
$authority = "https://login.windows.net/$adTenant"
# Create Authentication Context tied to Azure AD Tenant
$authContext = New-Object "Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext" -ArgumentList $authority
# Acquire token
$global:authResultASM = $authContext.AcquireToken($resourceAppIdURIASM, $clientId, $redirectUri, "Auto")
$global:authResultARM = $authContext.AcquireToken($resourceAppIdURIARM, $clientId, $redirectUri, "Auto")
}

Function ASM-StorageAPI ($SourceStorageAccountName) { # to get the source storage key
# Create Authorization Header
$authHeader = $global:authResultASM.CreateAuthorizationHeader()
# Set HTTP request headers to include Authorization header | @marckean
$requestHeader = @{
"x-ms-version" = "2014-10-01"; #'2014-10-01'
"Authorization" = $authHeader
}
 
$Uri = "https://management.core.windows.net/$SubscriptionID/services/storageservices/{0}/keys" -f $SourceStorageAccountName
$Global:SourceKey = Invoke-RestMethod -Method Get -Headers $requestheader -Uri $Uri | 
select -ExpandProperty StorageService | select -ExpandProperty StorageServiceKeys | select -ExpandProperty primary
 
}
 
Function ARM-VMInfoAPI ($VMName, $RGName) { # to get the source storage key
# Create Authorization Header
$authHeader = $global:authResultARM.CreateAuthorizationHeader()
# Set HTTP request headers to include Authorization header | @marckean
$requestHeader = @{
"x-ms-version" = "2014-10-01"; #'2014-10-01'
"Authorization" = $authHeader
}
 
$Uri = "https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Compute/virtualMachines/{2}?api-version={3}" `
-f $SubscriptionID, $RGName, $VMName, '2015-06-15'
$Global:VMInfo = Invoke-RestMethod -Method Get -Headers $requestheader -Uri $uri
 
}

############# Script starts here ##############
# Login and select appropriate subscription
Write-Output("Logging and selecting Azure Subscription")
Select-AzureRmSubscription -SubscriptionId $global:subscriptionId -ErrorAction SilentlyContinue
if(-not $?) {
    Write-Output("Aah! You are not logged-in. Let us log-in into environment: {0}." -f $armtestbrazilus)
    Login-AzureRmAccount -Environment $environment
    Select-AzureRmSubscription -SubscriptionId $global:subscriptionId
}
RESTAPI-Auth # To Logon to Rest and get an an auth key

Invoke-Prompt "Getting the first storage account's primary key - using Azure Classic"
 
##########################################################################################
#######################      Rest API against Azure Classic     ##########################
##########################################################################################
 
# Run Rest API call to get the Storage Key - only works for Classic Storage Accounts
ASM-StorageAPI (Get-AzureRmResource | ? {$_.ResourceType -match 'ClassicStorage/storageAccounts'})[0].Name
 
# Display the Results
$Global:SourceKey
 
Invoke-Prompt "Getting the first VM Information - using Azure ARM"

##########################################################################################
##########################      Rest API against Azure ARM     ###########################
##########################################################################################
 
# Run Rest API call to get the Storage Key
$Name = (Get-AzureRmResource | ? {$_.ResourceType -match 'Microsoft.Compute/virtualMachines'})[0].Name
$ResourceGroupName = (Get-AzureRmResource | ? {$_.ResourceType -match 'Microsoft.Compute/virtualMachines'})[0].ResourceGroupName
ARM-VMInfoAPI $Name $ResourceGroupName
 
# Display the Results
$Global:VMInfo

Write-Output("Script execution finished.")
