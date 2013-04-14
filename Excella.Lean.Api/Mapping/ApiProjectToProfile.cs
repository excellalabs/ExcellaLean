namespace Excella.Lean.Api.Mapping
{
    using AutoMapper;

    public class ApiProjectToProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ApiProjectTo";
            }
        }

        protected override void Configure()
        {
        }
    }
}
