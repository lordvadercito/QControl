namespace QuarterControl.Models
{
    public abstract class Inspect : Entity
    {
        public int GarronID { get; set; }

        public abstract bool Aprueba();
    }
}
