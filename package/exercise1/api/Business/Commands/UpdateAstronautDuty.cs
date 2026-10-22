using Dapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Data;
using StargateAPI.Controllers;
using System.Net;

namespace StargateAPI.Business.Commands
{
    public class UpdateAstronautDuty : IRequest<UpdateAstronautDutyResult>
    {
        public required string Name { get; set; }

        public required string Rank { get; set; }

        public required string DutyTitle { get; set; }

        public DateTime DutyStartDate { get; set; }

        public DateTime? DutyEndDate { get; set; }
    }

    public class UpdateAstronautDutyPreProcessor : IRequestPreProcessor<UpdateAstronautDuty>
    {
        private readonly StargateContext _context;

        public UpdateAstronautDutyPreProcessor(StargateContext context)
        {
            _context = context;
        }

        public Task Process(UpdateAstronautDuty request, CancellationToken cancellationToken)
        {
            var person = _context.People
                .AsNoTracking()
                .FirstOrDefault(z => z.Name == request.Name);

            if (person is null){
                throw new BadHttpRequestException("Person does not exist", 400);
            }
            var verifyNoPreviousDuty = _context.AstronautDuties
                .FirstOrDefault(z => z.DutyTitle == request.DutyTitle 
                                && z.DutyStartDate == request.DutyStartDate);

            if (verifyNoPreviousDuty is null)
            {
                throw new BadHttpRequestException("Person does not have an assigned duty", 400);  
            } 

            return Task.CompletedTask;
        }
    }

    public class UpdateAstronautDutyHandler : IRequestHandler<UpdateAstronautDuty, UpdateAstronautDutyResult>
    {
        private readonly StargateContext _context;

        public UpdateAstronautDutyHandler(StargateContext context)
        {
            _context = context;
        }
        public async Task<UpdateAstronautDutyResult> Handle(UpdateAstronautDuty request, CancellationToken cancellationToken)
        {

            var query = $"SELECT * FROM [Person] WHERE \'{request.Name}\' = Name";

            var personId = await _context.Person
                .AsNoTracking()
                .FirstOrDefaultAsync(z => z.Name == request.Name, cancellationToken).Id;

            var astronautDetail = await _context.AstronautDetails
                .AsNoTracking()
                .FirstOrDefaultAsync(z => z.PersonId == personId, cancellationToken);

            if (astronautDetail == null)
            {
                astronautDetail = new AstronautDetail
                {
                    PersonId = personId,
                    CurrentDutyTitle = request.DutyTitle,
                    CurrentRank = request.Rank,
                    CareerStartDate = request.DutyStartDate.Date,
                    astronautDetail.CareerEndDate = request.DutyTitle.ToUpper() == "RETIRED" 
                                ? request.DutyStartDate.Date : null
                };

                await _context.AstronautDetails.AddAsync(astronautDetail);

            }
            else
            {
                astronautDetail.CurrentDutyTitle = request.DutyTitle;
                astronautDetail.CurrentRank = request.Rank;
                astronautDetail.CareerEndDate = request.DutyTitle.ToUpper() == "RETIRED" 
                                ? request.DutyStartDate.Date : null;
                _context.AstronautDetails.Update(astronautDetail);
            }

            var duty = await _context.AstronautDuties
                .AsNoTracking()
                .FirstOrDefaultAsync(z => z.PersonId == personId, cancellationToken)
                .OrderByDescending(z => z.DutyStartDate);

            if (duty != null)
            {
                duty.DutyEndDate = request.DutyStartDate.AddDays(-1).Date;
                _context.AstronautDuties.Update(duty);
            }

            var newAstronautDuty = new AstronautDuty()
            {
                PersonId = person.Id,
                Rank = request.Rank,
                DutyTitle = request.DutyTitle,
                DutyStartDate = request.DutyStartDate.Date,
                DutyEndDate = null
            };

            await _context.AstronautDuties.AddAsync(newAstronautDuty, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateAstronautDutyResult()
            {
                Id = newAstronautDuty.Id
            };
        }
    }

    public class UpdateAstronautDutyResult : BaseResponse
    {
        public int? Id { get; set; }
    }
}
