﻿using Newtonsoft.Json;

namespace nUnitSpecflow.DataAccess.DTO
{
    public class UsersDto : JsonSerializable
    {
        public UsersDto()
            : base() { }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("support")]
        public Support TheSupport { get; set; }

        public class Datum
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("avatar")]
            public string Avatar { get; set; }
        }

        public class Support
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }
        }
    }
}
