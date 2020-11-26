using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class ItemEntity
    {
        public long Id { get; set; }
        [Required]
        public DateTime data_inicio { get; set; }
        [Required]
        public DateTime data_fim { get; set; }
        [Required]
        public string moeda { get; set; }
    }
}
