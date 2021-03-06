using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;
using Domain;



namespace Application._PageTag
{
    public class Edit
    {
        public class Command : IRequest<PageTagDto>
        {            
            
		public Guid Id { get; set; }
		public string label { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.label).NotEmpty();
				
            }

            private object RRuleFor(Func<object, object> p)
            {
                throw new NotImplementedException();
            }
        }

        public class Handler : IRequestHandler<Command, PageTagDto>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<PageTagDto> Handle(Command request, CancellationToken cancellationToken)
            {
                //var test = request.test;

                var pageTag = await _context.PageTags
                    .FindAsync(request.Id);
                if (pageTag == null)
                    throw new RestException(HttpStatusCode.NotFound, new { PageTag = "Not found" });

				pageTag.label  = request.label ?? pageTag.label;
				
				
				// _context.Entry(cl).State = EntityState.Modified;  //.Entry(user).State = EntityState.Added; /
				var success = await _context.SaveChangesAsync() > 0;                   
				//if (success) return Unit.Value;
				if (success)
				{
					var toReturn = _mapper.Map<PageTag, PageTagDto>(pageTag);
					return toReturn;
				}


                throw new Exception("Problem saving changes");
            }
        }

    }
}
