using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Appliation.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }



        // handler for getting the list of activities and return them
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            
            public Handler(DataContext context)
            {
                
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request,
                CancellationToken cancellationToken)
            {

                

                // get the list of activities and return them
                var activities = await _context.Activities.ToListAsync();

                return activities;
            }
        }
    }
}