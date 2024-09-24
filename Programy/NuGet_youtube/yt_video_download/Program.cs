using System.Runtime.Intrinsics.X86;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

var yt_client = new YoutubeClient();

Console.WriteLine("YouTube video downloading program");
Console.Write("Enter video ID / url: ");
string video_url = Console.ReadLine();
while(string.IsNullOrEmpty(video_url) || string.IsNullOrWhiteSpace(video_url)){
    Console.WriteLine("\nInvalid url.");
    Console.Write("Enter url: ");
    video_url = Console.ReadLine();
}
var video = await yt_client.Videos.GetAsync(video_url);

Console.WriteLine("Downloading '" + video.Title + "'" );
Console.WriteLine("Uploaded by '" + video.Author.ChannelTitle + "'");
Console.WriteLine("Length: " + video.Duration);

string videoFileName = video.Title.Replace(' ', '_');

var streamManifest = await yt_client.Videos.Streams.GetManifestAsync(video_url);
var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
await yt_client.Videos.Streams.DownloadAsync(streamInfo, $"../yt_video_download/videos/{videoFileName.ToLower()}.{streamInfo.Container}");

Console.WriteLine("Video downloaded.");