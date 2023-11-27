namespace NewsApi
{
    public class Item
    {
        public string id { get; set; }
        public bool deleted { get; set; }
        public string type { get; set; }
        public string by { get; set; }
        public string time { get; set; }
        public string text { get; set; }
        public bool dead { get; set; }
        public string parent { get; set; }
        public string poll { get; set; }
        public List<int> kids { get; set; }
        public string url { get; set; }
        public string score { get; set; }
        public string title { get; set; }
        public List<int> parts { get; set; }
        public string descendants { get; set; }
    }
}
