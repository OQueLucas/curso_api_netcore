using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root";
            var optionsBuider = new DbContextOptionsBuilder<MyContext>();
            optionsBuider.UseMySql(connectionString);
            return new MyContext(optionsBuider.Options);
        }
    }
}
