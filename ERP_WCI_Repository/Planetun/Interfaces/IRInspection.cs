using ERP_WCI_Model.Identity;
using ERP_WCI_Model.Planetun;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Planetun.Interfaces
{
    public interface IRInspection
    {
        Task<int> AddInspectionAsync(Inspection Inspection);
        Task<Inspection> GetInspectionbyIdAsync(int InspectionId);
        Task<bool> DeleteInspectionAsync(int InspectionId);
        Task<Inspection> UpdateInspectionAsync(Inspection Inspection);
        Task<List<Inspection>> GetListAllAsync(string defaultFilter);
    }
}
