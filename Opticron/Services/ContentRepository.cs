
using Microsoft.EntityFrameworkCore;

namespace Opticron;

public class ContentRepository : IContentRepository
{
    private readonly ContentContext _context;

    public ContentRepository(ContentContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<News>> GetAllNewsAsync()
    {
        return await _context.News.OrderBy(n => n.Id).ToListAsync();
    }

    public async Task<IEnumerable<Offer>> GetAllOffersAsync()
    {
        return await _context.Offers.OrderBy(o => o.Id).ToListAsync();
    }

    public async Task<News?> GetNewsAsync(int id)
    {
        //get news from database
        return await _context.News.Where(n => n.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Offer?> GetOfferAsync(int id)
    {
        return await _context.Offers.Where(o => o.Id == id).FirstOrDefaultAsync();
    }

    public Task<News> UpdateNews(News news)
    {
        //update news in database
        _context.News.Update(news);
        _context.SaveChanges();
        return Task.FromResult(news);
    }

    public Task<Offer> UpdateOffer(Offer offer)
    {
        // update offer in database
        _context.Offers.Update(offer);
        _context.SaveChanges();
        return Task.FromResult(offer);
    }
}
