$session = New-Object Microsoft.PowerShell.Commands.WebRequestSession
$session.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36"
$session.Cookies.Add((New-Object System.Net.Cookie("connect.sid", "s%3AoD-ffYVPQxQduGlE3AfYBr4HQwbiLy0x.sQ5J6CF8uxwSF%2BHA9f8QLyUjjVIjBBOcCyrBKlUfJVo", "/", "127.0.0.1")))
$session.Cookies.Add((New-Object System.Net.Cookie("io", "2BPc0hLLkNIEmPbMAAA4", "/", "127.0.0.1")))
Invoke-WebRequest -UseBasicParsing -Uri "http://127.0.0.1:6600/user/login" `
-Method "POST" `
-WebSession $session `
-Headers @{
"Accept"="application/json, text/javascript, */*; q=0.01"
  "Accept-Encoding"="gzip, deflate"
  "Accept-Language"="zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7"
  "Origin"="http:/127.0.0.1:6600"
  "Referer"="http://127.0.0.1:6600/login"
  "X-Requested-With"="XMLHttpRequest"
} `
-ContentType "application/json" `
-Body "[{`"name`":`"UserName`",`"value`":`"ENG`"},{`"name`":`"Password`",`"value`":`"12345678`"}]"