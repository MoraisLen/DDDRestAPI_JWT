namespace DDDRestAPI_JWT.Domain.Enties
{
    public class ClientAPI : EntieBase
    {
        public string NameId { get; set; }
        public string Secret { get; set; }
        public string Role { get; set; }
    }
}