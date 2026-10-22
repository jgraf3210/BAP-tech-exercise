using MediatR;
using StargateAPI.Business.Data;
using StargateAPI.Controllers;

namespace StargateAPI.Business.Commands
{
    public class CreateLogMessage : IRequest<CreateLogMessageResult>
    {
        public required string Message { get; set; } = string.Empty;
        public required bool IsError { get; set; }
        public required int? ErrorCode { get; set; } = null;
    }

    public class CreateLogMessageHandler : IRequestHandler<CreateLogMessage, CreateLogMessageResult>
    {
        private readonly StargateContext _context;

        public CreateLogMessageHandler(StargateContext context)
        {
            _context = context;
        }
        public async Task<CreateLogMessageResult> Handle(CreateLogMessage request, CancellationToken cancellationToken)
        {
            var newLogMessage = new Log()
            {
                Message = request.Message,
                IsError = request.IsError,
                ErrorCode = request.ErrorCode
            };

            await _context.Logs.AddAsync(newLogMessage, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new CreateLogMessageResult()
            {
                Id = newLogMessage.Id
            };
          
        }
    }

    public class CreateLogMessageResult : BaseResponse
    {
        public int Id { get; set; }
    }
}
