using System.Text.Json;
using System.Text.Json.Serialization;

namespace AspNetCoreApp.Web.Models
{
    public class Brand
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; } = new Name();

        [JsonPropertyName("image")]
        public Image Image { get; set; } = new Image();

        [JsonPropertyName("models")]
        public Models Models { get; set; } = new Models();
    }

    public class Name
    {
        [JsonPropertyName("_text")]
        public string Text { get; set; } = string.Empty;
    }

    public class Image
    {
        [JsonPropertyName("_text")]
        public string Text { get; set; } = string.Empty;
    }

    public class Models
    {
        [JsonPropertyName("model")]
        public List<Model> Model { get; set; } = new List<Model>();
    }

    public class Model
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; } = new Name();

        [JsonPropertyName("generations")]
        public Generations Generations { get; set; } = new Generations();
    }

    public class Generations
    {
        [JsonPropertyName("generation")]
        [JsonConverter(typeof(GenerationConverter))]
        public List<Generation> Generation { get; set; } = new List<Generation>();
    }

    public class Generation
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; } = new Name();

        [JsonPropertyName("modelYear")]
        public Name ModelYear { get; set; } = new Name();

        [JsonPropertyName("images")]
        public Images Images { get; set; } = new Images();

        [JsonPropertyName("modifications")]
        public Modifications Modifications { get; set; } = new Modifications();
    }

    public class Images
    {
        [JsonPropertyName("image")]
        public List<ImageInfo> Image { get; set; } = new List<ImageInfo>();
    }

    public class ImageInfo
    {
        [JsonPropertyName("small")]
        public Name Small { get; set; } = new Name();

        [JsonPropertyName("big")]
        public Name Big { get; set; } = new Name();
    }

    public class Modifications
    {
        [JsonPropertyName("modification")]
        public List<Modification> Modification { get; set; } = new List<Modification>();
    }

    public class Modification
    {
        [JsonPropertyName("powerHp")]
        public Name PowerHp { get; set; } = new Name();

        [JsonPropertyName("torqueNm")]
        public Name TorqueNm { get; set; } = new Name();

        [JsonPropertyName("engineDisplacement")]
        public Name EngineDisplacement { get; set; } = new Name();

        [JsonPropertyName("fuelSystem")]
        public Name FuelSystem { get; set; } = new Name();

        [JsonPropertyName("turbine")]
        public Name Turbine { get; set; } = new Name();

        [JsonPropertyName("transmission")]
        public Name Transmission { get; set; } = new Name();

        [JsonPropertyName("driveWheel")]
        public Name DriveWheel { get; set; } = new Name();

        [JsonPropertyName("length")]
        public Name Length { get; set; } = new Name();

        [JsonPropertyName("width")]
        public Name Width { get; set; } = new Name();

        [JsonPropertyName("height")]
        public Name Height { get; set; } = new Name();
       

        [JsonPropertyName("frontSuspension")]
        public Name FrontSuspension { get; set; } = new Name();

        [JsonPropertyName("rearSuspension")]
        public Name RearSuspension { get; set; } = new Name();

    }

    public class GenerationConverter : JsonConverter<List<Generation>>
    {
        public override List<Generation> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var generation = JsonSerializer.Deserialize<Generation>(ref reader, options);
                return new List<Generation> { generation };
            }
            else if (reader.TokenType == JsonTokenType.StartArray)
            {
                return JsonSerializer.Deserialize<List<Generation>>(ref reader, options);
            }
            return new List<Generation>();
        }

        public override void Write(Utf8JsonWriter writer, List<Generation> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
} 