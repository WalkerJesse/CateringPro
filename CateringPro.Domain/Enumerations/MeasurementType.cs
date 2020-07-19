namespace CateringPro.Domain.Enumerations
{

    public class MeasurementType : Enumeration
    {

        #region - - - - - - Fields - - - - - -

        public static readonly MeasurementType Gram = new WeightMeasurementType("Gram", 0);

        public static readonly MeasurementType Kilogram = new WeightMeasurementType("Kilogram", 1);

        public static readonly MeasurementType Millilitre = new VolumeMeasurementType("Millilitre", 2);

        public static readonly MeasurementType Litre = new VolumeMeasurementType("Litre", 3);

        public static readonly MeasurementType Cup = new VolumeMeasurementType("Cup", 4);

        public static readonly MeasurementType Teaspoon = new VolumeMeasurementType("Teaspoon", 5);

        public static readonly MeasurementType Tablespoon = new VolumeMeasurementType("Tablespoon", 6);

        public static readonly MeasurementType Item = new ItemMeasurementType("Item", 7);

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        private MeasurementType() { }

        protected MeasurementType(string name, int value) : base(name, value) { }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public static implicit operator MeasurementType(string name)
            => FromName<MeasurementType>(name);

        public static implicit operator MeasurementType(int value)
            => FromValue<MeasurementType>(value);

        #endregion Methods

        #region - - - - - - Nested Classes - - - - - -

        private class WeightMeasurementType : MeasurementType
        {

            #region - - - - - - Constructors - - - - - -

            public WeightMeasurementType(string name, int value) : base(name, value) { }

            #endregion Constructors

            #region - - - - - - Methods - - - - - -

            //TODO conversion here from x to Weight

            #endregion Methods

        }

        private class VolumeMeasurementType : MeasurementType
        {

            #region - - - - - - Constructors - - - - - -

            public VolumeMeasurementType(string name, int value) : base(name, value) { }

            #endregion Constructors

            #region - - - - - - Methods - - - - - -

            //TODO conversion here from x to Volume

            #endregion Methods

        }

        private class ItemMeasurementType : MeasurementType
        {

            #region - - - - - - Constructors - - - - - -

            public ItemMeasurementType(string name, int value) : base(name, value) { }

            #endregion Constructors

            #region - - - - - - Methods - - - - - -

            // Cannot convert to and from weight or volume

            #endregion Methods

        }

        #endregion Nested Classes

    }

}
