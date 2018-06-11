namespace DDD.Services.Contracts
{
    public interface IProjectionBuilder
    {
        TProjection Build<TObject, TProjection>(TObject obj);
    }
}
