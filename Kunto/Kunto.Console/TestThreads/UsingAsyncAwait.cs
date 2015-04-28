using System.Net.Http;
using System.Threading.Tasks;

namespace Kunto.ConsoleClient.TestThreads
{
    public class UsingAsyncAwait
    {
        public async Task<string> GetHtmlFromWebSite(string link)
        {
            var httpClient = new HttpClient();
            string content = await httpClient.GetStringAsync(link);
            return content;
        }
    }
}
