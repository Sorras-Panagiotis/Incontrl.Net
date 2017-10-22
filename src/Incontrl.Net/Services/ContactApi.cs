﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class ContactApi : IContactApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IContactCompaniesApi> _contactCompaniesApi;

        public ContactApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _contactCompaniesApi = new Lazy<IContactCompaniesApi>(() => new ContactCompaniesApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string ContactId { get; set; }

        public IContactCompaniesApi Companies() {
            var contactCompaniesApi = _contactCompaniesApi.Value;
            contactCompaniesApi.SubscriptionId = SubscriptionId;
            contactCompaniesApi.ContactId = ContactId;

            return contactCompaniesApi;
        }

        public Task<Contact> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<Contact>($"subscriptions/{SubscriptionId}/contacts/{ContactId}", cancellationToken);

        public Task<Contact> UpdateAsync(UpdateContactRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<UpdateContactRequest, Contact>($"subscriptions/{SubscriptionId}/contacts/{ContactId}", request, cancellationToken);
    }
}
