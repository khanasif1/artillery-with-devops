using Artillery.Yaml.Validation;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Microsoft.Extensions.Configuration;

try
{

    Console.WriteLine("Start Yaml Validator");
    IConfiguration config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables()
                            .Build();
    Settings settings = config.GetRequiredSection("Settings").Get<Settings>();
    Console.WriteLine("Reading settings");

    Console.WriteLine($"Path:{settings.ArtilleryPath}");
    Console.WriteLine(File.ReadAllText(settings.ArtilleryPath));
    var yaml = File.ReadAllText(settings.ArtilleryPath);
    var deserializer = new DeserializerBuilder()
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .Build();
    ArtilleryYaml _artilleryConfig = deserializer.Deserialize<ArtilleryYaml>(yaml.ToLower());

    bool _configValidationState = true;
    foreach (Phase phase in _artilleryConfig.Config.Environments.localdev.Phases)
    {
        Console.WriteLine("Looping through duration");
        long _srcDuration = phase.duration;
        if (settings.duration < _srcDuration)
        {
            _configValidationState = false;
            Console.WriteLine("Validation Failed");
            break;
        }
    }
    if (!_configValidationState)
        throw new Exception($"Artillery.yaml has duration value greter than approved limit {settings.duration}. " +
            $"Please fix the value and checking for build");

    Console.WriteLine("End Yaml Validator");
    //Console.ReadLine();
}
catch (Exception ex)
{
    //Console.ReadLine();
    throw ex;
    
}


public sealed class Settings
{
    public string ArtilleryPath { get; set; }
    public string AWSConfig { get; set; }
    public int duration { get; set; }
}