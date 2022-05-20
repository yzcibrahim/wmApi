using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordApi
{
    public class WordDefinition
    {
        public int Id { get; set; }
        public string WordDef { get; set; }
        public string Meaning { get; set; }
        public int LngId { get; set; }
    }
}
