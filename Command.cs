namespace SPTOIndividual
{
    public class Command
    {
        public string LeftBorder {  get; set; }
        public string RightBorder { get; set; }
        public string Eps {  get; set; }
        public int Method {  get; set; }
        public List<double> Coefficients {  get; set; } = new List<double>();
    }
}
