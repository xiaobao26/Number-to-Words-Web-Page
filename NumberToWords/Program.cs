using NumberToWords.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Services to container
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<INumberToWordsService, NumberToWordsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI();    
}

app.UseHttpsRedirection();

// UseDefaultFiles must be called before UseStaticFiles to serve the default file.
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

app.Run();
