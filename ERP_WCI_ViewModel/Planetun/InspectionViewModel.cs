using ERP_WCI_Model.Planetun;
using ERP_WCI_ViewModel.General;

namespace ERP_WCI_ViewModel.Planetun
{
    public class InspectionViewModel : BaseViewModel
    {
        public int InspectionId { get; set; }
        public int CompanyId { get; set; }
        public string BrokerCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string InspectionNumber { get; set; }

        public static implicit operator InspectionViewModel(Inspection model)
        {
            return new InspectionViewModel
            {
                InspectionId = model.InspectionId,
                CompanyId = model.CompanyId,
                BrokerCode = model.BrokerCode,
                ProductCode = model.ProductCode,
                ProductName = model.ProductName,
                InspectionNumber = model.InspectionNumber
            };
        }
    }
}
