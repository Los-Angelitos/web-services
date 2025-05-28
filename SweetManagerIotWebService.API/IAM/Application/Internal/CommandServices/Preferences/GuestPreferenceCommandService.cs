using SweetManagerIotWebService.API.IAM.Domain.Model.Commands.Preferences;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Preferences;
using SweetManagerIotWebService.API.IAM.Domain.Repositories.Preferences;
using SweetManagerIotWebService.API.IAM.Domain.Services.CommandServices.Preferences;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.IAM.Application.Internal.CommandServices.Preferences
{
    public class GuestPreferenceCommandService(IGuestPreferenceRepository guestPreferenceRepository,
        IUnitOfWork unitOfWork) : IGuestPreferenceCommandService
    {
        public async Task<GuestPreference?> Handle(CreateGuestPreferenceCommand command)
        {
            try
            {
                var entity = new GuestPreference(command);

                await guestPreferenceRepository.AddAsync(entity);

                await unitOfWork.CommitAsync();

                return entity;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<GuestPreference?> Handle(UpdateGuestPreferenceCommand command)
        {
            try
            {
                var entity = await guestPreferenceRepository.FindByIdAsync(command.Id) ?? throw new Exception("The guest preference with the given id, doesn't exists.");
                entity.Update(command);

                guestPreferenceRepository.Update(entity);

                await unitOfWork.CommitAsync();

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
