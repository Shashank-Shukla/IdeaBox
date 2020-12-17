using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaListRazor.Model
{
    public class Idea
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IdeaText { get; set; }
        public string Author { get; set; }

        public string Tag { get; set; }
        public int Rating { get; set; }
    }
}
