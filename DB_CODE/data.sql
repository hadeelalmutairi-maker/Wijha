

USE wijha_db;
GO

/* ---------------------------------------------------------------------
   1. ADMINS (3)
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT admins ON;
INSERT INTO admins (admin_id, full_name, email, password_hash, phone, admin_role, last_login, created_at) VALUES
(1, N'Sarah Alqurzai',    'sarah.alqurzai@wijha.sa',    '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0511223344',    'Super Admin',   '2026-10-10 20:15:00', '2025-10-01 09:00:00'),
(2, N'Fahad Al-Dossary',  'fahad.aldossary@wijha.sa',   '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '+966530405060', 'Support Admin', '2026-10-09 11:00:00', '2025-10-05 09:00:00'),
(3, N'Nourah Al-Harbi',   'nourah.alharbi@wijha.sa',    '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0588112233',    'Support Admin', '2026-10-08 16:30:00', '2025-10-10 09:00:00');
SET IDENTITY_INSERT admins OFF;
GO

/* ---------------------------------------------------------------------
   2. CUSTOMERS (10) — rows 1-6 are the Wijha capstone team
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT customers ON;
INSERT INTO customers (customer_id, first_name, last_name, email, password_hash, phone, gender, city, profile_image_url, account_status, registration_date, last_login) VALUES
(1,  N'Hadeel',   N'Almutairi',  'hadeel.almutairi@gmail.com',  '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0554128830',    'Female', N'Jubail',  NULL, 'Active',  '2025-09-01 10:00:00', '2026-10-09 08:40:00'),
(2,  N'Reema',    N'Alshahrani', 'reema.alshahrani@gmail.com',  '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '+966551122334', 'Female', N'Dammam',  NULL, 'Active',  '2025-09-03 10:00:00', '2026-10-05 09:00:00'),
(3,  N'Ghaday',   N'Albahloul',  'ghaday.albahloul@gmail.com',  '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0567891234',    'Female', N'Jubail',  NULL, 'Active',  '2025-09-05 10:00:00', '2026-10-07 18:20:00'),
(4,  N'Hella',    N'Alkhaldi',   'hella.alkhaldi@hotmail.com',  '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '+966509988776', 'Female', N'Khobar',  NULL, 'Active',  '2025-09-07 10:00:00', '2026-09-20 12:00:00'),
(5,  N'Renad',    N'Almushref',  'renad.almushref@gmail.com',   '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0598765432',    'Female', N'Riyadh',  NULL, 'Active',  '2025-09-10 10:00:00', '2026-10-04 07:50:00'),
(6,  N'Laila',    N'Alrashidi',  'laila.alrashidi@gmail.com',   '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '+966544556677', 'Female', N'Jeddah',  NULL, 'Active',  '2025-09-12 10:00:00', '2026-10-01 21:10:00'),
(7,  N'Faisal',   N'Alqahtani',  'faisal.alqahtani@gmail.com',  '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0512345678',    'Male',   N'Riyadh',  NULL, 'Active',  '2025-09-15 10:00:00', '2026-09-15 10:30:00'),
(8,  N'Abdullah', N'Alghamdi',   'abdullah.alghamdi@outlook.com','$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '+966533221144', 'Male',   N'Jeddah',  NULL, 'Blocked', '2025-09-18 10:00:00', '2026-09-28 15:40:00'),
(9,  N'Noura',    N'Alsubaie',   'noura.alsubaie@gmail.com',    '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0534567890',    'Female', N'Dammam',  NULL, 'Active',  '2025-09-20 10:00:00', '2026-10-02 19:15:00'),
(10, N'Khalid',   N'Alharbi',    'khalid.alharbi@gmail.com',    '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '+966522334455', 'Male',   N'Yanbu',   NULL, 'Active',  '2025-09-22 10:00:00', '2026-08-20 11:05:00');
SET IDENTITY_INSERT customers OFF;
GO

/* ---------------------------------------------------------------------
   3. SERVICES — platform-wide catalogue (10)
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT services ON;
INSERT INTO services (service_id, service_name, service_description, icon_url, is_active) VALUES
(1,  N'Photography',                   N'Professional event photography coverage.',               '/icons/photography.svg',       1),
(2,  N'Videography',                   N'Event video coverage and highlight reels.',               '/icons/videography.svg',       1),
(3,  N'Decoration',                    N'Hall, stage and venue decoration.',                       '/icons/decoration.svg',         1),
(4,  N'Flowers & Bouquets',            N'Floral arrangements and bridal bouquets.',                '/icons/flowers.svg',            1),
(5,  N'Cakes & Desserts',              N'Custom cakes and dessert tables.',                        '/icons/cakes.svg',              1),
(6,  N'Catering',                      N'Food and beverage catering services.',                    '/icons/catering.svg',           1),
(7,  N'Henna Artist',                  N'Bridal and guest henna art.',                             '/icons/henna.svg',              1),
(8,  N'Lighting & Sound',              N'Event lighting and sound production.',                    '/icons/lighting-sound.svg',     1),
(9,  N'Invitation Cards',              N'Custom printed and digital invitations.',                 '/icons/invitations.svg',        1),
(10, N'Event Planning & Coordination', N'Full event planning and day-of coordination.',           '/icons/event-planning.svg',     1);
SET IDENTITY_INSERT services OFF;
GO

/* ---------------------------------------------------------------------
   4. SERVICE_PROVIDERS (10) — 7 Approved, 1 Pending, 1 Rejected,
      ratings below are pre-aggregated to match the REVIEWS inserted later
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT service_providers ON;
INSERT INTO service_providers (provider_id, admin_id, business_name, owner_name, email, password_hash, phone, city, business_address, business_description, commercial_register_no, logo_url, average_rating, total_reviews, approval_status, account_status, subscription_start_date, subscription_end_date, registration_date) VALUES
(1,  1,    N'Lamasat Studio',          N'Ghaday Albahloul',       'info@lamasatstudio.sa',   '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0561112222',    N'Jubail', N'King Fahd Road, Al Fanateer, Jubail',         N'Wedding and graduation photography in Jubail since 2019. Two photographers, same-day preview, edited album within 10 days.', '2055134887', '/images/providers/lamasat-studio.png',   4.50, 2, 'Approved', 'Active', '2026-01-01', '2026-12-31', '2025-09-10 09:00:00'),
(2,  1,    N'Zahrat Aljubail',         N'Sara Alamri',            'contact@zahrataljubail.sa','$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '+966577889900', N'Jubail', N'Al Huwaylat District, Jubail',                N'Fresh floral arrangements and bridal bouquets for weddings and engagements across the Eastern Province.', '2059876543', '/images/providers/zahrat-aljubail.png', 4.00, 1, 'Approved', 'Active', '2026-02-01', '2027-01-31', '2025-09-12 09:00:00'),
(3,  2,    N'Lailaty Events',          N'Fahad Alotaibi',         'info@lailatyevents.sa',   '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0572223333',    N'Dammam', N'Prince Mohammed bin Fahd Road, Dammam',       N'Full event decoration and styling for weddings, graduations and corporate occasions.', '3011122334', '/images/providers/lailaty-events.png', 3.00, 1, 'Approved', 'Active', '2026-01-15', '2026-12-31', '2025-09-15 09:00:00'),
(4,  2,    N'Halawiyat Sukar',         N'Mona Alzahrani',         'orders@halawiyatsukar.sa','$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '+966588990011', N'Khobar',  N'Prince Turki Street, Al Khobar',              N'Custom wedding cakes, dessert tables and favors made fresh to order.', '3022233445', '/images/providers/halawiyat-sukar.png', 5.00, 1, 'Approved', 'Active', '2026-03-01', '2027-02-28', '2025-09-18 09:00:00'),
(5,  3,    N'Noor Lens Photography',   N'Abdulrahman Alqahtani',  'booking@noorlens.sa',     '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0583334444',    N'Riyadh',  N'Al Olaya District, Riyadh',                   N'Photography and videography coverage for weddings, graduations and family events.', '1033344556', '/images/providers/noor-lens.png', 5.00, 1, 'Approved', 'Active', '2026-01-10', '2026-12-31', '2025-09-20 09:00:00'),
(6,  1,    N'Rawnaq Decor',            N'Hind Alsulami',          'hello@rawnaqdecor.sa',    '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '+966599001122', N'Jeddah',  N'Tahlia Street, Jeddah',                       N'Themed stage and hall decoration specializing in Saudi wedding traditions.', '4044455667', '/images/providers/rawnaq-decor.png', 5.00, 1, 'Approved', 'Active', '2026-02-15', '2027-02-14', '2025-09-22 09:00:00'),
(7,  NULL, N'Bidaya Events Planning',  N'Yousef Alsubhi',         'plan@bidayaevents.sa',    '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0594445555',    N'Riyadh',  N'King Abdullah Financial District, Riyadh',    N'End-to-end event planning and day-of coordination for weddings and corporate events.', '1055566778', NULL, 0.00, 0, 'Pending', 'Active', NULL, NULL, '2026-09-01 09:00:00'),
(8,  2,    N'Fustuq Catering',         N'Waleed Almansour',       'info@fustuqcatering.sa',  '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '+966510203040', N'Dammam',  N'Al Faisaliyah District, Dammam',              N'Catering services for weddings and corporate gatherings, including live cooking stations.', '3066677889', '/images/providers/fustuq-catering.png', 0.00, 0, 'Approved', 'Active', '2026-01-01', '2026-12-31', '2025-09-25 09:00:00'),
(9,  3,    N'Hena Ward',               N'Amal Aldosari',          'book@henaward.sa',        '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '0505556666',    N'Khobar',  N'Al Aqrabiyah District, Khobar',               N'Bridal and guest henna artistry for weddings and engagement parties.', '3077788990', '/images/providers/hena-ward.png', 5.00, 1, 'Approved', 'Active', '2026-04-01', '2027-03-31', '2025-09-28 09:00:00'),
(10, 2,    N'SoundWave Production',    N'Omar Alzahrani',         'contact@soundwaveksa.sa', '$2y$10$J4eyO6nIhvbH0RhH3Qs5WOs1sy3fXsSWH5q64A71RrD7OyaRQ6m4G', '+966520304050', N'Jubail',  N'Al Fanateer, Jubail',                         N'Registration rejected: incomplete commercial registration documents.', '2088899001', NULL, 0.00, 0, 'Rejected', 'Active', NULL, NULL, '2026-08-20 09:00:00');
SET IDENTITY_INSERT service_providers OFF;
GO

/* ---------------------------------------------------------------------
   5. SERVICE_CATEGORIES (10) — optional storefront categories;
      note providers 7 (Pending) and 10 (Rejected) deliberately have none,
      per the policy rule "cannot offer/organise services until approved"
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT service_categories ON;
INSERT INTO service_categories (service_category_id, provider_id, category_name, category_description, display_order, is_active) VALUES
(1,  1, N'Wedding Photography',    N'Full wedding day coverage packages.',          1, 1),
(2,  1, N'Graduation Photography', N'Graduation and portrait sessions.',            2, 1),
(3,  2, N'Bridal Bouquets',        N'Bridal and bridesmaid flower arrangements.',   1, 1),
(4,  2, N'Hall Flower Decor',      N'Floral centerpieces and hall arrangements.',   2, 1),
(5,  3, N'Wedding Decoration',     N'Stage and hall styling for weddings.',         1, 1),
(6,  4, N'Wedding Cakes',          N'Multi-tier custom wedding cakes.',             1, 1),
(7,  4, N'Dessert Tables',         N'Sweet tables and favors.',                     2, 1),
(8,  5, N'Wedding Coverage',       N'Photography and videography bundles.',        1, 1),
(9,  6, N'Birthday Decoration',    N'Themed birthday party styling.',               1, 1),
(10, 9, N'Bridal Henna',           N'Bridal henna art packages.',                   1, 1);
SET IDENTITY_INSERT service_categories OFF;
GO

/* ---------------------------------------------------------------------
   6. PROVIDER_SERVICES (15) — the bridge entity; the row a customer books
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT provider_services ON;
INSERT INTO provider_services (provider_service_id, provider_id, service_id, service_category_id, offering_title, offering_description, price, price_unit, duration_hours, portfolio_url, service_city, is_active, created_at, updated_at) VALUES
(1,  1, 1,  1,    N'Full-Day Wedding Coverage',          N'Two photographers, 8 hours coverage, same-day preview, edited album within 10 days.', 4500.00, 'Fixed',    8.0,  '/portfolio/lamasat/wedding',       N'Jubail', 1, '2025-09-11 10:00:00', '2025-09-11 10:00:00'),
(2,  1, 1,  2,    N'Graduation Portrait Session',        N'One photographer, 2 hours, 30 edited photos.',                                         800.00,  'Fixed',    2.0,  '/portfolio/lamasat/graduation',    N'Jubail', 1, '2025-09-11 10:05:00', '2025-09-11 10:05:00'),
(3,  1, 2,  NULL, N'Wedding Highlight Video',            N'Same-day edit highlight reel plus full video within 2 weeks.',                        2200.00, 'Fixed',    8.0,  '/portfolio/lamasat/video',         N'Jubail', 1, '2025-09-11 10:10:00', '2025-09-11 10:10:00'),
(4,  2, 4,  3,    N'Bridal Bouquet Package',             N'Bridal bouquet plus 4 bridesmaid bouquets, fresh seasonal flowers.',                  1200.00, 'Fixed',    NULL, '/portfolio/zahrat/bouquet',        N'Jubail', 1, '2025-09-13 10:00:00', '2025-09-13 10:00:00'),
(5,  2, 4,  4,    N'Hall Floral Centerpiece (per table)',N'Fresh floral centerpiece for one guest table.',                                        180.00, 'Per Item', NULL, '/portfolio/zahrat/centerpiece',    N'Jubail', 1, '2025-09-13 10:05:00', '2025-09-13 10:05:00'),
(6,  3, 3,  5,    N'Wedding Stage & Hall Styling',       N'Full stage backdrop, aisle and hall styling package.',                                6000.00, 'Fixed',    NULL, '/portfolio/lailaty/wedding',       N'Dammam', 1, '2025-09-16 10:00:00', '2025-09-16 10:00:00'),
(7,  3, 3,  NULL, N'Graduation Party Decoration',        N'Themed graduation decoration for a private hall.',                                     2500.00, 'Fixed',    NULL, '/portfolio/lailaty/graduation',    N'Dammam', 1, '2025-09-16 10:05:00', '2025-09-16 10:05:00'),
(8,  4, 5,  6,    N'Three-Tier Wedding Cake',            N'Custom three-tier cake, flavor and design of your choice.',                           1500.00, 'Fixed',    NULL, '/portfolio/halawiyat/cake',        N'Khobar', 1, '2025-09-19 10:00:00', '2025-09-19 10:00:00'),
(9,  4, 5,  7,    N'Dessert Table (per guest)',          N'Assorted mini desserts and favors.',                                                    35.00, 'Per Guest',NULL, '/portfolio/halawiyat/desserts',    N'Khobar', 1, '2025-09-19 10:05:00', '2025-09-19 10:05:00'),
(10, 5, 1,  8,    N'Wedding Photo & Video Bundle',       N'Photography and videography team, 10 hours coverage.',                               7000.00, 'Fixed',    10.0, '/portfolio/noorlens/bundle',       N'Riyadh', 1, '2025-09-21 10:00:00', '2025-09-21 10:00:00'),
(11, 5, 2,  NULL, N'Engagement Video Package',          N'2-hour engagement coverage with a short edited film.',                                1800.00, 'Fixed',    2.0,  '/portfolio/noorlens/engagement',   N'Riyadh', 1, '2025-09-21 10:05:00', '2025-09-21 10:05:00'),
(12, 6, 3,  9,    N'Birthday Hall Decoration',           N'Balloon and themed decoration for birthday parties.',                                 1200.00, 'Fixed',    NULL, '/portfolio/rawnaq/birthday',       N'Jeddah', 1, '2025-09-23 10:00:00', '2025-09-23 10:00:00'),
(13, 8, 6,  NULL, N'Wedding Buffet Catering (per guest)',N'Full buffet with a live cooking station, per guest pricing.',                           95.00, 'Per Guest',NULL, '/portfolio/fustuq/buffet',         N'Dammam', 1, '2025-09-26 10:00:00', '2025-09-26 10:00:00'),
(14, 9, 7,  10,   N'Bridal Henna Package',               N'Full bridal hands and feet henna art, includes henna for 2 guests.',                   700.00, 'Fixed',    3.0,  '/portfolio/henaward/bridal',       N'Khobar', 1, '2025-09-29 10:00:00', '2025-09-29 10:00:00'),
(15, 2, 4,  NULL, N'Event Flower Wall (per sqm)',        N'Fresh or silk flower wall backdrop for photos.',                                       250.00, 'Per Item', NULL, '/portfolio/zahrat/flowerwall',     N'Jubail', 1, '2025-09-13 10:10:00', '2025-09-13 10:10:00');
SET IDENTITY_INSERT provider_services OFF;
GO

/* ---------------------------------------------------------------------
   7. AVAILABILITY_SCHEDULES (15) — store-level, per provider
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT availability_schedules ON;
INSERT INTO availability_schedules (availability_id, provider_id, available_date, start_time, end_time, availability_status, updated_at) VALUES
(1,  1, '2026-11-12', '08:00', '20:00', 'Booked',  '2026-10-02 09:00:00'),
(2,  1, '2026-11-19', '09:00', '17:00', 'Open',    '2025-10-15 09:00:00'),
(3,  1, '2026-11-26', '09:00', '17:00', 'Open',    '2025-10-15 09:00:00'),
(4,  2, '2026-11-20', '08:00', '14:00', 'Booked',  '2026-10-05 09:00:00'),
(5,  2, '2026-11-27', '08:00', '14:00', 'Open',    '2025-10-16 09:00:00'),
(6,  3, '2026-12-06', '10:00', '22:00', 'Booked',  '2026-10-20 12:00:00'),
(7,  3, '2026-12-13', '10:00', '22:00', 'Open',    '2025-10-18 09:00:00'),
(8,  4, '2026-11-12', '08:00', '20:00', 'Booked',  '2026-10-01 10:45:00'),
(9,  4, '2026-11-19', '08:00', '12:00', 'Open',    '2025-10-19 09:00:00'),
(10, 5, '2026-08-14', '08:00', '20:00', 'Booked',  '2026-07-01 09:00:00'),
(11, 5, '2026-11-05', '09:00', '19:00', 'Open',    '2025-10-21 09:00:00'),
(12, 6, '2026-11-15', '10:00', '18:00', 'Open',    '2025-10-23 09:00:00'),
(13, 6, '2026-03-20', '10:00', '18:00', 'Booked',  '2026-02-15 10:00:00'),
(14, 8, '2026-12-01', '16:00', '23:00', 'Open',    '2025-10-26 09:00:00'),
(15, 9, '2026-11-12', '13:00', '20:00', 'Booked',  '2026-10-03 11:00:00');
SET IDENTITY_INSERT availability_schedules OFF;
GO

/* ---------------------------------------------------------------------
   8. MY_EVENTS (8) — optional cart-like grouping of bookings
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT my_events ON;
INSERT INTO my_events (my_event_id, customer_id, event_name, event_type, event_date, total_budget, event_status, created_at) VALUES
(1, 1, N'Hadeel & Faisal''s Wedding',      'Wedding',     '2026-11-12', 25000.00, 'Confirmed', '2025-10-01 10:00:00'),
(2, 2, N'Reema''s Graduation',             'Graduation',  '2026-12-06', 6000.00,  'Planning',  '2026-10-18 10:00:00'),
(3, 5, N'Renad''s Engagement Party',       'Engagement',  '2026-11-20', 15000.00, 'Confirmed', '2026-10-04 10:00:00'),
(4, 6, N'Baby Shower for Laila',           'Baby Shower', '2026-11-28', 4000.00,  'Planning',  '2026-10-30 10:00:00'),
(5, 9, N'Noura''s Birthday',               'Birthday',    '2026-12-10', 3000.00,  'Planning',  '2026-10-02 10:00:00'),
(6, 3, N'Ghaday''s Family Gathering',      'Other',       '2026-11-15', 2500.00,  'Planning',  '2026-10-01 10:00:00'),
(7, 7, N'Faisal''s Company Anniversary',   'Corporate',   '2026-12-01', 20000.00, 'Planning',  '2026-10-10 10:00:00'),
(8, 4, N'Hella''s Graduation Celebration', 'Graduation',  '2026-11-25', 5000.00,  'Planning',  '2026-10-14 10:00:00');
SET IDENTITY_INSERT my_events OFF;
GO

/* ---------------------------------------------------------------------
   9. BOOKINGS (17) — the busiest entity; all occasion detail lives here
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT bookings ON;
INSERT INTO bookings (booking_id, customer_id, my_event_id, provider_service_id, booking_date, service_date, service_time, venue_address, guest_count, quantity, agreed_price, special_requirements, booking_status, modification_deadline, provider_response_date, rejection_reason, cancellation_date, cancellation_reason) VALUES
(1,  1, 1,    1,  '2025-10-01 10:30:00', '2026-11-12', '09:00', N'Al Fanar Hall, King Fahd Road, Al Fanateer, Jubail',   220, 1, 4500.00, N'Women-only hall, so both photographers must be female. Please arrive at 15:00 for the bridal preparation shots.', 'Accepted', '2025-10-02 10:30:00', '2025-10-02 09:00:00', NULL, NULL, NULL),
(2,  1, 1,    3,  '2025-10-01 10:40:00', '2026-11-12', '16:00', N'Al Fanar Hall, King Fahd Road, Al Fanateer, Jubail',   220, 1, 2200.00, N'Include drone shots if the hall allows.', 'Accepted', '2025-10-02 10:40:00', '2025-10-02 09:10:00', NULL, NULL, NULL),
(3,  1, 1,    8,  '2025-10-01 10:45:00', '2026-11-12', '18:00', N'Al Fanar Hall, King Fahd Road, Al Fanateer, Jubail',   220, 1, 1500.00, N'Deliver the cake by 17:00.', 'Accepted', '2025-10-02 10:45:00', '2025-10-02 09:20:00', NULL, NULL, NULL),
(4,  2, 2,    7,  '2026-10-20 12:00:00', '2026-12-06', '17:00', N'Ithra Hall, King Fahd Road, Dammam',                    80, 1, 2500.00, NULL, 'Pending',  '2026-10-21 12:00:00', NULL, NULL, NULL, NULL),
(5,  5, 3,    4,  '2025-10-05 09:00:00', '2026-11-20', '10:00', N'Narcissus Palace Hall, Riyadh',                        NULL, 1, 1200.00, N'Deliver bouquets by 9:00 AM.', 'Accepted', '2025-10-06 09:00:00', '2025-10-05 18:00:00', NULL, NULL, NULL),
(6,  6, 4,    9,  '2026-11-01 14:00:00', '2026-11-28', '16:00', N'Laila''s residence, Al Shati District, Jeddah',         30, 1, 1050.00, N'Pastel pink and gold theme.', 'Pending', '2026-11-02 14:00:00', NULL, NULL, NULL, NULL),
(7,  4, 8,    2,  '2026-10-15 09:00:00', '2026-11-25', '10:00', N'Hella''s residence, Al Rakah District, Khobar',        NULL, 1, 800.00,  NULL, 'Rejected', '2026-10-16 09:00:00', '2026-10-16 09:30:00', N'Fully booked on this date due to graduation season. Suggested 27 November instead.', NULL, NULL),
(8,  3, NULL, 14, '2025-10-03 11:00:00', '2026-11-12', '14:00', N'Al Fanar Hall, King Fahd Road, Al Fanateer, Jubail',    NULL, 1, 700.00,  N'Henna for the groom''s sister too if time allows.', 'Accepted', '2025-10-04 11:00:00', '2025-10-03 15:00:00', NULL, NULL, NULL),
(9,  8, NULL, 11, '2026-09-20 10:00:00', '2026-10-05', '17:00', N'Family hall, Al Olaya District, Riyadh',                60, 1, 1800.00, NULL, 'Cancelled', '2026-09-21 10:00:00', '2026-09-20 16:00:00', NULL, '2026-09-28 09:00:00', N'Engagement postponed to next year.'),
(10, 10,NULL, 10, '2026-07-01 09:00:00', '2026-08-14', '10:00', N'Khalid''s wedding hall, Al Olaya District, Riyadh',    180, 1, 7000.00, N'Family only, no public photos online.', 'Completed', '2026-07-02 09:00:00', '2026-07-01 14:00:00', NULL, NULL, NULL),
(11, 7, NULL, 1,  '2026-06-10 10:00:00', '2026-07-20', '09:00', N'Al Fanar Hall, King Fahd Road, Al Fanateer, Jubail',   150, 1, 4500.00, NULL, 'Completed', '2026-06-11 10:00:00', '2026-06-10 15:00:00', NULL, NULL, NULL),
(12, 2, NULL, 6,  '2026-05-01 09:00:00', '2026-06-10', '11:00', N'Ithra Hall, King Fahd Road, Dammam',                   120, 1, 6000.00, NULL, 'Completed', '2026-05-02 09:00:00', '2026-05-01 16:00:00', NULL, NULL, NULL),
(13, 9, NULL, 9,  '2026-04-01 10:00:00', '2026-05-01', '15:00', N'Noura''s home, Al Hamra District, Jeddah',              20, 1, 700.00,  NULL, 'Completed', '2026-04-02 10:00:00', '2026-04-01 17:00:00', NULL, NULL, NULL),
(14, 6, NULL, 4,  '2026-03-10 09:00:00', '2026-04-15', '09:00', N'Laila''s wedding hall, Jeddah',                        NULL, 1, 1200.00, NULL, 'Completed', '2026-03-11 09:00:00', '2026-03-10 13:00:00', NULL, NULL, NULL),
(15, 3, NULL, 12, '2026-02-15 10:00:00', '2026-03-20', '17:00', N'Ghaday''s home, Al Fanateer District, Jubail',          25, 1, 1200.00, NULL, 'Completed', '2026-02-16 10:00:00', '2026-02-15 15:00:00', NULL, NULL, NULL),
(16, 4, NULL, 14, '2026-08-01 09:00:00', '2026-09-01', '13:00', N'Hella''s home, Al Rakah District, Khobar',             NULL, 1, 700.00,  NULL, 'Completed', '2026-08-02 09:00:00', '2026-08-01 14:00:00', NULL, NULL, NULL),
(17, 1, NULL, 2,  '2026-01-10 09:00:00', '2026-02-10', '10:00', N'Hadeel''s university, Jubail',                        NULL, 1, 800.00,  NULL, 'Completed', '2026-01-11 09:00:00', '2026-01-10 13:00:00', NULL, NULL, NULL);
SET IDENTITY_INSERT bookings OFF;
GO

/* ---------------------------------------------------------------------
   10. PAYMENTS (15) — 1:1 with booking; excludes the 2 Pending/Rejected
       bookings that never reached payment (bookings 6 and 7)
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT payments ON;
INSERT INTO payments (payment_id, booking_id, invoice_number, amount, payment_method, payment_status, transaction_ref, payment_date, refund_amount, refund_date) VALUES
(1,  1,  'INV-WJ-2026-0001', 4500.00, 'Mada',          'Paid',     'TRX77001', '2025-10-02 11:00:00', NULL, NULL),
(2,  2,  'INV-WJ-2026-0002', 2200.00, 'Mada',          'Paid',     'TRX77002', '2025-10-02 11:05:00', NULL, NULL),
(3,  3,  'INV-WJ-2026-0003', 1500.00, 'Credit Card',   'Paid',     'TRX77003', '2025-10-02 11:10:00', NULL, NULL),
(4,  4,  'INV-WJ-2026-0004', 2500.00, 'Mada',          'Failed',   NULL,       '2026-10-20 12:30:00', NULL, NULL),
(5,  5,  'INV-WJ-2026-0005', 1200.00, 'STC Pay',       'Paid',     'TRX77005', '2025-10-05 19:00:00', NULL, NULL),
(6,  8,  'INV-WJ-2026-0006', 700.00,  'Apple Pay',     'Paid',     'TRX77006', '2025-10-03 15:30:00', NULL, NULL),
(7,  9,  'INV-WJ-2026-0007', 1800.00, 'Mada',          'Refunded', 'TRX77007', '2026-09-20 16:30:00', 1800.00, '2026-09-28 10:00:00'),
(8,  10, 'INV-WJ-2026-0008', 7000.00, 'Bank Transfer', 'Paid',     'TRX77008', '2026-07-01 14:30:00', NULL, NULL),
(9,  11, 'INV-WJ-2026-0009', 4500.00, 'Mada',          'Paid',     'TRX77009', '2026-06-10 15:30:00', NULL, NULL),
(10, 12, 'INV-WJ-2026-0010', 6000.00, 'STC Pay',       'Paid',     'TRX77010', '2026-05-01 16:30:00', NULL, NULL),
(11, 13, 'INV-WJ-2026-0011', 700.00,  'Mada',          'Paid',     'TRX77011', '2026-04-01 17:30:00', NULL, NULL),
(12, 14, 'INV-WJ-2026-0012', 1200.00, 'Credit Card',   'Paid',     'TRX77012', '2026-03-10 13:30:00', NULL, NULL),
(13, 15, 'INV-WJ-2026-0013', 1200.00, 'Mada',          'Paid',     'TRX77013', '2026-02-15 15:30:00', NULL, NULL),
(14, 16, 'INV-WJ-2026-0014', 700.00,  'Apple Pay',     'Paid',     'TRX77014', '2026-08-01 14:30:00', NULL, NULL),
(15, 17, 'INV-WJ-2026-0015', 800.00,  'Mada',          'Paid',     'TRX77015', '2026-01-10 13:30:00', NULL, NULL);
SET IDENTITY_INSERT payments OFF;
GO

/* ---------------------------------------------------------------------
   11. REVIEWS (8) — 1:1 with booking, only on Completed bookings
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT reviews ON;
INSERT INTO reviews (review_id, booking_id, moderated_by_admin_id, rating, review_text, review_date, is_visible) VALUES
(1, 10, NULL, 5, N'Amazing coverage, the team was professional and delivered right on time. Highly recommend Noor Lens!', '2026-08-16 09:00:00', 1),
(2, 11, NULL, 5, N'Lamasat Studio captured every moment beautifully. Worth every riyal.',                                '2026-07-22 09:00:00', 1),
(3, 12, 2,    3, N'Beautiful decoration, though the setup started later than agreed and the team seemed a bit disorganized.', '2026-06-12 09:00:00', 1),
(4, 13, NULL, 5, N'The dessert table was stunning and everyone loved the mini desserts.',                                 '2026-05-03 09:00:00', 1),
(5, 14, NULL, 4, N'Lovely fresh flowers, arrived slightly later than the agreed time.',                                   '2026-04-17 09:00:00', 1),
(6, 15, NULL, 5, N'Rawnaq Decor turned my daughter''s birthday into something out of a magazine.',                       '2026-03-22 09:00:00', 1),
(7, 16, NULL, 5, N'Hena Ward did gorgeous bridal henna, very detailed work.',                                             '2026-09-03 09:00:00', 1),
(8, 17, NULL, 4, N'Great graduation photos, just wish we had more outdoor shots.',                                        '2026-02-12 09:00:00', 1);
SET IDENTITY_INSERT reviews OFF;
GO

/* ---------------------------------------------------------------------
   12. MESSAGES (12) — chat threads between a customer and a provider
   --------------------------------------------------------------------- */
