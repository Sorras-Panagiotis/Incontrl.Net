﻿using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class OrganisationApi : IOrganisationApi
    {
        private readonly ClientBase _clientBase;

        public OrganisationApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string OrganisationId { get; set; }

        public Task<Organisation> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<Organisation>($"subscriptions/{SubscriptionId}/organisations/{OrganisationId}", cancellationToken);

        public Task<Organisation> UpdateAsync(UpdateOrganisationRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PutAsync<UpdateOrganisationRequest, Organisation>($"subscriptions/{SubscriptionId}/organisations/{OrganisationId}", request, cancellationToken);
    }
}
