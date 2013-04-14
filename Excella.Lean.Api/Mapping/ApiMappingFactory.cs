namespace Excella.Lean.Api.Mapping
{
    using AutoMapper;
    using AutoMapper.Mappers;

    public static class ApiMappingFactory
    {
        private static ApiProfile apiProfile;

        private static volatile bool hasInitialized;

        private static ApiProjectToProfile apiProjectToProfile;

        public static ApiProfile Api
        {
            get
            {
                return apiProfile ?? (apiProfile = new ApiProfile());
            }
        }

        public static ApiProjectToProfile ApiProjectTo
        {
            get
            {
                return apiProjectToProfile ?? (apiProjectToProfile = new ApiProjectToProfile());
            }
        }

        public static MappingEngine ApiProjectToMapper { get; private set; }

        /// <summary>
        ///     Used to setup AutoMapper
        /// </summary>
        /// <param name="additionalProfiles">These profiles will override any existing mappings in an additive manner. Base and ProjectTo are applied automatically.</param>
        /// <exception cref="AutoMapperConfigurationException">Thrown the mapping configuration is invalid - check the logs</exception>
        public static void InitializeMappers(params Profile[] additionalProfiles)
        {
            if (!hasInitialized)
            {
                hasInitialized = true;
            }
            else
            {
                throw new AutoMapperConfigurationException("InitializeMappers should only be called once during the lifetime of an application.");
            }

            // Setup Mapper
            Mapper.AddProfile(Api);

            if (additionalProfiles != null)
            {
                foreach (Profile additionalProfile in additionalProfiles)
                {
                    Mapper.AddProfile(additionalProfile);
                }
            }

            // Verify Mapper configuration
            Mapper.AssertConfigurationIsValid();

            // Setup ProjectToMapper
            ConfigurationStore getAllConfig = CreateConfiguration();

            ApiProjectToMapper = CreateMapper(getAllConfig);

            getAllConfig.AddProfile(Api);
            getAllConfig.AddProfile(ApiProjectTo);
        }

        public static void DestructMappers()
        {
            Mapper.Reset();
            ApiProjectToMapper = null;
            hasInitialized = false;
        }

        private static ConfigurationStore CreateConfiguration()
        {
            return new ConfigurationStore(new TypeMapFactory(), MapperRegistry.AllMappers());
        }

        private static MappingEngine CreateMapper(IConfigurationProvider configuration)
        {
            return new MappingEngine(configuration);
        }
    }
}