SET IDENTITY_INSERT messages ON;
INSERT INTO messages (message_id, customer_id, provider_id, booking_id, sender_type, message_text, attachment_url, sent_at, is_read) VALUES
(1,  1, 1, 1, 'Customer', N'Hi, I''d like to confirm the photographer will be female for our hall.',          NULL, '2025-10-01 09:00:00', 1),
(2,  1, 1, 1, 'Provider', N'Yes, both of our photographers for that date are female. Looking forward to it!', NULL, '2025-10-01 09:30:00', 1),
(3,  1, 4, 3, 'Customer', N'Can the cake be delivered by 5 PM instead of later?',                             NULL, '2025-10-01 11:00:00', 1),
(4,  1, 4, 3, 'Provider', N'Sure, we will deliver by 5 PM as requested.',                                     NULL, '2025-10-01 11:20:00', 1),
(5,  2, 3, 4, 'Customer', N'What theme options do you have for graduation decoration?',                       NULL, '2026-10-20 13:00:00', 0),
(6,  5, 2, 5, 'Customer', N'Do you deliver bouquets to Riyadh or only Jubail?',                                NULL, '2025-10-05 08:00:00', 1),
(7,  5, 2, 5, 'Provider', N'We can deliver to Riyadh for an additional travel fee.',                           NULL, '2025-10-05 08:30:00', 1),
(8,  6, 4, 6, 'Customer', N'Is the dessert table customizable to pastel pink and gold?',                       NULL, '2026-11-01 14:10:00', 0),
(9,  4, 1, 7, 'Provider', N'I''m sorry, we are fully booked on 25 November for graduation season.',           NULL, '2026-10-16 09:00:00', 1),
(10, 4, 1, 7, 'Customer', N'No problem, can we do 27 November instead?',                                      NULL, '2026-10-16 09:15:00', 1),
(11, 3, 9, 8, 'Customer', N'Can you also do henna for the groom''s sister?',                                   NULL, '2025-10-03 10:30:00', 1),
(12, 3, 9, 8, 'Provider', N'Yes, we can add one more guest henna for an extra fee.',                           NULL, '2025-10-03 10:45:00', 1);
SET IDENTITY_INSERT messages OFF;
GO

/* ---------------------------------------------------------------------
   Row-count sanity check
   --------------------------------------------------------------------- */
SELECT 'admins' t, COUNT(*) rows FROM admins
UNION ALL SELECT 'customers', COUNT(*) FROM customers
UNION ALL SELECT 'services', COUNT(*) FROM services
UNION ALL SELECT 'service_providers', COUNT(*) FROM service_providers
UNION ALL SELECT 'service_categories', COUNT(*) FROM service_categories
UNION ALL SELECT 'provider_services', COUNT(*) FROM provider_services
UNION ALL SELECT 'availability_schedules', COUNT(*) FROM availability_schedules
UNION ALL SELECT 'my_events', COUNT(*) FROM my_events
UNION ALL SELECT 'bookings', COUNT(*) FROM bookings
UNION ALL SELECT 'payments', COUNT(*) FROM payments
UNION ALL SELECT 'reviews', COUNT(*) FROM reviews
UNION ALL SELECT 'messages', COUNT(*) FROM messages;
GO
