using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.General
{
    public class Settings
    {   
        public string Secret { get; set; }
        public string Public { get; set; }
        public string PublicMessage { get; set; }
        public string TokenIntranet { get; set; }
        public string LinkIntranet { get; set; }
        public EmailSettings EmailSettings { get; set; }
    }

    public class EmailSettings
    {
        public string EmailRemetente { get; set; }
        public string EnderecoServidor { get; set; }
        public int PortaServidor { get; set; }
        public bool UtilizarRelacaoConfianca { get; set; }
        public string Usuario { get; set; }
        public string SenhaCriptografada { get; set; }
        public bool HabilitarSSL { get; set; }        

    }
}
