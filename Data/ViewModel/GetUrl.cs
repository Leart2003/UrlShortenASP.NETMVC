namespace ShortUrl.Data.ViewModel
{
    public class GetUrl
    {

        public int Id { get; set; }


        public string OriginalLink { get; set; }


        public string ShortLink { get; set; }

        public int ClickedTime { get; set; }

        public int UserID { get; set; }


        public GetUserVM User { get; set; }
    }
}
