public class Program
{
    public static void Main(string[] args)
    {
        using (var ctx = new MyStreamingContext())
        {
            ctx.Database.EnsureCreated();

            // Insert Roles
            var role1 = new Role { RoleName = "Admin" };
            var role2 = new Role { RoleName = "Editor" };
            var role3 = new Role { RoleName = "Viewer" };

            var user1 = new User { Name = "Alice", UserName = "alice", Password = "password123", Email = "alice@example.com", BirthDate = new DateTime(1990, 1, 1), UserRole = UserRole.ADM, RoleId = role1.RoleId, Role = role1};
            var user2 = new User { Name = "Bob", UserName = "bob", Password = "password123", Email = "bob@example.com", BirthDate = new DateTime(1992, 2, 2), UserRole = UserRole.INSTRUCTOR , RoleId = role2.RoleId, Role = role2};
            var user3 = new User { Name = "Charlie", UserName = "charlie", Password = "password123", Email = "charlie@example.com", BirthDate = new DateTime(1995, 3, 3), UserRole = UserRole.HALFOFFICIAL, RoleId = role3.RoleId, Role = role3 };

            ctx.Users.AddRange(user1, user2, user3);

            // Insert Channels
            var channel1 = new Channel { ChannelName = "Tech Talk", ChannelType = ChannelType.ENTERTAINMENT };
            var channel2 = new Channel { ChannelName = "Music Mania", ChannelType = ChannelType.MUSIC };
            var channel3 = new Channel { ChannelName = "Gaming Zone", ChannelType = ChannelType.GAMES };

            ctx.Channels.AddRange(channel1, channel2, channel3);

            // Insert Videos
            var video1 = new Video { VideoName = "Introduction to C#", Channel = channel1 };
            var video2 = new Video { VideoName = "Top 10 Music Hits", Channel = channel2 };
            var video3 = new Video { VideoName = "Best Gaming Tips", Channel = channel3 };

            ctx.Videos.AddRange(video1, video2, video3);

            // Insert Playlists
            var playlist1 = new Playlist { PlaylistName = "C# Tutorials", User = user1 };
            var playlist2 = new Playlist { PlaylistName = "Top Tracks", User = user2 };
            var playlist3 = new Playlist { PlaylistName = "Gaming Guides", User = user3 };

            ctx.Playlists.AddRange(playlist1, playlist2, playlist3);

            // Insert Comments
            var comment1 = new Comment { CommentText = "Great video!", User = user1, Video = video1 };
            var comment2 = new Comment { CommentText = "Loved the music selection.", User = user2, Video = video2 };
            var comment3 = new Comment { CommentText = "Amazing tips, thanks!", User = user3, Video = video3 };

            ctx.Comments.AddRange(comment1, comment2, comment3);

            // Insert Reactions
            var reaction1 = new Reaction { ReactionType = ReactionType.LIKE, Video = video1, User = user1 };
            var reaction2 = new Reaction { ReactionType = ReactionType.DISLIKE, Video = video2, User = user2 };
            var reaction3 = new Reaction { ReactionType = ReactionType.NOREACTION, Video = video3, User = user3 };

            ctx.Reactions.AddRange(reaction1, reaction2, reaction3);

            // Insert Contents
            var content1 = new Content { Piece = new byte[] { 1, 2, 3 }, Video = video1 };
            var content2 = new Content { Piece = new byte[] { 4, 5, 6 }, Video = video2 };
            var content3 = new Content { Piece = new byte[] { 7, 8, 9 }, Video = video3 };

            ctx.Contents.AddRange(content1, content2, content3);

            // Insert Permissions
            var permission1 = new Permission { Name = "View" };
            var permission2 = new Permission { Name = "Edit" };
            var permission3 = new Permission { Name = "Delete" };

            ctx.Permissions.AddRange(permission1, permission2, permission3);


            ctx.Roles.AddRange(role1, role2, role3);

            // Insert Groups
            var group1 = new Group { Name = "Developers", Permissions = new List<Permission> { permission1, permission2 } };
            var group2 = new Group { Name = "Content Creators", Permissions = new List<Permission> { permission1, permission3 } };
            var group3 = new Group { Name = "Subscribers", Permissions = new List<Permission> { permission1 } };

            ctx.Groups.AddRange(group1, group2, group3);

            // Insert ChannelRoles
            var channelRole1 = new ChannelRole { ChannelRoleId = channel1.ChannelId };
            var channelRole2 = new ChannelRole { ChannelRoleId = channel2.ChannelId };
            var channelRole3 = new ChannelRole { ChannelRoleId = channel3.ChannelId };

            ctx.ChannelRoles.AddRange(channelRole1, channelRole2, channelRole3);

            // Insert ChannelPermissions
            var channelPermission1 = new ChannelPermission { ChannelRoles = new List<ChannelRole> { channelRole1 } };
            var channelPermission2 = new ChannelPermission { ChannelRoles = new List<ChannelRole> { channelRole2 } };
            var channelPermission3 = new ChannelPermission { ChannelRoles = new List<ChannelRole> { channelRole3 } };

            ctx.ChannelPermissions.AddRange(channelPermission1, channelPermission2, channelPermission3);

            // Insert ChannelManagements
            var channelManagement1 = new ChannelManagement { User = user1, ChannelRole = channelRole1, Channel = channel1 };
            var channelManagement2 = new ChannelManagement { User = user2, ChannelRole = channelRole2, Channel = channel2 };
            var channelManagement3 = new ChannelManagement { User = user3, ChannelRole = channelRole3, Channel = channel3 };

            ctx.ChannelManagements.AddRange(channelManagement1, channelManagement2, channelManagement3);

            // Insert Subscribed
            var subscribed1 = new Subscribed { User = user1, Channel = channel1 };
            var subscribed2 = new Subscribed { User = user2, Channel = channel2 };
            var subscribed3 = new Subscribed { User = user3, Channel = channel3 };

            ctx.Subscribeds.AddRange(subscribed1, subscribed2, subscribed3);

            // Save changes
            ctx.SaveChanges();
        }
        Console.WriteLine("AAAA");
    }
}