using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Rate limiting using Fixed Window algorithm

// builder.Services.AddRateLimiter(options =>
// {
// 	options.RejectionStatusCode = 429;
// 	options.AddFixedWindowLimiter(policyName: "fixed", options =>
// 	{
// 		options.PermitLimit = 3;
// 		options.Window = TimeSpan.FromMinutes(1);
// 	});
// });


// Rate limiting using Sliding Window algorithm
// builder.Services.AddRateLimiter(options =>
// {
// 	options.RejectionStatusCode = 429;
// 	options.AddSlidingWindowLimiter(policyName: "sliding", options =>
// 	{
// 		options.PermitLimit = 3;
// 		options.Window = TimeSpan.FromMinutes(1);
// 		options.SegmentsPerWindow = 1;
// 	});
// });


// Rate limiting using Token Bucket algorithm
// builder.Services.AddRateLimiter(options =>
// {
// 	options.RejectionStatusCode = 429;
// 	options.AddTokenBucketLimiter(policyName: "token", options =>
// 	{
// 		options.TokenLimit = 3;;
// 		options.TokensPerPeriod = 3;
// 		options.ReplenishmentPeriod = TimeSpan.FromMinutes(1);
// 	});
// });


// Rate limiting using Concurrency Limit algorithm
builder.Services.AddRateLimiter(options =>
{
	options.RejectionStatusCode = 429;
	options.AddConcurrencyLimiter(policyName: "concurrency", options =>
	{
		options.PermitLimit = 2;
		options.QueueLimit = 2;
	});
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseRateLimiter();

app.Run();
