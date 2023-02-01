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
        public IUserRepository UserRepository { get; private set; }
        public IQuestionnaireDetailRepository QuestionaireDetailRepository {get; private set;}
        public IVisitPlanRepository VisitPlanRepository { get; private set; }
        public IJobTaskRepository JobTaskRepository { get; private set; }
        public IQuestionnaireRepository QuestionaireRepository {get; private set;}
        public INotiRepository NotiRepository { get; private set; }
        public ICommentRepository CommentRepository { get; private set; }

        public UnitOfWork(CDEUnileverDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            AreaRepository = new AreaRepository(_context, _logger);
            TitleRepository = new TitleRepository(_context, _logger);
            DistributorRepository = new DistributorRepository(_context, _logger);
            UserRepository= new UserRepository(_context, _logger);
            QuestionaireRepository = new QuestionnaireRepository(_context, _logger);
            QuestionaireDetailRepository = new QuestionnaireDetailRepository(_context, _logger);
            VisitPlanRepository = new VisitPlanRepository(_context, _logger);
            JobTaskRepository = new JobTaskRepository(_context, _logger);
            NotiRepository = new NotiRepository(_context, _logger);
            CommentRepository = new CommentRepository(_context, _logger);
        }
        public void Commit() => _context.SaveChanges();
        public async Task CommitAsync() => await _context.SaveChangesAsync();
        public void Rollback() => _context.Dispose();
        public async Task RollbackAsync() => await _context.DisposeAsync();
    }
}
