using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Repositories;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Application.Internal.CommandServices
{
    public class MultimediaCommandService(IMultimediaRepository multimediaRepository,
        IUnitOfWork unitOfWork) : IMultimediaCommandService
    {
        public async Task<Multimedia?> Handle(CreateMultimediaCommand command)
        {
            var entity = new Multimedia(command);

            await multimediaRepository.AddAsync(entity);

            await unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<Multimedia?> Handle(UpdateMultimediaCommand command)
        {
            var entity = await multimediaRepository.FindByIdAsync(command.Id) ?? throw new Exception("The given ID is not valid.");
            
            entity!.UpdateData(command);

            multimediaRepository.Update(entity);

            await unitOfWork.CommitAsync();

            return entity;
        }
    }
}
