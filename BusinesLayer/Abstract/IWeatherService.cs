﻿using CoreLayer.Results.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IWeatherService
    {
        IDataResult<List<Results>> GetList(string city);

    }
}
