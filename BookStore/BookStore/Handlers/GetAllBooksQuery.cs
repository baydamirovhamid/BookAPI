using BookStore.Models;
using MediatR;

namespace BookStore.Handlers
{
    public class GetAllBooksQuery : IRequest<IEnumerable<Book>> 
    {

    }
}