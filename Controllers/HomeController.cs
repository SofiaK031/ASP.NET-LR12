using LR12.Models;
using LR12.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LR12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;
        private readonly UserService _userService;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext, UserService userService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userService = userService;
        }

        public IActionResult Index()
        {
            _dbContext.Users.Add(new UserModel("Sophie", "sophie@gmail.com", 21));
            return View();
        }

        public async Task<IActionResult> AddUsers()
        {
            await _userService.CreateUserAsync("Liam", "Smith", 29);
            await _userService.CreateUserAsync("Max", "Brown", 24);
            await _userService.CreateUserAsync("Isabella", "Lightwood", 25);
            await _userService.CreateUserAsync("Noah", "Miller", 36);
            await _userService.CreateUserAsync("Charlotte", "Fall", 28);

            return View();
        }

        public IActionResult ShowUsers()
        {
            var users = _dbContext.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, First name: {user.FirstName}, Second name: {user.SecondName}, Age: {user.Age}");
            }

            return View(users);
        }

        public async Task<IActionResult> AddCompanies()
        {
            var companies = new List<CompanyModel>
            {
                new CompanyModel("Tech Corp", "123 Silicon Valley", 1998, "Technology"),
                new CompanyModel("Green Energy", "45 Eco Street", 2005, "Energy"),
                new CompanyModel("HealthPlus", "78 Wellness Ave", 2010, "Healthcare"),
                new CompanyModel("EduSmart", "21 Knowledge Blvd", 2015, "Education"),
                new CompanyModel("OrgFood Inc", "90 Gourmet Rd", 2000, "Food")
            };

            _dbContext.Companies.AddRange(companies);
            await _dbContext.SaveChangesAsync();

            return View(companies);
            //return RedirectToAction("ShowCompanies");
        }

        public IActionResult ShowCompanies()
        {
            var companies = _dbContext.Companies.ToList();
            return View(companies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
