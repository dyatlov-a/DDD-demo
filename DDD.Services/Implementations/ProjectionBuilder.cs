using AutoMapper;
using DDD.Services.Contracts;

namespace DDD.Services.Implementations
{
    public class ProjectionBuilder : IProjectionBuilder
    {
        public TProjection Build<TObject, TProjection>(TObject obj)
        {
            return Mapper.Map<TObject, TProjection>(obj);
        }
    }
}
