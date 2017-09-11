using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAccountAPI.Models
{
    public class MyContext : DbContext
    {
        /// <summary>
        /// Entidade de contas
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Entidade de clientes
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Entidade de compras
        /// </summary>
        public DbSet<Purchase> Purchases { get; set; }

        public MyContext(DbContextOptions options) : base(options)
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Vinicius\\Documents\\webPurchase.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.ForSqlServerUseIdentityColumns();

            SettingsAccount(construtorDeModelos);
            SettingsClient(construtorDeModelos);
            SettingsPurchase(construtorDeModelos);
        }

        private void SettingsAccount(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<Account>(etd =>
            {
                etd.ToTable("tb_account");
                etd.HasKey(c => c.code).HasName("cd_account");
                etd.Property(c => c.code).HasColumnName("cd_account").ValueGeneratedOnAdd();
                etd.Property(c => c.account).HasColumnName("nm_account").HasMaxLength(250);
                etd.Property(c => c.agency).HasColumnName("nm_agency").HasMaxLength(250);
                etd.Property(c => c.digit).HasColumnName("nm_digit").HasMaxLength(2);
                etd.Property(c => c.codeBank).HasColumnName("nm_bank").HasMaxLength(4);
                etd.Property(c => c.status).HasColumnName("tp_status");
            });
        }

        private void SettingsClient(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<Client>(etd =>
           {
               etd.ToTable("tb_client");
               etd.HasKey(c => c.code).HasName("cd_client");
               etd.Property(c => c.code).HasColumnName("cd_client").ValueGeneratedOnAdd();
               etd.Property(c => c.name).HasColumnName("nm_name").HasMaxLength(250);
               etd.Property(c => c.cpf).HasColumnName("nm_cpf").HasMaxLength(11);
               etd.Property(c => c.birthyDay).HasColumnName("dt_birthyDay");
               etd.Property(c => c.genre).HasColumnName("tp_genre");
               etd.Property(c => c.telephone).HasColumnName("nm_telefone").HasMaxLength(30);
               etd.Property(c => c.telephone1).HasColumnName("nm_telefone1").HasMaxLength(30);
               etd.Property(c => c.email).HasColumnName("nm_email").HasMaxLength(250);
               etd.Property(c => c.cep).HasColumnName("nm_cep").HasMaxLength(30);
               etd.Property(c => c.address).HasColumnName("nm_address").HasMaxLength(250);
               etd.Property(c => c.number).HasColumnName("nr_number");
               etd.Property(c => c.neighboorood).HasColumnName("nm_neighboorood").HasMaxLength(250);
               etd.Property(c => c.city).HasColumnName("nm_city").HasMaxLength(250);
               etd.Property(c => c.state).HasColumnName("nm_state").HasMaxLength(250);
               etd.Property(c => c.status).HasColumnName("tp_status");
           });
        }

        private void SettingsPurchase(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<Purchase>(etd =>
            {
                etd.ToTable("tb_purchase");
                etd.HasKey(p => p.code).HasName("cd_purchase");
                etd.Property(p => p.price).HasColumnName("nr_price").ValueGeneratedOnAdd();
                etd.Property(p => p.purchaseDate).HasColumnName("dt_purchase");
                etd.Property(p => p.quantity).HasColumnName("nr_quantity");
                etd.Property(c => c.status).HasColumnName("tp_status");
                //etd.HasOne(c => c.client).WithMany(p => p.);
            });

        }
    }
}
