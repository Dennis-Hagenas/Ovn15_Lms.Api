﻿using Lms.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.DTOs
{
    public class TournamentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        [Required]
        public DateTime? StartDate { get; set; }
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}