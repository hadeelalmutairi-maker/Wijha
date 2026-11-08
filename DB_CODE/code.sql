
IF DB_ID('wijha_db') IS NULL
BEGIN
    CREATE DATABASE wijha_db;
END
GO

USE wijha_db;
GO

/* ---------------------------------------------------------------------
   1. ADMIN
   --------------------------------------------------------------------- */
CREATE TABLE admins (
    admin_id        INT IDENTITY(1,1) NOT NULL,
    full_name       NVARCHAR(100)     NOT NULL,
    email           NVARCHAR(150)     NOT NULL,
    password_hash   VARCHAR(255)      NOT NULL,
    phone           VARCHAR(20)       NOT NULL,
    admin_role      VARCHAR(20)       NOT NULL CONSTRAINT DF_admins_role DEFAULT ('Support Admin'),
    last_login      DATETIME2(0)      NULL,
    created_at      DATETIME2(0)      NOT NULL CONSTRAINT DF_admins_created_at DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_admins PRIMARY KEY (admin_id),
    CONSTRAINT UQ_admins_email UNIQUE (email),
    CONSTRAINT UQ_admins_phone UNIQUE (phone),
    CONSTRAINT CK_admins_role CHECK (admin_role IN ('Super Admin','Support Admin'))
);
GO

/* ---------------------------------------------------------------------
   2. CUSTOMER
   --------------------------------------------------------------------- */
CREATE TABLE customers (
    customer_id        INT IDENTITY(1,1) NOT NULL,
    first_name          NVARCHAR(60)      NOT NULL,
    last_name           NVARCHAR(60)      NOT NULL,
    email               NVARCHAR(150)     NOT NULL,
    password_hash       VARCHAR(255)      NOT NULL,
    phone               VARCHAR(20)       NOT NULL,
    gender              VARCHAR(10)       NULL,
    city                NVARCHAR(60)      NOT NULL,
    profile_image_url   NVARCHAR(255)     NULL,
    account_status      VARCHAR(20)       NOT NULL CONSTRAINT DF_customers_status DEFAULT ('Active'),
    registration_date   DATETIME2(0)      NOT NULL CONSTRAINT DF_customers_reg_date DEFAULT (SYSDATETIME()),
    last_login          DATETIME2(0)      NULL,
    CONSTRAINT PK_customers PRIMARY KEY (customer_id),
    CONSTRAINT UQ_customers_email UNIQUE (email),
    CONSTRAINT UQ_customers_phone UNIQUE (phone),
    CONSTRAINT CK_customers_gender CHECK (gender IN ('Male','Female')),
    CONSTRAINT CK_customers_status CHECK (account_status IN ('Active','Blocked'))
);
GO

/* ---------------------------------------------------------------------
   3. SERVICE_PROVIDER
   --------------------------------------------------------------------- */
