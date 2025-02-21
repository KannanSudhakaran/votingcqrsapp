using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineVoting.Application.Commands.Command;
using OnlineVoting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Commands.CommandHandlers
{
    public class LockVoterCommandHandler : IRequestHandler<LockVoterCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public LockVoterCommandHandler(UserManager<ApplicationUser> user)
        {
            _userManager = user;
        }

        public async Task<bool> Handle(LockVoterCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return false; // User not found
            }

            if (request.Lock)
            {
                // Lock the user by setting a lockout end date far in the future
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddYears(100));
            }
            else
            {
                // Unlock the user by setting the lockout end date to null
                await _userManager.SetLockoutEndDateAsync(user, null);
            }

            return true;

        }
    }
}
