using BitoDesktop.Domain.Entities.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Settings
{
    public class CashbackSettingsResponse
    {

        [JsonPropertyName("organization_id")]
        public string OrganizationId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("cashbacks")]
        public List<Cashback> Cashbacks { get; set; }

        public CashbackSetting Get()
        {
            return new CashbackSetting
            {
                OrganizationId = OrganizationId,
                Type = Type,
                IsActive = IsActive,
                Cashbacks = Cashbacks?.Select(c => c.Get())
            };
        }

        public class Cashback
        {
            [JsonPropertyName("cashback_type")]
            public string Type { get; set; }

            [JsonPropertyName("min_amount")]
            public double MinAmount { get; set; }

            [JsonPropertyName("amount")]
            public double Amount { get; set; }

            [JsonPropertyName("currency_id")]
            public string CurrencyId { get; set; }

            public CashbackSetting.Cashback Get()
            {
                return new CashbackSetting.Cashback
                {
                    Type = Type,
                    MinAmount = MinAmount,
                    Amount = Amount,
                    CurrencyId = CurrencyId
                };
            }
        }

    }
}
