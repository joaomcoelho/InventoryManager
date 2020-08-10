namespace FELFEL.Data
{
    public class BaseWorker
    {
        protected readonly DataContext _context;

        public BaseWorker(DataContext context)
        {
            _context = context;
        }
    }
}