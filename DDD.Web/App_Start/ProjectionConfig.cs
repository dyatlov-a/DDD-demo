using AutoMapper;
using DDD.Services;

namespace DDD.Web
{
    public static class ProjectionConfig
    {
        private static void RegisterProfiles(IMapperConfigurationExpression config)
        {
            config.AddProfile(new DtosProfile());
        }

        /// <summary>
        /// Projection Register
        /// </summary>
        public static void Register()
        {
            Mapper.Initialize(RegisterProfiles);
        }
    }
}