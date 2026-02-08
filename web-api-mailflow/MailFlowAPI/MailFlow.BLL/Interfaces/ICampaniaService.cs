using MailFlow.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.Interfaces
{
    public interface ICampaniaService
    {
        Task StartCampaign(string campaignId);
        Task<CampaniaResponse> RegisterAsync(CampaniaRegistroRequest request);

    }
}
