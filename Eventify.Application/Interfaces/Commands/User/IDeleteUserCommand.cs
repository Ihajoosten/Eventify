using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Application.Interfaces.Commands.User
{
    public interface IDeleteUserCommand : IUserCommand
    {
        public Guid Id { get; set; }
    }
}
