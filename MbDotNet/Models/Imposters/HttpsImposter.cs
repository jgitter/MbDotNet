﻿using MbDotNet.Models.Stubs;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MbDotNet.Models.Imposters
{
    public class HttpsImposter : Imposter 
    {
        [JsonProperty("stubs")]
        public ICollection<HttpStub> Stubs { get; private set; }
        
        // TODO Need to not include key in serialization when its null to allow mb to use self-signed certificate.
        [JsonProperty("key")]
        public string Key { get; private set; }

        public HttpsImposter(int port, string name) : this(port, name, null)
        {
        }

        public HttpsImposter(int port, string name, string key) : base(port, MbDotNet.Enums.Protocol.Https, name)
        {
            Key = key;
            Stubs = new List<HttpStub>();
        }

        public HttpStub AddStub()
        {
            var stub = new HttpStub();
            Stubs.Add(stub);
            return stub;
        }
    }
}
