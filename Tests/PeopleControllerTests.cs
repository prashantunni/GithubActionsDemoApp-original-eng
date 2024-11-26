using GithubActionsDemoApp.Controllers;
using GithubActionsDemoApp.Entities;
using GithubActionsDemoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Pruebas
{
    [TestClass]
    public class PeopleControllerTests: TestBase
    {
        [TestMethod]
        public async Task Index_ReturnsTwoPeople()
        {
            // Preparación
            var nameBD = Guid.NewGuid().ToString();
            var context = BuildContext(nameBD);

            context.People.Add(new Person() { Name = "Name 1" });
            context.People.Add(new Person() { Name = "Name 2" });
            await context.SaveChangesAsync();

            var contexto2 = BuildContext(nameBD);

            // Prueba
            var controller = new PeopleController(contexto2);
            var response = await controller.Index();

            // Verificación

            var viewResult = response as ViewResult;
            var model = (PeopleIndex)viewResult!.Model!;

            Assert.AreEqual(2, model.People.Count());
        }

        [TestMethod]
        public async Task Index_ReturnsEmpty_WhenTableIsEmpty()
        {
            // Preparación
            var nameDB = Guid.NewGuid().ToString();
            var context = BuildContext(nameDB);

            // Prueba
            var controller = new PeopleController(context);
            var response = await controller.Index();

            // Verificación

            var viewResult = response as ViewResult;
            var model = (PeopleIndex)viewResult!.Model!;

            Assert.AreEqual(0, model.People.Count());
        }
    }
}
