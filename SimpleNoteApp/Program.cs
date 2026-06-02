using SimpleNoteApp.Service;
using SimpleNoteApp.DTOs;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<NoteService>();
builder.Services.AddEndpointsApiExplorer();
object value = builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/notes", (NoteService service) =>
{
    return Results.Ok(service.GetAllNotes());
});

app.MapGet("/notes/{id}", (int id, NoteService service) =>
{
    var note = service.GetById(id);
    return note is null ? Results.NotFound() : Results.Ok(note);
});

app.MapPost("/notes", (CreateNoteDTO dto, NoteService service) =>
{
    var note = service.Create(dto.Title, dto.Content);
    return Results.Created($"/notes/{note.Id}", note);
});

app.MapPut("/notes/{id}", (int id, UpdateNoteDTO dto, NoteService service) =>
{
    var updated = service.Update(id, dto.Title, dto.Description);
    return updated ? Results.NoContent() : Results.NotFound();
});

app.MapDelete("/notes/{id}", (int id, NoteService service) =>
{
    var deleted = service.Delete(id);
    return deleted ? Results.NoContent() : Results.NotFound();
});

app.Run();
