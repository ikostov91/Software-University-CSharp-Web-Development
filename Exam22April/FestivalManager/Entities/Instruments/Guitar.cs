namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int repaitAmmountValue = 60;

	    protected override int RepairAmount => repaitAmmountValue;
    }
}
