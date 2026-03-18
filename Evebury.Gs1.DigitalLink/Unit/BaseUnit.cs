namespace Evebury.Gs1.DigitalLink.Unit
{
    /// <summary>
    /// Base Unit
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseUnit<T> : Double, IBaseUnit
    {
        internal short Power { get; set; }
        internal string PostFix { get; set; }

        /// <summary>
        /// Unit (of Measure)
        /// </summary>
        public T Unit { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        protected BaseUnit(double value, T unit):base(value)
        {
            Unit = unit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="precision"></param>
        /// <param name="unit"></param>
        protected BaseUnit(double value, int precision, T unit) :base(value,precision)
        {
            Unit = unit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract string GetSymbol();

        /// <summary>
        /// Formattable unit string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string value = base.ToString();
            string power = string.Empty;
            switch (Power) 
            {
                case 2: 
                    {
                        power = "²";
                        break;
                    }
                case 3:
                    {
                        power = "³";
                        break;
                    }
            }
            string postFix = string.Empty;
            if(PostFix != null) postFix = PostFix;
            return $"{value} {GetSymbol()}{power}{postFix}";
        }
    }
}
