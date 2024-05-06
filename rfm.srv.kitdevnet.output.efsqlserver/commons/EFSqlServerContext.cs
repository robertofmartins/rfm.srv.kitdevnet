using Microsoft.EntityFrameworkCore;
using rfm.srv.kitdevnet.output.sqlserver.ef.Item.Repository.Entity;

namespace rfm.srv.kitdevnet.output.sqlserver.ef.commons
{
    public class EFSqlServerContext : DbContext
    {
        public EFSqlServerContext(DbContextOptions<EFSqlServerContext> options)
            : base(options)
        {
        }

        internal DbSet<ItemEntity> Itens { get; set; }
    }
}
