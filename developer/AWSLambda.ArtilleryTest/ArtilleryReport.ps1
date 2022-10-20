cd C:\_code\lambda\\AWSLambda.ArtilleryTest
$stamp = Get-Date -format "dd-MMM-yyyy-HH-mm-ss"
artillery run  -e localdev .\Artillery.yml -o .\report\result.json
$name="report-$stamp.html"
artillery report  -o .\report\$name .\report\result.json


