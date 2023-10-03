using System;
using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Settings
{
    internal class GeneralSettingsResponse
    {
        [JsonPropertyName("isArchived")]
        public bool IsArchived { get; set; }

        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("completelyDeleted")]
        public bool CompletelyDeleted { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("useDeliveryLocation")]
        public bool UseDeliveryLocation { get; set; }

        [JsonPropertyName("statistics")]
        public bool Statistics { get; set; }

        [JsonPropertyName("sales")]
        public bool Sales { get; set; }

        [JsonPropertyName("discount")]
        public bool Discount { get; set; }

        [JsonPropertyName("etiket")]
        public bool Etiket { get; set; }

        [JsonPropertyName("customerReturnReason")]
        public bool CustomerReturnReason { get; set; }

        [JsonPropertyName("saleRefund")]
        public bool SaleRefund { get; set; }

        [JsonPropertyName("installmentPlan")]
        public bool InstallmentPlan { get; set; }

        [JsonPropertyName("customers")]
        public bool Customers { get; set; }

        [JsonPropertyName("customer")]
        public bool Customer { get; set; }

        [JsonPropertyName("saleOrder")]
        public bool SaleOrder { get; set; }

        [JsonPropertyName("customerCategory")]
        public bool CustomerCategory { get; set; }

        [JsonPropertyName("supply")]
        public bool Supply { get; set; }

        [JsonPropertyName("purchaseRequest")]
        public bool PurchaseRequest { get; set; }

        [JsonPropertyName("purchaseOrder")]
        public bool PurchaseOrder { get; set; }

        [JsonPropertyName("purchase")]
        public bool Purchase { get; set; }

        [JsonPropertyName("purchaseReturn")]
        public bool PurchaseReturn { get; set; }

        [JsonPropertyName("supplier")]
        public bool Supplier { get; set; }

        [JsonPropertyName("supplierCategory")]
        public bool SupplierCategory { get; set; }

        [JsonPropertyName("purchaseReason")]
        public bool PurchaseReason { get; set; }

        [JsonPropertyName("supplierReturnReason")]
        public bool SupplierReturnReason { get; set; }

        [JsonPropertyName("warehouse")]
        public bool Warehouse { get; set; }

        [JsonPropertyName("income")]
        public bool Income { get; set; }

        [JsonPropertyName("inventorization")]
        public bool Inventorization { get; set; }

        [JsonPropertyName("writeOffReason")]
        public bool WriteOffReason { get; set; }

        [JsonPropertyName("writeOff")]
        public bool WriteOff { get; set; }

        [JsonPropertyName("material")]
        public bool Material { get; set; }

        [JsonPropertyName("semiProduct")]
        public bool SemiProduct { get; set; }

        [JsonPropertyName("productCategory")]
        public bool ProductCategory { get; set; }

        [JsonPropertyName("warehouseGet")]
        public bool WarehouseGet { get; set; }

        [JsonPropertyName("warehouseType")]
        public bool WarehouseType { get; set; }

        [JsonPropertyName("transferReason")]
        public bool TransferReason { get; set; }

        [JsonPropertyName("internalTransferRequest")]
        public bool InternalTransferRequest { get; set; }

        [JsonPropertyName("internalTransfer")]
        public bool InternalTransfer { get; set; }

        [JsonPropertyName("organizationalTransferRequest")]
        public bool OrganizationalTransferRequest { get; set; }

        [JsonPropertyName("organizationalTransfer")]
        public bool OrganizationalTransfer { get; set; }

        [JsonPropertyName("productStock")]
        public bool ProductStock { get; set; }

        [JsonPropertyName("statisticsProductAmount")]
        public bool StatisticsProductAmount { get; set; }

        [JsonPropertyName("statisticsProductCost")]
        public bool StatisticsProductCost { get; set; }

        [JsonPropertyName("statisticsProductIncome")]
        public bool StatisticsProductIncome { get; set; }

        [JsonPropertyName("finance")]
        public bool Finance { get; set; }

        [JsonPropertyName("cashbox")]
        public bool Cashbox { get; set; }

        [JsonPropertyName("transactions")]
        public bool Transactions { get; set; }

        [JsonPropertyName("invoice")]
        public bool Invoice { get; set; }

        [JsonPropertyName("customerBalanceUpdate")]
        public bool CustomerBalanceUpdate { get; set; }

        [JsonPropertyName("supplierBalanceUpdate")]
        public bool SupplierBalanceUpdate { get; set; }

        [JsonPropertyName("employeeBalanceUpdate")]
        public bool EmployeeBalanceUpdate { get; set; }

        [JsonPropertyName("cashboxBalanceUpdate")]
        public bool CashboxBalanceUpdate { get; set; }

        [JsonPropertyName("currency")]
        public bool Currency { get; set; }

        [JsonPropertyName("tax")]
        public bool Tax { get; set; }

        [JsonPropertyName("paymentType")]
        public bool PaymentType { get; set; }

        [JsonPropertyName("extraCost")]
        public bool ExtraCost { get; set; }

        [JsonPropertyName("contract")]
        public bool Contract { get; set; }

        [JsonPropertyName("customerBalance")]
        public bool CustomerBalance { get; set; }

        [JsonPropertyName("employeeBalance")]
        public bool EmployeeBalance { get; set; }

        [JsonPropertyName("supplierBalance")]
        public bool SupplierBalance { get; set; }

        [JsonPropertyName("personBalance")]
        public bool PersonBalance { get; set; }

        [JsonPropertyName("statisticsCostByCategory")]
        public bool StatisticsCostByCategory { get; set; }

        [JsonPropertyName("statisticsBalance")]
        public bool StatisticsBalance { get; set; }

        [JsonPropertyName("statisticsCashflow")]
        public bool StatisticsCashflow { get; set; }

        [JsonPropertyName("hr")]
        public bool Hr { get; set; }

        [JsonPropertyName("employee")]
        public bool Employee { get; set; }

        [JsonPropertyName("section")]
        public bool Section { get; set; }

        [JsonPropertyName("position")]
        public bool Position { get; set; }

        [JsonPropertyName("role")]
        public bool Role { get; set; }

        [JsonPropertyName("integrations")]
        public bool Integrations { get; set; }

        [JsonPropertyName("integration")]
        public bool Integration { get; set; }

        [JsonPropertyName("smsTemplate")]
        public bool SmsTemplate { get; set; }

        [JsonPropertyName("production")]
        public bool Production { get; set; }

        [JsonPropertyName("productionRouteSheet")]
        public bool ProductionRouteSheet { get; set; }

        [JsonPropertyName("productionOperation")]
        public bool ProductionOperation { get; set; }

        [JsonPropertyName("reference")]
        public bool Reference { get; set; }

        [JsonPropertyName("price")]
        public bool Price { get; set; }

        [JsonPropertyName("legalPerson")]
        public bool LegalPerson { get; set; }

        [JsonPropertyName("naturalPerson")]
        public bool NaturalPerson { get; set; }

        [JsonPropertyName("producer")]
        public bool Producer { get; set; }

        [JsonPropertyName("brand")]
        public bool Brand { get; set; }

        [JsonPropertyName("settings")]
        public bool Settings { get; set; }

        [JsonPropertyName("isMarkActive")]
        public bool IsMarkActive { get; set; }

        [JsonPropertyName("isNoteActive")]
        public bool IsNoteActive { get; set; }

        [JsonPropertyName("isReceiptActive")]
        public bool IsReceiptActive { get; set; }

        [JsonPropertyName("materialCategory")]
        public bool MaterialCategory { get; set; }

        [JsonPropertyName("useCompoundProduct")]
        public bool UseCompoundProduct { get; set; }

        [JsonPropertyName("useVariantProduct")]
        public bool UseVariantProduct { get; set; }

        [JsonPropertyName("transferRequest")]
        public bool TransferRequest { get; set; }

        [JsonPropertyName("statisticsSale")]
        public bool StatisticsSale { get; set; }

        [JsonPropertyName("statisticsCashbox")]
        public bool StatisticsCashbox { get; set; }

        [JsonPropertyName("statisticsProduct")]
        public bool StatisticsProduct { get; set; }

        [JsonPropertyName("statisticsCategory")]
        public bool StatisticsCategory { get; set; }

        [JsonPropertyName("statisticsEmployee")]
        public bool StatisticsEmployee { get; set; }

        [JsonPropertyName("statisticsCustomer")]
        public bool StatisticsCustomer { get; set; }

        [JsonPropertyName("statisticsPaymentMethod")]
        public bool StatisticsPaymentMethod { get; set; }

        [JsonPropertyName("statisticsReceipt")]
        public bool StatisticsReceipt { get; set; }

        [JsonPropertyName("statisticsWarehouse")]
        public bool StatisticsWarehouse { get; set; }

        [JsonPropertyName("statisticsSpecificProduct")]
        public bool StatisticsSpecificProduct { get; set; }

        [JsonPropertyName("statisticsSpecificCustomer")]
        public bool StatisticsSpecificCustomer { get; set; }

        [JsonPropertyName("statisticsByCustomer")]
        public bool StatisticsByCustomer { get; set; }

        [JsonPropertyName("statisticsProfitLoss")]
        public bool StatisticsProfitLoss { get; set; }
    }
}
