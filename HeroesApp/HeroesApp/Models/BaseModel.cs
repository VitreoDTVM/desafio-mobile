namespace HeroesApp.Models
{
    public class BaseModel<T>
    {
        public BaseModel(int code, string status, string copyright, string attribuionText, string eTag, DataItens<T> items)
        {
            Code = code;
            Status = status;
            Copyright = copyright;
            AttributionText = attribuionText;
            Etag = eTag;
            Items = items;
        }

        public int Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string Etag { get; set; }
        public DataItens<T> Items { get; set; }
    }
}
