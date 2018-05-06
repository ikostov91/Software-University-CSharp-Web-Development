namespace FestivalManager.Entities.Instruments
{
	public class Drums : Instrument
	{
	    private const int repaitAmmountValue = 20;

	    protected override int RepairAmount => repaitAmmountValue;
	}
}
