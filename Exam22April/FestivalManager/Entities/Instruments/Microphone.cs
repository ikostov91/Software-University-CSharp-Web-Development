namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int repaitAmmountValue = 80;

        protected override int RepairAmount => repaitAmmountValue;
    }
}
