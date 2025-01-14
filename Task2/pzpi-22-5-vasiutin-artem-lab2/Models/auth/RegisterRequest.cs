using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace light_show.Models.auth
{
    public class RegisterRequest
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }

    }
}
