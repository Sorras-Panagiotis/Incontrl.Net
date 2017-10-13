﻿using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class InvoiceInvoiceTypeApi : IInvoiceInvoiceTypeApi
    {
        private readonly ClientBase _clientBase;

        public InvoiceInvoiceTypeApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string InvoiceId { get; set; }

        public async Task<InvoiceType> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<InvoiceType>($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}/type", cancellationToken);

        public async Task<InvoiceType> UpdateAsync(UpdateInvoiceTypeRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateInvoiceTypeRequest, InvoiceType>($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}/type", request, cancellationToken);
    }
}
