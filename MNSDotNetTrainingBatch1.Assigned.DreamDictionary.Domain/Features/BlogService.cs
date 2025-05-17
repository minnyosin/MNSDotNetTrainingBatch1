using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using MNSDotNetTrainingBatch1.Assigned.DreamDictionary.Database.Models;
using MNSDotNetTrainingBatch1.Assigned.DreamDictionary.Domain.Models;


namespace MNSDotNetTrainingBatch1.Assigned.DreamDictionary.Domain.Features
{
    public class BlogService
    {
        private readonly AppDbContext _dbContext;

        public BlogService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseModel GetBlogHeader(int id)
        {
            try
            {
                var lst = _dbContext.TblBlogHeaders.FirstOrDefault(x => x.BlogId == id);
                return new ResponseModel(true, "Success", lst);
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.ToString());
            }
        }
        public ResponseModel GetBlogDetail(int id)
        {
            try
            {
                var lst = _dbContext.TblBlogDetails.Where(x => x.BlogId == id);
                return new ResponseModel(true, "Success", lst);
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, ex.ToString());
            }
        }

    }
}