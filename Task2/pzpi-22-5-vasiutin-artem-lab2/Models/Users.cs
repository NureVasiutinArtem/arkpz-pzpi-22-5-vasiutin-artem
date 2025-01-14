using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using light_show.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace light_show.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
/*public static class UsersEndpoints
{
	public static void MapUsersEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Users").WithTags(nameof(Users));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Users.ToListAsync();
        })
        .WithName("GetAllUsers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Users>, NotFound>> (int userid, ApplicationDbContext db) =>
        {
            return await db.Users.AsNoTracking()
                .FirstOrDefaultAsync(model => model.UserId == userid)
                is Users model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetUsersById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int userid, Users users, ApplicationDbContext db) =>
        {
            var affected = await db.Users
                .Where(model => model.UserId == userid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.UserId, users.UserId)
                  .SetProperty(m => m.Username, users.Username)
                  .SetProperty(m => m.Email, users.Email)
                  .SetProperty(m => m.CreatedAt, users.CreatedAt)
                  );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateUsers")
        .WithOpenApi();

        group.MapPost("/", async (Users users, ApplicationDbContext db) =>
        {
            db.Users.Add(users);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Users/{users.UserId}",users);
        })
        .WithName("CreateUsers")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int userid, ApplicationDbContext db) =>
        {
            var affected = await db.Users
                .Where(model => model.UserId == userid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteUsers")
        .WithOpenApi();
    }
}}
*/