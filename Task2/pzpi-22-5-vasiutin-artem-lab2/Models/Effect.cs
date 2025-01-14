using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using light_show.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
namespace light_show.Models
{
    public class Effect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EffectId { get; set; }

        [Required]
        [StringLength(100)]
        public string EffectName { get; set; }

        [Required]
        public string EffectData { get; set; }
    }

}
