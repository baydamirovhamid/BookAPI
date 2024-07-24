using BookStore.Models;
using MediatR;


namespace BookStore.Handlers
{
    public class CreateBook : IRequest<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }
}