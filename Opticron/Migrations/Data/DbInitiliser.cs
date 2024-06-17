
using Microsoft.EntityFrameworkCore;

namespace Opticron;

public class DbInitiliser
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<ContentContext>());
    }

    private static void SeedData(ContentContext context)
    {
        context.Database.Migrate();

        if(context.Carousels.Any())
        {
            Console.WriteLine("Already seeded carousels");
        }
        else
        {
            // var carousels = GetCarouselSeedData();
            // context.AddRange(carousels);
        }
        if(context.Categories.Any())
        {
            Console.WriteLine("Already seeded categories");
        }
        else
        {
            // var categories = GetCategorySeedData();
        }
        if(context.News.Any())
        {
            Console.WriteLine("Already seeded news");
        }
        else
        {
            var news = GetNewsSeedData();
            context.AddRange(news);
        }
        if(context.Offers.Any())
        {
            Console.WriteLine("Already seeded offers");
        }
        else
        {
            var offers = GetOfferSeedData();
            context.AddRange(offers);
        }
        context.SaveChanges();
    }

    private static List<Offer> GetOfferSeedData()
    {
        var OfferList = new List<Offer>()
        {
            new Offer
            {
                Title = "Discovery WP PC",
                Description = "£20 Cashback",
                ImageUrl = "https://via.placeholder.com/150"
            },
            new Offer
            {
                Title = "HR ED Fieldscopes",
                Description = "Free Digiscoping Kit",
                ImageUrl = "https://via.placeholder.com/150"
            },
            new Offer
            {
                Title = "IS 60 WP Fieldscope Kits",
                Description = "Save 25%",
                ImageUrl = "https://via.placeholder.com/150"
            }
        };
        return OfferList;
    }

    private static List<News> GetNewsSeedData()
    {
        var NewsList = new List<News>()
        {
            new News
            {
                Name = "New Products",
                Description = "This is the first news",
                ButtonName = "New Products",
                ImageUrl = "https://via.placeholder.com/150"
            },
            new News
            {
                Name = "Field Events",
                Description = "This is the second news",
                ButtonName = "View Events",
                ImageUrl = "https://via.placeholder.com/150"
            },
            new News
            {
                Name = "Latest News",
                Description = "This is the third news",
                ButtonName = "Read Article",
                ImageUrl = "https://via.placeholder.com/150"
            },
            new News
            {
                Name = "Gallery",
                Description = "This is the fourth news",
                ButtonName = "View Gallery",
                ImageUrl = "https://via.placeholder.com/150"
            }
            
        };
        return NewsList;
    }

    private static object GetCategorySeedData()
    {
        throw new NotImplementedException();
    }

    private static object GetCarouselSeedData()
    {
        throw new NotImplementedException();
    }
}
