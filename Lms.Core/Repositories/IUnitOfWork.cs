namespace Lms.Data.Repositories
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        ITournamentRepository TournamentRepository { get; }

        Task CompleteAsync();
    }
}