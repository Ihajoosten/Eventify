using AutoMapper;
using Eventify.Application.Interfaces.Commands;
using Eventify.Application.Interfaces.Commands.Venue;
using Eventify.Application.Interfaces.Dto;
using Eventify.Application.Interfaces.Handlers;
using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Microsoft.Extensions.Logging;

namespace Eventify.Application.Handlers.Commands
{
    public class VenueCommandHandler : ICommandHandler<IVenueDto, IVenueCommand>
    {
        private readonly IVenueRepository _repository;
        private readonly ILogger<VenueCommandHandler> _logger;
        private readonly IMapper _mapper;

        public VenueCommandHandler(IVenueRepository repository, ILogger<VenueCommandHandler> logger, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IVenueDto?> Handle(IVenueCommand command)
        {

            return command switch
            {
                ICreateVenueCommand createCommand => await CreateVenue(createCommand),
                IUpdateVenueCommand updateCommand => await UpdateVenue(updateCommand),
                IDeleteVenueCommand deleteCommand => await DeleteVenue(deleteCommand),
                IChangeVenueAddressCommand changeVenueAddressCommand => await UpdateVenue(changeVenueAddressCommand),
                _ => null
            };
        }

        private async Task<IVenueDto?> CreateVenue(ICreateVenueCommand command)
        {
            try
            {
                var newVenue = new Venue
                {
                    Id = Guid.NewGuid(),
                    Name = command.Name,
                    Capacity = command.Capacity,
                    ContactPerson = command.ContactPerson,
                    VenueAddress = command.VenueAddress,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                };

                var created = await _repository.AddAsync(newVenue);
                if (created != null)
                {
                    _logger.LogInformation($"Created new Venue, ID: {created.Id}");
                    return _mapper.Map<IVenueDto>(created);
                }
                else
                {
                    _logger.LogWarning($"Warning CreateVenue :: Failed to create new Venue");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Critical CreateVenue :: Exception: {ex.Message}");
                return null;
            }
        }

        private async Task<IVenueDto?> UpdateVenue(IVenueCommand command)
        {
            try
            {
                var updated = await _repository.UpdateAsync(_mapper.Map<Venue>(command));
                if (updated != null)
                {
                    _logger.LogInformation($"Updated Venue, ID: {updated.Id}");
                    return _mapper.Map<IVenueDto>(updated);
                }
                else
                {
                    _logger.LogWarning($"Warning {GetCommandTypeName(command)} :: Failed to update Venue with ID: {GetIdProperty(command)}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Critical {GetCommandTypeName(command)} :: Exception: {ex.Message}");
                return null;
            }
        }

        private async Task<IVenueDto?> DeleteVenue(IDeleteVenueCommand command)
        {
            try
            {
                var deleted = await _repository.RemoveAsync(_mapper.Map<Venue>(command));
                if (deleted != null)
                {
                    _logger.LogInformation($"Deleted Venue, ID: {deleted.Id}");
                    return _mapper.Map<IVenueDto>(deleted);
                }
                else
                {
                    _logger.LogWarning($"Warning DeleteVenue :: Failed to delete Venue with ID: {command.Id}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Critical DeleteVenue :: Exception: {ex.Message}");
                return null;
            }
        }

        private static string GetCommandTypeName(IVenueCommand command)
        {
            return command?.GetType().Name ?? "UnknownCommandType";
        }

        private static string GetIdProperty(IVenueCommand command)
        {
            var idProperty = command.GetType().GetProperty("Id");
            return idProperty?.GetValue(command)?.ToString() ?? "N/A";
        }
    }
}
