$session = New-Object Microsoft.PowerShell.Commands.WebRequestSession
$session.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36"
$session.Cookies.Add((New-Object System.Net.Cookie("connect.sid", "this_is_connect.sid", "/", "127.0.0.1")))
$session.Cookies.Add((New-Object System.Net.Cookie("io", "this_is_io", "/", "127.0.0.1")))
Invoke-WebRequest -UseBasicParsing -Uri "http://127.0.0.1:6600/mission/cancel?TaskName=*Local_20230718103059880" `
-WebSession $session `
-Headers @{
"Accept"="*/*"
  "Accept-Encoding"="gzip, deflate"
  "Accept-Language"="zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7"
  "Referer"="http://127.0.0.1:6600/index"
  "X-Requested-With"="XMLHttpRequest"
}