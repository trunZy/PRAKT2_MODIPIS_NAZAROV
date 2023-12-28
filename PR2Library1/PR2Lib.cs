namespace PR2Library1
{
    public class PR2Lib
    {
        public PR2OutputData Calc(PR2InputData data)
        {
            var rows = new List<PR2OutputRow>();
            var rows1 = new List<PR2OutputRow>();


            double m = Math.Round((data.C_MAT * data.Rashod) / (data.C_GAS * data.V_GAS * 3.14 * (Math.Pow(data.D_ap / 2, 2))), 4);

            double y0 = Math.Round((data.koefficient * data.H) / (data.V_GAS * data.C_GAS * 1000), 4);

            double Y0 = Math.Round(1 - (m * Math.Exp(((m - 1) * y0) / m)), 4);

        
            for (double i = 0; i <= data.H; i += 0.5)
            {
                double YYY = Math.Round(((data.koefficient * i) / (data.V_GAS * data.C_GAS * 1000)), 4);
                double exp_exp = Math.Round(1 - Math.Exp(((m - 1) * YYY) / m), 4);
                double mexp_mexp = Math.Round(1 - m * Math.Exp(((m - 1) * YYY) / m), 4);
                double vvv = Math.Round(exp_exp/(1 - m * Math.Exp(((m - 1) * y0) / m)), 4);
                double ooo = Math.Round(mexp_mexp / (1 - m * Math.Exp(((m - 1) * y0) / m)), 4);
                double t_small = Math.Round(data.T_MAT + (data.T_GAS - data.T_MAT) * vvv, 0);
                double T_big = Math.Round(data.T_MAT + (data.T_GAS - data.T_MAT) * ooo, 0);
                double T_minus_t = Math.Abs(T_big - t_small);

                rows.Add(new PR2OutputRow { 
                    X = i,                  
                    tmal = t_small,
                    TBOL = T_big,
                    RASN_T_t = T_minus_t

                });
            }


            return new PR2OutputData

            {
                Rows = rows,
                
                yyyyyyyyy = Y0
            };
                
        }
    }
}
