namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Roll
    /// </summary>
    /// <param name="slitWidth"></param>
    /// <param name="length"></param>
    /// <param name="diameter"></param>
    /// <param name="winding"></param>
    /// <param name="splice"></param>
    public class Roll(int slitWidth, int length, int diameter, Winding winding, Splice splice)
    {
        /// <summary>
        /// Slit width in millimetres (width of the roll)
        /// </summary>
        public int SlitWidth { get; private set; } = slitWidth;

        /// <summary>
        /// Actual length in metres
        /// </summary>
        public int Length { get; private set; } = length;

        /// <summary>
        /// Internal core diameter in millimetres
        /// </summary>
        public int Diameter { get; private set; } = diameter;

        /// <summary>
        /// Winding Direction
        /// </summary>
        public Winding Winding { get; private set; } = winding;

        /// <summary>
        /// Number of Splices
        /// </summary>
        public Splice Splices { get; private set; } = splice;
    }

    /// <summary>
    /// Winding Direction
    /// </summary>
    public enum Winding 
    {
        /// <summary>
        /// Face out
        /// </summary>
        FACE_OUT = 0,
        /// <summary>
        /// Face in
        /// </summary>
        FACE_IN = 1,
        /// <summary>
        /// Undefined
        /// </summary>
        UNDEFINED = 9,
    }

    /// <summary>
    /// Splice
    /// </summary>
    public enum Splice 
    {
        /// <summary>
        /// Splice 0
        /// </summary>
        SPLICE_0 = 0,
        /// <summary>
        /// Splice 1
        /// </summary>
        SPLICE_1 = 1,
        /// <summary>
        /// Splice 2
        /// </summary>
        SPLICE_2 = 2,
        /// <summary>
        /// Splice 3
        /// </summary>
        SPLICE_3 = 3,
        /// <summary>
        /// Splice 4
        /// </summary>
        SPLICE_4 = 4,
        /// <summary>
        /// Splice 5
        /// </summary>
        SPLICE_5 = 5,
        /// <summary>
        /// Splice 6
        /// </summary>
        SPLICE_6 = 6,
        /// <summary>
        /// Splice 7
        /// </summary>
        SPLICE_7 = 7,
        /// <summary>
        /// Splice 8
        /// </summary>
        SPLICE_8 = 8,
        /// <summary>
        /// Undefined
        /// </summary>
        UNDEFINED = 9,
    }
}
