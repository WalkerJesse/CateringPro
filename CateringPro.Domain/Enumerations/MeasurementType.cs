namespace CateringPro.Domain.Enumerations
{

    public class MeasurementType : Enumeration
    {

        #region - - - - - - Fields - - - - - -

        public static readonly MeasurementType Gram = new WeightMeasurementType("Gram", 1);

        public static readonly MeasurementType Kilogram = new WeightMeasurementType("Kilogram", 2);

        public static readonly MeasurementType Millilitre = new VolumeMeasurementType("Millilitre", 3);

        public static readonly MeasurementType Litre = new VolumeMeasurementType("Litre", 4);

        public static readonly MeasurementType Cup = new VolumeMeasurementType("Cup", 5);

        public static readonly MeasurementType Teaspoon = new VolumeMeasurementType("Teaspoon", 6);

        public static readonly MeasurementType Tablespoon = new VolumeMeasurementType("Tablespoon", 7);

        public static readonly MeasurementType Item = new ItemMeasurementType("Item", 8);

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        private MeasurementType() { }

        protected MeasurementType(string name, long value) : base(name, value) { }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public static implicit operator MeasurementType(string name)
            => FromName<MeasurementType>(name);

        public static implicit operator MeasurementType(long value)
            => FromValue<MeasurementType>(value);

        public virtual decimal GetBaseMeasurement(decimal measurement)
            => 0;

        #endregion Methods

        #region - - - - - - Nested Classes - - - - - -

        private class WeightMeasurementType : MeasurementType
        {

            #region - - - - - - Constructors - - - - - -

            public WeightMeasurementType(string name, int value) : base(name, value) { }

            #endregion Constructors

            #region - - - - - - Methods - - - - - -

            public override decimal GetBaseMeasurement(decimal measurement)
                => this.Name switch
                {
                    "Gram" => measurement,
                    "Kilogram" => measurement * 1000
                };

            #endregion Methods

        }

        private class VolumeMeasurementType : MeasurementType
        {

            #region - - - - - - Constructors - - - - - -

            public VolumeMeasurementType(string name, int value) : base(name, value) { }

            #endregion Constructors

            #region - - - - - - Methods - - - - - -

            public override decimal GetBaseMeasurement(decimal measurement)
                => this.Name switch
                {
                    "Millilitre" => measurement,
                    "Litre" => measurement * 1000,
                    "Cup" => measurement * 250,
                    "Tablespoon" => measurement * 20,
                    "Teaspoon" => measurement * 5
                };

            #endregion Methods

        }

        private class ItemMeasurementType : MeasurementType
        {

            #region - - - - - - Constructors - - - - - -

            public ItemMeasurementType(string name, int value) : base(name, value) { }

            #endregion Constructors

            #region - - - - - - Methods - - - - - -
            public override decimal GetBaseMeasurement(decimal measurement)
               => measurement;

            #endregion Methods

        }

        #endregion Nested Classes

    }

}
