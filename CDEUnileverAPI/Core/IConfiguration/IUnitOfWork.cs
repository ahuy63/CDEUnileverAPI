﻿using CDEUnileverAPI.Core.IRepositories;

namespace CDEUnileverAPI.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IAreaRepository AreaRepository { get; }
        ITitleRepository TitleRepository { get; }
        IDistributorRepository DistributorRepository { get; }
        IUserRepository UserRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();

        //Task CompleteAsync();
    }
}
