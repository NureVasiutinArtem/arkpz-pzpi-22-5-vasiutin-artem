using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using light_show.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace light_show.Models
{
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceId { get; set; } // Первичный ключ

        [Required]
        public int UserId { get; set; } // Внешний ключ

        [Required]
        [StringLength(100)]
        public string DeviceName { get; set; } // Название устройства

        [StringLength(50)]
        public string? DeviceType { get; set; } // Тип устройства (может быть NULL)

        public DateTime? LastOnline { get; set; } // Дата последнего подключения (может быть NULL)

        [ForeignKey("UserId")]
        public virtual Users User { get; set; } // Навигационное свойство для связи с User
    }
}

