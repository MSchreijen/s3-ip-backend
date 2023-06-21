using DAL;
using DAL.Handlers;
using DAL.Interfaces;
using BLL.Logic;
using BLL.Interfaces;

var MyAllowSpecificOrigins = "MergerSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "https://localhost:3000");
            policy.WithHeaders("content-type");
        });
});

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MergerContext>();

builder.Services.AddScoped<IUserHandler, UserHandler>();
builder.Services.AddScoped<IUserLogic, UserLogic>();

builder.Services.AddScoped<IPlaylistHandler, PlaylistHandler>();
builder.Services.AddScoped<IPlaylistLogic, PlaylistLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
