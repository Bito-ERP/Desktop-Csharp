CREATE TABLE IF NOT EXISTS product_organization(
	organizationId TEXT NOT NULL,
	productId TEXT NOT NULL,
	amount REAL NOT NULL,
	inTransit REAL NOT NULL,
	trash REAL NOT NULL,
	booked REAL NOT NULL,
	yellowLine REAL,
	redLine REAL,
	maxStock REAL,
	isAvailable BOOLEAN,
	isAvailableForSale BOOLEAN,
	PRIMARY KEY(
		organizationId,
		productId
	)
);

CREATE TABLE IF NOT EXISTS product_warehouse(
    id TEXT NOT NULL PRIMARY KEY,
	warehouseId TEXT NOT NULL,
	organizationId TEXT NOT NULL,
	productId TEXT NOT NULL,
	booked REAL NOT NULL,
	inTrash REAL NOT NULL,
	inTransit REAL NOT NULL,
	amount REAL NOT NULL
);

CREATE TABLE IF NOT EXISTS product_price(
    id TEXT NOT NULL PRIMARY KEY,
	priceId TEXT NOT NULL,
	organizationId TEXT NOT NULL,
	productId TEXT NOT NULL,
	priceAmount REAL NOT NULL,
	minPrice REAL,
	maxPrice REAL,
	minSaleAmount REAL
);

CREATE TABLE IF NOT EXISTS product(
     id TEXT NOT NULL PRIMARY KEY,
     name TEXT NOT NULL,
     categoryId TEXT,
     categoryName TEXT,
     boxTypeId TEXT,
     boxItem REAL NOT NULL,
     boxItemBarcode TEXT,
     unitMeasurementId TEXT NOT NULL,
     sku TEXT NOT NULL,
     barcode TEXT,
     barcodes TEXT NOT NULL,
     image TEXT,
     isMarked BOOLEAN NOT NULL,
     isProduct BOOLEAN NOT NULL,
     isMaterial BOOLEAN NOT NULL,
     isSemiProduct BOOLEAN NOT NULL,
     taxIds TEXT,
     shape TEXT,
     netWeight REAL NOT NULL,
     grossWeight REAL NOT NULL,
     height REAL NOT NULL,
	 width REAL NOT NULL,
     volume REAL NOT NULL,
     diameter REAL NOT NULL,
     length REAL NOT NULL,
     suppliers TEXT
);