CREATE TABLE service_providers (
    provider_id             INT IDENTITY(1,1) NOT NULL,
    admin_id                INT               NULL,
    business_name           NVARCHAR(150)     NOT NULL,
    owner_name              NVARCHAR(100)     NOT NULL,
    email                   NVARCHAR(150)     NOT NULL,
    password_hash           VARCHAR(255)      NOT NULL,
    phone                   VARCHAR(20)       NOT NULL,
    city                    NVARCHAR(60)      NOT NULL,
    business_address        NVARCHAR(255)     NOT NULL,
    business_description    NVARCHAR(1000)    NULL,
    commercial_register_no  VARCHAR(20)       NOT NULL,
    logo_url                NVARCHAR(255)     NULL,
    average_rating          DECIMAL(3,2)      NOT NULL CONSTRAINT DF_providers_rating DEFAULT (0),
    total_reviews           INT               NOT NULL CONSTRAINT DF_providers_total_reviews DEFAULT (0),
    approval_status         VARCHAR(20)       NOT NULL CONSTRAINT DF_providers_approval DEFAULT ('Pending'),
    account_status          VARCHAR(20)       NOT NULL CONSTRAINT DF_providers_status DEFAULT ('Active'),
    subscription_start_date DATE              NULL,
    subscription_end_date   DATE              NULL,
    registration_date       DATETIME2(0)      NOT NULL CONSTRAINT DF_providers_reg_date DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_service_providers PRIMARY KEY (provider_id),
    CONSTRAINT UQ_service_providers_email UNIQUE (email),
    CONSTRAINT UQ_service_providers_phone UNIQUE (phone),
    CONSTRAINT UQ_service_providers_cr_no UNIQUE (commercial_register_no),
    CONSTRAINT FK_service_providers_admin FOREIGN KEY (admin_id)
        REFERENCES admins (admin_id) ON DELETE SET NULL,
    CONSTRAINT CK_service_providers_rating CHECK (average_rating BETWEEN 0 AND 5),
    CONSTRAINT CK_service_providers_total_reviews CHECK (total_reviews >= 0),
    CONSTRAINT CK_service_providers_approval CHECK (approval_status IN ('Pending','Approved','Rejected')),
    CONSTRAINT CK_service_providers_status CHECK (account_status IN ('Active','Blocked'))
);
GO
CREATE INDEX IX_service_providers_admin_id ON service_providers (admin_id);
GO

/* ---------------------------------------------------------------------
   4. SERVICE_CATEGORY  (optional, provider-defined storefront categories)
   --------------------------------------------------------------------- */
CREATE TABLE service_categories (
    service_category_id INT IDENTITY(1,1) NOT NULL,
    provider_id          INT               NOT NULL,
    category_name        NVARCHAR(100)     NOT NULL,
    category_description NVARCHAR(500)     NULL,
    display_order         INT              NOT NULL CONSTRAINT DF_categories_order DEFAULT (0),
    is_active             BIT              NOT NULL CONSTRAINT DF_categories_active DEFAULT (1),
    CONSTRAINT PK_service_categories PRIMARY KEY (service_category_id),
    CONSTRAINT FK_service_categories_provider FOREIGN KEY (provider_id)
        REFERENCES service_providers (provider_id) ON DELETE CASCADE
);
GO
CREATE INDEX IX_service_categories_provider_id ON service_categories (provider_id);
GO

/* ---------------------------------------------------------------------
   5. SERVICE  (platform-wide catalogue of service kinds)
   --------------------------------------------------------------------- */
CREATE TABLE services (
    service_id          INT IDENTITY(1,1) NOT NULL,
    service_name          NVARCHAR(100)   NOT NULL,
    service_description   NVARCHAR(500)   NULL,
    icon_url               NVARCHAR(255)  NULL,
    is_active              BIT            NOT NULL CONSTRAINT DF_services_active DEFAULT (1),
    CONSTRAINT PK_services PRIMARY KEY (service_id),
    CONSTRAINT UQ_services_name UNIQUE (service_name)
);
GO

/* ---------------------------------------------------------------------
   6. PROVIDER_SERVICE  (bridge entity — the row a customer books)
   --------------------------------------------------------------------- */
