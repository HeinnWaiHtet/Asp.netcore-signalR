using Asp.netCoreSignlaR.Hubs;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

/** Add Services */
services.AddMvc();
services.AddRazorPages();
services.AddSignalR();


var app = builder.Build();

/** Add Middleware */
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<MessageHubs>("/messages");

app.Run();
