using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistence;
using Application.Errors;
using System.Net;
using Application.Todo;
using AutoMapper;
using Domain;

namespace Application.ToDos
{ 
    public class Edit
    {
        public class Command : IRequest<ToDoDto>
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Title).NotEmpty();            
            }
        }


        public class Handler : IRequestHandler<Command, ToDoDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                 _mapper = mapper;
            }

            public async Task<ToDoDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var todo = await _context.Todos.FindAsync(request.Id);    

                if (todo == null)
                    throw new RestException(HttpStatusCode.NotFound, new { ToDo = "Not Found" });

                todo.Title = request.Title ?? todo.Title;            
                        

                var success = await _context.SaveChangesAsync() > 0;

                //if (success) return Unit.Value;
                if (success){
                    return _mapper.Map <ToDo, ToDoDto>(todo);                               
                } 

                throw new Exception("Problem saving changes");
            }
        }
    }
}