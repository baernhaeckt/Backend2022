using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MixMeal.Core.Models;

namespace MixMeal.Persistence.PostgreSQL;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

public class MixMealDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }

    public DbSet<Ingredient> Ingredients { get; set; }

    public DbSet<IngredientTag> IngredientTags { get; set; }

    public DbSet<Allergy> Allergies { get; set; }

    public DbSet<Menu> Menu { get; set; }

    public MixMealDbContext()
      : base()
    {
    }

    public MixMealDbContext(string connectionString)
        : base(new DbContextOptionsBuilder().UseNpgsql(connectionString).Options)
    {
        Database.Migrate();
    }

    public MixMealDbContext(DbContextOptions<MixMealDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>()
            .HasKey(i => i.Name);

        modelBuilder.Entity<Ingredient>()
            .Property(i => i.ValidDishTypes)
            .HasConversion(v => string.Join(',', v), v => ToValidDishTypes(v).ToList())
            .Metadata
            .SetValueComparer(EnumToStringValueComparer);

        modelBuilder.Entity<Ingredient>()
            .HasMany(i => i.Tags);

        modelBuilder.Entity<Dish>()
            .HasKey(d => d.Id);
        modelBuilder.Entity<Dish>()
            .HasMany(d => d.Ingredients)
            .WithMany(i => i.UsedIn);

        modelBuilder.Entity<Menu>()
            .HasKey(m => m.Id);
        modelBuilder.Entity<Menu>()
            .HasMany(m => m.Dishes)
            .WithMany(d => d.UsedIn);


        modelBuilder.Entity<User>()
            .HasKey(d => d.Id);

        modelBuilder.Entity<IntakeTrackingRecord>()
            .HasOne(i => i.User)
            .WithMany(u => u.IntakeTrackingRecords);

        modelBuilder.Entity<IntakeTrackingRecord>()
            .HasKey(i => i.Id);

        modelBuilder.Entity<Allergy>()
            .HasKey(a => a.Name);

        modelBuilder.Entity<IngredientTag>()
            .HasKey(t => t.Name);

        base.OnModelCreating(modelBuilder);
    }

    private static IEnumerable<DishType> ToValidDishTypes(string csvField)
        => csvField.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(val => (DishType)Enum.Parse(typeof(DishType), val));

    private static ValueComparer<IReadOnlyCollection<DishType>> EnumToStringValueComparer => new(
                (left, right) => left!.SequenceEqual(right!),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToHashSet());
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.