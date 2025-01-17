﻿using Milmom_Service.Model.Response.Category;
using Milmom_Service.Model.Response.ImageProduct;
using Milmom_Service.Model.Response.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Product
{
    public class GetProductByIdResponse
    {
        public string Name { get; set; }
        public double PurchasePrice { get; set; }
        public ICollection<GetAllImageProductsResponse> ImageProducts { get; set; }
        public GetCategoryResponse Category { get; set; }
        public ICollection<RatingResponse> Ratings { get; set; }
    }
}
