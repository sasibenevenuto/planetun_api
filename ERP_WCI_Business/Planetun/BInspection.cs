using ERP_WCI_Business.Planetun.Interfaces;
using ERP_WCI_Model.Planetun;
using ERP_WCI_Repository.Planetun.Interfaces;
using ERP_WCI_ViewModel.Commands.Planetun;
using ERP_WCI_ViewModel.General;
using ERP_WCI_ViewModel.Planetun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_WCI_Business.Planetun
{
    public class BInspection : IBInspection
    {
        private readonly IRInspection _rInspection;        

        public BInspection(IRInspection rInspection)
        {
            _rInspection = rInspection;
        }

        public async Task<BaseReturnCrudViewModel> AddInspectionAsync(CommandAddInspection commandAddInspection)
        {
            var InspectionId = await _rInspection.AddInspectionAsync(new Inspection()
            {
                CompanyId = commandAddInspection.CompanyId,
                BrokerCode = commandAddInspection.BrokerCode,
                ProductCode = commandAddInspection.ProductCode,
                ProductName = commandAddInspection.ProductName,
                InspectionNumber = commandAddInspection.InspectionNumber
            });

            return new BaseReturnCrudViewModel() { ReturnValue = InspectionId, ReturnMessage = "Inspeção gravada com sucesso" };
        }

        public async Task<BaseReturnCrudViewModel> DeleteInspectionAsync(int InspectionId)
        {
            var inspection = await _rInspection.GetInspectionbyIdAsync(InspectionId);

            if (inspection != null)
            {
                return new BaseReturnCrudViewModel() { Status = System.Net.HttpStatusCode.NoContent,ReturnMessage = "Inspeção não encontrada!" };
            }

            var deleteRerturn = await _rInspection.DeleteInspectionAsync(InspectionId);

            return new BaseReturnCrudViewModel() { ReturnValue = deleteRerturn, ReturnMessage = "Inspeção apagadas com sucesso!" };
        }

        public async Task<BaseReturnApiViewModel<InspectionViewModel>> GetListInspectionAllAsync(string defaultFilter)
        {
            var inspections = new List<InspectionViewModel>();
            (await _rInspection.GetListAllAsync(defaultFilter)).ForEach(c => inspections.Add(c));

            return new BaseReturnApiViewModel<InspectionViewModel>()
            {
                ListData = inspections
            };
        }

        public async Task<BaseReturnApiViewModel<InspectionViewModel>> GetInspectionByIdAsync(int InspectionId)
        {
            var inspection = await _rInspection.GetInspectionbyIdAsync(InspectionId);

            return new BaseReturnApiViewModel<InspectionViewModel>() { Data = inspection };
        }

        public async Task<BaseReturnCrudViewModel> UpdateInspectionAsync(CommandUpdateInspection commandUpdateInspection)
        {
            var InspectionId = await _rInspection.UpdateInspectionAsync(new Inspection()
            {
                InspectionId = commandUpdateInspection.InspectionId,
                CompanyId = commandUpdateInspection.CompanyId,
                BrokerCode = commandUpdateInspection.BrokerCode,
                ProductCode = commandUpdateInspection.ProductCode,
                ProductName = commandUpdateInspection.ProductName,
                InspectionNumber = commandUpdateInspection.InspectionNumber
            });

            return new BaseReturnCrudViewModel() { ReturnValue = InspectionId, ReturnMessage = "Inspeção alterada com sucesso" };
        }
    }
}
