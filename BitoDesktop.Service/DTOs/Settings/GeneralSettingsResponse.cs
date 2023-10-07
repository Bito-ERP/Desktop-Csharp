using System;
using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings
{
    public class GeneralSettingsResponse
    {
        [JsonProperty("isArchived")]
        public bool IsArchived { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("completelyDeleted")]
        public bool CompletelyDeleted { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("useDeliveryLocation")]
        public bool UseDeliveryLocation { get; set; }

        [JsonProperty("statistics")]
        public bool Statistics { get; set; }

        [JsonProperty("sales")]
        public bool Sales { get; set; }

        [JsonProperty("discount")]
        public bool Discount { get; set; }

        [JsonProperty("etiket")]
        public bool Etiket { get; set; }

        [JsonProperty("customerReturnReason")]
        public bool CustomerReturnReason { get; set; }

        [JsonProperty("saleRefund")]
        public bool SaleRefund { get; set; }

        [JsonProperty("installmentPlan")]
        public bool InstallmentPlan { get; set; }

        [JsonProperty("customers")]
        public bool Customers { get; set; }

        [JsonProperty("customer")]
        public bool Customer { get; set; }

        [JsonProperty("saleOrder")]
        public bool SaleOrder { get; set; }

        [JsonProperty("customerCategory")]
        public bool CustomerCategory { get; set; }

        [JsonProperty("supply")]
        public bool Supply { get; set; }

        [JsonProperty("purchaseRequest")]
        public bool PurchaseRequest { get; set; }

        [JsonProperty("purchaseOrder")]
        public bool PurchaseOrder { get; set; }

        [JsonProperty("purchase")]
        public bool Purchase { get; set; }

        [JsonProperty("purchaseReturn")]
        public bool PurchaseReturn { get; set; }

        [JsonProperty("supplier")]
        public bool Supplier { get; set; }

        [JsonProperty("supplierCategory")]
        public bool SupplierCategory { get; set; }

        [JsonProperty("purchaseReason")]
        public bool PurchaseReason { get; set; }

        [JsonProperty("supplierReturnReason")]
        public bool SupplierReturnReason { get; set; }

        [JsonProperty("warehouse")]
        public bool Warehouse { get; set; }

        [JsonProperty("income")]
        public bool Income { get; set; }

        [JsonProperty("inventorization")]
        public bool Inventorization { get; set; }

        [JsonProperty("writeOffReason")]
        public bool WriteOffReason { get; set; }

        [JsonProperty("writeOff")]
        public bool WriteOff { get; set; }

        [JsonProperty("material")]
        public bool Material { get; set; }

        [JsonProperty("semiProduct")]
        public bool SemiProduct { get; set; }

        [JsonProperty("productCategory")]
        public bool ProductCategory { get; set; }

        [JsonProperty("warehouseGet")]
        public bool WarehouseGet { get; set; }

        [JsonProperty("warehouseType")]
        public bool WarehouseType { get; set; }

        [JsonProperty("transferReason")]
        public bool TransferReason { get; set; }

        [JsonProperty("publicTransferRequest")]
        public bool publicTransferRequest { get; set; }

        [JsonProperty("publicTransfer")]
        public bool publicTransfer { get; set; }

        [JsonProperty("organizationalTransferRequest")]
        public bool OrganizationalTransferRequest { get; set; }

        [JsonProperty("organizationalTransfer")]
        public bool OrganizationalTransfer { get; set; }

        [JsonProperty("productStock")]
        public bool ProductStock { get; set; }

        [JsonProperty("statisticsProductAmount")]
        public bool StatisticsProductAmount { get; set; }

        [JsonProperty("statisticsProductCost")]
        public bool StatisticsProductCost { get; set; }

        [JsonProperty("statisticsProductIncome")]
        public bool StatisticsProductIncome { get; set; }

        [JsonProperty("finance")]
        public bool Finance { get; set; }

        [JsonProperty("cashbox")]
        public bool Cashbox { get; set; }

        [JsonProperty("transactions")]
        public bool Transactions { get; set; }

        [JsonProperty("invoice")]
        public bool Invoice { get; set; }

        [JsonProperty("customerBalanceUpdate")]
        public bool CustomerBalanceUpdate { get; set; }

        [JsonProperty("supplierBalanceUpdate")]
        public bool SupplierBalanceUpdate { get; set; }

        [JsonProperty("employeeBalanceUpdate")]
        public bool EmployeeBalanceUpdate { get; set; }

        [JsonProperty("cashboxBalanceUpdate")]
        public bool CashboxBalanceUpdate { get; set; }

        [JsonProperty("currency")]
        public bool Currency { get; set; }

        [JsonProperty("tax")]
        public bool Tax { get; set; }

        [JsonProperty("paymentType")]
        public bool PaymentType { get; set; }

        [JsonProperty("extraCost")]
        public bool ExtraCost { get; set; }

        [JsonProperty("contract")]
        public bool Contract { get; set; }

        [JsonProperty("customerBalance")]
        public bool CustomerBalance { get; set; }

        [JsonProperty("employeeBalance")]
        public bool EmployeeBalance { get; set; }

        [JsonProperty("supplierBalance")]
        public bool SupplierBalance { get; set; }

        [JsonProperty("personBalance")]
        public bool PersonBalance { get; set; }

        [JsonProperty("statisticsCostByCategory")]
        public bool StatisticsCostByCategory { get; set; }

        [JsonProperty("statisticsBalance")]
        public bool StatisticsBalance { get; set; }

        [JsonProperty("statisticsCashflow")]
        public bool StatisticsCashflow { get; set; }

        [JsonProperty("hr")]
        public bool Hr { get; set; }

        [JsonProperty("employee")]
        public bool Employee { get; set; }

        [JsonProperty("section")]
        public bool Section { get; set; }

        [JsonProperty("position")]
        public bool Position { get; set; }

        [JsonProperty("role")]
        public bool Role { get; set; }

        [JsonProperty("integrations")]
        public bool Integrations { get; set; }

        [JsonProperty("integration")]
        public bool Integration { get; set; }

        [JsonProperty("smsTemplate")]
        public bool SmsTemplate { get; set; }

        [JsonProperty("production")]
        public bool Production { get; set; }

        [JsonProperty("productionRouteSheet")]
        public bool ProductionRouteSheet { get; set; }

        [JsonProperty("productionOperation")]
        public bool ProductionOperation { get; set; }

        [JsonProperty("reference")]
        public bool Reference { get; set; }

        [JsonProperty("price")]
        public bool Price { get; set; }

        [JsonProperty("legalPerson")]
        public bool LegalPerson { get; set; }

        [JsonProperty("naturalPerson")]
        public bool NaturalPerson { get; set; }

        [JsonProperty("producer")]
        public bool Producer { get; set; }

        [JsonProperty("brand")]
        public bool Brand { get; set; }

        [JsonProperty("settings")]
        public bool Settings { get; set; }

        [JsonProperty("isMarkActive")]
        public bool IsMarkActive { get; set; }

        [JsonProperty("isNoteActive")]
        public bool IsNoteActive { get; set; }

        [JsonProperty("isReceiptActive")]
        public bool IsReceiptActive { get; set; }

        [JsonProperty("materialCategory")]
        public bool MaterialCategory { get; set; }

        [JsonProperty("useCompoundProduct")]
        public bool UseCompoundProduct { get; set; }

        [JsonProperty("useVariantProduct")]
        public bool UseVariantProduct { get; set; }

        [JsonProperty("transferRequest")]
        public bool TransferRequest { get; set; }

        [JsonProperty("statisticsSale")]
        public bool StatisticsSale { get; set; }

        [JsonProperty("statisticsCashbox")]
        public bool StatisticsCashbox { get; set; }

        [JsonProperty("statisticsProduct")]
        public bool StatisticsProduct { get; set; }

        [JsonProperty("statisticsCategory")]
        public bool StatisticsCategory { get; set; }

        [JsonProperty("statisticsEmployee")]
        public bool StatisticsEmployee { get; set; }

        [JsonProperty("statisticsCustomer")]
        public bool StatisticsCustomer { get; set; }

        [JsonProperty("statisticsPaymentMethod")]
        public bool StatisticsPaymentMethod { get; set; }

        [JsonProperty("statisticsReceipt")]
        public bool StatisticsReceipt { get; set; }

        [JsonProperty("statisticsWarehouse")]
        public bool StatisticsWarehouse { get; set; }

        [JsonProperty("statisticsSpecificProduct")]
        public bool StatisticsSpecificProduct { get; set; }

        [JsonProperty("statisticsSpecificCustomer")]
        public bool StatisticsSpecificCustomer { get; set; }

        [JsonProperty("statisticsByCustomer")]
        public bool StatisticsByCustomer { get; set; }

        [JsonProperty("statisticsProfitLoss")]
        public bool StatisticsProfitLoss { get; set; }
    }
}
