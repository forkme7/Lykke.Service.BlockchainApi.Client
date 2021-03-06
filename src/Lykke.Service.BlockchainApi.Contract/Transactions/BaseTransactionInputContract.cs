﻿using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Lykke.Service.BlockchainApi.Contract.Transactions
{
    /// <summary>
    /// Base class for transaction input
    /// </summary>
    [PublicAPI]
    public abstract class BaseTransactionInputContract
    {
        /// <summary>
        /// Source address
        /// </summary>
        [JsonProperty("fromAddress")]
        public string FromAddress { get; set; }

        /// <summary>
        /// Amount to transfer from the <see cref="FromAddress"/> or actual amount, 
        /// which is transferred from the <see cref="FromAddress"/>, depending on the context.
        /// Integer as string, aligned 
        /// to the asset accuracy. Actual value can be 
        /// writen using <see cref="Conversions.CoinsToContract"/>
        /// and can be read using <see cref="Conversions.CoinsFromContract"/>
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }
    }
}
