using CoreLayer.Results.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IActivityService
    {
        IResult Add(ActivityDto activityDto);
        IResult Update(Activity activity, string Id);
        IResult Delete(string Id);
        IDataResult<List<Activity>> GetList();
    }
}
