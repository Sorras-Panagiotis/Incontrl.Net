﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class InvoiceApi : IInvoiceApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IInvoiceDocumentApi> _invoiceDocumentApi;
        private readonly Lazy<IInvoiceStatusApi> _invoiceStatusApi;
        private readonly Lazy<IInvoiceTrackingApi> _invoiceTrackingApi;
        private readonly Lazy<IInvoiceInvoiceTypeApi> _invoiceInvoiceTypeApi;

        public InvoiceApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _invoiceDocumentApi = new Lazy<IInvoiceDocumentApi>(() => new InvoiceDocumentApi(_clientBase));
            _invoiceStatusApi = new Lazy<IInvoiceStatusApi>(() => new InvoiceStatusApi(_clientBase));
            _invoiceTrackingApi = new Lazy<IInvoiceTrackingApi>(() => new InvoiceTrackingApi(_clientBase));
            _invoiceInvoiceTypeApi = new Lazy<IInvoiceInvoiceTypeApi>(() => new InvoiceInvoiceTypeApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string InvoiceId { get; set; }

        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.DeleteAsync($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}", cancellationToken);

        public async Task<Invoice> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Invoice>($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}", cancellationToken);

        public IInvoiceDocumentApi As(InvoiceFormat format) {
            var invoiceDocumentApi = _invoiceDocumentApi.Value;
            invoiceDocumentApi.SubscriptionId = SubscriptionId;
            invoiceDocumentApi.InvoiceId = InvoiceId;
            invoiceDocumentApi.Format = format;

            return invoiceDocumentApi;
        }

        public async Task<Invoice> UpdateAsync(UpdateInvoiceRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateInvoiceRequest, Invoice>($"subscriptions/{SubscriptionId}/invoices/{InvoiceId}", request, cancellationToken);

        public IInvoiceStatusApi Status() {
            var invoiceStatusApi = _invoiceStatusApi.Value;
            invoiceStatusApi.SubscriptionId = SubscriptionId;
            invoiceStatusApi.InvoiceId = InvoiceId;

            return invoiceStatusApi;
        }

        public IInvoiceTrackingApi Trackings() {
            var invoiceTrackingApi = _invoiceTrackingApi.Value;
            invoiceTrackingApi.SubscriptionId = SubscriptionId;
            invoiceTrackingApi.InvoiceId = InvoiceId;

            return invoiceTrackingApi;
        }

        public IInvoiceInvoiceTypeApi Type() {
            var invoiceInvoiceTypeApi = _invoiceInvoiceTypeApi.Value;
            invoiceInvoiceTypeApi.SubscriptionId = SubscriptionId;
            invoiceInvoiceTypeApi.InvoiceId = InvoiceId;

            return invoiceInvoiceTypeApi;
        }
    }
}
