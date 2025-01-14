using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using light_show.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace light_show.Models
{
    public class TemplateEffect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TemplateEffectId { get; set; } // Первичный ключ

        [Required]
        public int TemplateId { get; set; } // Внешний ключ на Template

        [Required]
        public int EffectId { get; set; } // Внешний ключ на Effect

        [ForeignKey("TemplateId")]
        public virtual Template Template { get; set; } // Навигационное свойство на Template

        [ForeignKey("EffectId")]
        public virtual Effect Effect { get; set; } // Навигационное свойство на Effect
    }
}
