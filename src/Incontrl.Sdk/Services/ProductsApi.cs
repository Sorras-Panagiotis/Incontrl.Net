﻿using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class ProductsApi : IProductsApi
    {
        private readonly ClientBase _clientBase;

        public ProductsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Product> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PostAsync<CreateProductRequest, Product>($"subscriptions/{SubscriptionId}/products", request, cancellationToken);

        public Task<ResultSet<Product>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<ResultSet<Product>>($"subscriptions/{SubscriptionId}/products", options, cancellationToken);
    }
}