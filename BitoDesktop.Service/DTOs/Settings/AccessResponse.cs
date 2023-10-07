using Newtonsoft.Json;

namespace BitoDesktop.Service.DTOs.Settings;
public class AccessResponse
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("organization_id")]
    public string OrganizationId { get; set; }

    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [JsonProperty("role_id")]
    public string RoleId { get; set; }

    public RoleResponse role { get; set; }

    public class RoleResponse
    {
        [JsonProperty("statistics")]
        public bool Statistics { get; set; }

        [JsonProperty("statistics_sale")]
        public bool StatisticsSale { get; set; }

        [JsonProperty("statistics_cashbox")]
        public bool StatisticsCashbox { get; set; }

        [JsonProperty("statistics_category")]
        public bool StatisticsCategory { get; set; }

        [JsonProperty("statistics_product")]
        public bool StatisticsProduct { get; set; }

        [JsonProperty("statistics_employee")]
        public bool StatisticsEmployee { get; set; }

        [JsonProperty("statistics_customer")]
        public bool StatisticsCustomer { get; set; }

        [JsonProperty("statistics_supplier")]
        public bool StatisticsSupplier { get; set; }

        [JsonProperty("statistics_payment_method")]
        public bool StatisticsPaymentMethod { get; set; }

        [JsonProperty("statistics_receipt")]
        public bool StatisticsReceipt { get; set; }

        [JsonProperty("statistics_warehouse")]
        public bool StatisticsWarehouse { get; set; }

        [JsonProperty("statistics_product_cost")]
        public bool StatisticsProductCost { get; set; }

        [JsonProperty("statistics_cost_by_category")]
        public bool StatisticsCostByCategory { get; set; }

        [JsonProperty("statistics_product_income")]
        public bool StatisticsProductIncome { get; set; }

        [JsonProperty("statistics_product_amount")]
        public bool StatisticsProductAmount { get; set; }

        [JsonProperty("statistics_specific_product")]
        public bool StatisticsSpecificProduct { get; set; }

        [JsonProperty("statistics_specific_customer")]
        public bool StatisticsSpecificCustomer { get; set; }

        [JsonProperty("statistics_by_customer")]
        public bool StatisticsByCustomer { get; set; }

        [JsonProperty("statistics_balance")]
        public bool StatisticsBalance { get; set; }

        [JsonProperty("statistics_profit_loss")]
        public bool StatisticsProfitLoss { get; set; }

        [JsonProperty("statistics_cashflow")]
        public bool StatisticsCashflow { get; set; }

        [JsonProperty("pos")]
        public bool Pos { get; set; }

        [JsonProperty("receipt_refund")]
        public bool ReceiptRefund { get; set; }

        [JsonProperty("change_sale_price")]
        public bool ChangeSalePrice { get; set; }

        [JsonProperty("sales")]
        public bool Sales { get; set; }

        [JsonProperty("sale_offer")]
        public bool SaleOffer { get; set; }

        [JsonProperty("sale_offer_create")]
        public bool SaleOfferCreate { get; set; }

        [JsonProperty("sale_offer_update")]
        public bool SaleOfferUpdate { get; set; }

        [JsonProperty("sale_offer_delete")]
        public bool SaleOfferDelete { get; set; }

        [JsonProperty("discount")]
        public bool Discount { get; set; }

        [JsonProperty("discount_create")]
        public bool DiscountCreate { get; set; }

        [JsonProperty("discount_update")]
        public bool DiscountUpdate { get; set; }

        [JsonProperty("discount_delete")]
        public bool DiscountDelete { get; set; }

        [JsonProperty("cross_sell")]
        public bool CrossSell { get; set; }

        [JsonProperty("cross_sell_create")]
        public bool CrossSellCreate { get; set; }

        [JsonProperty("cross_sell_update")]
        public bool CrossSellUpdate { get; set; }

        [JsonProperty("cross_sell_delete")]
        public bool CrossSellDelete { get; set; }

        [JsonProperty("customers")]
        public bool Customers { get; set; }

        [JsonProperty("customer")]
        public bool Customer { get; set; }

        [JsonProperty("customer_create")]
        public bool CustomerCreate { get; set; }

        [JsonProperty("customer_update")]
        public bool CustomerUpdate { get; set; }

        [JsonProperty("customer_delete")]
        public bool CustomerDelete { get; set; }

        [JsonProperty("customer_balance")]
        public bool CustomerBalance { get; set; }

        [JsonProperty("customer_balance_update")]
        public bool CustomerBalanceUpdate { get; set; }

        [JsonProperty("call_record")]
        public bool CallRecord { get; set; }

        [JsonProperty("call_record_create")]
        public bool CallRecordCreate { get; set; }

        [JsonProperty("call_record_update")]
        public bool CallRecordUpdate { get; set; }

        [JsonProperty("call_record_delete")]
        public bool CallRecordDelete { get; set; }

        [JsonProperty("sale")]
        public bool Sale { get; set; }

        [JsonProperty("sale_create")]
        public bool SaleCreate { get; set; }

        [JsonProperty("sale_update")]
        public bool SaleUpdate { get; set; }

        [JsonProperty("sale_delete")]
        public bool SaleDelete { get; set; }

        [JsonProperty("sale_order")]
        public bool SaleOrder { get; set; }

        [JsonProperty("sale_order_create")]
        public bool SaleOrderCreate { get; set; }

        [JsonProperty("sale_order_update")]
        public bool SaleOrderUpdate { get; set; }

        [JsonProperty("sale_order_delete")]
        public bool SaleOrderDelete { get; set; }

        [JsonProperty("installment_plan")]
        public bool InstallmentPlan { get; set; }

        [JsonProperty("products")]
        public bool Products { get; set; }

        [JsonProperty("product")]
        public bool Product { get; set; }

        [JsonProperty("semi_product")]
        public bool SemiProduct { get; set; }

        [JsonProperty("semi_product_create")]
        public bool SemiProductCreate { get; set; }

        [JsonProperty("semi_product_update")]
        public bool SemiProductUpdate { get; set; }

        [JsonProperty("semi_product_delete")]
        public bool SemiProductDelete { get; set; }

        [JsonProperty("product_amount")]
        public bool ProductAmount { get; set; }

        [JsonProperty("product_stock")]
        public bool ProductStock { get; set; }

        [JsonProperty("product_create")]
        public bool ProductCreate { get; set; }

        [JsonProperty("product_update")]
        public bool ProductUpdate { get; set; }

        [JsonProperty("product_delete")]
        public bool ProductDelete { get; set; }

        [JsonProperty("product_category")]
        public bool ProductCategory { get; set; }

        [JsonProperty("product_category_create")]
        public bool ProductCategoryCreate { get; set; }

        [JsonProperty("product_category_update")]
        public bool ProductCategoryUpdate { get; set; }

        [JsonProperty("product_category_delete")]
        public bool ProductCategoryDelete { get; set; }

        [JsonProperty("etiket")]
        public bool Etiket { get; set; }

        [JsonProperty("product_income")]
        public bool ProductIncome { get; set; }

        [JsonProperty("product_income_create")]
        public bool ProductIncomeCreate { get; set; }

        [JsonProperty("product_income_update")]
        public bool ProductIncomeUpdate { get; set; }

        [JsonProperty("product_income_delete")]
        public bool ProductIncomeDelete { get; set; }

        [JsonProperty("transfer_request")]
        public bool TransferRequest { get; set; }

        [JsonProperty("transfer_request_create")]
        public bool TransferRequestCreate { get; set; }

        [JsonProperty("transfer_request_update")]
        public bool TransferRequestUpdate { get; set; }

        [JsonProperty("organizational_transfer_request")]
        public bool OrganizationalTransferRequest { get; set; }

        [JsonProperty("organizational_transfer_request_create")]
        public bool OrganizationalTransferRequestCreate { get; set; }

        [JsonProperty("organizational_transfer_request_update")]
        public bool OrganizationalTransferRequestUpdate { get; set; }

        [JsonProperty("purchase_return")]
        public bool PurchaseReturn { get; set; }

        [JsonProperty("purchase_return_create")]
        public bool PurchaseReturnCreate { get; set; }

        [JsonProperty("purchase_return_update")]
        public bool PurchaseReturnUpdate { get; set; }

        [JsonProperty("supply")]
        public bool Supply { get; set; }

        [JsonProperty("supplier")]
        public bool Supplier { get; set; }

        [JsonProperty("supplier_create")]
        public bool SupplierCreate { get; set; }

        [JsonProperty("supplier_update")]
        public bool SupplierUpdate { get; set; }

        [JsonProperty("supplier_delete")]
        public bool SupplierDelete { get; set; }

        [JsonProperty("supplier_balance")]
        public bool SupplierBalance { get; set; }

        [JsonProperty("supplier_balance_update")]
        public bool SupplierBalanceUpdate { get; set; }

        [JsonProperty("person_balance")]
        public bool PersonBalance { get; set; }

        [JsonProperty("product_order")]
        public bool ProductOrder { get; set; }

        [JsonProperty("product_order_create")]
        public bool ProductOrderCreate { get; set; }

        [JsonProperty("product_order_update")]
        public bool ProductOrderUpdate { get; set; }

        [JsonProperty("product_order_delete")]
        public bool ProductOrderDelete { get; set; }

        [JsonProperty("material_order")]
        public bool MaterialOrder { get; set; }

        [JsonProperty("material_order_create")]
        public bool MaterialOrderCreate { get; set; }

        [JsonProperty("material_order_update")]
        public bool MaterialOrderUpdate { get; set; }

        [JsonProperty("material_order_delete")]
        public bool MaterialOrderDelete { get; set; }

        [JsonProperty("hr")]
        public bool Hr { get; set; }

        [JsonProperty("employee")]
        public bool Employee { get; set; }

        [JsonProperty("employee_create")]
        public bool EmployeeCreate { get; set; }

        [JsonProperty("employee_update")]
        public bool EmployeeUpdate { get; set; }

        [JsonProperty("employee_delete")]
        public bool EmployeeDelete { get; set; }

        [JsonProperty("employee_balance")]
        public bool EmployeeBalance { get; set; }

        [JsonProperty("employee_balance_update")]
        public bool EmployeeBalanceUpdate { get; set; }

        [JsonProperty("attendance")]
        public bool Attendance { get; set; }

        [JsonProperty("attendance_create")]
        public bool AttendanceCreate { get; set; }

        [JsonProperty("attendance_update")]
        public bool AttendanceUpdate { get; set; }

        [JsonProperty("attendance_delete")]
        public bool AttendanceDelete { get; set; }

        [JsonProperty("position")]
        public bool Position { get; set; }

        [JsonProperty("position_create")]
        public bool PositionCreate { get; set; }

        [JsonProperty("position_update")]
        public bool PositionUpdate { get; set; }

        [JsonProperty("position_delete")]
        public bool PositionDelete { get; set; }

        [JsonProperty("section")]
        public bool Section { get; set; }

        [JsonProperty("section_create")]
        public bool SectionCreate { get; set; }

        [JsonProperty("section_update")]
        public bool SectionUpdate { get; set; }

        [JsonProperty("section_delete")]
        public bool SectionDelete { get; set; }

        [JsonProperty("role")]
        public bool Role { get; set; }

        [JsonProperty("role_create")]
        public bool RoleCreate { get; set; }

        [JsonProperty("role_update")]
        public bool RoleUpdate { get; set; }

        [JsonProperty("role_delete")]
        public bool RoleDelete { get; set; }

        [JsonProperty("salary")]
        public bool Salary { get; set; }

        [JsonProperty("salary_create")]
        public bool SalaryCreate { get; set; }

        [JsonProperty("salary_update")]
        public bool SalaryUpdate { get; set; }

        [JsonProperty("schedule")]
        public bool Schedule { get; set; }

        [JsonProperty("schedule_create")]
        public bool ScheduleCreate { get; set; }

        [JsonProperty("schedule_update")]
        public bool ScheduleUpdate { get; set; }

        [JsonProperty("schedule_delete")]
        public bool ScheduleDelete { get; set; }

        [JsonProperty("purchase_reason")]
        public bool PurchaseReason { get; set; }

        [JsonProperty("purchase_reason_create")]
        public bool PurchaseReasonCreate { get; set; }

        [JsonProperty("purchase_reason_update")]
        public bool PurchaseReasonUpdate { get; set; }

        [JsonProperty("purchase_reason_delete")]
        public bool PurchaseReasonDelete { get; set; }

        [JsonProperty("purchase_request")]
        public bool PurchaseRequest { get; set; }

        [JsonProperty("purchase_request_create")]
        public bool PurchaseRequestCreate { get; set; }

        [JsonProperty("purchase_request_update")]
        public bool PurchaseRequestUpdate { get; set; }

        [JsonProperty("purchase_order")]
        public bool PurchaseOrder { get; set; }

        [JsonProperty("purchase_order_create")]
        public bool PurchaseOrderCreate { get; set; }

        [JsonProperty("purchase_order_update")]
        public bool PurchaseOrderUpdate { get; set; }

        [JsonProperty("income")]
        public bool Income { get; set; }

        [JsonProperty("income_create")]
        public bool IncomeCreate { get; set; }

        [JsonProperty("purchase")]
        public bool Purchase { get; set; }

        [JsonProperty("purchase_create")]
        public bool PurchaseCreate { get; set; }

        [JsonProperty("purchase_update")]
        public bool PurchaseUpdate { get; set; }

        [JsonProperty("warehouse")]
        public bool Warehouse { get; set; }

        [JsonProperty("storekeeper")]
        public bool Storekeeper { get; set; }

        [JsonProperty("material")]
        public bool Material { get; set; }

        [JsonProperty("material_create")]
        public bool MaterialCreate { get; set; }

        [JsonProperty("material_update")]
        public bool MaterialUpdate { get; set; }

        [JsonProperty("material_delete")]
        public bool MaterialDelete { get; set; }
        [JsonProperty("material_category")]
        public bool MaterialCategory { get; set; }

        [JsonProperty("material_category_create")]
        public bool MaterialCategoryCreate { get; set; }

        [JsonProperty("material_category_update")]
        public bool MaterialCategoryUpdate { get; set; }

        [JsonProperty("material_category_delete")]
        public bool MaterialCategoryDelete { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("active_create")]
        public bool ActiveCreate { get; set; }

        [JsonProperty("active_update")]
        public bool ActiveUpdate { get; set; }

        [JsonProperty("active_delete")]
        public bool ActiveDelete { get; set; }

        [JsonProperty("material_income")]
        public bool MaterialIncome { get; set; }

        [JsonProperty("material_income_create")]
        public bool MaterialIncomeCreate { get; set; }

        [JsonProperty("material_income_update")]
        public bool MaterialIncomeUpdate { get; set; }

        [JsonProperty("material_income_delete")]
        public bool MaterialIncomeDelete { get; set; }

        [JsonProperty("material_transfer")]
        public bool MaterialTransfer { get; set; }

        [JsonProperty("material_transfer_create")]
        public bool MaterialTransferCreate { get; set; }

        [JsonProperty("material_transfer_update")]
        public bool MaterialTransferUpdate { get; set; }

        [JsonProperty("material_transfer_delete")]
        public bool MaterialTransferDelete { get; set; }

        [JsonProperty("public_transfer_request")]
        public bool publicTransferRequest { get; set; }

        [JsonProperty("public_transfer_request_create")]
        public bool publicTransferRequestCreate { get; set; }

        [JsonProperty("public_transfer_request_update")]
        public bool publicTransferRequestUpdate { get; set; }

        [JsonProperty("public_transfer")]
        public bool publicTransfer { get; set; }

        [JsonProperty("public_transfer_create")]
        public bool publicTransferCreate { get; set; }

        [JsonProperty("public_transfer_update")]
        public bool publicTransferUpdate { get; set; }

        [JsonProperty("organizational_transfer")]
        public bool OrganizationalTransfer { get; set; }

        [JsonProperty("organizational_transfer_create")]
        public bool OrganizationalTransferCreate { get; set; }

        [JsonProperty("organizational_transfer_update")]
        public bool OrganizationalTransferUpdate { get; set; }

        [JsonProperty("material_return")]
        public bool MaterialReturn { get; set; }

        [JsonProperty("material_return_create")]
        public bool MaterialReturnCreate { get; set; }

        [JsonProperty("material_return_update")]
        public bool MaterialReturnUpdate { get; set; }

        [JsonProperty("material_return_delete")]
        public bool MaterialReturnDelete { get; set; }

        [JsonProperty("finance")]
        public bool Finance { get; set; }

        [JsonProperty("cashbox")]
        public bool Cashbox { get; set; }

        [JsonProperty("cashbox_balance_update")]
        public bool CashboxBalanceUpdate { get; set; }

        [JsonProperty("transactions")]
        public bool Transactions { get; set; }

        [JsonProperty("transaction_update")]
        public bool TransactionUpdate { get; set; }

        [JsonProperty("cash_income")]
        public bool CashIncome { get; set; }

        [JsonProperty("cash_expense")]
        public bool CashExpense { get; set; }

        [JsonProperty("cash_exchange")]
        public bool CashExchange { get; set; }

        [JsonProperty("cash_exchange_method")]
        public bool CashExchangeMethod { get; set; }

        [JsonProperty("cash_transfer")]
        public bool CashTransfer { get; set; }

        [JsonProperty("cashbox_create")]
        public bool CashboxCreate { get; set; }

        [JsonProperty("cashbox_update")]
        public bool CashboxUpdate { get; set; }

        [JsonProperty("cashbox_delete")]
        public bool CashboxDelete { get; set; }

        [JsonProperty("payment_type")]
        public bool PaymentType { get; set; }

        [JsonProperty("payment_type_create")]
        public bool PaymentTypeCreate { get; set; }

        [JsonProperty("payment_type_update")]
        public bool PaymentTypeUpdate { get; set; }

        [JsonProperty("payment_type_delete")]
        public bool PaymentTypeDelete { get; set; }

        [JsonProperty("inventorization")]
        public bool Inventorization { get; set; }

        [JsonProperty("inventorization_create")]
        public bool InventorizationCreate { get; set; }

        [JsonProperty("inventorization_update")]
        public bool InventorizationUpdate { get; set; }

        [JsonProperty("inventorization_delete")]
        public bool InventorizationDelete { get; set; }

        [JsonProperty("invoice")]
        public bool Invoice { get; set; }

        [JsonProperty("invoice_create")]
        public bool InvoiceCreate { get; set; }

        [JsonProperty("invoice_income_create")]
        public bool InvoiceIncomeCreate { get; set; }

        [JsonProperty("invoice_expense_create")]
        public bool InvoiceExpenseCreate { get; set; }

        [JsonProperty("invoice_update")]
        public bool InvoiceUpdate { get; set; }

        [JsonProperty("invoice_delete")]
        public bool InvoiceDelete { get; set; }

        [JsonProperty("tax")]
        public bool Tax { get; set; }

        [JsonProperty("tax_create")]
        public bool TaxCreate { get; set; }

        [JsonProperty("tax_update")]
        public bool TaxUpdate { get; set; }

        [JsonProperty("tax_delete")]
        public bool TaxDelete { get; set; }

        [JsonProperty("document")]
        public bool Document { get; set; }

        [JsonProperty("document_create")]
        public bool DocumentCreate { get; set; }

        [JsonProperty("document_update")]
        public bool DocumentUpdate { get; set; }

        [JsonProperty("document_delete")]
        public bool DocumentDelete { get; set; }

        [JsonProperty("currency")]
        public bool Currency { get; set; }

        [JsonProperty("currency_create")]
        public bool CurrencyCreate { get; set; }

        [JsonProperty("currency_update")]
        public bool CurrencyUpdate { get; set; }

        [JsonProperty("currency_delete")]
        public bool CurrencyDelete { get; set; }

        [JsonProperty("reference")]
        public bool Reference { get; set; }

        [JsonProperty("tasks")]
        public bool Tasks { get; set; }

        [JsonProperty("task_create")]
        public bool TaskCreate { get; set; }

        [JsonProperty("task_update")]
        public bool TaskUpdate { get; set; }

        [JsonProperty("task_delete")]
        public bool TaskDelete { get; set; }

        [JsonProperty("states")]
        public bool States { get; set; }

        [JsonProperty("states_create")]
        public bool StatesCreate { get; set; }

        [JsonProperty("states_update")]
        public bool StatesUpdate { get; set; }

        [JsonProperty("states_delete")]
        public bool StatesDelete { get; set; }

        [JsonProperty("settings")]
        public bool Settings { get; set; }

        [JsonProperty("payment_methods")]
        public bool PaymentMethods { get; set; }

        [JsonProperty("payment_method_create")]
        public bool PaymentMethodCreate { get; set; }

        [JsonProperty("payment_method_update")]
        public bool PaymentMethodUpdate { get; set; }

        [JsonProperty("payment_method_delete")]
        public bool PaymentMethodDelete { get; set; }

        [JsonProperty("receipt_detail_get")]
        public bool ReceiptDetailGet { get; set; }

        [JsonProperty("receipt_detail_set")]
        public bool ReceiptDetailSet { get; set; }

        [JsonProperty("devices")]
        public bool Devices { get; set; }

        [JsonProperty("device_create")]
        public bool DeviceCreate { get; set; }

        [JsonProperty("device_update")]
        public bool DeviceUpdate { get; set; }

        [JsonProperty("device_delete")]
        public bool DeviceDelete { get; set; }

        [JsonProperty("product_history")]
        public bool ProductHistory { get; set; }

        [JsonProperty("web_hook")]
        public bool WebHook { get; set; }

        [JsonProperty("web_hook_create")]
        public bool WebHookCreate { get; set; }

        [JsonProperty("web_hook_update")]
        public bool WebHookUpdate { get; set; }

        [JsonProperty("web_hook_delete")]
        public bool WebHookDelete { get; set; }

        [JsonProperty("integrations")]
        public bool Integrations { get; set; }

        [JsonProperty("integration")]
        public bool Integration { get; set; }

        [JsonProperty("integration_create")]
        public bool IntegrationCreate { get; set; }

        [JsonProperty("integration_update")]
        public bool IntegrationUpdate { get; set; }

        [JsonProperty("integration_delete")]
        public bool IntegrationDelete { get; set; }

        [JsonProperty("sms_template")]
        public bool SmsTemplate { get; set; }

        [JsonProperty("sms_template_create")]
        public bool SmsTemplateCreate { get; set; }

        [JsonProperty("sms_template_update")]
        public bool SmsTemplateUpdate { get; set; }

        [JsonProperty("sms_template_delete")]
        public bool SmsTemplateDelete { get; set; }

        [JsonProperty("price")]
        public bool Price { get; set; }

        [JsonProperty("price_create")]
        public bool PriceCreate { get; set; }

        [JsonProperty("price_update")]
        public bool PriceUpdate { get; set; }

        [JsonProperty("price_delete")]
        public bool PriceDelete { get; set; }
        [JsonProperty("legal_person")]
        public bool LegalPerson { get; set; }

        [JsonProperty("legal_person_create")]
        public bool LegalPersonCreate { get; set; }

        [JsonProperty("legal_person_update")]
        public bool LegalPersonUpdate { get; set; }

        [JsonProperty("legal_person_delete")]
        public bool LegalPersonDelete { get; set; }

        [JsonProperty("natural_person")]
        public bool NaturalPerson { get; set; }

        [JsonProperty("natural_person_create")]
        public bool NaturalPersonCreate { get; set; }

        [JsonProperty("natural_person_update")]
        public bool NaturalPersonUpdate { get; set; }

        [JsonProperty("natural_person_delete")]
        public bool NaturalPersonDelete { get; set; }

        [JsonProperty("units_of_measure")]
        public bool UnitsOfMeasure { get; set; }

        [JsonProperty("units_of_measure_create")]
        public bool UnitsOfMeasureCreate { get; set; }

        [JsonProperty("units_of_measure_update")]
        public bool UnitsOfMeasureUpdate { get; set; }

        [JsonProperty("units_of_measure_delete")]
        public bool UnitsOfMeasureDelete { get; set; }

        [JsonProperty("reason")]
        public bool Reason { get; set; }

        [JsonProperty("reason_create")]
        public bool ReasonCreate { get; set; }

        [JsonProperty("reason_update")]
        public bool ReasonUpdate { get; set; }

        [JsonProperty("reason_delete")]
        public bool ReasonDelete { get; set; }

        [JsonProperty("box_types")]
        public bool BoxTypes { get; set; }

        [JsonProperty("box_types_create")]
        public bool BoxTypesCreate { get; set; }

        [JsonProperty("box_types_update")]
        public bool BoxTypesUpdate { get; set; }

        [JsonProperty("box_types_delete")]
        public bool BoxTypesDelete { get; set; }

        [JsonProperty("warehouse_get")]
        public bool WarehouseGet { get; set; }

        [JsonProperty("warehouse_get_create")]
        public bool WarehouseGetCreate { get; set; }

        [JsonProperty("warehouse_get_update")]
        public bool WarehouseGetUpdate { get; set; }

        [JsonProperty("warehouse_get_delete")]
        public bool WarehouseGetDelete { get; set; }

        [JsonProperty("warehouse_type")]
        public bool WarehouseType { get; set; }

        [JsonProperty("warehouse_type_create")]
        public bool WarehouseTypeCreate { get; set; }

        [JsonProperty("warehouse_type_update")]
        public bool WarehouseTypeUpdate { get; set; }

        [JsonProperty("warehouse_type_delete")]
        public bool WarehouseTypeDelete { get; set; }

        [JsonProperty("extra_cost")]
        public bool ExtraCost { get; set; }

        [JsonProperty("extra_cost_create")]
        public bool ExtraCostCreate { get; set; }

        [JsonProperty("extra_cost_update")]
        public bool ExtraCostUpdate { get; set; }

        [JsonProperty("extra_cost_delete")]
        public bool ExtraCostDelete { get; set; }

        [JsonProperty("write_off")]
        public bool WriteOff { get; set; }

        [JsonProperty("write_off_create")]
        public bool WriteOffCreate { get; set; }

        [JsonProperty("write_off_update")]
        public bool WriteOffUpdate { get; set; }

        [JsonProperty("write_off_delete")]
        public bool WriteOffDelete { get; set; }

        [JsonProperty("supplier_return_reason")]
        public bool SupplierReturnReason { get; set; }

        [JsonProperty("supplier_return_reason_create")]
        public bool SupplierReturnReasonCreate { get; set; }

        [JsonProperty("supplier_return_reason_update")]
        public bool SupplierReturnReasonUpdate { get; set; }

        [JsonProperty("supplier_return_reason_delete")]
        public bool SupplierReturnReasonDelete { get; set; }

        [JsonProperty("customer_return_reason")]
        public bool CustomerReturnReason { get; set; }

        [JsonProperty("customer_return_reason_create")]
        public bool CustomerReturnReasonCreate { get; set; }

        [JsonProperty("customer_return_reason_update")]
        public bool CustomerReturnReasonUpdate { get; set; }

        [JsonProperty("customer_return_reason_delete")]
        public bool CustomerReturnReasonDelete { get; set; }

        [JsonProperty("purchase_request_reason")]
        public bool PurchaseRequestReason { get; set; }

        [JsonProperty("purchase_request_reason_create")]
        public bool PurchaseRequestReasonCreate { get; set; }

        [JsonProperty("purchase_request_reason_update")]
        public bool PurchaseRequestReasonUpdate { get; set; }

        [JsonProperty("purchase_request_reason_delete")]
        public bool PurchaseRequestReasonDelete { get; set; }

        [JsonProperty("contract_cancel_reason")]
        public bool ContractCancelReason { get; set; }

        [JsonProperty("contract_cancel_reason_create")]
        public bool ContractCancelReasonCreate { get; set; }

        [JsonProperty("contract_cancel_reason_update")]
        public bool ContractCancelReasonUpdate { get; set; }

        [JsonProperty("contract_cancel_reason_delete")]
        public bool ContractCancelReasonDelete { get; set; }

        [JsonProperty("order_cancel_reason")]
        public bool OrderCancelReason { get; set; }

        [JsonProperty("order_cancel_reason_create")]
        public bool OrderCancelReasonCreate { get; set; }

        [JsonProperty("order_cancel_reason_update")]
        public bool OrderCancelReasonUpdate { get; set; }

        [JsonProperty("order_cancel_reason_delete")]
        public bool OrderCancelReasonDelete { get; set; }

        [JsonProperty("transfer_reason")]
        public bool TransferReason { get; set; }

        [JsonProperty("transfer_reason_create")]
        public bool TransferReasonCreate { get; set; }

        [JsonProperty("transfer_reason_update")]
        public bool TransferReasonUpdate { get; set; }

        [JsonProperty("transfer_reason_delete")]
        public bool TransferReasonDelete { get; set; }

        [JsonProperty("transfer_cancel_reason")]
        public bool TransferCancelReason { get; set; }

        [JsonProperty("transfer_cancel_reason_create")]
        public bool TransferCancelReasonCreate { get; set; }

        [JsonProperty("transfer_cancel_reason_update")]
        public bool TransferCancelReasonUpdate { get; set; }

        [JsonProperty("transfer_cancel_reason_delete")]
        public bool TransferCancelReasonDelete { get; set; }

        [JsonProperty("write_off_reason")]
        public bool WriteOffReason { get; set; }

        [JsonProperty("write_off_reason_create")]
        public bool WriteOffReasonCreate { get; set; }

        [JsonProperty("write_off_reason_update")]
        public bool WriteOffReasonUpdate { get; set; }

        [JsonProperty("write_off_reason_delete")]
        public bool WriteOffReasonDelete { get; set; }

        [JsonProperty("update_balance")]
        public bool UpdateBalance { get; set; }

        [JsonProperty("sale_refund")]
        public bool SaleRefund { get; set; }

        [JsonProperty("sale_refund_create")]
        public bool SaleRefundCreate { get; set; }

        [JsonProperty("sale_refund_update")]
        public bool SaleRefundUpdate { get; set; }

        [JsonProperty("producer")]
        public bool Producer { get; set; }

        [JsonProperty("producer_create")]
        public bool ProducerCreate { get; set; }

        [JsonProperty("producer_update")]
        public bool ProducerUpdate { get; set; }

        [JsonProperty("producer_delete")]
        public bool ProducerDelete { get; set; }

        [JsonProperty("brand")]
        public bool Brand { get; set; }

        [JsonProperty("brand_create")]
        public bool BrandCreate { get; set; }

        [JsonProperty("brand_update")]
        public bool BrandUpdate { get; set; }

        [JsonProperty("brand_delete")]
        public bool BrandDelete { get; set; }

        [JsonProperty("sale_price_update")]
        public bool SalePriceUpdate { get; set; }

        [JsonProperty("income_price_update")]
        public bool IncomePriceUpdate { get; set; }

        [JsonProperty("attribute")]
        public bool Attribute { get; set; }

        [JsonProperty("attribute_create")]
        public bool AttributeCreate { get; set; }

        [JsonProperty("attribute_update")]
        public bool AttributeUpdate { get; set; }

        [JsonProperty("contract")]
        public bool Contract { get; set; }

        [JsonProperty("contract_create")]
        public bool ContractCreate { get; set; }

        [JsonProperty("contract_update")]
        public bool ContractUpdate { get; set; }

        [JsonProperty("contract_delete")]
        public bool ContractDelete { get; set; }

        [JsonProperty("supplier_category")]
        public bool SupplierCategory { get; set; }

        [JsonProperty("supplier_category_create")]
        public bool SupplierCategoryCreate { get; set; }

        [JsonProperty("supplier_category_update")]
        public bool SupplierCategoryUpdate { get; set; }

        [JsonProperty("supplier_category_delete")]
        public bool SupplierCategoryDelete { get; set; }

        [JsonProperty("customer_category")]
        public bool CustomerCategory { get; set; }

        [JsonProperty("customer_category_create")]
        public bool CustomerCategoryCreate { get; set; }

        [JsonProperty("customer_category_update")]
        public bool CustomerCategoryUpdate { get; set; }

        [JsonProperty("customer_category_delete")]
        public bool CustomerCategoryDelete { get; set; }

        [JsonProperty("product_price_set")]
        public bool ProductPriceSet { get; set; }

        [JsonProperty("cashback")]
        public bool Cashback { get; set; }

        [JsonProperty("production")]
        public bool Production { get; set; }

        [JsonProperty("production_route_sheet")]
        public bool ProductionRouteSheet { get; set; }

        [JsonProperty("production_route_sheet_create")]
        public bool ProductionRouteSheetCreate { get; set; }

        [JsonProperty("production_route_sheet_update")]
        public bool ProductionRouteSheetUpdate { get; set; }

        [JsonProperty("production_route_sheet_delete")]
        public bool ProductionRouteSheetDelete { get; set; }

        [JsonProperty("production_operation")]
        public bool ProductionOperation { get; set; }

        [JsonProperty("production_operation_create")]
        public bool ProductionOperationCreate { get; set; }

        [JsonProperty("production_operation_update")]
        public bool ProductionOperationUpdate { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("mobile")]
        public bool Mobile { get; set; }
    }
}
