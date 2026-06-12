namespace SpotTrack.Platform.Profiles.Interfaces.Acl;

public interface IProfilesContextFacade
{
    Task<int> FetchClientIdByEmailAsync(string email);
    Task<int> FetchAdminIdByEmailAsync(string email);
}
