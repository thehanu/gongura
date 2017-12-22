$size = 50
$hash = @{}
$hash.Add("abc", (, $null * $size))
$hash.Add("def", (, $null * $size))

function Add-ArrayObject($arr, $index, $obj)
{
    if($arr[$index] -eq $null)
    {
        $arr[$index] = ,($obj)
    }
    else
    {
        $arr[$index] += $obj
    }
}

for($i = 0; $i -lt $size; $i += 2)
{    
    Add-ArrayObject $hash["abc"] $i @{id = $i; title = "Title $i"}
}

for($i = 0; $i -lt $size; $i += 4)
{
    $id = 1000 + $i
    Add-ArrayObject $hash["abc"] $i @{id = $id; title = "Title $id"}
}

for($i = 0; $i -lt $size; $i++)
{
    $id = 2000 + $i
    #Add-ArrayObject $hash["abc"] $i @{id = $id; title = "Title $id"}
}

$dayCount = 0
foreach($day in $hash["abc"])
{    
    Write-Output("Timeline day count: {0}" -f $dayCount++)

    if($day -ne $null)
    {
        foreach($item in $day)
        {
            Write-Output("Item id in Day: {0}, Title: {1}" -f $item.id, $item.title)
        }
    }
    Write-Output("----")
}

$daysProcessed = 0
while($daysProcessed -lt $size)
{
    $sprint = ""
    for($i = 0; $i -lt 14 -and $daysProcessed -lt $size; $i++)
    {
        if($hash["abc"][$daysProcessed] -ne $null)
        {
            foreach($item in $hash["abc"][$daysProcessed])
            {
                $sprint += "<ID: {0}> " -f $item.id
            }
        }
        $daysProcessed++
        $sprint += "| "
    }
    Write-Output("Sprint: {0}" -f $sprint)
}


    $daysProcessed = 0
    while($daysProcessed -lt $size)
    {
        $updatedDateProcessed = $false
        $daysProcessedThisIteration = 0
        foreach($key in $hash.Keys) 
        {
            $daysProcessedForThisKey = 0
            $sprint = ""
            for($i = 0; $i -lt 14 -and $daysProcessed + $daysProcessedForThisKey -lt $size; $i++)
            {
                if($hash[$key][$daysProcessed + $daysProcessedForThisKey] -ne $null)
                {
                    foreach($item in $hash[$key][$daysProcessed + $daysProcessedForThisKey])
                    {
                        $sprint += "ID: {0} " -f $item.id
                    }
                }
                $daysProcessedForThisKey++
                $sprint += "| "
            }

            if(!$updatedDateProcessed)
            {
                $daysProcessedThisIteration += $daysProcessedForThisKey
                $updatedDateProcessed = $true
            }
            Write-Output("{0} - {1}" -f $key, $sprint)
        }

        $daysProcessed += $daysProcessedThisIteration
    }

