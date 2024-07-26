using Api.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IItemsService, ItemsService>();

builder.Services.AddHttpClient("item", client =>
{
    client.DefaultRequestHeaders.Add("X-Functions-Key", builder.Configuration["ApiSettings:Key"]);
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:Url"]);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.Run();