# open names.txt into stream_reader
$stream_reader = New-Object System.IO.StreamReader("C:\Users\buchi\OneDrive\Documents\Names.txt")

# read next line and assign to current_line
$current_line =$stream_reader.ReadLine()

# loop until current_line is not null
while($current_line -ne $null)
{
    # write current_line
    $current_line

    # read next line and assign to current_line
    $current_line =$stream_reader.ReadLine()
}
