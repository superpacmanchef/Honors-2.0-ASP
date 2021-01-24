using Honors_2._0.Persistance.Contexts;

namespace HonorsTest2.Persistance.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly Honors20Context _context;

        public BaseRepository(Honors20Context context)
        {
            _context = context;
        }
    }
}