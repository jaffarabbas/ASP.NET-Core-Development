/*products*/
CREATE TABLE PRODUCTS (
    P_ID INT PRIMARY KEY,
    P_NAME NVARCHAR(50) NOT NULL,
    P_DESCRIPTION NVARCHAR(50) NOT NULL,
    P_PRICE DECIMAL(20, 2) NOT NULL,
    P_IMAGE INT NOT NULL UNIQUE,
    P_CATEGORY INT NOT NULL,
    STATUS BIT DEFAULT 1,
    CREATED_AT DATETIME DEFAULT CURRENT_TIMESTAMP,
);

/*category*/

CREATE TABLE CATEGORIES (
    C_ID INT PRIMARY KEY,
    C_NAME NVARCHAR(50) NOT NULL,
    STATUS BIT DEFAULT 1,
    CREATED_AT DATETIME DEFAULT CURRENT_TIMESTAMP,
);

/*images*/

CREATE TABLE IMAGES (
    I_ID INT PRIMARY KEY,
    I_NAME NVARCHAR(50) NOT NULL,
    I_PATH NVARCHAR(50) NOT NULL,
    STATUS BIT DEFAULT 1,
    CREATED_AT DATETIME DEFAULT CURRENT_TIMESTAMP,
);

/*user login*/
CREATE TABLE USERS (
    U_ID INT PRIMARY KEY,
    U_EMAIL NVARCHAR(100) NOT NULL,
    U_PASS NVARCHAR(50) NOT NULL,
    STATUS BIT DEFAULT 1,
    CREATED_AT DATETIME DEFAULT CURRENT_TIMESTAMP,
);

/*user detials*/

CREATE TABLE USER_DETAILS (
    UD_ID INT PRIMARY KEY,
    UD_FNAME NVARCHAR(50) NOT NULL,
    UD_LNAME NVARCHAR(50) NOT NULL,
    UD_ACTYPE NVARCHAR(50) NOT NULL,
    UD_TYPE NVARCHAR(50) NOT NULL,
    UD_USER_ID INT NOT NULL,
    STATUS BIT DEFAULT 1,
    CREATED_AT DATETIME DEFAULT CURRENT_TIMESTAMP,
);