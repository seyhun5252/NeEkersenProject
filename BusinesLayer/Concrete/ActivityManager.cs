using BusinesLayer.Abstract;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DataLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BusinesLayer.Concrete
{
    public class ActivityManager : IActivityService
    {
        private readonly IActivityDal _activitDal;

        public ActivityManager(IActivityDal activitDal)
        {
            _activitDal = activitDal;
        }

        public IResult Add(ActivityDto activityDto)
        {
            Guid guid = Guid.NewGuid();

            // guid'in string değerini al
            string guidString = guid.ToString();


            Activity  activity = new Activity
            {
                Category = activityDto.Category,
                City = activityDto.City,
                Date =DateTime.Now,
                Description = activityDto.Description,
                Title = activityDto.Title,
                Venue = activityDto.Venue,
                Id = guid
            }; 

            _activitDal.Add(activity);
            return new SuccessResult("Başarıyla Eklendi");
        }

        public IResult Delete(string Id)
        {
            var result = _activitDal.Get(x => x.Id == new Guid(Id));

            if (result != null)
            {
                _activitDal.Delete(result);
                return new SuccessResult("Başarıyla Silindi");

            }

            return new ErrorResult("Böyle bir Id yok");
        }

        public IDataResult<List<Activity>> GetList()
        {
            return new SuccessDataResult<List<Activity>>(_activitDal.GetList());
        }

        public IResult Update(Activity activity, string Id)
        {
            var result = _activitDal.Get(x => x.Id == new Guid(Id));

            if (result == null)
            {
                return new ErrorResult("Böyle bir Id yok");

            }
            result.Title = activity.Title;
            result.Venue = activity.Venue;
            result.City = activity.City;
            result.Description = activity.Description;
            result.Category = activity.Category;
            

            _activitDal.Update(result);
            return new SuccessResult("Başarıyla Güncellendi");


        }
    }
}
