﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRA.SingleOffenderId
{
    public class Offender
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("noms_id")]
        public string NomsId { get; set; }

        [JsonProperty("nationality_code")]
        public string NationalityCode { get; set; }

        [JsonProperty("establishment_code")]
        public string EstablishmentCode { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("middle_names")]
        public string MiddleNames { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("pnc_number")]
        public string PncNumber { get; set; }

        [JsonProperty("cro_number")]
        public string CroNumber { get; set; }

        [JsonProperty("ethnicity_code")]
        public string EthnicityCode { get; set; }
    }
}
