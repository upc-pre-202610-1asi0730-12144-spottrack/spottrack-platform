using Microsoft.Extensions.Logging;
using SpotTrack.Platform.Profiles.Application.CommandServices;
using SpotTrack.Platform.Profiles.Domain.Model.Commands;
using SpotTrack.Platform.Profiles.Interfaces.Events;
using SpotTrack.Platform.Shared.Application.Internal.EventHandlers;

namespace SpotTrack.Platform.Profiles.Application.Internal.EventHandlers;

public class RoleAssignedEventHandler(
    IClientCommandService clientCommandService,
    IAdminCommandService adminCommandService,
    ILogger<RoleAssignedEventHandler> logger)
    : IEventHandler<RoleAssignedIntegrationEvent>
{
    public async Task Handle(RoleAssignedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        switch (notification.Role)
        {
            case "ROLE_CLIENT":
            {
                var command = new CreateClientCommand(
                    notification.UserId,
                    notification.Email,
                    notification.FirstName,
                    notification.LastName,
                    notification.PhoneNumber,
                    notification.Dni);

                var result = await clientCommandService.Handle(command, cancellationToken);
                if (result.IsFailure)
                    logger.LogWarning("Failed to create client profile for user {UserId}: {Error}",
                        notification.UserId, result.Error);
                break;
            }
            case "ROLE_ADMIN":
            {
                var command = new CreateAdminCommand(
                    notification.UserId,
                    notification.Email,
                    notification.FirstName,
                    notification.LastName,
                    notification.PhoneNumber,
                    notification.Dni);

                var result = await adminCommandService.Handle(command, cancellationToken);
                if (result.IsFailure)
                    logger.LogWarning("Failed to create admin profile for user {UserId}: {Error}",
                        notification.UserId, result.Error);
                break;
            }
            default:
                logger.LogWarning("Unrecognized role '{Role}' for user {UserId}; no profile created.",
                    notification.Role, notification.UserId);
                break;
        }
    }
}
