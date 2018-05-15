using System;
using System.Web.Mvc;
using BookStore.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace BookStore.Controllers
{
    public class SearchController : Controller
    {
        private static SearchIndexClient playersSearchIndexClient;
        private static SearchIndexClient booksSearchIndexClient;
        private static SearchIndexClient studentsSearchIndexClient;

        static SearchController()
        {
            var credentials = new SearchCredentials("422CE86A5BD07505CAB44F1CBAA12A02");
            const string searchServiceName = "dm-bookstore";

            playersSearchIndexClient = new SearchIndexClient(searchServiceName, "players", credentials);
            booksSearchIndexClient = new SearchIndexClient(searchServiceName, "books", credentials);
            studentsSearchIndexClient = new SearchIndexClient(searchServiceName, "students", credentials);
        }

        public ActionResult Search(string text)
        {
            SearchParameters parameters;
            DocumentSearchResult<Book> results;

            parameters = new SearchParameters();

            results = booksSearchIndexClient.Documents.Search<Book>("Толстой", parameters);


            return View();
        }
    }
}