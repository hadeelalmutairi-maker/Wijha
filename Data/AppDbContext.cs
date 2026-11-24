using Microsoft.EntityFrameworkCore;
using Wijha.Models;

namespace Wijha.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<FailedJob> FailedJobs => Set<FailedJob>();

    public DbSet<Admin> Admins => Set<Admin>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Service> Services => Set<Service>();

    public DbSet<ServiceProvider> ServiceProviders => Set<ServiceProvider>();

    public DbSet<ServiceCategory> ServiceCategories => Set<ServiceCategory>();

    public DbSet<ProviderService> ProviderServices => Set<ProviderService>();

    public DbSet<AvailabilitySchedule> AvailabilitySchedules => Set<AvailabilitySchedule>();

    public DbSet<MyEvent> MyEvents => Set<MyEvent>();

    public DbSet<Booking> Bookings => Set<Booking>();

    public DbSet<Payment> Payments => Set<Payment>();

    public DbSet<Review> Reviews => Set<Review>();

    public DbSet<Message> Messages => Set<Message>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FailedJob>(e =>
        {
            e.ToTable("failed_jobs");
            e.HasKey(x => x.Id).HasName("PK_failed_jobs");
            e.HasIndex(x => x.Uuid).IsUnique().HasDatabaseName("UQ_failed_jobs_uuid");
            e.Property(x => x.FailedAt).HasDefaultValueSql("GETDATE()");
        });

        modelBuilder.Entity<Admin>(e =>
        {
            e.ToTable("admins", t => t.HasCheckConstraint("CK_admins_role", "admin_role IN ('Super Admin','Support Admin')"));
            e.HasKey(x => x.AdminId).HasName("PK_admins");
            e.Property(x => x.FullName).HasMaxLength(100).IsRequired();
            e.Property(x => x.Email).HasMaxLength(150).IsRequired();
            e.Property(x => x.PasswordHash).HasMaxLength(255).IsUnicode(false).IsRequired();
            e.Property(x => x.Phone).HasMaxLength(20).IsUnicode(false).IsRequired();
            e.Property(x => x.AdminRole).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Support Admin");
            e.Property(x => x.LastLogin).HasColumnType("datetime2(0)");
            e.Property(x => x.CreatedAt).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            e.HasIndex(x => x.Email).IsUnique().HasDatabaseName("UQ_admins_email");
            e.HasIndex(x => x.Phone).IsUnique().HasDatabaseName("UQ_admins_phone");
        });

        modelBuilder.Entity<Customer>(e =>
        {
            e.ToTable("customers", t =>
            {
                t.HasCheckConstraint("CK_customers_gender", "gender IN ('Male','Female')");
                t.HasCheckConstraint("CK_customers_status", "account_status IN ('Active','Blocked')");
            });
            e.HasKey(x => x.CustomerId).HasName("PK_customers");
            e.Property(x => x.FirstName).HasMaxLength(60).IsRequired();
            e.Property(x => x.LastName).HasMaxLength(60).IsRequired();
            e.Property(x => x.Email).HasMaxLength(150).IsRequired();
            e.Property(x => x.PasswordHash).HasMaxLength(255).IsUnicode(false).IsRequired();
            e.Property(x => x.Phone).HasMaxLength(20).IsUnicode(false).IsRequired();
            e.Property(x => x.Gender).HasMaxLength(10).IsUnicode(false);
            e.Property(x => x.City).HasMaxLength(60).IsRequired();
            e.Property(x => x.ProfileImageUrl).HasMaxLength(255);
            e.Property(x => x.AccountStatus).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Active");
            e.Property(x => x.RegistrationDate).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            e.Property(x => x.LastLogin).HasColumnType("datetime2(0)");
            e.HasIndex(x => x.Email).IsUnique().HasDatabaseName("UQ_customers_email");
            e.HasIndex(x => x.Phone).IsUnique().HasDatabaseName("UQ_customers_phone");
        });

        modelBuilder.Entity<Service>(e =>
        {
            e.ToTable("services");
            e.HasKey(x => x.ServiceId).HasName("PK_services");
            e.Property(x => x.ServiceName).HasMaxLength(100).IsRequired();
            e.Property(x => x.ServiceDescription).HasMaxLength(500);
            e.Property(x => x.IconUrl).HasMaxLength(255);
            e.Property(x => x.IsActive).HasDefaultValue(true);
            e.HasIndex(x => x.ServiceName).IsUnique().HasDatabaseName("UQ_services_name");
        });

        modelBuilder.Entity<ServiceProvider>(e =>
        {
            e.ToTable("service_providers", t =>
            {
                t.HasCheckConstraint("CK_service_providers_rating", "average_rating BETWEEN 0 AND 5");
                t.HasCheckConstraint("CK_service_providers_total_reviews", "total_reviews >= 0");
                t.HasCheckConstraint("CK_service_providers_approval", "approval_status IN ('Pending','Approved','Rejected')");
                t.HasCheckConstraint("CK_service_providers_status", "account_status IN ('Active','Blocked')");
            });
            e.HasKey(x => x.ProviderId).HasName("PK_service_providers");
            e.Property(x => x.BusinessName).HasMaxLength(150).IsRequired();
            e.Property(x => x.OwnerName).HasMaxLength(100).IsRequired();
            e.Property(x => x.Email).HasMaxLength(150).IsRequired();
            e.Property(x => x.PasswordHash).HasMaxLength(255).IsUnicode(false).IsRequired();
            e.Property(x => x.Phone).HasMaxLength(20).IsUnicode(false).IsRequired();
            e.Property(x => x.City).HasMaxLength(60).IsRequired();
            e.Property(x => x.BusinessAddress).HasMaxLength(255).IsRequired();
            e.Property(x => x.BusinessDescription).HasMaxLength(1000);
            e.Property(x => x.CommercialRegisterNo).HasMaxLength(20).IsUnicode(false).IsRequired();
            e.Property(x => x.LogoUrl).HasMaxLength(255);
            e.Property(x => x.AverageRating).HasColumnType("decimal(3,2)").HasDefaultValue(0m);
            e.Property(x => x.TotalReviews).HasDefaultValue(0);
            e.Property(x => x.ApprovalStatus).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Pending");
            e.Property(x => x.AccountStatus).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Active");
            e.Property(x => x.SubscriptionStartDate).HasColumnType("date");
            e.Property(x => x.SubscriptionEndDate).HasColumnType("date");
            e.Property(x => x.RegistrationDate).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            e.HasIndex(x => x.Email).IsUnique().HasDatabaseName("UQ_service_providers_email");
            e.HasIndex(x => x.Phone).IsUnique().HasDatabaseName("UQ_service_providers_phone");
            e.HasIndex(x => x.CommercialRegisterNo).IsUnique().HasDatabaseName("UQ_service_providers_cr_no");
            e.HasIndex(x => x.AdminId).HasDatabaseName("IX_service_providers_admin_id");
            e.HasOne(x => x.Admin)
                .WithMany(a => a.ServiceProviders)
                .HasForeignKey(x => x.AdminId)
                .HasConstraintName("FK_service_providers_admin")
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<ServiceCategory>(e =>
        {
            e.ToTable("service_categories");
            e.HasKey(x => x.ServiceCategoryId).HasName("PK_service_categories");
            e.Property(x => x.CategoryName).HasMaxLength(100).IsRequired();
            e.Property(x => x.CategoryDescription).HasMaxLength(500);
            e.Property(x => x.DisplayOrder).HasDefaultValue(0);
            e.Property(x => x.IsActive).HasDefaultValue(true);
            e.HasIndex(x => x.ProviderId).HasDatabaseName("IX_service_categories_provider_id");
            e.HasOne(x => x.ServiceProvider)
                .WithMany(p => p.ServiceCategories)
                .HasForeignKey(x => x.ProviderId)
                .HasConstraintName("FK_service_categories_provider")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ProviderService>(e =>
        {
            e.ToTable("provider_services", t =>
            {
                t.HasCheckConstraint("CK_provider_services_price", "price >= 0");
                t.HasCheckConstraint("CK_provider_services_duration", "duration_hours IS NULL OR duration_hours >= 0");
                t.HasCheckConstraint("CK_provider_services_unit", "price_unit IN ('Fixed','Per Hour','Per Guest','Per Item')");
            });
            e.HasKey(x => x.ProviderServiceId).HasName("PK_provider_services");
            e.Property(x => x.OfferingTitle).HasMaxLength(150).IsRequired();
            e.Property(x => x.OfferingDescription).HasMaxLength(1000);
            e.Property(x => x.Price).HasColumnType("decimal(10,2)");
            e.Property(x => x.PriceUnit).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Fixed");
            e.Property(x => x.DurationHours).HasColumnType("decimal(4,1)");
            e.Property(x => x.PortfolioUrl).HasMaxLength(255);
            e.Property(x => x.ServiceCity).HasMaxLength(60).IsRequired();
            e.Property(x => x.IsActive).HasDefaultValue(true);
            e.Property(x => x.CreatedAt).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            e.Property(x => x.UpdatedAt).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            e.HasIndex(x => x.ProviderId).HasDatabaseName("IX_provider_services_provider_id");
            e.HasIndex(x => x.ServiceId).HasDatabaseName("IX_provider_services_service_id");
            e.HasIndex(x => x.ServiceCategoryId).HasDatabaseName("IX_provider_services_category_id");
            e.HasOne(x => x.ServiceProvider)
                .WithMany(p => p.ProviderServices)
                .HasForeignKey(x => x.ProviderId)
                .HasConstraintName("FK_provider_services_provider")
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Service)
                .WithMany(s => s.ProviderServices)
                .HasForeignKey(x => x.ServiceId)
                .HasConstraintName("FK_provider_services_service")
                .OnDelete(DeleteBehavior.NoAction);
            e.HasOne(x => x.ServiceCategory)
                .WithMany(c => c.ProviderServices)
                .HasForeignKey(x => x.ServiceCategoryId)
                .HasConstraintName("FK_provider_services_category")
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<AvailabilitySchedule>(e =>
        {
            e.ToTable("availability_schedules", t =>
            {
                t.HasCheckConstraint("CK_availability_status", "availability_status IN ('Open','Booked','Blocked')");
                t.HasCheckConstraint("CK_availability_times", "end_time > start_time");
            });
            e.HasKey(x => x.AvailabilityId).HasName("PK_availability_schedules");
            e.Property(x => x.AvailableDate).HasColumnType("date");
            e.Property(x => x.StartTime).HasColumnType("time(0)");
            e.Property(x => x.EndTime).HasColumnType("time(0)");
            e.Property(x => x.AvailabilityStatus).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Open");
            e.Property(x => x.UpdatedAt).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            e.HasIndex(x => new { x.ProviderId, x.AvailableDate, x.StartTime }).IsUnique().HasDatabaseName("UQ_availability_slot");
            e.HasIndex(x => x.ProviderId).HasDatabaseName("IX_availability_provider_id");
            e.HasOne(x => x.ServiceProvider)
                .WithMany(p => p.AvailabilitySchedules)
                .HasForeignKey(x => x.ProviderId)
                .HasConstraintName("FK_availability_provider")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<MyEvent>(e =>
        {
            e.ToTable("my_events", t =>
            {
                t.HasCheckConstraint("CK_my_events_type", "event_type IN ('Wedding','Engagement','Graduation','Birthday','Baby Shower','Corporate','National Day','Other')");
                t.HasCheckConstraint("CK_my_events_budget", "total_budget IS NULL OR total_budget >= 0");
                t.HasCheckConstraint("CK_my_events_status", "event_status IN ('Planning','Confirmed','Completed','Cancelled')");
            });
            e.HasKey(x => x.MyEventId).HasName("PK_my_events");
            e.Property(x => x.EventName).HasMaxLength(150).IsRequired();
            e.Property(x => x.EventType).HasMaxLength(50).IsUnicode(false).IsRequired();
            e.Property(x => x.EventDate).HasColumnType("date");
            e.Property(x => x.TotalBudget).HasColumnType("decimal(10,2)");
            e.Property(x => x.EventStatus).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Planning");
            e.Property(x => x.CreatedAt).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            e.HasIndex(x => x.CustomerId).HasDatabaseName("IX_my_events_customer_id");
            e.HasOne(x => x.Customer)
                .WithMany(c => c.MyEvents)
                .HasForeignKey(x => x.CustomerId)
                .HasConstraintName("FK_my_events_customer")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Booking>(e =>
        {
            e.ToTable("bookings", t =>
            {
                t.HasCheckConstraint("CK_bookings_guest_count", "guest_count IS NULL OR guest_count >= 0");
                t.HasCheckConstraint("CK_bookings_quantity", "quantity >= 1");
                t.HasCheckConstraint("CK_bookings_price", "agreed_price >= 0");
                t.HasCheckConstraint("CK_bookings_status", "booking_status IN ('Pending','Accepted','Rejected','Completed','Cancelled')");
            });
            e.HasKey(x => x.BookingId).HasName("PK_bookings");
            e.Property(x => x.BookingDate).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            e.Property(x => x.ServiceDate).HasColumnType("date");
            e.Property(x => x.ServiceTime).HasColumnType("time(0)");
            e.Property(x => x.VenueAddress).HasMaxLength(255).IsRequired();
            e.Property(x => x.Quantity).HasDefaultValue(1);
            e.Property(x => x.AgreedPrice).HasColumnType("decimal(10,2)");
            e.Property(x => x.SpecialRequirements).HasMaxLength(1000);
            e.Property(x => x.BookingStatus).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Pending");
            e.Property(x => x.ModificationDeadline).HasColumnType("datetime2(0)");
            e.Property(x => x.ProviderResponseDate).HasColumnType("datetime2(0)");
            e.Property(x => x.RejectionReason).HasMaxLength(500);
            e.Property(x => x.CancellationDate).HasColumnType("datetime2(0)");
            e.Property(x => x.CancellationReason).HasMaxLength(500);
            e.Ignore(x => x.Reference);
            e.HasIndex(x => x.CustomerId).HasDatabaseName("IX_bookings_customer_id");
            e.HasIndex(x => x.MyEventId).HasDatabaseName("IX_bookings_my_event_id");
            e.HasIndex(x => x.ProviderServiceId).HasDatabaseName("IX_bookings_provider_service_id");
            e.HasOne(x => x.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(x => x.CustomerId)
                .HasConstraintName("FK_bookings_customer")
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.MyEvent)
                .WithMany(m => m.Bookings)
                .HasForeignKey(x => x.MyEventId)
                .HasConstraintName("FK_bookings_my_event")
                .OnDelete(DeleteBehavior.NoAction);
            e.HasOne(x => x.ProviderService)
                .WithMany(p => p.Bookings)
                .HasForeignKey(x => x.ProviderServiceId)
                .HasConstraintName("FK_bookings_provider_service")
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Payment>(e =>
        {
            e.ToTable("payments", t =>
            {
                t.HasCheckConstraint("CK_payments_amount", "amount >= 0");
                t.HasCheckConstraint("CK_payments_method", "payment_method IN ('Mada','Credit Card','Apple Pay','STC Pay','Bank Transfer')");
                t.HasCheckConstraint("CK_payments_status", "payment_status IN ('Pending','Paid','Failed','Refunded')");
                t.HasCheckConstraint("CK_payments_refund", "refund_amount IS NULL OR refund_amount >= 0");
            });
            e.HasKey(x => x.PaymentId).HasName("PK_payments");
            e.Property(x => x.InvoiceNumber).HasMaxLength(30).IsUnicode(false).IsRequired();
            e.Property(x => x.Amount).HasColumnType("decimal(10,2)");
            e.Property(x => x.PaymentMethod).HasMaxLength(20).IsUnicode(false).IsRequired();
            e.Property(x => x.PaymentStatus).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Pending");
            e.Property(x => x.TransactionRef).HasMaxLength(50).IsUnicode(false);
            e.Property(x => x.PaymentDate).HasColumnType("datetime2(0)");
            e.Property(x => x.RefundAmount).HasColumnType("decimal(10,2)");
            e.Property(x => x.RefundDate).HasColumnType("datetime2(0)");
            e.HasIndex(x => x.BookingId).IsUnique().HasDatabaseName("UQ_payments_booking");
            e.HasIndex(x => x.InvoiceNumber).IsUnique().HasDatabaseName("UQ_payments_invoice");
            e.HasOne(x => x.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(x => x.BookingId)
                .HasConstraintName("FK_payments_booking")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Review>(e =>
        {
            e.ToTable("reviews", t => t.HasCheckConstraint("CK_reviews_rating", "rating BETWEEN 1 AND 5"));
            e.HasKey(x => x.ReviewId).HasName("PK_reviews");
            e.Property(x => x.Rating).HasColumnType("tinyint");
            e.Property(x => x.ReviewText).HasMaxLength(1000);
            e.Property(x => x.ReviewDate).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            e.Property(x => x.IsVisible).HasDefaultValue(true);
            e.HasIndex(x => x.BookingId).IsUnique().HasDatabaseName("UQ_reviews_booking");
            e.HasIndex(x => x.ModeratedByAdminId).HasDatabaseName("IX_reviews_admin_id");
            e.HasOne(x => x.Booking)
                .WithOne(b => b.Review)
                .HasForeignKey<Review>(x => x.BookingId)
                .HasConstraintName("FK_reviews_booking")
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Moderator)
                .WithMany(a => a.ModeratedReviews)
                .HasForeignKey(x => x.ModeratedByAdminId)
                .HasConstraintName("FK_reviews_admin")
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Message>(e =>
        {
            e.ToTable("messages", t => t.HasCheckConstraint("CK_messages_sender", "sender_type IN ('Customer','Provider')"));
            e.HasKey(x => x.MessageId).HasName("PK_messages");
            e.Property(x => x.SenderType).HasMaxLength(20).IsUnicode(false).IsRequired();
            e.Property(x => x.MessageText).HasMaxLength(1000).IsRequired();
            e.Property(x => x.AttachmentUrl).HasMaxLength(255);
            e.Property(x => x.SentAt).HasColumnType("datetime2(0)").HasDefaultValueSql("SYSDATETIME()");
            e.Property(x => x.IsRead).HasDefaultValue(false);
            e.HasIndex(x => x.CustomerId).HasDatabaseName("IX_messages_customer_id");
            e.HasIndex(x => x.ProviderId).HasDatabaseName("IX_messages_provider_id");
            e.HasIndex(x => x.BookingId).HasDatabaseName("IX_messages_booking_id");
            e.HasOne(x => x.Customer)
                .WithMany(c => c.Messages)
                .HasForeignKey(x => x.CustomerId)
                .HasConstraintName("FK_messages_customer")
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.ServiceProvider)
                .WithMany(p => p.Messages)
                .HasForeignKey(x => x.ProviderId)
                .HasConstraintName("FK_messages_provider")
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Booking)
                .WithMany(b => b.Messages)
                .HasForeignKey(x => x.BookingId)
                .HasConstraintName("FK_messages_booking")
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}
