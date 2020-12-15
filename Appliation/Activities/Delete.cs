using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Appliation.Activities {
    public class Delete {
        public class Command : IRequest 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler <Command> 
        {
            private readonly DataContext _context;
            public Handler(DataContext context) 
            {
                _context = context;
            }

            // Unit is an empty object which we are going to be returning from this command
            public async Task <Unit> Handle(Command request, CancellationToken cancellationToken) 
            {
                var activity = await _context.Activities.FindAsync(request.Id);

                if (activity == null) 
                {
                    throw new Exception("Could not find Activity");
                }
                _context.Remove(activity);
                
                // if the saveasync returns greater than zero then it will consider successful (var success)
                var success = await _context.SaveChangesAsync() > 0;

                if (success) 
                {
                    return Unit.Value;
                }
                throw new Exception("Problem saving changes");
            }
        }
    }
}