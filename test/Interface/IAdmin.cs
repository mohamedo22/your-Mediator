using test.Dto;

namespace test.Interface
{
    public interface IAdmin
    {
        public bool addAdmin(AdminDTO adminDTO);
        public bool removeAdmin(int adminID);
        public bool editAdmin (AdminDTO adminDTO,int adminID);
        public List<AdminDTO> getAdmins();
    }
}