CREATE TABLE IF NOT EXISTS finance_tax(
    id TEXT NOT NULL PRIMARY KEY,
	name TEXT NOT NULL,
	rate REAL NOT NULL,
	type TEXT NOT NULL,
	toPrice BOOLEAN NOT NULL,
	isAll BOOLEAN NOT NULL,
	isAllCategories BOOLEAN NOT NULL,
	isAllSuppliers BOOLEAN NOT NULL,
	itemCount INTEGER,
	categoryIds TEXT,
	supplierIds TEXT,
	addedItemIds TEXT,
	removedItemIds TEXT,
	organizationIds TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS discount(
    id TEXT NOT NULL PRIMARY KEY,
	name TEXT NOT NULL,
	applyType TEXT NOT NULL,
	value REAL NOT NULL,
	currencyId TEXT,
	image TEXT
);

CREATE TABLE IF NOT EXISTS employee(
    id TEXT NOT NULL PRIMARY KEY,
    fullName TEXT NOT NULL,
    personId TEXT,
    personName TEXT,
    isBoss BOOLEAN NOT NULL,
    employmentType TEXT NOT NULL,
    workRate REAL NOT NULL,
    holidays INT NOT NULL,
    salary REAL NOT NULL,
    phoneNumber TEXT NOT NULL,
    pincode TEXT NOT NULL,
    bossId TEXT NOT NULL,
    address TEXT,
    birthDate TIMESTAMP WITH TIME ZONE,
    acceptanceDate TIMESTAMP WITH TIME ZONE NOT NULL,
    image TEXT,
    comment TEXT
);

CREATE TABLE IF NOT EXISTS employee_position(
    employeeId TEXT NOT NULL,
    organizationId TEXT NOT NULL,
    roleId TEXT NOT NULL,
    roleName TEXT NOT NULL,
    sectionId TEXT NOT NULL,
    sectionName TEXT,
    positionId TEXT NOT NULL,
    positionName TEXT,
	PRIMARY KEY(
		employeeId,
		organizationId,
		sectionId,
		positionId
	)
);

CREATE TABLE IF NOT EXISTS unit_measurement(
    id TEXT NOT NULL PRIMARY KEY,
    code TEXT,
    shortName TEXT,
    name TEXT NOT NULL,
    decimalCount INTEGER NOT NULL,
    status TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS currency(
    id TEXT NOT NULL PRIMARY KEY,
    name TEXT NOT NULL,
    values TEXT NOT NULL,
    side TEXT NOT NULL,
    isMain BOOL NOT NULL,
    symbol TEXT,
	updatedAt TIMESTAMP WITH TIME ZONE NOT NULL
);

CREATE TABLE IF NOT EXISTS payment_method(
    id TEXT NOT NULL PRIMARY KEY,
    name TEXT NOT NULL,
    isEnabled BOOL NOT NULL
);

CREATE TABLE IF NOT EXISTS receipt(
    uuid TEXT NOT NULL PRIMARY KEY,
    id TEXT NOT NULL,
    organizationId TEXT NOT NULL,
    counter INTEGER NOT NULL,
    synced BOOL NOT NULL,
    calcAddedTaxAfterDiscount BOOL NOT NULL,
    calcIncludedTaxAfterDiscount BOOL NOT NULL,
    calcSaleDiscountAfterProducts BOOL NOT NULL,
    totalToPay REAL NOT NULL,
    totalToRefund REAL,
    totalPrice REAL NOT NULL,
    productsTotalDiscount REAL NOT NULL,
    saleTotalDiscount REAL NOT NULL,
    totalIncludedTax REAL NOT NULL,
    totalAddedTax REAL NOT NULL,
    isRefund BOOL NOT NULL,
    state TEXT NOT NULL,
    number INTEGER NOT NULL,
    refundNumber INTEGER,
    refundUUID TEXT,
    cashboxId TEXT NOT NULL,
    cashboxName TEXT NOT NULL,
    deviceId TEXT,
    deviceName TEXT,
    creatorId TEXT NOT NULL,
    creatorName TEXT NOT NULL,
	responsibleId TEXT,
	responsibleName TEXT,
    customerId TEXT,
    customerName TEXT,
    currencyId TEXT NOT NULL,
    currencyName TEXT NOT NULL,
    currencySide TEXT NOT NULL,
    currencySymbol TEXT,
    baseCurrencyValue REAL NOT NULL,
    earnedCashbackId TEXT,
    earnedCashbackCurrencyId TEXT,
    earnedCashbackCurrencyName TEXT,
    earnedCashbackCurrencyValue REAL,
    earnedCashbackCurrencySide TEXT,
    earnedCashbackCurrencySymbol TEXT,
    earnedCashbackAmount REAL,
    customerBeforeBalance TEXT NOT NULL,
    customerAfterBalance TEXT NOT NULL,
    customerBeforeCashback TEXT NOT NULL,
    customerAfterCashback TEXT NOT NULL,
    warehouseId TEXT NOT NULL,
    warehouseName TEXT NOT NULL,
    contractId TEXT,
    contractCode TEXT,
    contractNumber TEXT,
    orderId TEXT,
    orderCode TEXT,
    orderNumber TEXT,
    deliveryLatitude REAL,
    deliveryLongitude REAL,
    deliveryLocationName TEXT,
    deliveryDate TIMESTAMP WITH TIME ZONE,
    isTrash BOOL,
    sendSms BOOL NOT NULL,
    soldAt TIMESTAMP WITH TIME ZONE NOT NULL,
    failed INTEGER NOT NULL,
    errorCode INTEGER NOT NULL,
    errorData TEXT
);

CREATE TABLE IF NOT EXISTS receipt_item (
    id TEXT NOT NULL PRIMARY KEY,
    receiptUUID TEXT NOT NULL,
    synced BOOL NOT NULL,
    productId TEXT NOT NULL,
    name TEXT NOT NULL,
    image TEXT,
    categoryName TEXT,
    sku TEXT NOT NULL,
    barcode TEXT,
    unitMeasurement TEXT NOT NULL,
    isMarked BOOL NOT NULL,
    amount REAL NOT NULL,
    amountInBox REAL,
    soldAmount REAL NOT NULL,
    refundAmount REAL NOT NULL,
    price REAL NOT NULL,
    realPrice REAL NOT NULL,
    productDiscount REAL NOT NULL,
    distributedDiscount REAL NOT NULL,
    includedTax REAL NOT NULL,
    addedTax REAL NOT NULL,
    discounts TEXT,
    taxes TEXT,
    marks TEXT
);

CREATE TABLE IF NOT EXISTS receipt_payment (
    id TEXT NOT NULL,
    receiptId TEXT NOT NULL,
    synced BOOL NOT NULL,
    amount REAL NOT NULL,
    paid REAL NOT NULL,
    baseCurrencyValue REAL NOT NULL,
    refunded REAL NOT NULL,
    paymentMethodId TEXT NOT NULL,
    paymentMethodName TEXT NOT NULL,
    currencyId TEXT NOT NULL,
    currencyName TEXT NOT NULL,
    currencyValue REAL NOT NULL,
    currencySide TEXT NOT NULL,
    currencySymbol TEXT,
    PRIMARY KEY (id, receiptId)
);

CREATE TABLE IF NOT EXISTS receipt_installment (
    id TEXT NOT NULL,
    receiptId TEXT NOT NULL,
    date TIMESTAMP WITH TIME ZONE NOT NULL,
    amount REAL NOT NULL,
    PRIMARY KEY (id, receiptId)
);

CREATE TABLE IF NOT EXISTS receipt_cashback (
    id TEXT NOT NULL,
    receiptId TEXT NOT NULL,
    amount REAL NOT NULL,
    paid REAL NOT NULL,
    baseCurrencyValue REAL NOT NULL,
    currencyId TEXT NOT NULL,
    currencyName TEXT NOT NULL,
    currencyValue REAL NOT NULL,
    currencySide TEXT NOT NULL,
    currencySymbol TEXT,
    PRIMARY KEY (id, receiptId)
);

CREATE TABLE IF NOT EXISTS receipt_discount (
    id TEXT NOT NULL,
    receiptId TEXT NOT NULL,
    name TEXT,
    applyType TEXT NOT NULL,
    value REAL NOT NULL,
    currencyId TEXT,
    isCustom BOOL NOT NULL,
    PRIMARY KEY (id, receiptId)
);

CREATE TABLE IF NOT EXISTS receipt_change (
    id TEXT NOT NULL,
    receiptId TEXT NOT NULL,
    amount REAL NOT NULL,
    paid REAL NOT NULL,
    baseCurrencyValue REAL NOT NULL,
    paymentMethodId TEXT NOT NULL,
    paymentMethodName TEXT NOT NULL,
    currencyId TEXT NOT NULL,
    currencyName TEXT NOT NULL,
    currencyValue REAL NOT NULL,
    currencySide TEXT NOT NULL,
    currencySymbol TEXT,
    PRIMARY KEY (id, receiptId)
);

CREATE TABLE IF NOT EXISTS invoice (
    id TEXT NOT NULL PRIMARY KEY,
    organizationId TEXT NOT NULL,
    type TEXT NOT NULL,
    number TEXT NOT NULL,
    paymentTypeId TEXT NOT NULL,
    paymentTypeName TEXT NOT NULL,
    userType TEXT,
    paymentFor TEXT,
    isRefund BOOL NOT NULL,
    date TIMESTAMP WITH TIME ZONE NOT NULL,
    customerId TEXT,
    customerName TEXT,
    employeeId TEXT,
    employeeName TEXT,
    supplierId TEXT,
    supplierName TEXT,
    personId TEXT,
    personName TEXT,
    toBePaid REAL NOT NULL,
    paid REAL NOT NULL,
    toBeRefunded REAL NOT NULL,
    refunded REAL NOT NULL,
    paidByBalance REAL NOT NULL,
    paidByCashback REAL NOT NULL,
    currencyId TEXT NOT NULL,
    tradeId TEXT
);

CREATE TABLE IF NOT EXISTS organization(
    id TEXT NOT NULL PRIMARY KEY,
	name TEXT NOT NULL,
	currencyId TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS price(
    id TEXT PRIMARY KEY,
    code TEXT,
    name TEXT NOT NULL,
    shortName TEXT,
    status TEXT NOT NULL,
    currencyId TEXT NOT NULL,
    type TEXT NOT NULL,
    minPrice REAL,
    maxPrice REAL,
    applyType TEXT NOT NULL,
    minSaleAmount REAL,
    isMain BOOL NOT NULL,
    canBeUpdated BOOL NOT NULL,
    employees TEXT
);

CREATE TABLE IF NOT EXISTS warehouse(
    id TEXT PRIMARY KEY,
    name TEXT NOT NULL,
    organizationId TEXT NOT NULL,
    responsibleEmployeeId TEXT NOT NULL,
    isMain BOOL NOT NULL,
    status TEXT NOT NULL,
    code TEXT
);

CREATE TABLE IF NOT EXISTS customer (
    id TEXT PRIMARY KEY NOT NULL,
    type TEXT NOT NULL,
    personId TEXT,
    personName TEXT,
    categoryId TEXT,
    categoryName TEXT,
    name TEXT NOT NULL,
    inn TEXT,
    phoneNumber TEXT,
    agentId TEXT,
    agentName TEXT,
    latitude REAL,
    longitude REAL,
    addressName TEXT,
    description TEXT,
    firstSale TIMESTAMP WITH TIME ZONE,
    lastSale TIMESTAMP WITH TIME ZONE,
    totalSale REAL NOT NULL,
    point REAL NOT NULL,
    organizations TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS customer_cashback (
    id TEXT PRIMARY KEY,
    customerId TEXT NOT NULL,
    amount REAL NOT NULL,
    currencyId TEXT NOT NULL
);


CREATE TABLE IF NOT EXISTS customer_total_balance (
    customerId TEXT NOT NULL,
    organizationId TEXT NOT NULL,
    balanceList TEXT NOT NULL,
    PRIMARY KEY (customerId, organizationId)
);

CREATE TABLE IF NOT EXISTS customer_balance_list (
    customerId TEXT NOT NULL,
    organizationId TEXT NOT NULL,
    balanceList TEXT NOT NULL,
    PRIMARY KEY (customerId, organizationId)
);

CREATE TABLE IF NOT EXISTS pos_table(
    id TEXT NOT NULL PRIMARY KEY,
	organizationId TEXT NOT NULL,
	name TEXT NOT NULL,
	"order" INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS ticket (
    id SERIAL PRIMARY KEY,
	organizationId TEXT NOT NULL,
    name TEXT NOT NULL,
    overallSum REAL NOT NULL,
    priceId TEXT NOT NULL,
    warehouseId TEXT NOT NULL,
    createdAt TIMESTAMP WITH TIME ZONE NOT NULL,
    tableId TEXT,
    comment TEXT,
    customerId TEXT,
	discounts TEXT
);

CREATE TABLE IF NOT EXISTS ticket_item (
    id SERIAL PRIMARY KEY,
    productId TEXT NOT NULL,
    price REAL NOT NULL,
    amount REAL NOT NULL,
    boxAmount INTEGER NOT NULL,
    ticketId INTEGER NOT NULL,
    totalAddedTax REAL NOT NULL,
    totalIncludedTax REAL NOT NULL,
	taxes TEXT, 
	totalDiscountCash REAL NOT NULL,
	totalDiscountPercent REAL NOT NULL,
    amountInBox REAL,
	discounts TEXT,
	marks TEXT
);

CREATE TABLE IF NOT EXISTS product_category (
    id TEXT PRIMARY KEY,
    name TEXT NOT NULL,
    parentId TEXT,
    parentName TEXT,
    image TEXT,
    itemCount INTEGER NOT NULL,
    childCount INTEGER NOT NULL,
    organizationIds TEXT
);

CREATE TABLE IF NOT EXISTS pos_page(
    id TEXT NOT NULL PRIMARY KEY,
	organizationId TEXT NOT NULL,
	name TEXT NOT NULL,
	"order" INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS pos_page(
    id TEXT NOT NULL PRIMARY KEY,
	organizationId TEXT NOT NULL,
	name TEXT NOT NULL,
	"order" INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS pos_page_item
(
    id TEXT PRIMARY KEY NOT NULL,
    type INT NOT NULL,
    "order" INT NOT NULL,
    pageId TEXT NOT NULL,
    itemId TEXT,
    itemName TEXT,
    itemImage TEXT,
    productUnitMeasurementId TEXT,
    productSku TEXT,
    productBarcode TEXT,
    isMarked BOOLEAN,
    amountInBox REAL,
    productCategoryId TEXT,
    productCategoryName TEXT,
    categoryChildCount INT,
    discountValue REAL,
    discountCurrencyId TEXT
);

CREATE TABLE IF NOT EXISTS reason (
    id TEXT PRIMARY KEY,
    name TEXT NOT NULL,
    description TEXT,
    type TEXT NOT NULL,
    isActive BOOL NOT NULL,
    isTrash BOOL,
    orderNumber INTEGER,
    code TEXT
);

CREATE TABLE IF NOT EXISTS printer (
    id TEXT PRIMARY KEY,
    name TEXT NOT NULL,
    type TEXT NOT NULL,
    address TEXT NOT NULL,
    paperWidth INTEGER NOT NULL,
    printReceipts BOOL NOT NULL,
    automaticallyPrintReceipts BOOL NOT NULL
);

CREATE TABLE IF NOT EXISTS cashback_setting (
    organizationId TEXT PRIMARY KEY,
    type TEXT,
    isActive BOOL,
    cashbacks TEXT
);

CREATE TABLE IF NOT EXISTS scale (
    id TEXT PRIMARY KEY  NOT NULL,
    organizationId TEXT NOT NULL,
    type INT NOT NULL,
    skuCount INT NOT NULL,
    sumCheckIndex INT NOT NULL,
    priceCount INT NOT NULL,
    weightCount INT NOT NULL,
    departmentCode INT NOT NULL,
    countAfterDot INT NOT NULL
);

CREATE TABLE IF NOT EXISTS configuration (
	key TEXT PRIMARY KEY NOT NULL,
	value TEXT
)

