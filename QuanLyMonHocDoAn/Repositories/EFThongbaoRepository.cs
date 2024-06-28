using Microsoft.EntityFrameworkCore;
using QuanLyMonHocDoAn.Models;

namespace QuanLyMonHocDoAn.Repositories
{
    public class EFThongbaoRepository : IThongBaoRepository
    {
        private readonly QldetainckhContext _context;
        public EFThongbaoRepository(QldetainckhContext context)
        {
            _context = context;
        }
        
        public Task<Thongbao> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Thongbao>> GetGetAllAsyncAsync()
        {
            throw new NotImplementedException();
        }
    }
}
