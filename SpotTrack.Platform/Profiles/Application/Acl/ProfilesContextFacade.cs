using SpotTrack.Platform.Profiles.Application.QueryServices;
using SpotTrack.Platform.Profiles.Domain.Model.Queries;
using SpotTrack.Platform.Profiles.Interfaces.Acl;

namespace SpotTrack.Platform.Profiles.Application.Acl;

public class ProfilesContextFacade(
    IClientQueryService clientQueryService,
    IAdminQueryService adminQueryService)
    : IProfilesContextFacade
{
    public async Task<int> FetchClientIdByEmailAsync(string email)
    {
        var client = await clientQueryService.Handle(
            new GetClientByEmailQuery(email), CancellationToken.None);
        return client?.Id ?? 0;
    }

    public async Task<int> FetchAdminIdByEmailAsync(string email)
    {
        var admin = await adminQueryService.Handle(
            new GetAdminByEmailQuery(email), CancellationToken.None);
        return admin?.Id ?? 0;
    }
}
