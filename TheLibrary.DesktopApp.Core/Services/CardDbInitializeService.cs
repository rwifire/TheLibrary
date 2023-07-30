using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.BZip2;
using Microsoft.Extensions.Configuration;

namespace TheLibrary.DesktopApp.Core.Services;

public class CardDbInitializeService
{
  private readonly IConfiguration _config;
  public static readonly string FileserverConfigPath = "CardDbConfig:FileServer";
  public static readonly string FileNameConfigPath = "CardDbConfig:FullZipFile";

  public CardDbInitializeService(IConfiguration config)
  {
    _config = config;
    if (IsFullDownloadNeeded())
    {
      DownloadAndUnzip();
    }
  }

  private bool IsFullDownloadNeeded()
  {
    return false;
  }

  private async void DownloadAndUnzip()
  {
    var webLocation = _config[FileserverConfigPath] + _config[FileNameConfigPath];
    var zipedFileName = _config[FileNameConfigPath] ?? "AllPrintings.json.bz2";

    //If a file exists, delete it (might be old one)
    if (File.Exists(zipedFileName))
    {
      File.Delete(zipedFileName);
    }
    
    await DownloadCompleteDataFile(webLocation, zipedFileName);
    
    await UnzipCompleteDataFile(zipedFileName);
  }

  private async Task UnzipCompleteDataFile(string zipedFileName)
  {
    await using var compressedFileStream = File.Open(zipedFileName, FileMode.Open);
    var unzipFileName = zipedFileName.Replace(".bz2", "");
    if (File.Exists(unzipFileName))
    {
      File.Delete(unzipFileName);
    }

    await using var decompressedFileStream = File.Create(unzipFileName);
    BZip2.Decompress(compressedFileStream, decompressedFileStream, true);
    File.Delete(zipedFileName);
  }

  private async Task DownloadCompleteDataFile(string webLocation, string fileName)
  {
    //Download new complete File
    var httpClient = new HttpClient();

    await using var webStream = await httpClient.GetStreamAsync(webLocation);
    await using var downloadFileStream = new FileStream(fileName, FileMode.CreateNew);
    await webStream.CopyToAsync(downloadFileStream);
    webStream.Close();
    downloadFileStream.Close();
    await downloadFileStream.DisposeAsync();
  }
}