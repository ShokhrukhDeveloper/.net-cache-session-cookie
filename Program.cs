var builder = WebApplication.CreateBuilder(args);

// Add 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/// memory cache service => can be inject ImemoryCache
builder.Services.AddMemoryCache();
/// distributed cache date service
builder.Services.AddDistributedMemoryCache();

/// Session and cookie configuration
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".request.count";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
  
    options.Cookie.MaxAge = TimeSpan.FromDays(30);
    
});
// add
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSession();

app.MapControllers();

app.Run();
