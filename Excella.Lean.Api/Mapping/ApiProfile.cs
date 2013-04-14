namespace Excella.Lean.Api.Mapping
{
    using AutoMapper;
    
    public class ApiProfile : Profile
    {
        public override string ProfileName
        {
            get { return "Api"; }
        }

        protected override void Configure()
        {
            // this.CreateMap<TypeA, TypeB>();
        }
    }
}