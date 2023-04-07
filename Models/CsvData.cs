namespace Laplace.Models;
public class CsvData
{
    public class EodValues
    {
        public DateTime Data { get; set; }
        public double Ultimo { get; set; }
        public double Abertura { get; set; }
        public double Alta { get; set; }
        public double Baixa { get; set; }
        public double Vol { get; set; }
        public double Var { get; set; }

        public EodValues()
        {
            Data = new DateTime();
            Ultimo = 0; Abertura = 0; Alta = 0; Baixa = 0; Vol = 0; Var = 0;
        }
        public EodValues(DateTime data, double ultimo, double abertura, double alta, double baixa, double vol, double var)
        {
            Data = data; Ultimo = ultimo; Abertura = abertura; Alta = alta; Baixa = baixa; Vol = vol; Var = var;
        }
    }

    public class GrdLine
    {
        public DateTime Data { get; set; }
        public double QuoteVale { get; set; }
        public double QuoteIron { get; set; }
        public double AvgDeltaVale { get; set; }    //  X - Xavg
        public double AvgDeltaIron { get; set; }    //  Y - Yavg
        public double Covar { get; set; }           //  ( X - Xavg ) * ( Y - Yavg )
        public double AvgDeltaSigmaVale { get; set; }    //  ( X - Xavg ) / StdDev
        public double AvgDeltaSigmaIron { get; set; }    //  ( Y - Yavg ) / StdDev
        public double Corr { get; set; }

        public GrdLine() 
        {
            Data = new DateTime();
            QuoteVale = 0; QuoteIron = 0;  Covar = 0;  Corr = 0;   
        }
        public GrdLine( DateTime data, double quoteVale, double quoteIron, double covar, double corr) 
        {
            Data = data; QuoteVale = quoteVale; QuoteIron = quoteIron; Covar = covar; Corr = corr;
        }
    }
}