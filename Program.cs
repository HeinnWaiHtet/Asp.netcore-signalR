using Asp.netCoreSignlaR.Hubs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var services = builder.Services;

/** Add Services */
services.AddMvc();
services.AddSignalR();

/** Add Middleware */
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.MapHub<MessageHubs>("/messages");

app.Run();
