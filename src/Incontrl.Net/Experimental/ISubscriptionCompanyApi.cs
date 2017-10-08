﻿using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Experimental
{
    public interface ISubscriptionCompanyApi
    {
        string SubscriptionId { get; set; }
        Task<JsonResponse<Organisation>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Organisation>> UpdateAsync(UpdateCompanyRequest company, CancellationToken cancellationToken = default(CancellationToken));
    }
}
