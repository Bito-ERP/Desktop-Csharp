using BitoDesktop.Domain.Entities.Settings;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings
{
    public class CashbackSettingsResponse
    {

        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("cashbacks")]
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
            [JsonProperty("cashback_type")]
            public string Type { get; set; }

            [JsonProperty("min_amount")]
            public double MinAmount { get; set; }

            [JsonProperty("amount")]
            public double Amount { get; set; }

            [JsonProperty("currency_id")]
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
