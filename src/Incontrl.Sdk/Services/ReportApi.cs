﻿using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class ReportApi : IReportApi
    {
        private readonly ClientBase _clientBase;

        public ReportApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Report> UpsertAsync(ReportType type, ReportingFrequency frequency, Document document, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<Document, Report>($"subscriptions/{SubscriptionId}/reports/types/{type}/frequencies/{frequency}", document, cancellationToken);
    }
}
