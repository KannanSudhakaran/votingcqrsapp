using MediatR;
using OnlineVoting.Application.Queries.Query;
using OnlineVoting.Domain.Entities;
using OnlineVoting.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.Queries.QueryHandlers
{
    public class GetVoteGroupByIdQueryHandler : IRequestHandler<GetVoteGroupByIdQuery, VoteGroup>
    {
       private readonly IUnitOfWork _unitOfWork;

        public GetVoteGroupByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async  Task<VoteGroup> Handle(GetVoteGroupByIdQuery request, CancellationToken cancellationToken)
        {
            return await  Task.Run(() =>
          
                  _unitOfWork.VoteGroups.GetByIdAsync(g=>g.Id==request.GroupId)
            );
        }
    }
}
