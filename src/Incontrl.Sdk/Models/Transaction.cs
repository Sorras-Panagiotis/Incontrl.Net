﻿using System;

namespace Incontrl.Sdk.Models
{
    public class Transaction
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Usually this is the transaction UID <see cref="Guid.ToByteArray()"/>.
        /// if not available it stores an hash generated by the transaction properties so that it is considered unique.
        /// </summary>
        public string UniqueId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TransactionType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Completed { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public Money Value { get; set; }
        public Money Balance { get; set; }
        public Guid? BatchId { get; set; }
    }
}
