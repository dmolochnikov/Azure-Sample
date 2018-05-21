using System;
using System.Linq;
using System.Web.Mvc;
using BookStore.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace BookStore.Controllers
{
    public class SearchController : Controller
    {
        private static readonly SearchIndexClient playersSearchIndexClient;
        private static readonly SearchIndexClient booksSearchIndexClient;
        private static readonly SearchIndexClient studentsSearchIndexClient;
        private static readonly IDatabase cache;

        static SearchController()
        {
            var credentials = new SearchCredentials("422CE86A5BD07505CAB44F1CBAA12A02");
            const string searchServiceName = "dm-bookstore";

            playersSearchIndexClient = new SearchIndexClient(searchServiceName, "players", credentials);
            booksSearchIndexClient = new SearchIndexClient(searchServiceName, "books", credentials);
            studentsSearchIndexClient = new SearchIndexClient(searchServiceName, "students", credentials);
            cache = Redis.RedisConnection.GetDatabase();
        }

        [HttpPost]
        public ActionResult Index(string textToFind)
        {
            RedisValue value = cache.StringGet(textToFind);
            if (!value.HasValue)
            {
                var tmp = GetValueFromDataSource(textToFind);
                value = JsonConvert.SerializeObject(tmp);
                cache.StringSet(textToFind, value, TimeSpan.FromMinutes(5));
            }

            var data = JsonConvert.DeserializeObject<SearchResultsViewModel>(value);

            return View(data);
        }

        private static SearchResultsViewModel GetValueFromDataSource(string textToFind)
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

            return new SearchResultsViewModel {Books = books, Players = players, Students = students, TotalItems = books.Count + players.Count + students.Count };
        }
    }
}