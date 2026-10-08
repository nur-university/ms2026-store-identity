using Identity.Application.Events;
using Joseco.Communication.External.Contracts.Services;
using MediatR;
using Joseco.Outbox.Contracts.Model;

namespace Identity.Application.OutboxMessageHandlers;

internal class PublishUserCreatedHandler(IExternalPublisher bus) : INotificationHandler<OutboxMessage<UserCreated>>
{
    public async Task Handle(OutboxMessage<UserCreated> notification, CancellationToken cancellationToken)
    {
        Nur.Store2026.Integration.Identity.UserCreated integrationEvent = new(notification.Content.UserId,
            notification.Content.FullName,
            notification.Content.Email) { Id = notification.Content.Id };

        await bus.PublishAsync(integrationEvent);
    }
}
