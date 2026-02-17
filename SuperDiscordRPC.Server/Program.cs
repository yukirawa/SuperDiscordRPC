using Microsoft.AspNetCore.Mvc;
using SuperDiscordRPC.Shared; // Sharedを使う

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var apiKey = Environment.GetEnvironmentVariable("API_KEY") ?? "default";
var store = new ActivityStore();

// スマホからの受信 (POST)
app.MapPost("/api/activity", ([FromHeader(Name = "X-API-KEY")] string key, [FromBody] ActivityStatus status) =>
{
    if (key != apiKey) return Results.Unauthorized();
    store.Update(status);
    return Results.Ok();
});

// PCへの送信 (GET)
app.MapGet("/api/activity", () =>
{
    // 5分以上更新がなければ非アクティブ
    if (DateTime.UtcNow - store.LastUpdated > TimeSpan.FromMinutes(5))
        return Results.Ok(new ActivityStatus { IsActive = false });

    return Results.Ok(store.CurrentStatus);
});

app.Run();

// データをメモリに保存しておくクラス
class ActivityStore
{
    public ActivityStatus CurrentStatus { get; private set; } = new();
    public DateTime LastUpdated { get; private set; } = DateTime.MinValue;

    public void Update(ActivityStatus status)
    {
        CurrentStatus = status;
        LastUpdated = DateTime.UtcNow;
    }
}