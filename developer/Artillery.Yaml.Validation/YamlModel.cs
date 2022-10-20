namespace Artillery.Yaml.Validation
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ArtilleryYaml
    {
        [JsonProperty("config")]
        public Config Config { get; set; }

        [JsonProperty("scenarios")]
        public Scenario[] Scenarios { get; set; }
    }

    public partial class Config
    {
        [JsonProperty("environments")]
        public Environments Environments { get; set; }
    }

    public partial class Environments
    {
        [JsonProperty("localdev")]
        public localdev localdev { get; set; }
    }

    public partial class localdev
    {
        [JsonProperty("target")]
        public Uri Target { get; set; }

        [JsonProperty("phases")]
        public Phase[] Phases { get; set; }
    }

    public partial class Phase
    {
        [JsonProperty("duration")]
        public long duration { get; set; }

        [JsonProperty("arrivalrate", NullValueHandling = NullValueHandling.Ignore)]
        public long arrivalrate { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("rampto", NullValueHandling = NullValueHandling.Ignore)]
        public long? rampto { get; set; }
    }

    public partial class Scenario
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("flow")]
        public Flow[] Flow { get; set; }
    }

    public partial class Flow
    {
        [JsonProperty("get")]
        public Get Get { get; set; }
    }

    public partial class Get
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class ArtilleryYaml
    {
        public static ArtilleryYaml FromJson(string json) => JsonConvert.DeserializeObject<ArtilleryYaml>(json, Artillery.Yaml.Validation.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ArtilleryYaml self) => JsonConvert.SerializeObject(self, Artillery.Yaml.Validation.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}


