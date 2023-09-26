CREATE TABLE IF NOT EXISTS product_organization(
	organizationId TEXT NOT NULL,
	productId TEXT NOT NULL,
	amount REAL NOT NULL,
	inTransit REAL NOT NULL,
	trash REAL NOT NULL,
	booked REAL NOT NULL,
	_yellowLine REAL,
	_redLine REAL,
	_maxStock REAL,
	isAvailable BIT,
	_isAvailableForSale BIT,
	PRIMARY KEY(
		organizationId,
		productId
	)
);

CREATE TABLE IF NOT EXISTS product_warehouse(
    _id TEXT NOT NULL PRIMARY KEY,
	warehouseId TEXT NOT NULL,
	organizationId TEXT NOT NULL,
	productId TEXT NOT NULL,
	booked REAL NOT NULL,
	inTrash REAL NOT NULL,
	inTransit REAL NOT NULL,
	amount REAL NOT NULL
);

CREATE TABLE IF NOT EXISTS product_price(
    _id TEXT NOT NULL PRIMARY KEY,
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
     isMarked BIT NOT NULL,
     isProduct BIT NOT NULL,
     isMaterial BIT NOT NULL,
     isSemiProduct BIT NOT NULL,
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
	toPrice BIT NOT NULL,
	isAll BIT NOT NULL,
	isAllCategories BIT NOT NULL,
	isAllSuppliers BIT NOT NULL,
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


CREATE TABLE IF NOT EXISTS pos_page(
    id TEXT NOT NULL PRIMARY KEY,
	name TEXT NOT NULL,
	"order" INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS pos_table(
    id TEXT NOT NULL PRIMARY KEY,
	name TEXT NOT NULL,
	"order" INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS pos_ticket(
    id SERIAL NOT NULL PRIMARY KEY,
	name TEXT NOT NULL,
	overallSum REAL NOT NULL,
	priceId TEXT NOT NULL,
	warehouseId TEXT NOT NULL,
	createdAt INTEGER NOT NULL,
	tableId TEXT,
	comment TEXT,
	customerId TEXT,
	discounts TEXT
);

