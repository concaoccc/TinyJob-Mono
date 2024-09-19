namespace TinyJobApi.Models.Vo
{
    public class PageVo <T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T>? Data { get; set; }
    }
}