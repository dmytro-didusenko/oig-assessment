using Application.User.Dtos;
using MediatR;

namespace Application.User.Queries
{
    public class GetUserByIdQuery(uint id) : IRequest<UserDto?>
    {
        public uint Id { get; set; } = id;
    }
}
