using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IRepositories;
using CDEUnileverAPI.Core.Repositories;

namespace CDEUnileverAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CDEUnileverDbContext _context;
        private readonly ILogger _logger;


        //public IAreaRepository AreaRepository => throw new NotImplementedException();
        public IAreaRepository AreaRepository { get; private set; }
        public ITitleRepository TitleRepository { get; private set; }
        public IDistributorRepository DistributorRepository { get; private set; }

        public UnitOfWork(CDEUnileverDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            AreaRepository = new AreaRepository(_context, _logger);
            TitleRepository = new TitleRepository(_context, _logger);
            DistributorRepository = new DistributorRepository(_context, _logger);
        }
        public void Commit() => _context.SaveChanges();
        public async Task CommitAsync() => await _context.SaveChangesAsync();
        public void Rollback() => _context.Dispose();
        public async Task RollbackAsync() => await _context.SaveChangesAsync();
    }
}
