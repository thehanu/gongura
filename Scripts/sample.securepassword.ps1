$cred = Get-Credential
$user = $cred.UserName
$pass = $cred.Password

# Encoded password.
$secpasswd = ConvertFrom-SecureString($cred.Password)
Write-Output("Password: {0}" -f ($secpasswd))

# Prepare PSCredential back.
$mycreds = New-Object System.Management.Automation.PSCredential($user, (ConvertTo-SecureString $secpasswd))
ConvertFrom-SecureString($mycreds.Password)

# Getting the password decrypted. 
$mycreds.GetNetworkCredential().Password

# Another way to getting decrypt back. 
$BSTR = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($mycreds.Password)
[System.Runtime.InteropServices.Marshal]::PtrToStringAuto($BSTR)