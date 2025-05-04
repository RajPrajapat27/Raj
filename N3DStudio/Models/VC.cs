using System.Text.Json.Serialization;

namespace N3DStudio.Models
{
    public class ElevenLabsVoicesResponse
    {
        [JsonPropertyName("voices")]
        public List<VoiceData> Voices { get; set; }
    }

    public class VoiceData
    {
        [JsonPropertyName("voice_id")]
        public string VoiceId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonPropertyName("samples")]
        public List<VoiceSample> Samples { get; set; }

        [JsonPropertyName("labels")]
        public VoiceLabels Labels { get; set; }
    }

    public class VoiceLabels
    {
        [JsonPropertyName("accent")]
        public string Accent { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("age")]
        public string Age { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("use_case")]
        public string UseCase { get; set; }
    }

    public class VoiceSample
    {
        [JsonPropertyName("sample_id")]
        public string SampleId { get; set; }

        [JsonPropertyName("file_name")]
        public string FileName { get; set; }

        [JsonPropertyName("mime_type")]
        public string MimeType { get; set; }

        [JsonPropertyName("size_bytes")]
        public int SizeBytes { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }
    }

    public class FineTuning
    {
        public bool IsAllowedToFineTune { get; set; }
        public Dictionary<string, string> State { get; set; }
        public List<string> VerificationFailures { get; set; }
        public int VerificationAttemptsCount { get; set; }
        public bool ManualVerificationRequested { get; set; }
    }

    public class VoiceSettings
    {
        public float Stability { get; set; }
        public float SimilarityBoost { get; set; }
        public float Style { get; set; }
        public bool UseSpeakerBoost { get; set; }
        public float Speed { get; set; }
    }

    public class SharingDetails
    {
        public string Status { get; set; }
        public long DateUnix { get; set; }
        public List<string> WhitelistedEmails { get; set; }
        public bool FinancialRewardsEnabled { get; set; }
        public bool FreeUsersAllowed { get; set; }
        public bool LiveModerationEnabled { get; set; }
        public bool Featured { get; set; }
        public int LikedByCount { get; set; }
        public int ClonedByCount { get; set; }
    }

    public class VerifiedLanguage
    {
        public string Language { get; set; }
        public string ModelId { get; set; }
        public string Accent { get; set; }
    }


}
