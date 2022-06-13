namespace DepotDeck.Core;
public class InspectionModel
{
    public int Id { get; set; }

    public DateTime Dt1 = new DateTime();
    public string? Registration { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? Description { get; set; }
}
