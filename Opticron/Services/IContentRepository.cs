using Microsoft.AspNetCore.SignalR;

namespace Opticron;

public interface IContentRepository
{
    // Edit data within database

    Task<IEnumerable<News>> GetAllNewsAsync();
    Task<News?> GetNewsAsync(int id);
    Task<News> UpdateNews(News news);
    Task<IEnumerable<Offer>> GetAllOffersAsync();
    Task<Offer?> GetOfferAsync(int id);
    Task<Offer> UpdateOffer(Offer offer);
}
