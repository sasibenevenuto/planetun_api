using ERP_WCI_Model.General;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Commands
{
    public class CommandPagination
    {
        public int TotalPage { get; set; } = 1;
        public int PageSkip { get; set; } = 0;
        public int PageTake { get; set; } = 10;
        public string DefaultFilter { get; set; } = "";

        public static implicit operator BasePagination(CommandPagination viewModel)
        {
            return new BasePagination()
            {
                TotalPage = viewModel.TotalPage,
                PageSkip = viewModel.PageSkip,
                PageTake = viewModel.PageTake,
                DefaultFilter = viewModel.DefaultFilter
            };
        }
    }
}
