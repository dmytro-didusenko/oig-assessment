using Application.User.Dtos;
using MediatR;

namespace Application.User.Queries
{
    public class UsersListQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
