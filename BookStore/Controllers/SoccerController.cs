using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using  BookStore.Models;
using System.Data.Entity;

namespace BookStore.Controllers
{
    public class SoccerController : Controller
    {
        private BookContext _context = new BookContext();

		protected override void Dispose(bool disposing)
		{
			if (_context != null)
			{
				_context.Dispose();
				_context = null;
			}

			base.Dispose(disposing);
		}

		public ActionResult Filtes(int? team, string position)
        {
            IQueryable<Player> players = _context.Players.Include(p => p.Team);
            if (team != null && team != 0)
            {
                players = players.Where(p => p.TeamId == team);
            }
            if (!String.IsNullOrEmpty(position) && !position.Equals("Все"))
            {
                players = players.Where(p => p.Position == position);
            }

            List<Team> teams = _context.Teams.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            teams.Insert(0, new Team { Name = "All", Id = 0 });

	        PlayersListViewModel plvm = new PlayersListViewModel
	        {
		        Players = players.ToList(),
		        Teams = new SelectList(teams, "Id", "Name"),
		        Positions = new SelectList(new List<string>()
		        {
			        "All",
			        "Forward",
			        "Midfielder",
			        "Defender",
			        "Goalkeeper"
		        })
	        };

            return View(plvm);
        }
        
        public ActionResult Index()
        {
            var players = _context.Players.Include(p => p.Team);
            return View(players.ToList());
        }

        public ActionResult TeamDetails(int? id)
        {
            id = 2;//?
            if (id == null)
            {
                return HttpNotFound();
            }
            Team team = _context.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            team.Players = _context.Players.Where(m => m.TeamId == team.Id);
            return View(team);
        }

        [HttpGet]
        public ActionResult Create()
        {
            // Формируем список команд для передачи в представление
            SelectList teams = new SelectList(_context.Teams, "Id", "Name");
            ViewBag.Teams = teams;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Player player)
        {
            //Добавляем игрока в таблицу
            _context.Players.Add(player);
            _context.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            // Находим в бд футболиста
            Player player = _context.Players.Find(id);
            if (player != null)
            {
                // Создаем список команд для передачи в представление
                SelectList teams = new SelectList(_context.Teams, "Id", "Name", player.TeamId);
                ViewBag.Teams = teams;
                return View(player);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return HttpNotFound();
            }

            _context.Players.Remove(player);

            return RedirectToAction("Index");
        }
    }
}