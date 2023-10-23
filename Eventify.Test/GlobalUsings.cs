global using Xunit;
global using Moq;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.EntityFrameworkCore;

// Domain Dependencies
global using Eventify.Domain.Attributes;
global using Eventify.Domain.Entities;
global using Eventify.Domain.IRepositories;
global using Eventify.Domain.IRepositories.Base;
global using Eventify.Domain.ValueObjects;

// Infrastructure Dependencies
global using Eventify.Infrastructure.Data;
global using Eventify.Infrastructure.UnitOfWork;