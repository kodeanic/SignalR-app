using SignalRApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.UseFileServer();

app.MapHub<GroupChatHub>("/groupchat");
app.MapHub<PrivateChatHub>("/privatechat");

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/p")
    {
        context.Response.Redirect("/private_chat.html");
        return;
    }

    await next();
});

app.Run();