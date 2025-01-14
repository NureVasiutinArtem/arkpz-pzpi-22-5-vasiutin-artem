using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using light_show.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace light_show.Models
{
    public class Template
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TemplateId { get; set; } // Первичный ключ

        [Required]
        [StringLength(100)]
        public string TemplateName { get; set; } // Название шаблона

        [Required]
        [StringLength(50)]
        public string Genre { get; set; } // Жанр

        // Навигационное свойство для связи с TemplateEffects
        public virtual ICollection<TemplateEffect> TemplateEffects { get; set; }
    }
}
