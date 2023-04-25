using ERP_WCI_Model.Common;
using ERP_WCI_Model.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Common.Interfaces
{
    public interface IRPersonalInformation : IRepository<PersonalInformation>
    {
        Task<List<PersonalInformation>> GetListPersonalInformationPaginationOrderByIncludeAsync(BasePagination pagination);
        Task<PersonalInformation> GetPersonalInformationbyIdAsync(int personalINformationId);
        Task<int> AddPersonalInformationAsync(PersonalInformation personalInformation);
        Task<int> GetListPersonalInformationCountAsync(BasePagination pagination);
        Task<bool> DeletePersonalInformationAsync(int personalInformationId);
        Task<PersonalInformation> UpdatePersonalInformationAsync(PersonalInformation personalInformation);
    }
}
