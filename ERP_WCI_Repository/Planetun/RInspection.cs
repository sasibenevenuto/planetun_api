using ERP_WCI_Context;
using ERP_WCI_Model.Identity;
using ERP_WCI_Model.Planetun;
using ERP_WCI_Repository.Identity.Interfaces;
using ERP_WCI_Repository.Planetun.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Repository.Planetun
{

    public class RInspection : Repository<Inspection>, IRInspection
    {
        public RInspection(Context context) : base(context)
        {

        }

        public async Task<int> AddInspectionAsync(Inspection Inspection)
        {
            try
            {
                return await AddAsync(Inspection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Inspection> GetInspectionbyIdAsync(int InspectionId)
        {
            try
            {
                return (await GetListAllAsync(x => x.InspectionId == InspectionId)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteInspectionAsync(int InspectionId)
        {
            try
            {
                await DeleteAsync(x => x.InspectionId == InspectionId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Inspection> UpdateInspectionAsync(Inspection Inspection)
        {
            try
            {
                return await UpdateAsync(Inspection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Inspection>> GetListAllAsync(string defaultFilter)
        {
            try
            {
                if (string.IsNullOrEmpty(defaultFilter))
                    return (await GetListAllAsync(x => true)).ToList();
                else
                    return (await GetListAllAsync(x => x.InspectionNumber.Contains(defaultFilter))).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
