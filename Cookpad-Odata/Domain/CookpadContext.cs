using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cookpad_Odata.Domain
{
    public partial class CookpadContext : DbContext
    {
        public CookpadContext()
        {
        }

        public CookpadContext(DbContextOptions<CookpadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<RecipesIngredients> RecipesIngredients { get; set; }
        public virtual DbSet<ShoppingList> ShoppingList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.HasKey(e => e.IngredientId)
                    .HasName("ingredients_pkey");

                entity.ToTable("ingredients", "cookpad");

                entity.Property(e => e.IngredientId)
                    .HasColumnName("ingredient_id")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CurrentQuantity)
                    .HasColumnName("current_quantity")
                    .HasColumnType("numeric");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasColumnName("ingredient_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.UnitOfMeasure)
                    .HasColumnName("unit_of_measure")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Recipes>(entity =>
            {
                entity.HasKey(e => e.RecipeId)
                    .HasName("recipes_pkey");

                entity.ToTable("recipes", "cookpad");

                entity.Property(e => e.RecipeId)
                    .HasColumnName("recipe_id")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.RecipeName)
                    .IsRequired()
                    .HasColumnName("recipe_name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<RecipesIngredients>(entity =>
            {
                entity.HasKey(e => e.RecipeIngredientId)
                    .HasName("recipes_ingredients_pkey");

                entity.ToTable("recipes_ingredients", "cookpad");

                entity.Property(e => e.RecipeIngredientId)
                    .HasColumnName("recipe_ingredient_id")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("numeric");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipesIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipes_ingredients_ingredient_id_fkey");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipesIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("recipes_ingredients_recipe_id_fkey");
            });

            modelBuilder.Entity<ShoppingList>(entity =>
            {
                entity.ToTable("shopping_list", "cookpad");

                entity.Property(e => e.ShoppingListId)
                    .HasColumnName("shopping_list_id")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.ShoppingList)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("shopping_list_ingredient_id_fkey");
            });
        }
    }
}
