using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P320FrontToBack.DataAccessLayer;
using P320FrontToBack.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace P320FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public IActionResult Index()
        //{
        //    var sliderImages = _dbContext.SliderImages.ToList();
        //    //var slider = _dbContext.Sliders.FirstOrDefault();
        //    var slider = _dbContext.Sliders.SingleOrDefault();
        //    var categories = _dbContext.Categories.ToList();
        //    var products = _dbContext.Products.Include(x => x.Category).ToList();

        //    //IEnumerable vs IQueryable

        //    //var test = _dbContext.Products.Where(x => x.Id > 2).ToList();
        //    //var test2 = _dbContext.Products.ToList().Where(x => x.Id > 2);

        //    //Count() vs Count
        //    //var test = _dbContext.Products.ToList().Count();
        //    //var test = _dbContext.Products.ToList().Count;
        //    //var test = _dbContext.Products.Count();

        //    //Select
        //    //var test = _dbContext.Products.Select(x => new
        //    //{
        //    //    x.Id,
        //    //    x.Name
        //    //}).ToList();

        //    return View(new HomeViewModel
        //    {
        //        SliderImages = sliderImages,
        //        Slider = slider,
        //        Categories = categories,
        //        Products = products
        //    });
        //}

        public async Task<IActionResult> Index()
        {
            var sliderImages = _dbContext.SliderImages.ToListAsync();
            var slider = _dbContext.Sliders.SingleOrDefaultAsync();
            var categories = _dbContext.Categories.ToListAsync();
            var products = _dbContext.Products.Include(x => x.Category).ToListAsync();

            return View(new HomeViewModel
            {
                SliderImages = await sliderImages,
                Slider = await slider,
                Categories = await categories,
                Products = await products
            });
        }
    }
}
