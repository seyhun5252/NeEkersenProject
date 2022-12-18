using CoreLayer.DataAccess.EntityFramework;
using DataLayer.Abstract;
using DataLayer.Concrete.EntityFramework.Context;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concrete
{
    public class EfActivityDal : EfEntityRepositoryBase<Activity, ContextDb>, IActivityDal
    {
    }
}
