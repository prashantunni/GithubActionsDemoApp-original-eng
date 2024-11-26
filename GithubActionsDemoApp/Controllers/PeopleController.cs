using GithubActionsDemoApp.Entities;
using GithubActionsDemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GithubActionsDemoApp.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext context;

        public PeopleController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var people = await context.People.ToListAsync();
            var model = new PeopleIndex()
            {
                People = people
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            context.Add(person);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

            if (person is null)
            {
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            context.Update(person);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var persona = await context.People.FirstOrDefaultAsync(x => x.Id == id);

            if (persona is null)
            {
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await context.People.Where(x => x.Id == id).ExecuteDeleteAsync();
            return RedirectToAction("Index");
        }
    }
}
