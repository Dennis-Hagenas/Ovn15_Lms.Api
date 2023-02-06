using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.DTOs
{
#nullable disable
    public class GameDto
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]

        public string Title { get; set; } = string.Empty;
        public DateTime Time { get; set; }
    }
}
