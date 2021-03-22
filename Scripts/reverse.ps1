# open names.txt into stream_reader
$stream_reader = New-Object System.IO.StreamReader("C:\Users\buchi\OneDrive\Documents\Names.Big.txt")

# read next line and assign to current_line
$current_line =$stream_reader.ReadLine()

# loop until current_line is not null
while($current_line -ne $null)
{
    # write current_line
    $current_line

    #reverse line to nothing
    $reversed_line = ""

    #figure out length of current line
    $current_line.length

    #  reverse line from 8
    for($i=$current_line.length ; $i -ge 0; $i-- )
    {
        $reversed_line = $reversed_line + $current_line[$i] 
        # $reversed_line
    }
    
    # reversed line
    $reversed_line

    # read next line and assign to current_line
    $current_line =$stream_reader.ReadLine()
}
$stream_reader.Close()