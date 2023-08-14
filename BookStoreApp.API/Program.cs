//using BookStoreApp.API.Data;
//using Microsoft.EntityFrameworkCore;
//using Serilog;


//var builder = WebApplication.CreateBuilder(args);



//// Add services to the container.
//var connString = builder.Configuration.GetConnectionString("BookStoreAppDbConnection");
//builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(connString));

//builder.Services.AddRazorPages();
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Host.UseSerilog((ctx, lc) =>
//    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration)
//);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", b => b.AllowAnyMethod().AllowAnyMethod().AllowAnyOrigin());
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    // app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    // app.UseHsts();
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseCors("AllowAll");
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//app.Run();


using BookStoreApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("BookStoreAppDbConnection");
builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(connString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        b => b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
