using System.ComponentModel.DataAnnotations;

namespace DotnetCQRS.Core.Users.Queries
{
    public class GetUserByIdQuery
    {
        [Required
        ]
        public int UserId { get; set; }
    }
}