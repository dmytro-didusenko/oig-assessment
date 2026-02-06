using Application.User.Dtos;
using MediatR;

namespace Application.User.Queries.GetById
{
    public class GetUserByIdQuery : IRequest<UserDto?>
    {
        public uint Id { get; set; }
    }
}
