using System.Net;
using YoutubeExplode;
using EntityFramework.Repositories;
using EntityFramework.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle]
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<HttpClient>(p =>
{
    var proxy = new WebProxy
    {
        Address = new Uri($"http://@rb-proxy-ca1.bosch.com:8080"),
        BypassProxyOnLocal = false,
        UseDefaultCredentials = false,

        // *** These creds are given to the proxy server, not the web server ***
        Credentials = new NetworkCredential(
            userName: "disrct",
            password: "area404etstech")
    };

    // Now create a client handler which uses that proxy
    var httpClientHandler = new HttpClientHandler
    {
        Proxy = proxy,
        UseProxy = true,
        PreAuthenticate = true
    };

    // Finally, create the HTTP client object
    var client = new HttpClient(handler: httpClientHandler, disposeHandler: true);
    
    
    return client;
});


builder.Services.AddSingleton<YoutubeClient>(p =>
{
    var client = p.GetRequiredService<HttpClient>();
    return new YoutubeClient(client);
});

builder.Services.AddCors(op => op
    .AddPolicy("main", policy => policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
    )
);


builder.Services.AddDbContext<MyStreamingContext>();

builder.Services.AddScoped<IChannelRepository, ChannelRepository>();
builder.Services.AddScoped<IChannelManagementRepository, ChannelManagementRepository>();
builder.Services.AddScoped<IChannelPermissionRepository, ChannelPermissionRepository>();
builder.Services.AddScoped<IChannelRoleRepository, ChannelRoleRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddScoped<IReactionRepository, ReactionRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ISubscribedRepository, SubscribedRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

app.Run();