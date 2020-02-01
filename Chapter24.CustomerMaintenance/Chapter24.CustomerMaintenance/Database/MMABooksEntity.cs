using Chapter24.CustomerMaintenance.Model;

namespace Chapter24.CustomerMaintenance.Database
{
    public class MMABooksEntity
    {
        private MMABooksEntities _dbContext;
        private static readonly object _syncLock = new object();
        private static MMABooksEntity _instance;

        public MMABooksEntities DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    lock (_syncLock)
                    {
                        _dbContext = new MMABooksEntities();
                    }
                }

                return _dbContext;
            }
        }

        public static MMABooksEntity Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MMABooksEntity();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
