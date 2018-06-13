using System;

namespace MyPatchV3
{
    using AutoMapper;

    using MyPatchV3.DL.Models;
    using MyPatchV3.SAL.DTO;
    using MyPatchV3.BL.Entities;

    public class Bootstrapper
    {
        public IMapper AutoMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FileInfoDto, DBFileInfo>().ForMember(dest => dest.FileType, opt => opt.MapFrom(src => src.file_Type));
                cfg.CreateMap<FileInfoDto, DBFileInfo>().ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.file_Name));
                cfg.CreateMap<FileInfoDto, DBFileInfo>().ForMember(dest => dest.FileSize, opt => opt.MapFrom(src => src.file_Size));
                cfg.CreateMap<FileInfoDto, DBFileInfo>().ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.version));
                cfg.CreateMap<FileInfoDto, DBFileInfo>().ForMember(dest => dest.PathHTTP, opt => opt.MapFrom(src => src.path_HTTP));
                cfg.CreateMap<FileInfoDto, DBFileInfo>().ForMember(dest => dest.IsComplete, opt => opt.MapFrom(src => src.isComplete));
            });

            return config.CreateMapper();
        }
    }
}

