using Application.User.Dtos;
using MediatR;

namespace Application.User.Queries.GetList
{
    public class UsersListQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
