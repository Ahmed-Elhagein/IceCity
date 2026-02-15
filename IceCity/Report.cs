namespace IceCity
{
    public class Report
    {
        private Service1 _calculationService;

        public Report(Service1 service)
        {
            this._calculationService = service;
        }

        public string GetFinalReport(House house)
        {
            double finalCost = house.CalculateHeatingCost(this._calculationService);

            return "The monthly average heating cost for owner " + house.Owner.Name + " is: " + finalCost ;
        }
    }
}