CREATE TABLE provider_services (
    provider_service_id INT IDENTITY(1,1) NOT NULL,
    provider_id           INT             NOT NULL,
    service_id            INT             NOT NULL,
    service_category_id   INT             NULL,
    offering_title         NVARCHAR(150)  NOT NULL,
    offering_description   NVARCHAR(1000) NULL,
    price                  DECIMAL(10,2)  NOT NULL,
    price_unit             VARCHAR(20)    NOT NULL CONSTRAINT DF_provider_services_unit DEFAULT ('Fixed'),
    duration_hours         DECIMAL(4,1)   NULL,
    portfolio_url          NVARCHAR(255)  NULL,
    service_city           NVARCHAR(60)   NOT NULL,
    is_active              BIT            NOT NULL CONSTRAINT DF_provider_services_active DEFAULT (1),
    created_at             DATETIME2(0)   NOT NULL CONSTRAINT DF_provider_services_created DEFAULT (SYSDATETIME()),
    updated_at             DATETIME2(0)   NOT NULL CONSTRAINT DF_provider_services_updated DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_provider_services PRIMARY KEY (provider_service_id),
    CONSTRAINT FK_provider_services_provider FOREIGN KEY (provider_id)
        REFERENCES service_providers (provider_id) ON DELETE CASCADE,
    CONSTRAINT FK_provider_services_service FOREIGN KEY (service_id)
        REFERENCES services (service_id) ON DELETE NO ACTION,
    CONSTRAINT FK_provider_services_category FOREIGN KEY (service_category_id)
        REFERENCES service_categories (service_category_id) ON DELETE NO ACTION,
    CONSTRAINT CK_provider_services_price CHECK (price >= 0),
    CONSTRAINT CK_provider_services_duration CHECK (duration_hours IS NULL OR duration_hours >= 0),
    CONSTRAINT CK_provider_services_unit CHECK (price_unit IN ('Fixed','Per Hour','Per Guest','Per Item'))
);
GO
CREATE INDEX IX_provider_services_provider_id ON provider_services (provider_id);
CREATE INDEX IX_provider_services_service_id ON provider_services (service_id);
CREATE INDEX IX_provider_services_category_id ON provider_services (service_category_id);
GO

/* ---------------------------------------------------------------------
   7. AVAILABILITY_SCHEDULE  (store-level — kept linked to the provider,
      per the project owner's decision: one provider = one working unit)
   --------------------------------------------------------------------- */
CREATE TABLE availability_schedules (
    availability_id      INT IDENTITY(1,1) NOT NULL,
    provider_id            INT             NOT NULL,
    available_date         DATE            NOT NULL,
    start_time             TIME(0)         NOT NULL,
    end_time               TIME(0)         NOT NULL,
    availability_status    VARCHAR(20)     NOT NULL CONSTRAINT DF_availability_status DEFAULT ('Open'),
    updated_at             DATETIME2(0)    NOT NULL CONSTRAINT DF_availability_updated DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_availability_schedules PRIMARY KEY (availability_id),
    CONSTRAINT FK_availability_provider FOREIGN KEY (provider_id)
        REFERENCES service_providers (provider_id) ON DELETE CASCADE,
    CONSTRAINT UQ_availability_slot UNIQUE (provider_id, available_date, start_time),
    CONSTRAINT CK_availability_status CHECK (availability_status IN ('Open','Booked','Blocked')),
    CONSTRAINT CK_availability_times CHECK (end_time > start_time)
);
GO
CREATE INDEX IX_availability_provider_id ON availability_schedules (provider_id);
GO

/* ---------------------------------------------------------------------
   8. MYEVENT  (optional cart-like grouping of bookings)
   --------------------------------------------------------------------- */
CREATE TABLE my_events (
    my_event_id     INT IDENTITY(1,1) NOT NULL,
    customer_id       INT             NOT NULL,
    event_name        NVARCHAR(150)   NOT NULL,
    event_type        VARCHAR(50)     NOT NULL,
    event_date        DATE            NOT NULL,
    total_budget      DECIMAL(10,2)   NULL,
    event_status      VARCHAR(20)     NOT NULL CONSTRAINT DF_my_events_status DEFAULT ('Planning'),
    created_at        DATETIME2(0)    NOT NULL CONSTRAINT DF_my_events_created DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_my_events PRIMARY KEY (my_event_id),
    CONSTRAINT FK_my_events_customer FOREIGN KEY (customer_id)
        REFERENCES customers (customer_id) ON DELETE CASCADE,
    CONSTRAINT CK_my_events_type CHECK (event_type IN ('Wedding','Engagement','Graduation','Birthday','Baby Shower','Corporate','National Day','Other')),
    CONSTRAINT CK_my_events_budget CHECK (total_budget IS NULL OR total_budget >= 0),
    CONSTRAINT CK_my_events_status CHECK (event_status IN ('Planning','Confirmed','Completed','Cancelled'))
);
GO
CREATE INDEX IX_my_events_customer_id ON my_events (customer_id);
GO

