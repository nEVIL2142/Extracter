using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extracter
{
  class Program
  {
    private static string _script = "powershell $WebClient_Obj = New-Object System.Net.WebClient; $WebClient_Obj.DownloadFile('https://engagedhits.com/extension/download/1.1.0','engagedhits_chrome_ext_1.1.0.zip')\nTASKKILL /IM chrome.exe /F\nREM powershell -command \"Expand-Archive -Force 'engagedhits_chrome_ext_1.1.0.zip' 'engagedhits_chrome_ext_1'\"\nREM powershell $shell = New-Object -ComObject shell.application; $zip = $shell.NameSpace('engagedhits_chrome_ext_1.1.0.zip'); MkDir('engagedhits_chrome_ext_1.1.0'); foreach ($item in $zip.items()) { $shell.Namespace('engagedhits_chrome_ext_1.1.0').CopyHere($item) }\npowershell.exe -nologo -noprofile -command \"& {  MkDir('engagedhits_chrome_ext_1.1.0'); $shell = New-Object -COM Shell.Application; $target = $shell.NameSpace('%CD%\\engagedhits_chrome_ext_1.1.0'); $zip = $shell.NameSpace('%CD%\\engagedhits_chrome_ext_1.1.0.zip'); $target.CopyHere($zip.Items(), 16); }\"\n\n\"C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe\" --load-extension=\"%CD%\\engagedhits_chrome_ext_1.1.0\"";
    static void Main(string[] args)
    {
      var tempPath = System.IO.Path.GetTempPath();
      var file = Path.Combine(tempPath, $"{Guid.NewGuid().ToString()}.bat");
      File.WriteAllText(file, _script);
      Process.Start(file, "");
    }
  }
}
