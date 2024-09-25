using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

public class PlaylistRepository(MyStreamingContext ctx) : IPlaylistRepository
{
    public async Task<Playlist> Add(Playlist playlist)
    {
        await ctx.AddAsync(playlist);
        await ctx.SaveChangesAsync();
        return playlist;
    }

    public async Task Delete(Guid guid)
    {
        Playlist playlist = await ctx.Playlists.FindAsync(guid);

        if (playlist is not null)
        {
            ctx.Playlists.Remove(playlist);
            await ctx.SaveChangesAsync();
        }
    }

    public async Task<Playlist> GetById(Guid guid)
    {
        return await ctx.Playlists.FindAsync(guid);
    }

    public async Task<IEnumerable<Video>> GetVideos(Guid guid)
    {
        var playlist = await GetById(guid);

        if (playlist is null)
            return [];

        return await ctx.Videos.Where(v => v.Playlists.Contains(playlist)).ToListAsync();
    }

    public Task<Playlist> Update(Guid guid, PlaylistDto playlistDto)
    {
        throw new NotImplementedException();
    }
}