/* ---------------------------------------------------------------------
   9. BOOKING  (the busiest entity — every occasion detail lives here)
   --------------------------------------------------------------------- */
CREATE TABLE bookings (
    booking_id             INT IDENTITY(1,1) NOT NULL,
    customer_id              INT             NOT NULL,
    my_event_id              INT             NULL,
    provider_service_id      INT             NOT NULL,
    booking_date             DATETIME2(0)    NOT NULL CONSTRAINT DF_bookings_booking_date DEFAULT (SYSDATETIME()),
    service_date             DATE            NOT NULL,
    service_time             TIME(0)         NOT NULL,
    venue_address             NVARCHAR(255)  NOT NULL,
    guest_count               INT            NULL,
    quantity                  INT            NOT NULL CONSTRAINT DF_bookings_quantity DEFAULT (1),
    agreed_price               DECIMAL(10,2) NOT NULL,
    special_requirements       NVARCHAR(1000) NULL,
    booking_status             VARCHAR(20)   NOT NULL CONSTRAINT DF_bookings_status DEFAULT ('Pending'),
    modification_deadline       DATETIME2(0) NULL,
    provider_response_date      DATETIME2(0) NULL,
    rejection_reason             NVARCHAR(500) NULL,
    cancellation_date            DATETIME2(0) NULL,
    cancellation_reason          NVARCHAR(500) NULL,
    CONSTRAINT PK_bookings PRIMARY KEY (booking_id),
    CONSTRAINT FK_bookings_customer FOREIGN KEY (customer_id)
        REFERENCES customers (customer_id) ON DELETE CASCADE,
    CONSTRAINT FK_bookings_my_event FOREIGN KEY (my_event_id)
        REFERENCES my_events (my_event_id) ON DELETE NO ACTION,
    CONSTRAINT FK_bookings_provider_service FOREIGN KEY (provider_service_id)
        REFERENCES provider_services (provider_service_id) ON DELETE NO ACTION,
    CONSTRAINT CK_bookings_guest_count CHECK (guest_count IS NULL OR guest_count >= 0),
    CONSTRAINT CK_bookings_quantity CHECK (quantity >= 1),
    CONSTRAINT CK_bookings_price CHECK (agreed_price >= 0),
    CONSTRAINT CK_bookings_status CHECK (booking_status IN ('Pending','Accepted','Rejected','Completed','Cancelled'))
);
GO
CREATE INDEX IX_bookings_customer_id ON bookings (customer_id);
CREATE INDEX IX_bookings_my_event_id ON bookings (my_event_id);
CREATE INDEX IX_bookings_provider_service_id ON bookings (provider_service_id);
GO

/* ---------------------------------------------------------------------
   10. PAYMENT  (1:1 with booking)
   --------------------------------------------------------------------- */
