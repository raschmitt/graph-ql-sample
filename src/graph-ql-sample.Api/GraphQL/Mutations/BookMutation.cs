using graph_ql_sample.Domain.Entities;
using graph_ql_sample.Domain.Interfaces;

namespace graph_ql_sample.GraphQL.Mutations;

public class BookMutation
{
    private readonly IRedisRepository<Book> _redisRepository;

    public BookMutation(IRedisRepository<Book> redisRepository)
    {
        _redisRepository = redisRepository;
    }
    
    public async Task<Book> AddBook(Book book)
    {
        return await _redisRepository.SetAsync(book);
    }
}   