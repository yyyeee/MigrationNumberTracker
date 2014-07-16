Param ([string] $SourcesDir = $(Throw "Parameter missing: -SourcesDir"))

$siteName = "Default Web Site"
$appPoolName = "ECB_MNT_AppPool"
$appPoolPath = "IIS:\AppPools\{0}" -F $appPoolName
$applicationName = "ecb-mnt"
$virtualPathDir = "C:\inetpub\wwwroot\"

import-module WebAdministration

function create_or_update_website($apppoolpath, $apppoolname)
{
    create_physical_path_for_virtual_directory
    create_app_pool $apppoolpath
    start_app_pool $apppoolpath
    create_web_site $applicationName $applicationName $apppoolname
}

function create_web_site($appName, $folder, $appPool)
{
    $sitePath = "IIS:\Sites\$siteName\$appName"
    $appPhysicalPath = "$virtualPathDir$folder"

    if (Test-Path $sitePath)
    {
        Remove-Item $sitePath -recurse
    }

    New-Item $sitePath -physicalPath $appPhysicalPath -type Application

    Write-host "Setting application pool to $appPoolName"
    Set-ItemProperty $sitePath -name applicationPool -value $appPool
}

function create_app_pool($poolPath)
{
    # Get or create application pool
    if(Test-Path $poolPath)
    {
        $pool = Get-Item $poolPath
        "$poolPath already exists" | Out-Host
    }
    else
    {
        $pool = New-Item $poolPath
        "$poolPath created" | Out-Host
    }
    
    $pool.processModel.identityType = "NetworkService"
    $pool | Set-Item
    
    # set 4.0 .NET Framework
    Set-ItemProperty $poolPath -name managedRuntimeVersion -value v4.0
    # auto start pool
    Set-ItemProperty $poolPath -name startMode -value 1

    # to LocalSystem
    Set-ItemProperty $poolPath -Name ProcessModel.IdentityType -value 0

    $week = [TimeSpan]::FromDays(7)
    Set-ItemProperty $poolPath -name recycling.periodicRestart.time $week
}

function start_app_pool ($poolPath)
{
    if(Test-Path $poolPath)
    {
        Start-WebItem $poolPath
        "$poolPath started" | Out-Host
    }
}

function create_physical_path_for_virtual_directory()
{
    $toFolder = "$virtualPathDir$applicationName"
    if (Test-Path -path $toFolder)
    {
        Remove-Item $toFolder -recurse
    }

    Copy-Item $SourcesDir $virtualPathDir -recurse
}

function main()
{
    create_or_update_website $appPoolPath $apppoolname

    if($reboot_needed -eq $true){
        Restart-Computer -Confirm
    }

    write-host "done."
}

main