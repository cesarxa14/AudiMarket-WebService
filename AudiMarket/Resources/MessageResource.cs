using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Resources
{
    public class MessageResource
    {
        public int Id { get; set; }
        public int Content { get; set; }
        public int CreateDate { get; set; }
        public int IdvProducer { get; set; }
        public int DmProducer { get; set; }
    }
}