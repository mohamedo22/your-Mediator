using test.Configuration;
using test.Dto;
using test.Interface;

namespace test.Repos
{
    public class AdminRepo : IAdmin
    {
        private readonly AppDbContext appDbContext;

        public AdminRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public bool addAdmin(AdminDTO adminDTO)
        {
            throw new NotImplementedException();
        }

        public bool editAdmin(AdminDTO adminDTO, int adminID)
        {
            throw new NotImplementedException();
        }

        public List<AdminDTO> getAdmins()
        {
            throw new NotImplementedException();
        }

        public bool removeAdmin(int adminID)
        {
            throw new NotImplementedException();
        }
    }
}
