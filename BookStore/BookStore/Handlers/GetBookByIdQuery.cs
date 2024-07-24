using BookStore.Models;
using MediatR;

namespace BookStore.Handlers
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }
    }
}