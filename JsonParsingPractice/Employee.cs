using System.Text.Json.Serialization;

namespace JsonParsingPractice;
internal class Employee
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("salary")]
    public string Salary { get; set; }
}

