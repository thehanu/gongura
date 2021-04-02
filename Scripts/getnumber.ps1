# open names.txt into stream_reader
$stream_reader = New-Object System.IO.StreamReader("C:\Users\buchi\OneDrive\Documents\Names.Big.txt")

# read next line and assign to current_line
$current_line =$stream_reader.ReadLine()

# loop until current_line is not null
while($current_line -ne $null)
{
    # write current_line
    $current_line

    #assigning 0 to remember count
    $remember_count =0

    # loop through current line carecters
    for($i= 0; $i -lt $current_line.length; $i++ )
    {
        #i am getting the newmeric value for the carecter, subtract 96, upend to remember count
        $remember_count = $remember_count + [byte][char] $current_line[$i]-96

        # write remember count for each carecter
        $remember_count
    }
    
    # write final remember count
    $remember_count

    # read next line and assign to current_line
    $current_line =$stream_reader.ReadLine()
}
$stream_reader.Close()