using QuanLyMonHocDoAn.Models;

namespace QuanLyMonHocDoAn.Repositories
{
    public interface IThongBaoRepository
    {
        Task<IEnumerable<Thongbao>> GetGetAllAsyncAsync();
        Task<Thongbao> GetByIdAsync(int id);
        
    }
}
