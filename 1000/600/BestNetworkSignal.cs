namespace DailyExercises
{
    /// <summary>
    /// 1620. 网络信号最好的坐标
    /// </summary>
    internal class BestNetworkSignal
    {
        //public static int[] BestCoordinate(int[][] towers, int radius)
        //{
        //    SignalTower[] signalTowers = new SignalTower[towers.Length];
        //    XY minPoint = new(int.MaxValue, int.MaxValue);
        //    XY maxPoint = new(int.MinValue, int.MinValue);
        //    for (int i = 0; i < towers.Length; i++)
        //    {
        //        SignalTower signalTower = new(towers[i][0], towers[i][1], towers[i][2], radius);
        //        signalTowers[i] = signalTower;
        //        maxPoint.X = Math.Max(maxPoint.X, signalTower.X);
        //        maxPoint.Y = Math.Max(maxPoint.Y, signalTower.Y);
        //        minPoint.X = Math.Min(minPoint.X, signalTower.X);
        //        minPoint.Y = Math.Min(minPoint.Y, signalTower.Y);
        //    }

        //    List<SignalPoint> signalPoints = new();
        //    for (int i = minPoint.Y; i <= maxPoint.Y; i++)
        //    {
        //        for (int j = minPoint.X; j <= maxPoint.X; j++)
        //        {
        //            XY point = new(j, i);
        //            double signalStrength = signalTowers.Select(t => t.GetSignalStrength(point)).Sum();
        //            signalPoints.Add(new SignalPoint(point, signalStrength));
        //        }
        //    }

        //    var result = SignalPoint.GetMaxStrengthPoint(signalPoints);
        //    return new int[] { result.X, result.Y };
        //}

        public static int[] BestCoordinate(int[][] towers, int radius)
        {
            SignalTower[] signalTowers = new SignalTower[towers.Length];
            for (int i = 0; i < towers.Length; i++)
            {
                SignalTower signalTower = new(towers[i][0], towers[i][1], towers[i][2], radius);
                signalTowers[i] = signalTower;
            }

            List<SignalPoint> signalPoints = new();
            for (int i = 0; i <= 50; i++)
            {
                for (int j = 0; j <= 50; j++)
                {
                    XY point = new(i, j);
                    int signalStrength = signalTowers.Select(t => t.GetSignalStrength(point)).Sum();
                    signalPoints.Add(new SignalPoint(point, signalStrength));
                }
            }

            var result = SignalPoint.GetMaxStrengthPoint(signalPoints);
            return new int[] { result.X, result.Y };
        }
    }

    class XY
    {
        public static XY Zero { get { return new XY(0, 0); } }
        public int X { get; set; }
        public int Y { get; set; }

        public XY() { }

        public XY(int x, int y)
        {
            X=x;
            Y=y;
        }

        public double Distance(XY point)
        {
            return Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2));
        }
    }

    class SignalTower : XY
    {
        public int Signal { get; set; }
        public int Radius { get; set; }

        public SignalTower(int x, int y, int signal, int radius)
        {
            X = x;
            Y = y;
            Signal = signal;
            Radius=radius;
        }

        public int GetSignalStrength(XY point)
        {
            var dis = Distance(point);
            if (dis > Radius) return 0;
            else return (int)(Signal / (dis + 1));
        }
    }

    class SignalPoint : XY
    {
        public double SignalStrength { get; set; }
        public SignalPoint(XY point, double signalStrength)
        {
            X = point.X;
            Y = point.Y;
            SignalStrength=signalStrength;
        }

        public static SignalPoint GetMaxStrengthPoint(List<SignalPoint> signalPoints)
        {
            SignalPoint maxPoint = new(Zero, double.MinValue);
            signalPoints.ForEach(p =>
            {
                if (p.SignalStrength > maxPoint.SignalStrength) maxPoint = p;
            });

            return maxPoint;
        }
    }
}
