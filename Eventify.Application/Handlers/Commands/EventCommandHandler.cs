using AutoMapper;
using Eventify.Application.Dto;
using Eventify.Application.Interfaces.Commands;
using Eventify.Application.Interfaces.Commands.Event;
using Eventify.Application.Interfaces.Handlers;
using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Microsoft.Extensions.Logging;

namespace Eventify.Application.Handlers.Commands
{
    public class EventCommandHandler : ICommandHandler<EventDto, IEventCommand>
    {
        private readonly IEventRepository _repository;
        private readonly ILogger<EventCommandHandler> _logger;
        private readonly IMapper _mapper;

        public EventCommandHandler(IEventRepository repository, ILogger<EventCommandHandler> logger, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EventDto?> Handle(IEventCommand command)
        {

            return command switch
            {
                ICreateEventCommand createCommand => await CreateEvent(createCommand),
                IUpdateEventCommand updateCommand => await UpdateEvent(updateCommand),
                IDeleteEventCommand deleteCommand => await DeleteEvent(deleteCommand),
                IChangeEventDateCommand changeDateCommand => await UpdateEvent(changeDateCommand),
                IChangeEventVenueCommand changeVenueCommand => await UpdateEvent(changeVenueCommand),
                _ => null
            };
        }

        public async Task<EventDto?> CreateEvent(ICreateEventCommand command)
        {
            try
            {
                var newEvent = new Event
                {
                    Id = Guid.NewGuid(),
                    Title = command.Title,
                    Description = command.Description,
                    StartDate = command.StartDate,
                    EndDate = command.EndDate,
                    EventUrl = command.EventUrl,
                    IsRegistrationRequired = command.IsRegistrationRequired,
                    MaximumAttendees = command.MaximumAttendees,
                    VenueId = command.VenueId,
                    SponsorId = command.SponsorId,
                    OrganizerId = command.OrganizerId,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                };

                var created = await _repository.AddAsync(newEvent);
                if (created != null)
                {
                    _logger.LogInformation($"Created new Event, ID: {created.Id}");
                    return _mapper.Map<EventDto>(created);
                }
                else
                {
                    _logger.LogWarning($"Warning CreateEvent :: Failed to create new Event");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Critical CreateEvent :: Exception: {ex.Message}");
                return null;
            }
        }

        private async Task<EventDto?> UpdateEvent(IEventCommand command)
        {
            try
            {
                var updated = await _repository.UpdateAsync(_mapper.Map<Event>(command));
                if (updated != null)
                {
                    _logger.LogInformation($"Updated Event, ID: {updated.Id}");
                    return _mapper.Map<EventDto>(updated);
                }
                else
                {
                    _logger.LogWarning($"Warning {GetCommandTypeName(command)} :: Failed to update Event with ID: {GetIdProperty(command)}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Critical {GetCommandTypeName(command)} :: Exception: {ex.Message}");
                return null;
            }
        }

        private async Task<EventDto?> DeleteEvent(IDeleteEventCommand command)
        {
            try
            {
                var deleted = await _repository.RemoveAsync(_mapper.Map<Event>(command));
                if (deleted != null)
                {
                    _logger.LogInformation($"Deleted Event, ID: {deleted.Id}");
                    return _mapper.Map<EventDto>(deleted);
                }
                else
                {
                    _logger.LogWarning($"Warning DeleteEvent :: Failed to delete Event with ID: {command.Id}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Critical DeleteEvent :: Exception: {ex.Message}");
                return null;
            }
        }

        private static string GetCommandTypeName(IEventCommand command)
        {
            return command?.GetType().Name ?? "UnknownCommandType";
        }

        private static string GetIdProperty(IEventCommand command)
        {
            var idProperty = command.GetType().GetProperty("Id");
            return idProperty?.GetValue(command)?.ToString() ?? "N/A";
        }
    }
}
