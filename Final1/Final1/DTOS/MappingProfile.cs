using Final1.Data.Entities;
using AutoMapper;
namespace Final1.DTOS
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatitentDTO>();

            CreateMap<PatientSaveDTO, Patient>();
            CreateMap<Patient, PatientSaveDTO>();
        }


    }
}
