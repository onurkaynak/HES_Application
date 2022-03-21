namespace CovidApp
{
    public class NotifyService : INotifyService
    {
        private readonly INotifyRepository _notifyrepository;
        public NotifyService(INotifyRepository notifyRepository)
        {
            _notifyrepository = notifyRepository;
        }

        private readonly IViolationTypeRepository _violationTyperepository;
        public NotifyService(IViolationTypeRepository violationTyperepository)
        {
            _violationTyperepository = violationTyperepository;
        }
        async Task<NotifyDTO> INotifyService.CreateNotify(Notify notify)
        {
            try
            {
                Notify Notify = await _notifyrepository.GetNotifyById(notify.Id);
                if (notify == null)
                {
                    return new NotifyDTO(await _notifyrepository.CreateNotify(notify));
                }
                return new NotifyDTO();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async Task<NotifyDTO> INotifyService.DeleteNotifyById(int id)
        {
            try
            {
                Notify Notify = await _notifyrepository.GetNotifyById(id);
                if (Notify != null)
                {
                    return new NotifyDTO(await _notifyrepository.DeleteNotifyById(id));
                }
                return new NotifyDTO();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async Task<IEnumerable<NotifyDTO>> INotifyService.GetAllNotifies()
        {
            try
            {
                IEnumerable<NotifyDTO> notifyDTOs = NotifyToNotifyDTO(await _notifyrepository.GetAllNotifies());
                if (notifyDTOs != null)
                {
                    return notifyDTOs;
                }
                return new List<NotifyDTO> { new NotifyDTO() };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        async Task<IEnumerable<NotifyDTO>> INotifyService.GetNotifiesByAddressId(int addressId)
        {
            try
            {
                IEnumerable<NotifyDTO> notifyDTOs = NotifyToNotifyDTO(await _notifyrepository.GetNotifiesByAddressId(addressId));
                if (notifyDTOs != null)
                {
                    return notifyDTOs;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async Task<IEnumerable<NotifyDTO>> INotifyService.GetNotifiesByCityId(int cityId)
        {
            try
            {
                IEnumerable<NotifyDTO> notifyDTOs = NotifyToNotifyDTO(await _notifyrepository.GetNotifiesByCityId(cityId));
                if (notifyDTOs != null)
                {
                    return notifyDTOs;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async Task<IEnumerable<NotifyDTO>> INotifyService.GetNotifiesByDistrictId(int districtId)
        {
            try
            {
                IEnumerable<NotifyDTO> notifyDTOs = NotifyToNotifyDTO(await _notifyrepository.GetNotifiesByDistrictId(districtId));
                if (notifyDTOs != null)
                {
                    return notifyDTOs;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async Task<IEnumerable<NotifyDTO>> INotifyService.GetNotifiesByUserId(int userId)
        {
            try
            {
                IEnumerable<NotifyDTO> notifyDTOs = NotifyToNotifyDTO(await _notifyrepository.GetNotifiesByUserId(userId));
                if (notifyDTOs != null)
                {
                    return notifyDTOs;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async Task<IEnumerable<NotifyDTO>> INotifyService.GetNotifiesByViolationSubject(ViolationSubject violationSubject)
        {
            try
            {
                IEnumerable<NotifyDTO> notifyDTOs = NotifyToNotifyDTO(await _notifyrepository.GetNotifiesByViolationSubject(violationSubject));
                if (notifyDTOs != null)
                {
                    return notifyDTOs;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async Task<NotifyDTO> INotifyService.GetNotifyById(int id)
        {
            try
            {
                NotifyDTO notifyDTO = new NotifyDTO(await _notifyrepository.GetNotifyById(id));
                if (notifyDTO != null)
                {
                    return notifyDTO;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async Task<NotifyDTO> INotifyService.GetNotifyByViolationTypeId(int violationTypeId)
        {
            try
            {
                NotifyDTO notifyDTO = new NotifyDTO(await _notifyrepository.GetNotifyByViolationTypeId(violationTypeId));
                if (notifyDTO != null)
                {
                    return notifyDTO;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async Task<NotifyDTO> INotifyService.UpdateNotifyById(Notify notify)
        {
            try
            {
                NotifyDTO notifyDTO = new NotifyDTO(await _notifyrepository.GetNotifyById(notify.Id));
                if (notifyDTO != null)
                {
                    return new NotifyDTO(await _notifyrepository.UpdateNotifyById(notify));
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<NotifyDTO> NotifyToNotifyDTO(IEnumerable<Notify> notifies)
        {   
            List<NotifyDTO> notifyDTOs = new List<NotifyDTO>();
            foreach (Notify item in notifies)
            {
                notifyDTOs.Add(new NotifyDTO(item));
            }
            return notifyDTOs;
        }

                 /////// violation type ////////////
        async public Task<IEnumerable<ViolationType>> GetAllViolationType()
        {
            try
            {
                IEnumerable<ViolationType> ViolationTypes = (await _violationTyperepository.GetAllViolationType());
                if (ViolationTypes != null)
                {
                    return ViolationTypes;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        async public Task<ViolationType> GetViolationTypeById(int id)
        {
            try
            {
                ViolationType ViolationType = (await _violationTyperepository.GetViolationTypeById(id));
                if (ViolationType != null)
                {
                    return ViolationType;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async public Task<ViolationType> CreateViolationType(ViolationType violationType)
        {
            try
            {
                ViolationType ViolationType = await _violationTyperepository.GetViolationTypeById(violationType.Id);
                if (ViolationType == null)
                {
                    return (await _violationTyperepository.CreateViolationType(violationType));
                }
                return new ViolationType();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async public Task<ViolationType> UpdateViolationTypeById(ViolationType violationType)
        {
            try
            {
                ViolationType ViolationType =(await _violationTyperepository.GetViolationTypeById(violationType.Id));
                if (ViolationType != null)
                {
                    return (await _violationTyperepository.UpdateViolationTypeById(violationType));
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        async public Task<ViolationType> DeleteViolationTypeById(int id)
        {
            try
            {
                ViolationType ViolationType = await _violationTyperepository.GetViolationTypeById(id);
                if (ViolationType != null)
                {
                    return (await _violationTyperepository.DeleteViolationTypeById(id));
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

}