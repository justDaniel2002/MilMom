using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_DataAccessObject
{
    public class ImageProductDAO : BaseDAO<ImageProduct>
    {
        private readonly MilmomSystemContext _context;
        public ImageProductDAO(MilmomSystemContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
