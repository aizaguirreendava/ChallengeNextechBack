using System.Net;

namespace NewsApi
{
    public class StoriesService : IStoriesService
    {
        private List<Item> listItem= new List<Item>();

        public async Task<List<Item>> GetStories()
        {
            string url = "https://hacker-news.firebaseio.com/v0/newstories.json?print=pretty";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            string json = new StreamReader(stream).ReadToEnd();
            json = json.Replace("[ ", "").Replace(" ]", "").Replace("\n", "");
            List<string> listStrLineElements = json.Split(", ").ToList();
            foreach (string i in listStrLineElements)
            {
                string itemUrl = "https://hacker-news.firebaseio.com/v0/item/" + i + ".json?print=pretty";
                request = WebRequest.Create(itemUrl) as HttpWebRequest;
                response = request.GetResponse() as HttpWebResponse;
                stream = response.GetResponseStream();
                json = new StreamReader(stream).ReadToEnd();
                Item item = Newtonsoft.Json.JsonConvert.DeserializeObject<Item>(json);
                listItem.Add(item);
            }

            return listItem;
        }
    }
}
