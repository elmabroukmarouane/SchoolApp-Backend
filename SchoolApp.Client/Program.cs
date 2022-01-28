using SchoSchoolApp.Client.Extensions.Add;
using SchoSchoolApp.Client.Extensions.Use;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // Added to bypass Local UTC Datetime with PostgreSQL
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConnection(builder.Configuration, builder.Environment);
builder.Services.AddJWT(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCORS(builder.Configuration);
builder.Services.AddSERVICES(builder.Configuration, builder.Environment);
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCORS(app.Configuration);
app.UseJWT();

app.MapControllers();

app.Run();
