using TransportOrderService.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
	// Add OpenAPI 3.0 document serving middleware
	// Available at: http://localhost:<port>/swagger/v1/swagger.json
	app.UseOpenApi();

	// Add web UIs to interact with the document
	// Available at: http://localhost:<port>/swagger
	app.UseSwaggerUi3();
}

app.Run();
