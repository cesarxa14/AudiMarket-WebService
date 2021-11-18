using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    [SwaggerSchema(Required = new [] {"Description"})]
    public class MusicProducerResource
    {
        [SwaggerSchema("Music producer Identifier")]
        public int Id { get; set; }
        [SwaggerSchema("Music producer firstname")]
        public string Firstname { get; set; }
        [SwaggerSchema("Music producer lastname")]
        public string Lastname { get; set; }
        [SwaggerSchema("Music producer dni")]
        public string Dni { get; set; }
        [SwaggerSchema("Music producer entrydate")]
        public DateTime Entrydate { get; set; }
        [SwaggerSchema("Music producer user")]
        public string User { get; set; }
        [SwaggerSchema("Music producer password")]
        public string Password { get; set; }
        
    }
}
