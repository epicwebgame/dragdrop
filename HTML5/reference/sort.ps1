$content = Get-Content "C:\Users\computer\Desktop\attributes of input types.txt"
$lineNumber = 1
$newContent = ""

foreach ($line in $content)
{
    $newLine = "$lineNumber. $line`r`n"
    $newContent = $newContent + $newLine
    $lineNumber = $lineNumber + 1
}

Write-Host $newContent
Set-Content "C:\Users\computer\Desktop\sorted.txt" $newContent
