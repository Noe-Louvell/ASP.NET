using Microsoft.EntityFrameworkCore;
using TpMusic.Models;

namespace TpMusic.Data
{
    public class MvcMusicContext : DbContext
    {
        public MvcMusicContext(DbContextOptions<MvcMusicContext> options)
            : base(options)
        {
        }

        public DbSet<Music> Music { get; set; }
    }
}

