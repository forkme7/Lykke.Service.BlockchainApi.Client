﻿using System;
using JetBrains.Annotations;
using Lykke.Service.BlockchainApi.Contract;
using Lykke.Service.BlockchainApi.Contract.Transactions;

namespace Lykke.Service.BlockchainApi.Client.Models
{
    /// <summary>
    /// Building transaction output
    /// </summary>
    [PublicAPI]
    public class BuildingTransactionOutput
    {
        /// <summary>
        /// Destination address
        /// </summary>
        public string ToAddress { get; }

        /// <summary>
        /// Amount to transfer from the <see cref="ToAddress"/> or actual amount, 
        /// which is transferred from the <see cref="ToAddress"/>, depending on the context.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Building transaction output
        /// </summary>
        public BuildingTransactionOutput(string toAddress, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(ToAddress))
            {
                throw new ArgumentException(nameof(toAddress), "Destination address is required");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Amount should be positive number");
            }

            ToAddress = toAddress;
            Amount = amount;
        }

        /// <summary>
        /// Converts transaction output to the contract DTO
        /// </summary>
        /// <param name="assetAccuracy"></param>
        /// <returns></returns>
        public BuildingTransactionOutputContract ToContract(int assetAccuracy)
        {
            return new BuildingTransactionOutputContract
            {
                ToAddress = ToAddress,
                Amount = Conversions.CoinsToContract(Amount, assetAccuracy)
            };
        }
    }
}
