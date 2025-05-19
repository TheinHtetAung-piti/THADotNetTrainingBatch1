using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THADotNetTrainingBatch1.Assi.Database.Models;

namespace THADotNetTrainingBatch1.Assi.Domain
{


    public class BlogService
    {
        private readonly AppDbContext _appDbContext;

        public BlogService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ResponseModel GetBlog(int letterCode)
        {
            try
            {
                var lstHedaer = _appDbContext.TblBlogHeaders
                            .Where(x => x.BlogId == letterCode)
                            .ToList();
                var lstDetails = _appDbContext.TblBlogDetails
                            .Where(x => x.BlogId == letterCode)
                            .ToList();
                return new ResponseModel(true, "Success", lstHedaer, lstDetails);
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.ToString());
            }
        }
    }
}
