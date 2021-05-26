using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SCMSupplyChain.Model;
using WalkingTec.Mvvm.Core;

namespace SCMSupplyChain.DataAccess
{
    public class DataContext : FrameworkContext
    {
        public DbSet<FrameworkUser> FrameworkUsers { get; set; }
        #region 自定义生成数据表
        public DbSet<CheckDepot> CheckDepot { get; set; }
        public DbSet<CheckDepotDetail> CheckDepotDetail { get; set; }
        public DbSet<CustomerOrder> CustomerOrder { get; set; }
        public DbSet<CustomerOrderDetail> CustomerOrderDetail { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Depots> Depots { get; set; }
        public DbSet<DepotStock> DepotStock { get; set; }
        public DbSet<DevolveDetail> DevolveDetail { get; set; }
        public DbSet<Devolves> Devolves { get; set; }
        public DbSet<InOutDepot> InOutDepot { get; set; }
        public DbSet<InOutDepotDetail> InOutDepotDetail { get; set; }
        public DbSet<LostDetail> LostDetail { get; set; }
        public DbSet<Losts> Losts { get; set; }
        public DbSet<OtherInDepot> OtherInDepot { get; set; }
        public DbSet<OtherInDepotDetail> OtherInDepotDetail { get; set; }
        public DbSet<OtherOutDepot> OtherOutDepot { get; set; }
        public DbSet<OtherOutDepotDetail> OtherOutDepotDetail { get; set; }
        public DbSet<PayOffDetail> PayOffDetail { get; set; }
        public DbSet<PayOffs> PayOffs { get; set; }
        public DbSet<ProduceInDepot> ProduceInDepot { get; set; }
        public DbSet<ProduceInDepotDeteil> ProduceInDepotDeteil { get; set; }
        public DbSet<ProduceOutDepot> ProduceOutDepot { get; set; }
        public DbSet<ProduceOutDepotDetail> ProduceOutDepotDetail { get; set; }
        public DbSet<ProductLend> ProductLend { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductSpec> ProductSpec { get; set; }
        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<ProductUnit> ProductUnit { get; set; }
        public DbSet<QuotePrice> QuotePrice { get; set; }
        public DbSet<QuotePriceDetail> QuotePriceDetail { get; set; }
        public DbSet<SaleDepot> SaleDepot { get; set; }
        public DbSet<SaleDepotDetail> SaleDepotDetail { get; set; }
        public DbSet<SaleReturn> SaleReturn { get; set; }
        public DbSet<SaleReturnDetail> SaleReturnDetail { get; set; }
        public DbSet<StockDetail> StockDetail { get; set; }
        public DbSet<StockInDepot> StockInDepot { get; set; }
        public DbSet<StockInDepotDetail> StockInDepotDetail { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        #endregion

        public DataContext(CS cs)
             : base(cs)
        {
        }

        public DataContext(string cs, DBTypeEnum dbtype)
            : base(cs, dbtype)
        {
        }

        public DataContext(string cs, DBTypeEnum dbtype, string version = null)
            : base(cs, dbtype, version)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //调出仓库
            modelBuilder.Entity<Devolves>().HasOne(i => i.DepotsDevOut).WithMany().HasForeignKey(t => t.DepotsDevOutID).OnDelete(DeleteBehavior.Restrict);
            //调入仓库
            modelBuilder.Entity<Devolves>().HasOne(i => i.DepotsDevIn).WithMany().HasForeignKey(t => t.DepotsDevInID).OnDelete(DeleteBehavior.Restrict);
            //供货商
            modelBuilder.Entity<StockInDepot>().HasOne(i => i.ProductLend).WithMany().HasForeignKey(t => t.ProductLendID).OnDelete(DeleteBehavior.Restrict);
            //仓库
            modelBuilder.Entity<StockInDepot>().HasOne(i => i.Depots).WithMany().HasForeignKey(t => t.DepotsID).OnDelete(DeleteBehavior.Restrict);
            
            
            base.OnModelCreating(modelBuilder);
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public override async Task<bool> DataInit(object allModules, bool IsSpa)
        {
            var state = await base.DataInit(allModules, IsSpa);
            bool emptydb = false;
            try
            {
                emptydb = Set<FrameworkUser>().Count() == 0 && Set<FrameworkUserRole>().Count() == 0;
            }
            catch { }
            if (state == true || emptydb == true)
            {
                //when state is true, means it's the first time EF create database, do data init here
                //当state是true的时候，表示这是第一次创建数据库，可以在这里进行数据初始化
                var user = new FrameworkUser
                {
                    ITCode = "admin",
                    Password = Utils.GetMD5String("000000"),
                    IsValid = true,
                    Name = "Admin"
                };

                var userrole = new FrameworkUserRole
                {
                    UserCode = user.ITCode,
                    RoleCode = "001"
                };
                
                var adminmenus = Set<FrameworkMenu>().Where(x => x.Url != null && x.Url.StartsWith("/api") == false).ToList();
                foreach (var item in adminmenus)
                {
                    item.Url = "/_admin" + item.Url;
                }

                Set<FrameworkUser>().Add(user);
                Set<FrameworkUserRole>().Add(userrole);
                await SaveChangesAsync();
            }
            return state;
        }

    }

    /// <summary>
    /// 用于EF迁移的DesignTimeFactory，请使用完整的连接字符串，
    /// EF将找到此类，并使用此处定义的连接来运行Add-Migration和Update-Database
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext("your full connection string", DBTypeEnum.SqlServer);
        }
    }

}
