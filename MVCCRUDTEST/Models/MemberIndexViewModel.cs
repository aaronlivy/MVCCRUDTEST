using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Mapster;
using X.PagedList;

namespace MVCCRUDTEST.Models
{
    public class MemberIndexViewModel
    {
        private MemeberRepository repo = RepositoryHelper.GetMemeberRepository();

        public int pageNo { get; set; } = 1;
        public int pageSize { get; set; } = 10;

        public string Q_Name { get; set; }

        public IPagedList<MemberItemViewModel> DataList { get; set; }

        public IQueryable<MemberItemViewModel> _Search()
        {
            IQueryable<Memeber> Result1 = repo.GetAll();

            if (!string.IsNullOrEmpty(Q_Name))
                Result1 = Result1.Where(o => o.Name.Contains(Q_Name));
           
            IQueryable<MemberItemViewModel> Result = Result1.ProjectToType<MemberItemViewModel>();

            return Result;
        }

        public void Search()
        {            
            DataList = _Search().ToPagedList(pageNo, pageSize);
        }
    }
}