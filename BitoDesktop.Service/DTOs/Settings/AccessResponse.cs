using System.Text.Json.Serialization;

namespace BitoDesktop.Service.DTOs.Settings;
internal class AccessResponse
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("organization_id")]
    public string OrganizationId { get; set; }

    [JsonPropertyName("user_id")]
    public string UserId { get; set; }

    [JsonPropertyName("role_id")]
    public string RoleId { get; set; }

    public RoleResponse role { get; set; }

    public class RoleResponse
    {
        [JsonPropertyName("statistics")]
        public bool Statistics { get; set; }

        [JsonPropertyName("statistics_sale")]
        public bool StatisticsSale { get; set; }

        [JsonPropertyName("statistics_cashbox")]
        public bool StatisticsCashbox { get; set; }

        [JsonPropertyName("statistics_category")]
        public bool StatisticsCategory { get; set; }

        [JsonPropertyName("statistics_product")]
        public bool StatisticsProduct { get; set; }

        [JsonPropertyName("statistics_employee")]
        public bool StatisticsEmployee { get; set; }

        [JsonPropertyName("statistics_customer")]
        public bool StatisticsCustomer { get; set; }

        [JsonPropertyName("statistics_supplier")]
        public bool StatisticsSupplier { get; set; }

        [JsonPropertyName("statistics_payment_method")]
        public bool StatisticsPaymentMethod { get; set; }

        [JsonPropertyName("statistics_receipt")]
        public bool StatisticsReceipt { get; set; }

        [JsonPropertyName("statistics_warehouse")]
        public bool StatisticsWarehouse { get; set; }

        [JsonPropertyName("statistics_product_cost")]
        public bool StatisticsProductCost { get; set; }

        [JsonPropertyName("statistics_cost_by_category")]
        public bool StatisticsCostByCategory { get; set; }

        [JsonPropertyName("statistics_product_income")]
        public bool StatisticsProductIncome { get; set; }

        [JsonPropertyName("statistics_product_amount")]
        public bool StatisticsProductAmount { get; set; }

        [JsonPropertyName("statistics_specific_product")]
        public bool StatisticsSpecificProduct { get; set; }

        [JsonPropertyName("statistics_specific_customer")]
        public bool StatisticsSpecificCustomer { get; set; }

        [JsonPropertyName("statistics_by_customer")]
        public bool StatisticsByCustomer { get; set; }

        [JsonPropertyName("statistics_balance")]
        public bool StatisticsBalance { get; set; }

        [JsonPropertyName("statistics_profit_loss")]
        public bool StatisticsProfitLoss { get; set; }

        [JsonPropertyName("statistics_cashflow")]
        public bool StatisticsCashflow { get; set; }

        [JsonPropertyName("pos")]
        public bool Pos { get; set; }

        [JsonPropertyName("receipt_refund")]
        public bool ReceiptRefund { get; set; }

        [JsonPropertyName("change_sale_price")]
        public bool ChangeSalePrice { get; set; }

        [JsonPropertyName("sales")]
        public bool Sales { get; set; }

        [JsonPropertyName("sale_offer")]
        public bool SaleOffer { get; set; }

        [JsonPropertyName("sale_offer_create")]
        public bool SaleOfferCreate { get; set; }

        [JsonPropertyName("sale_offer_update")]
        public bool SaleOfferUpdate { get; set; }

        [JsonPropertyName("sale_offer_delete")]
        public bool SaleOfferDelete { get; set; }

        [JsonPropertyName("discount")]
        public bool Discount { get; set; }

        [JsonPropertyName("discount_create")]
        public bool DiscountCreate { get; set; }

        [JsonPropertyName("discount_update")]
        public bool DiscountUpdate { get; set; }

        [JsonPropertyName("discount_delete")]
        public bool DiscountDelete { get; set; }

        [JsonPropertyName("cross_sell")]
        public bool CrossSell { get; set; }

        [JsonPropertyName("cross_sell_create")]
        public bool CrossSellCreate { get; set; }

        [JsonPropertyName("cross_sell_update")]
        public bool CrossSellUpdate { get; set; }

        [JsonPropertyName("cross_sell_delete")]
        public bool CrossSellDelete { get; set; }

        [JsonPropertyName("customers")]
        public bool Customers { get; set; }

        [JsonPropertyName("customer")]
        public bool Customer { get; set; }

        [JsonPropertyName("customer_create")]
        public bool CustomerCreate { get; set; }

        [JsonPropertyName("customer_update")]
        public bool CustomerUpdate { get; set; }

        [JsonPropertyName("customer_delete")]
        public bool CustomerDelete { get; set; }

        [JsonPropertyName("customer_balance")]
        public bool CustomerBalance { get; set; }

        [JsonPropertyName("customer_balance_update")]
        public bool CustomerBalanceUpdate { get; set; }

        [JsonPropertyName("call_record")]
        public bool CallRecord { get; set; }

        [JsonPropertyName("call_record_create")]
        public bool CallRecordCreate { get; set; }

        [JsonPropertyName("call_record_update")]
        public bool CallRecordUpdate { get; set; }

        [JsonPropertyName("call_record_delete")]
        public bool CallRecordDelete { get; set; }

        [JsonPropertyName("sale")]
        public bool Sale { get; set; }

        [JsonPropertyName("sale_create")]
        public bool SaleCreate { get; set; }

        [JsonPropertyName("sale_update")]
        public bool SaleUpdate { get; set; }

        [JsonPropertyName("sale_delete")]
        public bool SaleDelete { get; set; }

        [JsonPropertyName("sale_order")]
        public bool SaleOrder { get; set; }

        [JsonPropertyName("sale_order_create")]
        public bool SaleOrderCreate { get; set; }

        [JsonPropertyName("sale_order_update")]
        public bool SaleOrderUpdate { get; set; }

        [JsonPropertyName("sale_order_delete")]
        public bool SaleOrderDelete { get; set; }

        [JsonPropertyName("installment_plan")]
        public bool InstallmentPlan { get; set; }

        [JsonPropertyName("products")]
        public bool Products { get; set; }

        [JsonPropertyName("product")]
        public bool Product { get; set; }

        [JsonPropertyName("semi_product")]
        public bool SemiProduct { get; set; }

        [JsonPropertyName("semi_product_create")]
        public bool SemiProductCreate { get; set; }

        [JsonPropertyName("semi_product_update")]
        public bool SemiProductUpdate { get; set; }

        [JsonPropertyName("semi_product_delete")]
        public bool SemiProductDelete { get; set; }

        [JsonPropertyName("product_amount")]
        public bool ProductAmount { get; set; }

        [JsonPropertyName("product_stock")]
        public bool ProductStock { get; set; }

        [JsonPropertyName("product_create")]
        public bool ProductCreate { get; set; }

        [JsonPropertyName("product_update")]
        public bool ProductUpdate { get; set; }

        [JsonPropertyName("product_delete")]
        public bool ProductDelete { get; set; }

        [JsonPropertyName("product_category")]
        public bool ProductCategory { get; set; }

        [JsonPropertyName("product_category_create")]
        public bool ProductCategoryCreate { get; set; }

        [JsonPropertyName("product_category_update")]
        public bool ProductCategoryUpdate { get; set; }

        [JsonPropertyName("product_category_delete")]
        public bool ProductCategoryDelete { get; set; }

        [JsonPropertyName("etiket")]
        public bool Etiket { get; set; }

        [JsonPropertyName("product_income")]
        public bool ProductIncome { get; set; }

        [JsonPropertyName("product_income_create")]
        public bool ProductIncomeCreate { get; set; }

        [JsonPropertyName("product_income_update")]
        public bool ProductIncomeUpdate { get; set; }

        [JsonPropertyName("product_income_delete")]
        public bool ProductIncomeDelete { get; set; }

        [JsonPropertyName("transfer_request")]
        public bool TransferRequest { get; set; }

        [JsonPropertyName("transfer_request_create")]
        public bool TransferRequestCreate { get; set; }

        [JsonPropertyName("transfer_request_update")]
        public bool TransferRequestUpdate { get; set; }

        [JsonPropertyName("organizational_transfer_request")]
        public bool OrganizationalTransferRequest { get; set; }

        [JsonPropertyName("organizational_transfer_request_create")]
        public bool OrganizationalTransferRequestCreate { get; set; }

        [JsonPropertyName("organizational_transfer_request_update")]
        public bool OrganizationalTransferRequestUpdate { get; set; }

        [JsonPropertyName("purchase_return")]
        public bool PurchaseReturn { get; set; }

        [JsonPropertyName("purchase_return_create")]
        public bool PurchaseReturnCreate { get; set; }

        [JsonPropertyName("purchase_return_update")]
        public bool PurchaseReturnUpdate { get; set; }

        [JsonPropertyName("supply")]
        public bool Supply { get; set; }

        [JsonPropertyName("supplier")]
        public bool Supplier { get; set; }

        [JsonPropertyName("supplier_create")]
        public bool SupplierCreate { get; set; }

        [JsonPropertyName("supplier_update")]
        public bool SupplierUpdate { get; set; }

        [JsonPropertyName("supplier_delete")]
        public bool SupplierDelete { get; set; }

        [JsonPropertyName("supplier_balance")]
        public bool SupplierBalance { get; set; }

        [JsonPropertyName("supplier_balance_update")]
        public bool SupplierBalanceUpdate { get; set; }

        [JsonPropertyName("person_balance")]
        public bool PersonBalance { get; set; }

        [JsonPropertyName("product_order")]
        public bool ProductOrder { get; set; }

        [JsonPropertyName("product_order_create")]
        public bool ProductOrderCreate { get; set; }

        [JsonPropertyName("product_order_update")]
        public bool ProductOrderUpdate { get; set; }

        [JsonPropertyName("product_order_delete")]
        public bool ProductOrderDelete { get; set; }

        [JsonPropertyName("material_order")]
        public bool MaterialOrder { get; set; }

        [JsonPropertyName("material_order_create")]
        public bool MaterialOrderCreate { get; set; }

        [JsonPropertyName("material_order_update")]
        public bool MaterialOrderUpdate { get; set; }

        [JsonPropertyName("material_order_delete")]
        public bool MaterialOrderDelete { get; set; }

        [JsonPropertyName("hr")]
        public bool Hr { get; set; }

        [JsonPropertyName("employee")]
        public bool Employee { get; set; }

        [JsonPropertyName("employee_create")]
        public bool EmployeeCreate { get; set; }

        [JsonPropertyName("employee_update")]
        public bool EmployeeUpdate { get; set; }

        [JsonPropertyName("employee_delete")]
        public bool EmployeeDelete { get; set; }

        [JsonPropertyName("employee_balance")]
        public bool EmployeeBalance { get; set; }

        [JsonPropertyName("employee_balance_update")]
        public bool EmployeeBalanceUpdate { get; set; }

        [JsonPropertyName("attendance")]
        public bool Attendance { get; set; }

        [JsonPropertyName("attendance_create")]
        public bool AttendanceCreate { get; set; }

        [JsonPropertyName("attendance_update")]
        public bool AttendanceUpdate { get; set; }

        [JsonPropertyName("attendance_delete")]
        public bool AttendanceDelete { get; set; }

        [JsonPropertyName("position")]
        public bool Position { get; set; }

        [JsonPropertyName("position_create")]
        public bool PositionCreate { get; set; }

        [JsonPropertyName("position_update")]
        public bool PositionUpdate { get; set; }

        [JsonPropertyName("position_delete")]
        public bool PositionDelete { get; set; }

        [JsonPropertyName("section")]
        public bool Section { get; set; }

        [JsonPropertyName("section_create")]
        public bool SectionCreate { get; set; }

        [JsonPropertyName("section_update")]
        public bool SectionUpdate { get; set; }

        [JsonPropertyName("section_delete")]
        public bool SectionDelete { get; set; }

        [JsonPropertyName("role")]
        public bool Role { get; set; }

        [JsonPropertyName("role_create")]
        public bool RoleCreate { get; set; }

        [JsonPropertyName("role_update")]
        public bool RoleUpdate { get; set; }

        [JsonPropertyName("role_delete")]
        public bool RoleDelete { get; set; }

        [JsonPropertyName("salary")]
        public bool Salary { get; set; }

        [JsonPropertyName("salary_create")]
        public bool SalaryCreate { get; set; }

        [JsonPropertyName("salary_update")]
        public bool SalaryUpdate { get; set; }

        [JsonPropertyName("schedule")]
        public bool Schedule { get; set; }

        [JsonPropertyName("schedule_create")]
        public bool ScheduleCreate { get; set; }

        [JsonPropertyName("schedule_update")]
        public bool ScheduleUpdate { get; set; }

        [JsonPropertyName("schedule_delete")]
        public bool ScheduleDelete { get; set; }

        [JsonPropertyName("purchase_reason")]
        public bool PurchaseReason { get; set; }

        [JsonPropertyName("purchase_reason_create")]
        public bool PurchaseReasonCreate { get; set; }

        [JsonPropertyName("purchase_reason_update")]
        public bool PurchaseReasonUpdate { get; set; }

        [JsonPropertyName("purchase_reason_delete")]
        public bool PurchaseReasonDelete { get; set; }

        [JsonPropertyName("purchase_request")]
        public bool PurchaseRequest { get; set; }

        [JsonPropertyName("purchase_request_create")]
        public bool PurchaseRequestCreate { get; set; }

        [JsonPropertyName("purchase_request_update")]
        public bool PurchaseRequestUpdate { get; set; }

        [JsonPropertyName("purchase_order")]
        public bool PurchaseOrder { get; set; }

        [JsonPropertyName("purchase_order_create")]
        public bool PurchaseOrderCreate { get; set; }

        [JsonPropertyName("purchase_order_update")]
        public bool PurchaseOrderUpdate { get; set; }

        [JsonPropertyName("income")]
        public bool Income { get; set; }

        [JsonPropertyName("income_create")]
        public bool IncomeCreate { get; set; }

        [JsonPropertyName("purchase")]
        public bool Purchase { get; set; }

        [JsonPropertyName("purchase_create")]
        public bool PurchaseCreate { get; set; }

        [JsonPropertyName("purchase_update")]
        public bool PurchaseUpdate { get; set; }

        [JsonPropertyName("warehouse")]
        public bool Warehouse { get; set; }

        [JsonPropertyName("storekeeper")]
        public bool Storekeeper { get; set; }

        [JsonPropertyName("material")]
        public bool Material { get; set; }

        [JsonPropertyName("material_create")]
        public bool MaterialCreate { get; set; }

        [JsonPropertyName("material_update")]
        public bool MaterialUpdate { get; set; }

        [JsonPropertyName("material_delete")]
        public bool MaterialDelete { get; set; }
        [JsonPropertyName("material_category")]
        public bool MaterialCategory { get; set; }

        [JsonPropertyName("material_category_create")]
        public bool MaterialCategoryCreate { get; set; }

        [JsonPropertyName("material_category_update")]
        public bool MaterialCategoryUpdate { get; set; }

        [JsonPropertyName("material_category_delete")]
        public bool MaterialCategoryDelete { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("active_create")]
        public bool ActiveCreate { get; set; }

        [JsonPropertyName("active_update")]
        public bool ActiveUpdate { get; set; }

        [JsonPropertyName("active_delete")]
        public bool ActiveDelete { get; set; }

        [JsonPropertyName("material_income")]
        public bool MaterialIncome { get; set; }

        [JsonPropertyName("material_income_create")]
        public bool MaterialIncomeCreate { get; set; }

        [JsonPropertyName("material_income_update")]
        public bool MaterialIncomeUpdate { get; set; }

        [JsonPropertyName("material_income_delete")]
        public bool MaterialIncomeDelete { get; set; }

        [JsonPropertyName("material_transfer")]
        public bool MaterialTransfer { get; set; }

        [JsonPropertyName("material_transfer_create")]
        public bool MaterialTransferCreate { get; set; }

        [JsonPropertyName("material_transfer_update")]
        public bool MaterialTransferUpdate { get; set; }

        [JsonPropertyName("material_transfer_delete")]
        public bool MaterialTransferDelete { get; set; }

        [JsonPropertyName("internal_transfer_request")]
        public bool InternalTransferRequest { get; set; }

        [JsonPropertyName("internal_transfer_request_create")]
        public bool InternalTransferRequestCreate { get; set; }

        [JsonPropertyName("internal_transfer_request_update")]
        public bool InternalTransferRequestUpdate { get; set; }

        [JsonPropertyName("internal_transfer")]
        public bool InternalTransfer { get; set; }

        [JsonPropertyName("internal_transfer_create")]
        public bool InternalTransferCreate { get; set; }

        [JsonPropertyName("internal_transfer_update")]
        public bool InternalTransferUpdate { get; set; }

        [JsonPropertyName("organizational_transfer")]
        public bool OrganizationalTransfer { get; set; }

        [JsonPropertyName("organizational_transfer_create")]
        public bool OrganizationalTransferCreate { get; set; }

        [JsonPropertyName("organizational_transfer_update")]
        public bool OrganizationalTransferUpdate { get; set; }

        [JsonPropertyName("material_return")]
        public bool MaterialReturn { get; set; }

        [JsonPropertyName("material_return_create")]
        public bool MaterialReturnCreate { get; set; }

        [JsonPropertyName("material_return_update")]
        public bool MaterialReturnUpdate { get; set; }

        [JsonPropertyName("material_return_delete")]
        public bool MaterialReturnDelete { get; set; }

        [JsonPropertyName("finance")]
        public bool Finance { get; set; }

        [JsonPropertyName("cashbox")]
        public bool Cashbox { get; set; }

        [JsonPropertyName("cashbox_balance_update")]
        public bool CashboxBalanceUpdate { get; set; }

        [JsonPropertyName("transactions")]
        public bool Transactions { get; set; }

        [JsonPropertyName("transaction_update")]
        public bool TransactionUpdate { get; set; }

        [JsonPropertyName("cash_income")]
        public bool CashIncome { get; set; }

        [JsonPropertyName("cash_expense")]
        public bool CashExpense { get; set; }

        [JsonPropertyName("cash_exchange")]
        public bool CashExchange { get; set; }

        [JsonPropertyName("cash_exchange_method")]
        public bool CashExchangeMethod { get; set; }

        [JsonPropertyName("cash_transfer")]
        public bool CashTransfer { get; set; }

        [JsonPropertyName("cashbox_create")]
        public bool CashboxCreate { get; set; }

        [JsonPropertyName("cashbox_update")]
        public bool CashboxUpdate { get; set; }

        [JsonPropertyName("cashbox_delete")]
        public bool CashboxDelete { get; set; }

        [JsonPropertyName("payment_type")]
        public bool PaymentType { get; set; }

        [JsonPropertyName("payment_type_create")]
        public bool PaymentTypeCreate { get; set; }

        [JsonPropertyName("payment_type_update")]
        public bool PaymentTypeUpdate { get; set; }

        [JsonPropertyName("payment_type_delete")]
        public bool PaymentTypeDelete { get; set; }

        [JsonPropertyName("inventorization")]
        public bool Inventorization { get; set; }

        [JsonPropertyName("inventorization_create")]
        public bool InventorizationCreate { get; set; }

        [JsonPropertyName("inventorization_update")]
        public bool InventorizationUpdate { get; set; }

        [JsonPropertyName("inventorization_delete")]
        public bool InventorizationDelete { get; set; }

        [JsonPropertyName("invoice")]
        public bool Invoice { get; set; }

        [JsonPropertyName("invoice_create")]
        public bool InvoiceCreate { get; set; }

        [JsonPropertyName("invoice_income_create")]
        public bool InvoiceIncomeCreate { get; set; }

        [JsonPropertyName("invoice_expense_create")]
        public bool InvoiceExpenseCreate { get; set; }

        [JsonPropertyName("invoice_update")]
        public bool InvoiceUpdate { get; set; }

        [JsonPropertyName("invoice_delete")]
        public bool InvoiceDelete { get; set; }

        [JsonPropertyName("tax")]
        public bool Tax { get; set; }

        [JsonPropertyName("tax_create")]
        public bool TaxCreate { get; set; }

        [JsonPropertyName("tax_update")]
        public bool TaxUpdate { get; set; }

        [JsonPropertyName("tax_delete")]
        public bool TaxDelete { get; set; }

        [JsonPropertyName("document")]
        public bool Document { get; set; }

        [JsonPropertyName("document_create")]
        public bool DocumentCreate { get; set; }

        [JsonPropertyName("document_update")]
        public bool DocumentUpdate { get; set; }

        [JsonPropertyName("document_delete")]
        public bool DocumentDelete { get; set; }

        [JsonPropertyName("currency")]
        public bool Currency { get; set; }

        [JsonPropertyName("currency_create")]
        public bool CurrencyCreate { get; set; }

        [JsonPropertyName("currency_update")]
        public bool CurrencyUpdate { get; set; }

        [JsonPropertyName("currency_delete")]
        public bool CurrencyDelete { get; set; }

        [JsonPropertyName("reference")]
        public bool Reference { get; set; }

        [JsonPropertyName("tasks")]
        public bool Tasks { get; set; }

        [JsonPropertyName("task_create")]
        public bool TaskCreate { get; set; }

        [JsonPropertyName("task_update")]
        public bool TaskUpdate { get; set; }

        [JsonPropertyName("task_delete")]
        public bool TaskDelete { get; set; }

        [JsonPropertyName("states")]
        public bool States { get; set; }

        [JsonPropertyName("states_create")]
        public bool StatesCreate { get; set; }

        [JsonPropertyName("states_update")]
        public bool StatesUpdate { get; set; }

        [JsonPropertyName("states_delete")]
        public bool StatesDelete { get; set; }

        [JsonPropertyName("settings")]
        public bool Settings { get; set; }

        [JsonPropertyName("payment_methods")]
        public bool PaymentMethods { get; set; }

        [JsonPropertyName("payment_method_create")]
        public bool PaymentMethodCreate { get; set; }

        [JsonPropertyName("payment_method_update")]
        public bool PaymentMethodUpdate { get; set; }

        [JsonPropertyName("payment_method_delete")]
        public bool PaymentMethodDelete { get; set; }

        [JsonPropertyName("receipt_detail_get")]
        public bool ReceiptDetailGet { get; set; }

        [JsonPropertyName("receipt_detail_set")]
        public bool ReceiptDetailSet { get; set; }

        [JsonPropertyName("devices")]
        public bool Devices { get; set; }

        [JsonPropertyName("device_create")]
        public bool DeviceCreate { get; set; }

        [JsonPropertyName("device_update")]
        public bool DeviceUpdate { get; set; }

        [JsonPropertyName("device_delete")]
        public bool DeviceDelete { get; set; }

        [JsonPropertyName("product_history")]
        public bool ProductHistory { get; set; }

        [JsonPropertyName("web_hook")]
        public bool WebHook { get; set; }

        [JsonPropertyName("web_hook_create")]
        public bool WebHookCreate { get; set; }

        [JsonPropertyName("web_hook_update")]
        public bool WebHookUpdate { get; set; }

        [JsonPropertyName("web_hook_delete")]
        public bool WebHookDelete { get; set; }

        [JsonPropertyName("integrations")]
        public bool Integrations { get; set; }

        [JsonPropertyName("integration")]
        public bool Integration { get; set; }

        [JsonPropertyName("integration_create")]
        public bool IntegrationCreate { get; set; }

        [JsonPropertyName("integration_update")]
        public bool IntegrationUpdate { get; set; }

        [JsonPropertyName("integration_delete")]
        public bool IntegrationDelete { get; set; }

        [JsonPropertyName("sms_template")]
        public bool SmsTemplate { get; set; }

        [JsonPropertyName("sms_template_create")]
        public bool SmsTemplateCreate { get; set; }

        [JsonPropertyName("sms_template_update")]
        public bool SmsTemplateUpdate { get; set; }

        [JsonPropertyName("sms_template_delete")]
        public bool SmsTemplateDelete { get; set; }

        [JsonPropertyName("price")]
        public bool Price { get; set; }

        [JsonPropertyName("price_create")]
        public bool PriceCreate { get; set; }

        [JsonPropertyName("price_update")]
        public bool PriceUpdate { get; set; }

        [JsonPropertyName("price_delete")]
        public bool PriceDelete { get; set; }
        [JsonPropertyName("legal_person")]
        public bool LegalPerson { get; set; }

        [JsonPropertyName("legal_person_create")]
        public bool LegalPersonCreate { get; set; }

        [JsonPropertyName("legal_person_update")]
        public bool LegalPersonUpdate { get; set; }

        [JsonPropertyName("legal_person_delete")]
        public bool LegalPersonDelete { get; set; }

        [JsonPropertyName("natural_person")]
        public bool NaturalPerson { get; set; }

        [JsonPropertyName("natural_person_create")]
        public bool NaturalPersonCreate { get; set; }

        [JsonPropertyName("natural_person_update")]
        public bool NaturalPersonUpdate { get; set; }

        [JsonPropertyName("natural_person_delete")]
        public bool NaturalPersonDelete { get; set; }

        [JsonPropertyName("units_of_measure")]
        public bool UnitsOfMeasure { get; set; }

        [JsonPropertyName("units_of_measure_create")]
        public bool UnitsOfMeasureCreate { get; set; }

        [JsonPropertyName("units_of_measure_update")]
        public bool UnitsOfMeasureUpdate { get; set; }

        [JsonPropertyName("units_of_measure_delete")]
        public bool UnitsOfMeasureDelete { get; set; }

        [JsonPropertyName("reason")]
        public bool Reason { get; set; }

        [JsonPropertyName("reason_create")]
        public bool ReasonCreate { get; set; }

        [JsonPropertyName("reason_update")]
        public bool ReasonUpdate { get; set; }

        [JsonPropertyName("reason_delete")]
        public bool ReasonDelete { get; set; }

        [JsonPropertyName("box_types")]
        public bool BoxTypes { get; set; }

        [JsonPropertyName("box_types_create")]
        public bool BoxTypesCreate { get; set; }

        [JsonPropertyName("box_types_update")]
        public bool BoxTypesUpdate { get; set; }

        [JsonPropertyName("box_types_delete")]
        public bool BoxTypesDelete { get; set; }

        [JsonPropertyName("warehouse_get")]
        public bool WarehouseGet { get; set; }

        [JsonPropertyName("warehouse_get_create")]
        public bool WarehouseGetCreate { get; set; }

        [JsonPropertyName("warehouse_get_update")]
        public bool WarehouseGetUpdate { get; set; }

        [JsonPropertyName("warehouse_get_delete")]
        public bool WarehouseGetDelete { get; set; }

        [JsonPropertyName("warehouse_type")]
        public bool WarehouseType { get; set; }

        [JsonPropertyName("warehouse_type_create")]
        public bool WarehouseTypeCreate { get; set; }

        [JsonPropertyName("warehouse_type_update")]
        public bool WarehouseTypeUpdate { get; set; }

        [JsonPropertyName("warehouse_type_delete")]
        public bool WarehouseTypeDelete { get; set; }

        [JsonPropertyName("extra_cost")]
        public bool ExtraCost { get; set; }

        [JsonPropertyName("extra_cost_create")]
        public bool ExtraCostCreate { get; set; }

        [JsonPropertyName("extra_cost_update")]
        public bool ExtraCostUpdate { get; set; }

        [JsonPropertyName("extra_cost_delete")]
        public bool ExtraCostDelete { get; set; }

        [JsonPropertyName("write_off")]
        public bool WriteOff { get; set; }

        [JsonPropertyName("write_off_create")]
        public bool WriteOffCreate { get; set; }

        [JsonPropertyName("write_off_update")]
        public bool WriteOffUpdate { get; set; }

        [JsonPropertyName("write_off_delete")]
        public bool WriteOffDelete { get; set; }

        [JsonPropertyName("supplier_return_reason")]
        public bool SupplierReturnReason { get; set; }

        [JsonPropertyName("supplier_return_reason_create")]
        public bool SupplierReturnReasonCreate { get; set; }

        [JsonPropertyName("supplier_return_reason_update")]
        public bool SupplierReturnReasonUpdate { get; set; }

        [JsonPropertyName("supplier_return_reason_delete")]
        public bool SupplierReturnReasonDelete { get; set; }

        [JsonPropertyName("customer_return_reason")]
        public bool CustomerReturnReason { get; set; }

        [JsonPropertyName("customer_return_reason_create")]
        public bool CustomerReturnReasonCreate { get; set; }

        [JsonPropertyName("customer_return_reason_update")]
        public bool CustomerReturnReasonUpdate { get; set; }

        [JsonPropertyName("customer_return_reason_delete")]
        public bool CustomerReturnReasonDelete { get; set; }

        [JsonPropertyName("purchase_request_reason")]
        public bool PurchaseRequestReason { get; set; }

        [JsonPropertyName("purchase_request_reason_create")]
        public bool PurchaseRequestReasonCreate { get; set; }

        [JsonPropertyName("purchase_request_reason_update")]
        public bool PurchaseRequestReasonUpdate { get; set; }

        [JsonPropertyName("purchase_request_reason_delete")]
        public bool PurchaseRequestReasonDelete { get; set; }

        [JsonPropertyName("contract_cancel_reason")]
        public bool ContractCancelReason { get; set; }

        [JsonPropertyName("contract_cancel_reason_create")]
        public bool ContractCancelReasonCreate { get; set; }

        [JsonPropertyName("contract_cancel_reason_update")]
        public bool ContractCancelReasonUpdate { get; set; }

        [JsonPropertyName("contract_cancel_reason_delete")]
        public bool ContractCancelReasonDelete { get; set; }

        [JsonPropertyName("order_cancel_reason")]
        public bool OrderCancelReason { get; set; }

        [JsonPropertyName("order_cancel_reason_create")]
        public bool OrderCancelReasonCreate { get; set; }

        [JsonPropertyName("order_cancel_reason_update")]
        public bool OrderCancelReasonUpdate { get; set; }

        [JsonPropertyName("order_cancel_reason_delete")]
        public bool OrderCancelReasonDelete { get; set; }

        [JsonPropertyName("transfer_reason")]
        public bool TransferReason { get; set; }

        [JsonPropertyName("transfer_reason_create")]
        public bool TransferReasonCreate { get; set; }

        [JsonPropertyName("transfer_reason_update")]
        public bool TransferReasonUpdate { get; set; }

        [JsonPropertyName("transfer_reason_delete")]
        public bool TransferReasonDelete { get; set; }

        [JsonPropertyName("transfer_cancel_reason")]
        public bool TransferCancelReason { get; set; }

        [JsonPropertyName("transfer_cancel_reason_create")]
        public bool TransferCancelReasonCreate { get; set; }

        [JsonPropertyName("transfer_cancel_reason_update")]
        public bool TransferCancelReasonUpdate { get; set; }

        [JsonPropertyName("transfer_cancel_reason_delete")]
        public bool TransferCancelReasonDelete { get; set; }

        [JsonPropertyName("write_off_reason")]
        public bool WriteOffReason { get; set; }

        [JsonPropertyName("write_off_reason_create")]
        public bool WriteOffReasonCreate { get; set; }

        [JsonPropertyName("write_off_reason_update")]
        public bool WriteOffReasonUpdate { get; set; }

        [JsonPropertyName("write_off_reason_delete")]
        public bool WriteOffReasonDelete { get; set; }

        [JsonPropertyName("update_balance")]
        public bool UpdateBalance { get; set; }

        [JsonPropertyName("sale_refund")]
        public bool SaleRefund { get; set; }

        [JsonPropertyName("sale_refund_create")]
        public bool SaleRefundCreate { get; set; }

        [JsonPropertyName("sale_refund_update")]
        public bool SaleRefundUpdate { get; set; }

        [JsonPropertyName("producer")]
        public bool Producer { get; set; }

        [JsonPropertyName("producer_create")]
        public bool ProducerCreate { get; set; }

        [JsonPropertyName("producer_update")]
        public bool ProducerUpdate { get; set; }

        [JsonPropertyName("producer_delete")]
        public bool ProducerDelete { get; set; }

        [JsonPropertyName("brand")]
        public bool Brand { get; set; }

        [JsonPropertyName("brand_create")]
        public bool BrandCreate { get; set; }

        [JsonPropertyName("brand_update")]
        public bool BrandUpdate { get; set; }

        [JsonPropertyName("brand_delete")]
        public bool BrandDelete { get; set; }

        [JsonPropertyName("sale_price_update")]
        public bool SalePriceUpdate { get; set; }

        [JsonPropertyName("income_price_update")]
        public bool IncomePriceUpdate { get; set; }

        [JsonPropertyName("attribute")]
        public bool Attribute { get; set; }

        [JsonPropertyName("attribute_create")]
        public bool AttributeCreate { get; set; }

        [JsonPropertyName("attribute_update")]
        public bool AttributeUpdate { get; set; }

        [JsonPropertyName("contract")]
        public bool Contract { get; set; }

        [JsonPropertyName("contract_create")]
        public bool ContractCreate { get; set; }

        [JsonPropertyName("contract_update")]
        public bool ContractUpdate { get; set; }

        [JsonPropertyName("contract_delete")]
        public bool ContractDelete { get; set; }

        [JsonPropertyName("supplier_category")]
        public bool SupplierCategory { get; set; }

        [JsonPropertyName("supplier_category_create")]
        public bool SupplierCategoryCreate { get; set; }

        [JsonPropertyName("supplier_category_update")]
        public bool SupplierCategoryUpdate { get; set; }

        [JsonPropertyName("supplier_category_delete")]
        public bool SupplierCategoryDelete { get; set; }

        [JsonPropertyName("customer_category")]
        public bool CustomerCategory { get; set; }

        [JsonPropertyName("customer_category_create")]
        public bool CustomerCategoryCreate { get; set; }

        [JsonPropertyName("customer_category_update")]
        public bool CustomerCategoryUpdate { get; set; }

        [JsonPropertyName("customer_category_delete")]
        public bool CustomerCategoryDelete { get; set; }

        [JsonPropertyName("product_price_set")]
        public bool ProductPriceSet { get; set; }

        [JsonPropertyName("cashback")]
        public bool Cashback { get; set; }

        [JsonPropertyName("production")]
        public bool Production { get; set; }

        [JsonPropertyName("production_route_sheet")]
        public bool ProductionRouteSheet { get; set; }

        [JsonPropertyName("production_route_sheet_create")]
        public bool ProductionRouteSheetCreate { get; set; }

        [JsonPropertyName("production_route_sheet_update")]
        public bool ProductionRouteSheetUpdate { get; set; }

        [JsonPropertyName("production_route_sheet_delete")]
        public bool ProductionRouteSheetDelete { get; set; }

        [JsonPropertyName("production_operation")]
        public bool ProductionOperation { get; set; }

        [JsonPropertyName("production_operation_create")]
        public bool ProductionOperationCreate { get; set; }

        [JsonPropertyName("production_operation_update")]
        public bool ProductionOperationUpdate { get; set; }

        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("mobile")]
        public bool Mobile { get; set; }
    }
}
