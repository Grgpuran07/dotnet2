using System.Text.Json.Serialization;

namespace dotnet2.Models
{
    
    //this is added in order to show actual type in schema rather than just only numbers
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Cleric=3
    }
}