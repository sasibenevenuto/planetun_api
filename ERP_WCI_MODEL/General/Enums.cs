using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.General
{
    public enum ETypeAccount
    {
        Adminstrator = 1,
        Support = 2,
        Accountant = 3,
        MasterClient = 4,
        UserClient = 5
    }

    public enum EEnvironment
    {
        Select = 0,
        Production = 1,
        homologation = 2
    }

    public enum TypePhone
    {
        HomePhone = 1,
        BusinessPhone = 2,
        ErrandsCell = 3,
        Other = 4
    }
}
