using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;
namespace MilmomStore_DataAccessObject;

public class OrderDetailDAO : BaseDAO<OrderDetail>
{
    private readonly MilmomSystemContext _context;
    public OrderDetailDAO(MilmomSystemContext context) : base(context)
    {
        _context = context;
    }
}