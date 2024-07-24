using BookStore.Data;
using BookStore.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Handlers
{
    public class BookHandlers :
        IRequestHandler<CreateBook, Book>,
        IRequestHandler<UpdateBook, Book>,
        IRequestHandler<DeleteBook, Unit>,
        IRequestHandler<GetBookByIdQuery, Book>,
        IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly BookContext _context;

        public BookHandlers(BookContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Year = request.Year
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Handle(UpdateBook request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);

            if (book == null) return null;

            book.Title = request.Title;
            book.Author = request.Author;
            book.Year = request.Year;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Unit> Handle(DeleteBook request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);

            if (book == null) return Unit.Value;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.FindAsync(request.Id);
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.ToListAsync();
        }
    }
}