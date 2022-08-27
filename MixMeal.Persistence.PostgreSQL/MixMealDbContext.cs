using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MixMeal.Core.Models;

namespace MixMeal.Persistence.PostgreSQL;

public class MixMealDbContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }

    public DbSet<Ingredient> Ingredients { get; set; }

    public DbSet<IngredientTag> IngredientTags { get; set; }

    public DbSet<Allergy> Allergies { get; set; }

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
            .HasKey(d => d.Name);


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

    private static ValueComparer<IReadOnlyCollection<DishType>> EnumToStringValueComparer
        => new ValueComparer<IReadOnlyCollection<DishType>>(
                (left, right) => left.SequenceEqual(right),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToHashSet());
}