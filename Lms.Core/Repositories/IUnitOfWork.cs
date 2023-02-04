namespace Lms.Data.Repositories
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        ITournamentRepository TournamenRepository { get; }

        Task CompleteAsync();
    }
}