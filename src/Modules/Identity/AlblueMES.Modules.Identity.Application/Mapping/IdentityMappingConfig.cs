using AlblueMES.Modules.Identity.Application.DTOs;
using AlblueMES.Modules.Identity.Domain.Entities;
using Mapster;

namespace AlblueMES.Modules.Identity.Application.Mapping;

public static class IdentityMappingConfig
{
    public static void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>()
            .Map(dest => dest.Processes, src => src.UserProcesses.Select(up => new UserProcessDto(up.ProcessId)).ToList());

        config.NewConfig<Shift, ShiftDto>();
    }
}
