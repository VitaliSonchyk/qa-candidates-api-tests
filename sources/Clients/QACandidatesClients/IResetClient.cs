using Clients.Contracts.Common;
using Clients.Contracts.Orders;
using Core.Common.Refit;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.QACandidatesClients
{
    public interface IResetClient : IRefitClient
    {
        [Post("/ENSEK/reset")]
        Task<ResponseMessageModel> PostAsync();
    }
}
