using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
        public class CarDetailDto : IDto
        {
            public int Id { get; set; }
            public string CarName { get; set; }
            public string BrandName { get; set; }
            public string ColorName { get; set; }
            public string ModelYear { get; set; }
            public int DailyPrice { get; set; }
            public string Description { get; set; }
            public List<CarImage> CarImages { get; set; }
            public string ImagePath { get; set; }

        }
    }
