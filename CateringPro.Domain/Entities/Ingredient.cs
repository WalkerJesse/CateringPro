﻿using CateringPro.Domain.Enumerations;

namespace CateringPro.Domain.Entities
{

    public class Ingredient
    {

        #region - - - - - - Properties - - - - - -

        public long ID { get; set; }

        public MeasurementType MeasurementType { get; set; }

        public string Name { get; set; }

        #endregion Properties

    }

}
