using DepotDeck.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DepotDeck.Pages.Inspection
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public InspectionModel? NewInspection { get; set; }
        public List<InspectionModel> inspections = new();
        public void OnGet()
        {
            inspections = new List<InspectionModel>
            {
                new InspectionModel {
                    Id = 1,
                    Registration = "MW57FRK",
                    Make = "Ford",
                    Model = "FireTruck",
                    Description = "Something is wrong with it..."
                }                
            };
        }
    }
}
