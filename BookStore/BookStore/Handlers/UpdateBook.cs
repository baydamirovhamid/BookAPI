using BookStore.Models;
using MediatR;

namespace BookStore.Handlers
{
    public class UpdateBook : IRequest<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }
}