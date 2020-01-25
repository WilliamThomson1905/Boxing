using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoxingSite.Models
{
    public class SingleTrainerViewmodel
    {
        public string Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string ImageSrc { get; set; }

        public bool Available { get; set; }

        public string Instagarm { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string Email { get; set; }
    }
}
