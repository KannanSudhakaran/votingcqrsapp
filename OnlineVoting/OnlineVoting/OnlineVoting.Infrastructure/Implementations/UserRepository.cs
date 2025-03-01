﻿using OnlineVoting.Domain.Entities;
using OnlineVoting.Domain.UseCases;
using OnlineVoting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Implementations
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(VotingContext context) : base(context)
        {
        }
    }
}
