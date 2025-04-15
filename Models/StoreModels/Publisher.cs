using PersonalWebsite.Models.StoreModels.APIOutputs;
using System.Text.Json.Serialization;

namespace PersonalWebsite.Models.StoreModels
{
    public class Publisher
    {
        public long PublisherId { get; set; }
        public string PublisherName { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Game>? Games { get; set; }

        //public List<PublisherGame> PublisherGames { get; set; } = [];

        public PublisherOutput ToPublisherOutput()
        {
            return new()
            {
                PublisherId = PublisherId,
                PublisherName = PublisherName,
                Games = Games?.ToDictionary(x => x.GameId, y => y.Name) ?? []
            };
        }
    }
}
