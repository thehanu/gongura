# Pointer: https://ss64.com/ps/syntax-regex.html

function Increment-Colspan([string] $td)
{
    $match = 'colspan="'
    $colSpanIndex = $td.LastIndexOf($match)
    $substr = $td.Substring($colSpanIndex + $match.Length)

    $colSpanStr = $substr.Substring(0, $substr.IndexOf('"'))
    [int] $colSpan = $colSpanStr
    $td.Substring(0, $colSpanIndex) + $match + ++$colSpan + $substr.Substring($colSpanStr.Length)
}

function Trim-Date([string] $date)
{
    $regex = "\d{4}/\d{2}/\d{2}"
    # Matches "2017/09/04  5:00:00 PM"
    if($date -match $regex)
    {
        Write-Host("With Regex: " + $regex + "match: " + $Matches[0])
    }

    $regex2 = "\d+[-/]\d+[-/]\d+"
    # this Matches "09/04/2017 5:00:00 pm" also
    if($date -match $regex2)
    {
        Write-Host("With Regex: " + $regex2 + "match: " + $Matches[0])
    }
}
# Increment-Colspan 'colspan="x"colspan="125"></td>'

Trim-Date "2017/09/04  5:00:00 PM"
Trim-Date "09/04/2017  5:00:00 PM"
Trim-Date "09-04-2017  5:00:00 PM"



