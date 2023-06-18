using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimitAspNetCoreDemo.Controllers
{
	[EnableRateLimiting("concurrency")] // <<<<<<<< Here we apply the rate limiting policy
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController: ControllerBase 
	{
		
		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Hello World from Get()");
		}
	}
}