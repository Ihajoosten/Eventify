using Eventify.Domain.IRepositories;
using Eventify.Domain.IRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eventify.Infrastructure.EFRepositories.Base
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<EFRepository<T>> _logger;

        public EFRepository(IUnitOfWork unitOfWork, ILogger<EFRepository<T>> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            try
            {
                var entities = await _unitOfWork.Set<T>().ToListAsync();
                if (entities.Any())
                {
                    _logger.LogInformation($"Retrieved {entities.Count} records from {typeof(T).Name}.");
                    await _unitOfWork.CommitAsync();
                    return entities;
                }
                else
                {
                    _logger.LogWarning($"Entities were not found.");
                    await _unitOfWork.RollbackAsync();
                    return null;
                }
            }

            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, $"Error while getting records from {typeof(T).Name}.");
                throw;
            }
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.Set<T>().FindAsync(id);
                if (entity != null)
                {
                    _logger.LogInformation($"Retrieved {entity} record from {typeof(T).Name}.");
                    return entity;
                }
                else
                {
                    _logger.LogWarning($"Entity with ID: {id} was not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting record from {typeof(T).Name}.");
                throw;
            }
        }

        public async Task<T?> AddAsync(T entity)
        {
            var entityId = GetEntityId(entity);
            if (entityId == "N/A") return null;

            try
            {
                await _unitOfWork.BeginTransactionAsync();
                {
                    try
                    {
                        _logger.LogInformation($"Adding a new {typeof(T).Name}. Id: {entityId}");

                        var added = await _unitOfWork.Set<T>().AddAsync(entity);
                        if (added != null)
                        {
                            var result = await _unitOfWork.SaveChangesAsync();
                            if (result > 0)
                            {
                                _logger.LogInformation($"Added a new {typeof(T).Name}. Id: {entityId}");
                                await _unitOfWork.CommitAsync();
                                return added.Entity;
                            }
                            else
                            {
                                _logger.LogWarning($"Failed to save changes of {typeof(T).Name}. Id: {entityId}");
                                await _unitOfWork.RollbackAsync();
                                return null;
                            }
                        }
                        else
                        {
                            _logger.LogWarning($"Failed to add a new {typeof(T).Name}. Id: {entityId}");
                            await _unitOfWork.RollbackAsync();
                            return null;
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        await _unitOfWork.RollbackAsync();
                        _logger.LogError(ex, $"Error while updating the database with changes from {typeof(T).Name}.");
                        throw new Exception($"Error while updating the database with changes from {typeof(T).Name}.", ex);
                    }
                    catch (Exception ex)
                    {
                        await _unitOfWork.RollbackAsync();
                        _logger.LogError(ex, $"Error while adding a new {typeof(T).Name}. Id: {entityId}");
                        throw new Exception($"Error while adding new Entity :: ${ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error beginning transaction for {nameof(AddAsync)}.");
                throw;
            }
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            var entityId = GetEntityId(entity);
            if (entityId == "N/A") return null;

            try
            {
                await _unitOfWork.BeginTransactionAsync();
                try
                {
                    _logger.LogInformation($"Updating an existing {typeof(T).Name}. Id: {entityId}");

                    _unitOfWork.Entry(entity).State = EntityState.Modified;
                    var result = await _unitOfWork.SaveChangesAsync();

                    if (result > 0)
                    {
                        _logger.LogInformation($"Updated {typeof(T).Name}. Id: {entityId}");
                        await _unitOfWork.CommitAsync();
                        return await GetByIdAsync(Guid.Parse(entityId));
                    }
                    else
                    {
                        _logger.LogWarning($"Failed to save changes of {typeof(T).Name}. Id: {entityId}");
                        await _unitOfWork.RollbackAsync();
                        return null;
                    }
                }
                catch (DbUpdateException ex)
                {
                    await _unitOfWork.RollbackAsync();
                    _logger.LogError(ex, $"Error while updating the database with changes from {typeof(T).Name}.");
                    throw new Exception($"Error while updating the database with changes from {typeof(T).Name}.", ex);
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackAsync();
                    _logger.LogError(ex, $"Error while updating {typeof(T).Name}. Id: {entityId}");
                    throw new Exception($"Error while updating entity :: ${ex.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error beginning transaction for {nameof(UpdateAsync)}.");
                throw;
            }
        }

        public async Task<T?> RemoveAsync(T entity)
        {
            var entityId = GetEntityId(entity);
            if (entityId == "N/A") return null;

            try
            {
                await _unitOfWork.BeginTransactionAsync();
                try
                {
                    var target = await GetByIdAsync(Guid.Parse(entityId));
                    if (target == null)
                    {
                        _logger.LogWarning($"Failed to remove {typeof(T).Name}. Entity was not found with Id: {entityId}");
                        await _unitOfWork.RollbackAsync();
                        return null;
                    }

                    _unitOfWork.Set<T>().Remove(entity);
                    var result = await _unitOfWork.SaveChangesAsync();

                    if (result > 0)
                    {
                        _logger.LogInformation($"Removed {typeof(T).Name}. Id: {GetEntityId(entity)}");
                        await _unitOfWork.CommitAsync();
                        return entity;
                    }
                    else
                    {
                        _logger.LogWarning($"Failed to remove {typeof(T).Name}. Id: {GetEntityId(entity)}");
                        await _unitOfWork.RollbackAsync();
                        return null;
                    }
                }
                catch (DbUpdateException ex)
                {
                    await _unitOfWork.RollbackAsync();
                    _logger.LogError(ex, $"Error while updating the database with changes from {typeof(T).Name}.");
                    throw new Exception($"Error while updating the database with changes from {typeof(T).Name}.", ex);
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackAsync();
                    _logger.LogError(ex, $"Error while deleting {typeof(T).Name}. Id: {entityId}");
                    throw new Exception($"Error while deleting entity :: ${ex.Message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error beginning transaction for {nameof(RemoveAsync)}.");
                throw;
            }
        }

        private static string GetEntityId(T entity)
        {
            var idProperty = entity.GetType().GetProperty("Id");
            return idProperty?.GetValue(entity)?.ToString() ?? "N/A";
        }
    }
}