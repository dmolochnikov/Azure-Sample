using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public ActionResult Index(string textToFind)
        {
            SearchParameters parameters;
            DocumentSearchResult<Book> booksResult;
            DocumentSearchResult<Player> playersResult;
            DocumentSearchResult<Student> studentsResult;

            parameters = new SearchParameters { Top = 5 };

            booksResult = booksSearchIndexClient.Documents.Search<Book>(textToFind, parameters);
            playersResult = playersSearchIndexClient.Documents.Search<Player>(textToFind, parameters);
            studentsResult = studentsSearchIndexClient.Documents.Search<Student>(textToFind, parameters);

            var books = booksResult.Results.Select(r => r.Document).ToList();
            var players = playersResult.Results.Select(r => r.Document).ToList();
            var students = studentsResult.Results.Select(r => r.Document).ToList();

            var data = new SearchResultsViewModel { Books = books, Players = players, Students = students };
            
            return View(data);
        }
    }
}