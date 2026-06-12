using SpotTrack.Platform.Shared.Domain.Model.Events;

namespace SpotTrack.Platform.Profiles.Interfaces.Events;

public record RoleAssignedIntegrationEvent(
    int UserId,
    string Email,
    string Role,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Dni) : IEvent;
