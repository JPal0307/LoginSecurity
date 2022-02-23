using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class SecurityModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }

        public string GetFullName()
        {
            return this.FirstName + " " + this.Lastname;
        }

        public class SpecificUserRequirement : AuthorizationHandler<SpecificUserRequirement>, IAuthorizationRequirement
        {
            public string UserName { get; set; }
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SpecificUserRequirement requirement)
            {
                if (context.User?.Identity?.Name?.Equals(UserName) ?? false)
                {
                    context.Succeed(requirement);

                }
                else
                {
                    context.Fail();
                }
                return Task.CompletedTask;
            }
            public SpecificUserRequirement(string username)
            {
                UserName = username;
            }
        }
    }
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MovieDetails { get; set; }
        public string MovieActors { get; set; }
        public int TimesWatched { get; set; }
        public string GetFullMovie()
        {
            return $"{MovieName} {TimesWatched} {MovieActors}";
        }
    }
}
