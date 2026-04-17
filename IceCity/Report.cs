namespace IceCity
{
    public class Report
    {
       
        private CostService _calculationService;

        public Report(CostService service)
        {
            this._calculationService = service;
        }

        public string GetFinalReport(House house)
        {
            double finalCost = house.CalculateHeatingCost(this._calculationService);
            return "The monthly average heating cost for owner " + house.Owner.Name + " is: $" + finalCost.ToString("F2");
        }
    }
}