CREATE TABLE payments (
    payment_id         INT IDENTITY(1,1) NOT NULL,
    booking_id            INT             NOT NULL,
    invoice_number        VARCHAR(30)     NOT NULL,
    amount                DECIMAL(10,2)   NOT NULL,
    payment_method        VARCHAR(20)     NOT NULL,
    payment_status        VARCHAR(20)     NOT NULL CONSTRAINT DF_payments_status DEFAULT ('Pending'),
    transaction_ref        VARCHAR(50)    NULL,
    payment_date           DATETIME2(0)   NULL,
    refund_amount          DECIMAL(10,2)  NULL,
    refund_date            DATETIME2(0)   NULL,
    CONSTRAINT PK_payments PRIMARY KEY (payment_id),
    CONSTRAINT FK_payments_booking FOREIGN KEY (booking_id)
        REFERENCES bookings (booking_id) ON DELETE CASCADE,
    CONSTRAINT UQ_payments_booking UNIQUE (booking_id),
    CONSTRAINT UQ_payments_invoice UNIQUE (invoice_number),
    CONSTRAINT CK_payments_amount CHECK (amount >= 0),
    CONSTRAINT CK_payments_method CHECK (payment_method IN ('Mada','Credit Card','Apple Pay','STC Pay','Bank Transfer')),
    CONSTRAINT CK_payments_status CHECK (payment_status IN ('Pending','Paid','Failed','Refunded')),
    CONSTRAINT CK_payments_refund CHECK (refund_amount IS NULL OR refund_amount >= 0)
);
GO

/* ---------------------------------------------------------------------
   11. REVIEW  (1:1 with booking)
   --------------------------------------------------------------------- */
CREATE TABLE reviews (
    review_id             INT IDENTITY(1,1) NOT NULL,
    booking_id              INT             NOT NULL,
    moderated_by_admin_id   INT             NULL,
    rating                  TINYINT        NOT NULL,
    review_text             NVARCHAR(1000) NULL,
    review_date              DATETIME2(0)  NOT NULL CONSTRAINT DF_reviews_date DEFAULT (SYSDATETIME()),
    is_visible               BIT           NOT NULL CONSTRAINT DF_reviews_visible DEFAULT (1),
    CONSTRAINT PK_reviews PRIMARY KEY (review_id),
    CONSTRAINT FK_reviews_booking FOREIGN KEY (booking_id)
        REFERENCES bookings (booking_id) ON DELETE CASCADE,
    CONSTRAINT FK_reviews_admin FOREIGN KEY (moderated_by_admin_id)
        REFERENCES admins (admin_id) ON DELETE SET NULL,
    CONSTRAINT UQ_reviews_booking UNIQUE (booking_id),
    CONSTRAINT CK_reviews_rating CHECK (rating BETWEEN 1 AND 5)
);
GO
CREATE INDEX IX_reviews_admin_id ON reviews (moderated_by_admin_id);
GO

/* ---------------------------------------------------------------------
   12. MESSAGE  (chat between a customer and a provider)
   --------------------------------------------------------------------- */
CREATE TABLE messages (
    message_id       INT IDENTITY(1,1) NOT NULL,
    customer_id         INT             NOT NULL,
    provider_id         INT             NOT NULL,
    booking_id          INT             NULL,
    sender_type         VARCHAR(20)     NOT NULL,
    message_text        NVARCHAR(1000)  NOT NULL,
    attachment_url       NVARCHAR(255)  NULL,
    sent_at              DATETIME2(0)   NOT NULL CONSTRAINT DF_messages_sent_at DEFAULT (SYSDATETIME()),
    is_read              BIT            NOT NULL CONSTRAINT DF_messages_read DEFAULT (0),
    CONSTRAINT PK_messages PRIMARY KEY (message_id),
    CONSTRAINT FK_messages_customer FOREIGN KEY (customer_id)
        REFERENCES customers (customer_id) ON DELETE CASCADE,
    CONSTRAINT FK_messages_provider FOREIGN KEY (provider_id)
        REFERENCES service_providers (provider_id) ON DELETE CASCADE,
    CONSTRAINT FK_messages_booking FOREIGN KEY (booking_id)
        REFERENCES bookings (booking_id) ON DELETE NO ACTION,
    CONSTRAINT CK_messages_sender CHECK (sender_type IN ('Customer','Provider'))
);
GO
CREATE INDEX IX_messages_customer_id ON messages (customer_id);
CREATE INDEX IX_messages_provider_id ON messages (provider_id);
CREATE INDEX IX_messages_booking_id ON messages (booking_id);
GO
