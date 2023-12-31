using eyeproject.Service;
using QuestPDF.Drawing;
using QuestPDF.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOriginPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IReportService, ReportService>();
builder.Services.AddSingleton<IDocumentService, DocumentService>();

//FontManager.RegisterFont( File.OpenRead("Times New Roman"));
FontManager.RegisterFont( File.OpenRead("Times New Roman/times new roman.ttf"));
// FontManager.RegisterFont( File.OpenRead("Times New Roman/times new roman bold.ttf"));
// FontManager.RegisterFont( File.OpenRead("Times New Roman/times new roman bold italic.ttf"));
// FontManager.RegisterFont( File.OpenRead("Times New Roman/times new roman italic.ttf"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOriginPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
