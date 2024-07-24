using BookStore.Models;
using MediatR;

namespace BookStore.Handlers
{

    public class DeleteBook : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}