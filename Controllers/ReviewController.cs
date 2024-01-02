/*using LaCroute.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Controllers
{
	public class ReviewController : Controller
	{
		private readonly LaCrouteContext _context;

		public ReviewController(LaCrouteContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var reviews = await _context.Review.OrderByDescending(reviews => reviews.created_at).Take(5).ToListAsync();
			return View(reviews);
		}
	}
}
*/