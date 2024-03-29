﻿using Newtonsoft.Json;


namespace MediatrWeb.Contracts.Response
{
    public class ResponseCalculatePrice
    {
        /// <summary>
        /// Price by Size
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public float Price { get; set; }

        /// <summary>
        /// Size from request
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }

        /// <summary>
        /// Size 'Price by Size'
        /// </summary>
        [JsonProperty(PropertyName = "describe")]
        public string Describe { get; set; }
    }
}
