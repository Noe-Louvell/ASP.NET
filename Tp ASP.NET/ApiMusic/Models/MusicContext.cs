using Microsoft.EntityFrameworkCore;


namespace ApiMusic.Models
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options)
            :base(options)
        {
        }

        public DbSet<MusicItem> MusicItems { get; set; }
    }
}
