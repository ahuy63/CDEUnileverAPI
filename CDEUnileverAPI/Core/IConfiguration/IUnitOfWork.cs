using CDEUnileverAPI.Core.IRepositories;

namespace CDEUnileverAPI.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IAreaRepository AreaRepository { get; }
        ITitleRepository TitleRepository { get; }
        IDistributorRepository DistributorRepository { get; }
        IUserRepository UserRepository { get; }
        IQuestionnaireDetailRepository QuestionaireDetailRepository { get; }
        IQuestionnaireRepository QuestionaireRepository { get; }
        IJobTaskRepository JobTaskRepository { get; }
        IVisitPlanRepository VisitPlanRepository { get; }
        INotiRepository NotiRepository { get; }
        ICommentRepository CommentRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();

        //Task CompleteAsync();
    }
}
