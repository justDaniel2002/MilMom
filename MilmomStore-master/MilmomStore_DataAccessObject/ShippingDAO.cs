using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;

namespace MilmomStore_DataAccessObject;

public class ShippingDAO : BaseDAO<ShippingInfor>
{
    private readonly MilmomSystemContext _context;
    public ShippingDAO(MilmomSystemContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
}