namespace NewsApi
{
    public interface IStoriesService
    {
        Task<List<Item>> GetStories();

    }
}
