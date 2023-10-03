using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings
{
    internal class SaleSettingsResponse
    {
        [JsonProperty("calc_tax_after_discount")]
        public bool CalcTaxAfterDiscount { get; set; }

        [JsonProperty("calc_sale_discount_after_product")]
        public bool CalcSaleDiscountAfterProducts { get; set; }

        [JsonProperty("sell_product_in_negative")]
        public bool SellingOutOfStock { get; set; }

        [JsonProperty("is_cashback_active")]
        public bool IsCashbackActive { get; set; }

        [JsonProperty("is_tax_active")]
        public bool IsTaxActive { get; set; }

        [JsonProperty("debt_approve_by_boss")]
        public bool DebtApproveByBoss { get; set; }

        [JsonProperty("on_revision")]
        public string OnRevision { get; set; }

        [JsonProperty("show_weight")]
        public bool ShowWeight { get; set; } = true;
    }
}
