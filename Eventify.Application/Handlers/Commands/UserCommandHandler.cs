using AutoMapper;
using Eventify.Application.Interfaces.Commands;
using Eventify.Application.Interfaces.Commands.User;
using Eventify.Application.Interfaces.Dto;
using Eventify.Application.Interfaces.Handlers;
using Eventify.Domain.Entities;
using Eventify.Domain.IRepositories;
using Microsoft.Extensions.Logging;

namespace Eventify.Application.Handlers.Commands
{
    public class UserCommandHandler : ICommandHandler<IUserDto, IUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UserCommandHandler(IUserRepository repository, ILogger<UserCommandHandler> logger, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IUserDto?> Handle(IUserCommand command)
        {

            return command switch
            {
                ICreateUserCommand createCommand => await CreateUser(createCommand),
                IUpdateUserCommand updateCommand => await UpdateUser(updateCommand),
                IDeleteUserCommand deleteCommand => await DeleteUser(deleteCommand),
                IChangePasswordCommand changeUserPasswordCommand => await UpdateUser(changeUserPasswordCommand),
                IChangeUserRoleCommand changeUserRoleCommand => await UpdateUser(changeUserRoleCommand),
                _ => null
            };
        }

        private async Task<IUserDto?> CreateUser(ICreateUserCommand command)
        {
            try
            {
                var newUser = new User
                {
                    Id = Guid.NewGuid(),
                    Username = command.Username,
                    Email = command.Email,
                    Password = command.Password,
                    ConfirmPassword = command.ConfirmPassword,
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    BirthDate = DateTime.Parse(command.BirthDate.ToShortDateString()),
                    UserAddress = command.UserAddress,
                    PhoneNumber = command.PhoneNumber,
                    Gender = command.Gender,
                    Role = command.Role,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                };

                var created = await _repository.AddAsync(newUser);
                if (created != null)
                {
                    _logger.LogInformation($"Created new User, ID: {created.Id}");
                    return _mapper.Map<IUserDto>(created);
                }
                else
                {
                    _logger.LogWarning($"Warning CreateUser :: Failed to create new User");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Critical CreateUser :: Exception: {ex.Message}");
                return null;
            }
        }

        private async Task<IUserDto?> UpdateUser(IUserCommand command)
        {
            try
            {
                var updated = await _repository.UpdateAsync(_mapper.Map<User>(command));
                if (updated != null)
                {
                    _logger.LogInformation($"Updated User, ID: {updated.Id}");
                    return _mapper.Map<IUserDto>(updated);
                }
                else
                {
                    _logger.LogWarning($"Warning {GetCommandTypeName(command)} :: Failed to update User with ID: {GetIdProperty(command)}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Critical {GetCommandTypeName(command)} :: Exception: {ex.Message}");
                return null;
            }
        }

        private async Task<IUserDto?> DeleteUser(IDeleteUserCommand command)
        {
            try
            {
                var deleted = await _repository.RemoveAsync(_mapper.Map<User>(command));
                if (deleted != null)
                {
                    _logger.LogInformation($"Deleted User, ID: {deleted.Id}");
                    return _mapper.Map<IUserDto>(deleted);
                }
                else
                {
                    _logger.LogWarning($"Warning DeleteUser :: Failed to delete User with ID: {command.Id}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Critical DeleteUser :: Exception: {ex.Message}");
                return null;
            }
        }

        private static string GetCommandTypeName(IUserCommand command)
        {
            return command?.GetType().Name ?? "UnknownCommandType";
        }

        private static string GetIdProperty(IUserCommand command)
        {
            var idProperty = command.GetType().GetProperty("Id");
            return idProperty?.GetValue(command)?.ToString() ?? "N/A";
        }
    }
}
