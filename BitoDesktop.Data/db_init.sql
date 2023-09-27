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

