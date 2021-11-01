using ConsoleApp1Test.Metier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplicationASPAuth2.Controllers;
using WebApplicationASPAuth2.Models;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // AAA : Arrangement Act and Assert
            int i = 5 + 6;
            //On s'attend à ce que la valeur de i soit 4

            Assert.AreEqual(11, i, "what happens!");
        }
        //[TestMethod]
        //public void TestProjetConsoleCalculAddition()
        //{
        //    // AAA
        //    // Arrangement: 
        //    // - importer le ou les projets
        //    // - importer les packages nuggets utiliser dans l'autres projets
        //    Calcul c = new Calcul();
        //   int i = c.Addition(5, 6);
        //    Assert.AreEqual(11, i);
        
        //}

        [TestMethod]
        public void TestLibCalculSoustraction()
        {
            ClassLibraryNetFramework.Calcul calcul = new ClassLibraryNetFramework.Calcul();
            int i = calcul.Soustraction(4, 10);
            Assert.AreEqual(6, i);
        }

        [TestMethod]
        public async Task TestAppASPAuth2CategoriesEditAsync()
        {
            CategoriesController categoriesController = new CategoriesController();

            //retourner l'affichage (Model +...) 
            ViewResult viewResult = await categoriesController.Edit(3) as ViewResult;
            var categorie = viewResult.Model as Categorie; // Model est la class de type Entity => propriete de Data 

            Assert.AreEqual(3, categorie.Id, "Pas bonne categories");

            //var categoriesController = new CategoriesController();
            //var result = categoriesController.Edit(3);
            //Assert.AreEqual("Edit", result.Result);

        }

    }
}
